using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public class FormFieldDTO
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string FormFieldName { get; set; }

        [JsonProperty]
        public string FormName { get; set; }

        [JsonProperty]
        public string FieldType { get; set; }

        [JsonProperty]
        public string field_type { get; set; }

        [JsonProperty]
        public int FormFieldId { get; set; }

        [JsonProperty]
        public string Dupe { get; set; }

        [JsonProperty]
        public string DropdownOptions { get; set; }

        [JsonProperty]
        public string BoolOptions { get; set; }

        [JsonProperty]
        public string ScreenPanel { get; set; }

        [JsonProperty]
        public string PanelSection { get; set; }

        [JsonProperty]
        public string XmlExport { get; set; }
    }
}
