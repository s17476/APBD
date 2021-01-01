using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cw4.Model
{
    public class Studies
    {
        [JsonIgnore]
        public int IdStudies { get; set; }
        public string Name { get; set; }
    }
}
