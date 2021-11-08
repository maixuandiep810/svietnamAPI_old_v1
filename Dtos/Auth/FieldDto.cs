using System;
using System.Collections.Generic;
namespace svietnamAPI.Dtos.Auth
{
    public class FieldDto
    {
        public int FieldId { get; set; }
        public string Code { get; set; }
        public int EntityId { get; set; }

        public EntityDto Entity { get; set; }
    }
}