using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace CH.Spartan.Authorization.Roles.Dto
{
    [AutoMap(typeof(Role))]
    public class CreateRoleDto : IDoubleWayDto
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

    public class CreateRoleInput : IInputDto
    {
        public CreateRoleDto Role { get; set; }
    }

    public class CreateRoleOutput : IOutputDto
    {
        public CreateRoleOutput(CreateRoleDto role)
        {
            Role = role;
        }

        public CreateRoleDto Role { get; set; }
    }
}


