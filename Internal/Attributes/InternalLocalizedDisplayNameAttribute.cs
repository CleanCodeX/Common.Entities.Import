using Common.Shared.Attributes;
using Common.Entities.Import.Properties;

namespace Common.Entities.Import.Internal.Attributes
{
    internal sealed class InternalLocalizedDisplayNameAttribute : LocalizedDisplayNameAttribute
    {
        public InternalLocalizedDisplayNameAttribute(string displayNameKey) : base(displayNameKey, typeof(Resources))
        { }
    }
}