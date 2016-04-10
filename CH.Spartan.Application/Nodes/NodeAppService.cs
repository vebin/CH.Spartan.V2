using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using Abp.Extensions;
using System.Data.Entity;
using CH.Spartan.Commons;
using CH.Spartan.Nodes.Dto;

namespace CH.Spartan.Nodes
{

    public class NodeAppService : SpartanAppServiceBase, INodeAppService
    {
        private readonly NodeManager _nodeManager;
        public NodeAppService(NodeManager nodeManager)
        {
            _nodeManager = nodeManager;
        }

        public async Task<ListResultOutput<GetNodeListDto>> GetNodeListAsync(GetNodeListInput input)
        {
            var list = await _nodeManager.Store.Query
                .OrderBy(input)
                .ToListAsync();
            return new ListResultOutput<GetNodeListDto>(list.MapTo<List<GetNodeListDto>>());
        }

        public async Task<PagedResultOutput<GetNodeListDto>> GetNodeListPagedAsync(GetNodeListPagedInput input)
        {
            var query = _nodeManager.Store.Query;
            //.WhereIf(!input.SearchText.IsNullOrEmpty(), p => p.TenancyName.Contains(input.SearchText) || p.Name.Contains(input.SearchText));

            var count = await query.CountAsync();

            var list = await query.OrderBy(input).PageBy(input).ToListAsync();

            return new PagedResultOutput<GetNodeListDto>(count, list.MapTo<List<GetNodeListDto>>());
        }

        public async Task CreateNodeAsync(CreateNodeInput input)
        {
            var node = input.Node.MapTo<Node>();
            await _nodeManager.Store.CreateAsync(node);
        }

        public async Task UpdateNodeAsync(UpdateNodeInput input)
        {
            var node = await _nodeManager.Store.FindByIdAsync(input.Node.Id);
            input.Node.MapTo(node);
            await _nodeManager.Store.UpdateAsync(node);
        }

        public CreateNodeOutput GetNewNode()
        {
            return new CreateNodeOutput(new CreateNodeDto());
        }

        public async Task<UpdateNodeOutput> GetUpdateNodeAsync(IdInput input)
        {
            var result = await _nodeManager.Store.FindByIdAsync(input.Id);
            return new UpdateNodeOutput(result.MapTo<UpdateNodeDto>());
        }

        public async Task DeleteNodeAsync(List<IdInput> input)
        {
            await _nodeManager.Store.DeleteByIdsAsync(input.Select(p => p.Id));
        }

    }
}