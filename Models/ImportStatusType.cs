using Common.Import.Entities.Internal.Attributes;
using Res = Common.Shared.Properties.Resources;

namespace Common.Import.Entities.Models
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