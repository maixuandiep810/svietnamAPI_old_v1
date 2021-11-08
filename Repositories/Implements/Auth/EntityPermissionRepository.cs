using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Dtos.Auth;
using svietnamAPI.Repositories.Interfaces.Auth;

namespace svietnamAPI.Repositories.Implements.Auth
{
    public partial class EntityPermissionDbRepository : GenericDbRepository, IEntityPermissionDbRepository
    {
        public EntityPermissionDbRepository(IDataConnectionFactory dataConnectionFactory) : base(dataConnectionFactory)
        {

        }

        public async Task<EntityPermissionDto> Get1_EP_Async(string entityCode, string actionType, List<string> roleCodes)
        {
            EntityPermissionDto entitypermission;
            // Get 1 EntityPermission: 1 EntityCode, 1 ActionType
            var queryParams = new
            {
                EntityCode = entityCode,
                ActionType = actionType,
                RoleCodes = roleCodes
            };
            entitypermission = await Get1_EP_Async(EntityPermissionDbQuery.Get1_EP, queryParams);

            return entitypermission;
        }

        public async Task<EntityPermissionDto> Get1_EP_OP_Async(string entityCode, string actionType, List<string> roleCodes, int userId)
        {
            EntityPermissionDto entitypermission;
            // Get 1 EntityPermission: 1 EntityCode, 1 ActionType, 1 IsObjectPermission -> GroupBy
            var queryParams = new
            {
                EntityCode = entityCode,
                IsObjectPermission = true,
                ActionType = actionType,
                RoleCodes = roleCodes,
                UserId = userId
            };
            entitypermission = await Get1_EP_OP_Async(EntityPermissionDbQuery.Get1_EP_OP, queryParams);
            return entitypermission;
        }



        /// <summary>
        /// Get 1 EntityPermission: 1 EntityCode, 1 ActionType, 1 IsObjectPermission -> GroupBy 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        private async Task<EntityPermissionDto> Get1_EP_OP_Async(string query, object queryParams)
        {
            var entityper = await WithConnection<IEnumerable<EntityPermissionDto>, EntityPermissionDto>(
                async dbConnection =>
                {
                    var records = await dbConnection.QueryAsync<EntityPermissionDto, EntityDto, FieldPermissionDto, FieldDto, RoleDto, ObjectPermissionDto, EntityPermissionDto>(
                    query, (entitypermission, entity, fieldpermission, field, role, objectpermission) =>
                    {
                        entitypermission.Entity = entity;
                        fieldpermission.Field = field;
                        entitypermission.FieldPermissions = new List<FieldPermissionDto>(new[] { fieldpermission }); ;
                        entitypermission.ObjectPermissions = new List<ObjectPermissionDto>(new[] { objectpermission });
                        return entitypermission;
                    },
                    queryParams,
                    splitOn: "EntityId, FieldPermissionId, FieldId, RoleId, ObjectPermissionId"
                    );
                    return records;
                },
                entitypermissions =>
                {
                    if (entitypermissions == null || entitypermissions.Count() == 0)
                        return null;
                    var entityper = entitypermissions.First();
                    var fieldpermissions = entitypermissions.Select(p => p.FieldPermissions.FirstOrDefault()).ToList();
                    fieldpermissions = fieldpermissions.GroupBy(p => p.Field.FieldId).Select(g =>
                    {
                        var groupedFPs = g.First();
                        var isAllowed = false;
                        g.AsList().ForEach(p => isAllowed = isAllowed || p.IsAllowed);
                        groupedFPs.IsAllowed = isAllowed;
                        return groupedFPs;
                    }
                    ).ToList();
                    entityper.FieldPermissions = fieldpermissions;
                    var objectPermissions = entitypermissions.Select(p => p.ObjectPermissions.FirstOrDefault())
                    .GroupBy(p => p.ObjectId)
                    .Select(g => g.First()).ToList();
                    return entityper;
                }
            );
            return entityper;
        }


        /// <summary>
        /// Get 1 EntityPermission: 1 EntityCode, 1 ActionType -> GroupBy 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        private async Task<EntityPermissionDto> Get1_EP_Async(string query, object queryParams)
        {
            var entityper = await WithConnection<IEnumerable<EntityPermissionDto>, EntityPermissionDto>(
                async dbConnection =>
                {
                    var records = await dbConnection.QueryAsync<EntityPermissionDto, EntityDto, FieldPermissionDto, FieldDto, RoleDto, EntityPermissionDto>(
                    query, (entitypermission, entity, fieldpermission, field, roleDto) =>
                    {
                        entitypermission.Entity = entity;
                        fieldpermission.Field = field;
                        entitypermission.FieldPermissions = new List<FieldPermissionDto>(new[] { fieldpermission });
                        return entitypermission;
                    },
                    queryParams,
                    splitOn: "EntityId, FieldPermissionId, FieldId, RoleId"
                    );
                    return records;
                },
                entitypermissions =>
                {
                    if (entitypermissions == null || entitypermissions.Count() == 0)
                        return null;
                    var entityper = entitypermissions.First();
                    var fieldpermissions = entitypermissions.Select(p => p.FieldPermissions.FirstOrDefault()).Distinct().ToList();
                    fieldpermissions = fieldpermissions.GroupBy(p => p.Field.FieldId).Select(g =>
                    {
                        var groupedFPs = g.First();
                        var isAllowed = false;
                        g.AsList().ForEach(p => isAllowed = isAllowed || p.IsAllowed);
                        groupedFPs.IsAllowed = isAllowed;
                        return groupedFPs;
                    }
                    ).ToList();
                    entityper.FieldPermissions = fieldpermissions;
                    return entityper;
                }
            );
            return entityper;
        }



    }
}