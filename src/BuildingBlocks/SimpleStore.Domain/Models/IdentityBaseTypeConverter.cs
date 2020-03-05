using System;
using System.ComponentModel;
using System.Globalization;

namespace SimpleStore.Domain.Models
{
    public class IdentityBaseTypeConverter<TIdentity> : TypeConverter where TIdentity : IdentityBase
    {
        #region Overrides of TypeConverter

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var stringValue = value as string;
            if (!string.IsNullOrEmpty(stringValue) && Guid.TryParse(stringValue, out var guid))
            {
                return IdentityFactory.Create<TIdentity>(guid);
            }

            return base.ConvertFrom(context, culture, value);
        }

        #endregion
    }
}
