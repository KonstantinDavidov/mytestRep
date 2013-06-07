using EnumAnnotations;
using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public class CCPORStatuses
    {
        private static List<String> _all;
        public static List<String> GetAll()
        {
            if (_all == null)
            {
                _all = EnumAnnotation.GetDisplays<CCPORStatus>().Select(x => x.Name).ToList();
            }
            return _all;
        }
    }
}
