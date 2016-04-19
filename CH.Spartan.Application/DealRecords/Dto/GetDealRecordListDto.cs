using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Infrastructure;

namespace CH.Spartan.DealRecords.Dto
{
    [AutoMapFrom(typeof(DealRecord))]
    public class GetDealRecordListDto : AuditedEntityDto
    {
        /// <summary>
        /// 交易流水号
        /// </summary>
        [MaxLength(250)]
        public string No { get; set; }

        /// <summary>
        /// 交易外部编号
        /// </summary>
        [MaxLength(250)]
        public string OutNo { get; set; }

        /// <summary>
        /// 交易名称
        /// </summary>
        [MaxLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// 交易备注
        /// </summary>
        [MaxLength(250)]
        public string Remark { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 所属租户
        /// </summary>
        public string TenantText { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TypeText { get; set; }

        /// <summary>
        /// 交易成功
        /// </summary>
        public string IsSucceedText { get; set; }
    }

    public class GetDealRecordListInput : QueryListResultRequestInput
    {

    }

    public class GetDealRecordListPagedInput : QueryListPagedResultRequestInput
    {
        public int? TenantId { get; set; }

        public EnumDealRecordType? Type { get; set; }
    }
}
