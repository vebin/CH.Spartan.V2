using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CH.Spartan.Nodes.Dto;

namespace CH.Spartan.Nodes
{

    public interface INodeAppService : IApplicationService
    {
        /// <summary>
        /// 获取 节点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultOutput<GetNodeListDto>> GetNodeListAsync(GetNodeListInput input);

        /// <summary>
        /// 获取 节点 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultOutput<GetNodeListDto>> GetNodeListPagedAsync(GetNodeListPagedInput input);

        /// <summary>
        /// 添加 节点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateNodeAsync(CreateNodeInput input);

        /// <summary>
        /// 更新 节点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateNodeAsync(UpdateNodeInput input);

        /// <summary>
        /// 获取 新节点
        /// </summary>
        /// <returns></returns>
        CreateNodeOutput GetNewNode();

        /// <summary>
        /// 获取 更新节点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UpdateNodeOutput> GetUpdateNodeAsync(IdInput input);

        /// <summary>
        /// 删除 节点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteNodeAsync(List<IdInput> input);
    }
}
