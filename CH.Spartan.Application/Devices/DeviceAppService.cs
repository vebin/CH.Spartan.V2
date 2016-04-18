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
using Abp.Runtime.Session;
using CH.Spartan.Areas.Dto;
using CH.Spartan.DealRecords;
using CH.Spartan.Devices.Dto;
using CH.Spartan.DeviceTypes;
using CH.Spartan.Infrastructure;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Nodes;

namespace CH.Spartan.Devices
{
    
    public class DeviceAppService : SpartanAppServiceBase, IDeviceAppService
    {
        private readonly DeviceManager _deviceManager;
        private readonly DeviceTypeManager _deviceTypeManager;
        private readonly NodeManager _nodeManager;
        private readonly TenantManager _tenantManager;

        private readonly IRepository<Device> _deviceRepository;
        private readonly IRepository<Tenant> _tenantRepository;
        private readonly IRepository<DeviceType> _deviceTypeRepository;
        private readonly IRepository<DealRecord> _dealRecordRepository;
        public DeviceAppService(IRepository<Device> deviceRepository,DeviceManager deviceManager, DeviceTypeManager deviceTypeManager, NodeManager nodeManager, TenantManager tenantManager, IRepository<Tenant> tenantRepository, IRepository<DeviceType> deviceTypeRepository, IRepository<DealRecord> dealRecordRepository)
        {
            _deviceRepository = deviceRepository;
            _deviceManager = deviceManager;
            _deviceTypeManager = deviceTypeManager;
            _nodeManager = nodeManager;
            _tenantManager = tenantManager;
            _tenantRepository = tenantRepository;
            _deviceTypeRepository = deviceTypeRepository;
            _dealRecordRepository = dealRecordRepository;
        }

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
                .WhereIf(input.DeviceTypeId.HasValue, p => p.BDeviceTypeId == input.DeviceTypeId.Value)
                .WhereIf(input.IsLocated.HasValue, p => p.GIsLocated)
                .WhereIfDynamic(input.StartTime.HasValue, input.SearchTime + ">", input.StartTime)
                .WhereIfDynamic(input.EndTime.HasValue, input.SearchTime + "<", input.EndTime);

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetDeviceListDto>(count, list.MapTo<List<GetDeviceListDto>>());
        }

        public async Task CreateDeviceByAgentAsync(CreateDeviceByAgentInput input)
        {
            var device = input.Device.MapTo<Device>();
            //获取或者创建所有的领域对象 所有的参数验证 已经在DTO中验证
            //设备类型
            var deviceType =await _deviceTypeRepository.GetAsync(device.BDeviceTypeId);
            //租户
            var tenant = await _tenantRepository.GetAsync(AbpSession.GetTenantId());
            //交易记录
            var dealRecord = DealRecord.CreateInstallDeviceDealRecord(AbpSession.GetTenantId(), device.UserId,deviceType.ServiceCharge);

            //设置默认参数
            device.BIconType = "PlaneCar";
            //生成设备Code
            device.BCode = await _deviceTypeManager.CreateCodeAsync(device, deviceType);
            //数据节点
            device.BNodeId = await _nodeManager.GetNodeIdAsync(device);
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
            await _deviceRepository.UpdateAsync(device);
        }
    
        public CreateDeviceByAgentOutput GetNewDeviceByAgent()
        {
            return new CreateDeviceByAgentOutput(new CreateDeviceByAgentDto() {BExpireTime = DateTime.Now.AddYears(1)});
        }

        public async Task<UpdateDeviceByAgentOutput> GetUpdateDeviceByAgentAsync(IdInput input)
        {
            
            var result = await _deviceRepository.GetAsync(input.Id);
            var updateDeviceByAgentDto = result.MapTo<UpdateDeviceByAgentDto>();
            updateDeviceByAgentDto.AreaSettings = result.GetOutAreaSettings().MapTo<List<AreaSettingDto>>();
            var output = new UpdateDeviceByAgentOutput(updateDeviceByAgentDto);
            return output;
        }

        public async Task DeleteDeviceAsync(List<IdInput> input)
        {
           await _deviceManager.DeleteByIdsAsync(input.Select(p => p.Id));
        }
        
    }
}