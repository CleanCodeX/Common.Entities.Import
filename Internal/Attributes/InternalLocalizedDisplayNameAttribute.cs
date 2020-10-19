using Common.Shared.Attributes;
using Common.Import.Entities.Properties;

namespace Common.Import.Entities.Internal.Attributes
{
    internal sealed class InternalLocalizedDisplayNameAttribute : LocalizedDisplayNameAttribute
    {
        public InternalLocalizedDisplayNameAttribute(string displayNameKey) : base(displayNameKey, typeof(Resources))
        { }
    }
}