using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Extensions;
using System.Data.Entity;
using Abp.Configuration;
using Abp.Runtime.Session;
using CH.Spartan.Areas;
using CH.Spartan.Areas.Dto;
using CH.Spartan.DealRecords;
using CH.Spartan.Devices.Dto;
using CH.Spartan.DeviceStocks;
using CH.Spartan.DeviceTypes;
using CH.Spartan.Infrastructure;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Nodes;

namespace CH.Spartan.Devices
{
    
    public class DeviceAppService : SpartanAppServiceBase, IDeviceAppService
    {
        #region 依赖
        private readonly DeviceManager _deviceManager;
        private readonly DeviceTypeManager _deviceTypeManager;
        private readonly NodeManager _nodeManager;
        private readonly TenantManager _tenantManager;
        private readonly DeviceStockManager _deviceStockManager;
        private readonly IRepository<Device> _deviceRepository;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IRepository<DeviceType> _deviceTypeRepository;
        private readonly IRepository<DealRecord> _dealRecordRepository;
        private readonly IRepository<Area> _areaRepository;
        public DeviceAppService(
            DeviceManager deviceManager,
            DeviceTypeManager deviceTypeManager,
            NodeManager nodeManager,
            TenantManager tenantManager,
            IRepository<Device> deviceRepository,
            IRepository<Tenant> tenantRepository,
            IRepository<DeviceType> deviceTypeRepository,
            IRepository<DealRecord> dealRecordRepository,
            IRepository<Area> areaRepository, DeviceStockManager deviceStockManager)
        {
            _deviceRepository = deviceRepository;
            _deviceManager = deviceManager;
            _deviceTypeManager = deviceTypeManager;
            _nodeManager = nodeManager;
            _tenantManager = tenantManager;
            _tenantRepository = tenantRepository;
            _deviceTypeRepository = deviceTypeRepository;
            _dealRecordRepository = dealRecordRepository;
            _areaRepository = areaRepository;
            _deviceStockManager = deviceStockManager;
        } 
        #endregion

        #region 通用
        public async Task<ListResultOutput<GetDeviceListDto>> GetDeviceListAsync(GetDeviceListInput input)
        {
            var list = await _deviceRepository.GetAll()
                .OrderBy(input)
                .ToListAsync();
            return new ListResultOutput<GetDeviceListDto>(list.MapTo<List<GetDeviceListDto>>());
        }

        public async Task<PagedResultOutput<GetDeviceListDto>> GetDeviceListPagedAsync(GetDeviceListPagedInput input)
        {
            var query = _deviceRepository.GetAll()
                .Include(p => p.Tenant)
                .Include(p => p.User)
                .Include(p => p.DeviceType)
                .WhereIf(!input.SearchText.IsNullOrEmpty(),
                    p => p.BName.Contains(input.SearchText) ||
                         p.BDscription.Contains(input.SearchText) ||
                         p.BSimNo.Contains(input.SearchText) ||
                         p.BNo.Contains(input.SearchText))
                .WhereIf(input.UserId.HasValue, p => p.UserId == input.UserId.Value)
                .WhereIf(input.DeviceTypeId.HasValue, p => p.BDeviceTypeId == input.DeviceTypeId.Value)
                .WhereIf(input.IsLocated.HasValue, p => p.GIsLocated)
                .WhereIfDynamic(input.StartTime.HasValue, input.SearchTime + ">", input.StartTime)
                .WhereIfDynamic(input.EndTime.HasValue, input.SearchTime + "<", input.EndTime);

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetDeviceListDto>(count, list.MapTo<List<GetDeviceListDto>>());
        }

        public async Task DeleteDeviceAsync(List<IdInput> input)
        {
            await _deviceManager.DeleteByIdsAsync(input.Select(p => p.Id));
        } 
        #endregion

