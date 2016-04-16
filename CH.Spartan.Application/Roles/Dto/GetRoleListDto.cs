using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CH.Spartan.Infrastructure;

namespace CH.Spartan.Authorization.Roles.Dto
{
    [AutoMapFrom(typeof(Role))]
    public class GetRoleListDto : EntityDto
          {
        /// <summary>
        /// Displaynameofthisrole.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Isthisastaticrole?Staticrolescannotbedeleted,cannotchangetheirname.Theycanbeusedprogrammatically.
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// Isthisrolewillbeassignedtonewusersasdefault?
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Uniquenameofthisrole.
        /// </summary>
        public string Name { get; set; }

}

    public class GetRoleListInput : QueryListResultRequestInput
    {

    }

    public class GetRoleListPagedInput : QueryListPagedResultRequestInput
    {

    }
}
