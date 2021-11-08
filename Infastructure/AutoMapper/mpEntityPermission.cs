using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using svietnamAPI.Dtos.AppFile;
using svietnamAPI.Dtos.Auth;
using svietnamAPI.Dtos.Catalog;
using svietnamAPI.Dtos.ValueDtos;
using svietnamAPI.Helper.Exceptions;

namespace svietnamAPI.Infastructure.AutoMapper
{
    public partial class MappingProfile : Profile
    {
        public void mpEntityPermission()
        {
            CreateMap<GroupDto, GroupDto>()
                .AfterMap((s, d, context) =>
                {
                    var httpEP = (HttpContextEntityPermission)context.Items[InfrasConst.AU_OptItems_HttpContextEntityPermission];
                    var ep = httpEP.GroupEP;
                    if (ep.IsObjectPermission == true && ep.ObjectPermissions.Find(p => p.ObjectId == d.GroupId) == null)
                    {
                        throw new EntityPermissionException();
                    }
                    d.GroupId = ep.FieldPermissions.Where(p => p.Field.Code == "GroupId").First().IsAllowed ? d.GroupId : -1;
                    d.Code = ep.FieldPermissions.Where(p => p.Field.Code == "Code").First().IsAllowed ? d.Code : null;
                });
            CreateMap<UserDto, UserDto>()
                .AfterMap((s, d, context) =>
                {
                    var httpEP = (HttpContextEntityPermission)context.Items[InfrasConst.AU_OptItems_HttpContextEntityPermission];
                    var ep = httpEP.UserEP;
                    if (ep.IsObjectPermission == true && ep.ObjectPermissions.Find(p => p.ObjectId == d.UserId) == null)
                    {
                        throw new EntityPermissionException();
                    }
                    d.UserId = ep.FieldPermissions.Where(p => p.Field.Code == "UserId").First().IsAllowed ? d.UserId : -1;
                    d.Username = ep.FieldPermissions.Where(p => p.Field.Code == "Username").First().IsAllowed ? d.Username : null;
                    d.HashedPassword = ep.FieldPermissions.Where(p => p.Field.Code == "HashedPassword").First().IsAllowed ? d.HashedPassword : null;
                    d.Salt = ep.FieldPermissions.Where(p => p.Field.Code == "Salt").First().IsAllowed ? d.Salt : null;
                    d.GroupId = ep.FieldPermissions.Where(p => p.Field.Code == "GroupId").First().IsAllowed ? d.GroupId : -1;
                    d.Email = ep.FieldPermissions.Where(p => p.Field.Code == "Email").First().IsAllowed ? d.Email : null;
                });


            // CreateMap<GroupDto, GroupDto>()
            //     .AfterMap((s, d, context) =>
            //     {
            //         var ptfs = (List<PermissionToFieldDto>)context.Items["PermissionToFields"];

            //     });


        }
    }
}