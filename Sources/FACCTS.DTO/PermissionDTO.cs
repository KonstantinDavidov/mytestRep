using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public class PermissionDTO
    {
        [JsonProperty]
        public long Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
       
    }
}
