using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.Authorization.Roles.Dto
{
    [AutoMap(typeof(Role))]
    public class UpdateRoleDto :EntityDto, IDoubleWayDto
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

    public class UpdateRoleInput : IInputDto
    {
        public UpdateRoleDto Role { get; set; }
    }

    public class UpdateRoleOutput : IOutputDto
    {
        public UpdateRoleOutput(UpdateRoleDto role)
        {
            Role = role;
        }

        public UpdateRoleDto Role { get; set; }
    }
}
