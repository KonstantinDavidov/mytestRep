using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class AddressInfoConfiguration : ComplexTypeConfiguration<AddressInfo>
    {
        public AddressInfoConfiguration()
        {
            Property(a => a.StreetAddress).HasColumnName(DbConsts.ADDRESS_INFO_STREET_ADDRESS_COLUMN_NAME).HasMaxLength(200);
            Property(a => a.City).HasColumnName(DbConsts.ADDRESS_INFO_CITY_COLUMN_NAME).HasMaxLength(100);
            Property(a => a.USAState).HasColumnName(DbConsts.ADDRESS_INFO_USA_STATE_COLUMN_NAME);
            Property(a => a.ZipCode).HasColumnName(DbConsts.ADDRESS_INFO_ZIP_CODE_COLUMN_NAME).HasMaxLength(20);
            Property(a => a.Phone).HasColumnName(DbConsts.ADDRESS_INFO_PHONE_COLUMN_NAME).HasMaxLength(20);
            Property(a => a.Fax).HasColumnName(DbConsts.ADDRESS_INFO_FAX_COLUMN_NAME).HasMaxLength(20);
        }
    }
}
