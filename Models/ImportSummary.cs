using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Common.Import.Entities.Internal.Attributes;
using Common.Entities.I32.Bases;
using Common.Import.Entities.Properties;
using Common.Shared.Attributes;
using Toolbelt.ComponentModel.DataAnnotations.Schema.V5;
using Res = Common.Shared.Properties.Resources;
using ResEntities = Common.Entities.Properties.Resources;
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Common.Import.Entities.Models
{
    public record ImportSummary : IdEntityBase
    {
        [InternalLocalizedDisplayName(nameof(ResEntities.UserId))]
        [IndexColumn]
        [StringLength(Const.Db.StringLength.UserId, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = nameof(ResEntities.ErrorNotLongerThanMaxLengthTemplate))]
        [Required(ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = nameof(Resources.ErrorMandatoryFieldTemplate))]
        public string UserId { get; set; }

        public ImportSummary([NotNull] string userId) => (UserId, Context) = (userId, string.Empty);
        public ImportSummary([NotNull] string userId, [NotNull] string context) =>
            (UserId, Context) = (userId, context);

        [IndexColumn]
        [InternalLocalizedDisplayName(nameof(ResEntities.Context))]
        [StringLength(Const.Db.StringLength.Context, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = nameof(ResEntities.ErrorNotLongerThanMaxLengthTemplate))]
        public string Context { get; set; }

        [InternalLocalizedDisplayName(nameof(Resources.RowCount))]
        public int RowCount { get; set; }

        [InternalLocalizedDisplayName(nameof(Resources.Duration))]
        [Column(TypeName = Const.Db.TimeWithoutMsType)]
        public TimeSpan Duration { get; set; }

        [InternalLocalizedDisplayName(nameof(Resources.IsCompleted))]
        public bool IsCompleted { get; set; }

        [InternalLocalizedDisplayName(nameof(Resources.Title))]
        [StringLength(64)]
        public string? Title { get; set; }

        [InternalLocalizedDisplayName(nameof(Resources.Filename))]
        [StringLength(64)]
        public string? Filename { get; set; }

        [DoNotCompare]
        [InternalLocalizedDisplayName(nameof(Resources.Rows))]
        public virtual ICollection<ImportRowStatus> Rows { get; set; } = new List<ImportRowStatus>();

        [InternalLocalizedDisplayName(nameof(ResEntities.Text))]
        public string? Text { get; set; }

        public virtual bool Equals(ImportSummary other) => base.Equals(other);
    }
}