        #region 代理
        public async Task CreateDeviceByAgentAsync(CreateDeviceByAgentInput input)
        {
            var device = input.Device.MapTo<Device>();
            //获取或者创建所有的领域对象 所有的参数验证 已经在DTO中验证
            //设备类型
            var deviceType = await _deviceTypeRepository.GetAsync(device.BDeviceTypeId);
            //租户
            var tenant = await _tenantRepository.GetAsync(AbpSession.GetTenantId());
            //交易记录
            var dealRecord = DealRecord.CreateInstallDeviceDealRecord(AbpSession.GetTenantId(), AbpSession.GetUserId(), deviceType.ServiceCharge);

            //设置默认参数
            device.BIconType = "PlaneCar";
            //生成设备Code
            device.BCode = await _deviceTypeManager.CreateCodeAsync(device, deviceType);
            //数据节点
            device.BNodeId = await _nodeManager.GetNodeIdAsync(device);
            //默认超速
            device.SLimitSpeed = SpartanConsts.DefaultLimitSpeed;
            //添加设备
            CheckErrors(await _deviceManager.CreateAsync(device));
            await CurrentUnitOfWork.SaveChangesAsync();
            //从租户中扣款
            CheckErrors(await _tenantManager.DeductMoneyByInstallDeviceAsync(tenant, device, deviceType));
            //添加交易记录
            await _dealRecordRepository.InsertAsync(dealRecord);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateDeviceByAgentAsync(UpdateDeviceByAgentInput input)
        {
            var device = await _deviceRepository.GetAsync(input.Device.Id);
            input.Device.MapTo(device);
            //设备类型
            var deviceType = await _deviceTypeRepository.GetAsync(device.BDeviceTypeId);
            //生成设备Code
            device.BCode = await _deviceTypeManager.CreateCodeAsync(device, deviceType);
            await _deviceManager.UpdateAsync(device);
        }

        public CreateDeviceByAgentOutput GetNewDeviceByAgent()
        {
            return new CreateDeviceByAgentOutput(new CreateDeviceByAgentDto() { BExpireTime = DateTime.Now.AddYears(1) });
        }

        public async Task<UpdateDeviceByAgentOutput> GetUpdateDeviceByAgentAsync(IdInput input)
        {
            var result = await _deviceRepository.GetAsync(input.Id);
            var output = new UpdateDeviceByAgentOutput
            {
                Device = result.MapTo<UpdateDeviceByAgentDto>(),
                AllAreas =
                    (await _areaRepository.GetAllListAsync(p => p.UserId == result.UserId)).MapTo<List<GetAreaListDto>>()
            };
            return output;
        } 
        #endregion

        #region 客户
        public async Task CreateDeviceByCustomerAsync(CreateDeviceByCustomerInput input)
        {
            //检查当前客户所属的租户库存是否有该设备号
            CheckErrors(await _deviceStockManager.CheckIsHaveDeviceNoAsync(input.Device.BNo));

            var device = input.Device.MapTo<Device>();
            //获取或者创建所有的领域对象 所有的参数验证 已经在DTO中验证
            //设备类型
            var deviceType = await _deviceTypeRepository.GetAsync(device.BDeviceTypeId);
            //租户
            var tenant = await _tenantRepository.GetAsync(AbpSession.GetTenantId());
            //交易记录
            var dealRecord = DealRecord.CreateInstallDeviceDealRecord(AbpSession.GetTenantId(), AbpSession.GetUserId(), deviceType.ServiceCharge);

            //设置默认参数
            device.BIconType = "PlaneCar";
            //所属用户
            device.UserId = AbpSession.GetUserId();
            //过期时间
            device.BExpireTime = DateTime.Now.AddYears(SettingManager.GetSettingValueForTenant<int>(SpartanSettingKeys.Tenant_Customer_InstallDevice_ExpireYear,AbpSession.GetTenantId()));
            //生成设备Code
            device.BCode = await _deviceTypeManager.CreateCodeAsync(device, deviceType);
            //数据节点
            device.BNodeId = await _nodeManager.GetNodeIdAsync(device);
            //默认超速
            device.SLimitSpeed = SpartanConsts.DefaultLimitSpeed;
            //添加设备
            CheckErrors(await _deviceManager.CreateAsync(device));
            await CurrentUnitOfWork.SaveChangesAsync();
            //从租户中扣款
            CheckErrors(await _tenantManager.DeductMoneyByInstallDeviceAsync(tenant, device, deviceType));
            //添加交易记录
            await _dealRecordRepository.InsertAsync(dealRecord);
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateDeviceByCustomerAsync(UpdateDeviceByCustomerInput input)
        {
            //检查当前客户所属的租户库存是否有该设备号
            CheckErrors(await _deviceStockManager.CheckIsHaveDeviceNoAsync(input.Device.BNo));

            var device = await _deviceRepository.GetAsync(input.Device.Id);
            input.Device.MapTo(device);
            //设备类型
            var deviceType = await _deviceTypeRepository.GetAsync(device.BDeviceTypeId);
            //生成设备Code
            device.BCode = await _deviceTypeManager.CreateCodeAsync(device, deviceType);
            await _deviceManager.UpdateAsync(device);
        }

        public CreateDeviceByCustomerOutput GetNewDeviceByCustomer()
        {
            return new CreateDeviceByCustomerOutput(new CreateDeviceByCustomerDto())
            {
                ExpireYear =
                    SettingManager.GetSettingValueForTenant<int>(
                        SpartanSettingKeys.Tenant_Customer_InstallDevice_ExpireYear, AbpSession.GetTenantId())
            };
        }

        public async Task<UpdateDeviceByCustomerOutput> GetUpdateDeviceByCustomerAsync(IdInput input)
        {
            var result = await _deviceRepository.GetAsync(input.Id);
            var output = new UpdateDeviceByCustomerOutput
            {
                Device = result.MapTo<UpdateDeviceByCustomerDto>(),
                AllAreas =
                    (await _areaRepository.GetAllListAsync(p => p.UserId == result.UserId)).MapTo<List<GetAreaListDto>>(),
                BExpireTime = result.BExpireTime
            };
            return output;
        } 
        #endregion
    }
}