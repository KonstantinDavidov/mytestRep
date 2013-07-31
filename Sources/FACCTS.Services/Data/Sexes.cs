using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    internal class Sexes : WebApiClientBase
    {
        protected List<EnumDescript<Gender>> GetSexes()
        {
            return EnumDescript<Gender>.GetList();
        }

        public static List<EnumDescript<Gender>> GetAll()
        {
            var values = new Sexes().GetSexes();
            if (values == null)
                return null;

            return values;
        }
    }
}
