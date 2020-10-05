using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Common.Entities.Import.Internal.Attributes;
using Common.Entities.Models.Bases;
using Toolbelt.ComponentModel.DataAnnotations.Schema.V5;
using Res = Common.Entities.Properties.Resources;
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Common.Entities.Import.Models
{
    public class ImportSummary : IdEntity
    {
        [InternalLocalizedDisplayName(nameof(Res.Username))]
        [IndexColumn]
        [StringLength(Const.Db.StringLength.Username, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = nameof(Res.ErrorNotLongerThanMaxLengthTemplate))]
        [Required(ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = nameof(Res.ErrorMandatoryFieldTemplate))]
        public string Username { get; set; }

        public ImportSummary([NotNull] string username) => (Username, Context) = (username, string.Empty);
        public ImportSummary([NotNull] string username, [NotNull] string context) =>
            (Username, Context) = (username, context);

        [IndexColumn]
        [InternalLocalizedDisplayName(nameof(Res.Context))]
        [StringLength(Const.Db.StringLength.Context, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = nameof(Res.ErrorNotLongerThanMaxLengthTemplate))]
        public string Context { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.RowCount))]
        public int RowCount { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Duration))]
        [Column(TypeName = Const.Db.TimeWithoutMsType)]
        public TimeSpan Duration { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.IsCompleted))]
        public bool IsCompleted { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Title))]
        [StringLength(64)]
        public string? Title { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Filename))]
        [StringLength(64)]
        public string? Filename { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Rows))]
        public virtual ICollection<ImportRowStatus> Rows { get; set; } = new List<ImportRowStatus>();

        [InternalLocalizedDisplayName(nameof(Res.Text))]
        [NotMapped]
        public string? Text { get; set; }
    }
}