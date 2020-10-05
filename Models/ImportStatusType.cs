using Common.Entities.Import.Internal.Attributes;
using Res = Common.Entities.Properties.Resources;

namespace Common.Entities.Import.Models
{
    public enum ImportStatusType
    {
        None,
        [InternalLocalizedDisplayName(nameof(Res.Info))]
        Info,
        [InternalLocalizedDisplayName(nameof(Res.Warning))]
        Warning,
        [InternalLocalizedDisplayName(nameof(Res.Error))]
        Error
    }
}