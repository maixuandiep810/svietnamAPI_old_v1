using System.Collections.Generic;

namespace svietnamAPI.Dtos.Auth
{
    public class EndpointDto
    {
        public int EndpointId { get; set; }
        public string Code { get; set; }
        public string Displayname { get; set; }
        public string Route { get; set; }
        public string Description { get; set; }       

        public List<RoleDto> Roles { get; set; } 
    }
}

