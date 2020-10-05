using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Entities.Import.Internal.Attributes;
using Common.Entities.Import.Properties;
using Common.Entities.Models.Bases;
using Res = Common.Entities.Properties.Resources;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace Common.Entities.Import.Models
{
    public class ImportRowStatus : IHasId
    {
        [InternalLocalizedDisplayName(nameof(Res.Id))]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), InverseProperty(nameof(ImportSummary.Rows))]
        public int Id { get; set; }

        [ForeignKey(nameof(Summary) + nameof(ImportSummary.Id))]
        public virtual ImportSummary? Summary { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Text))]
        public string? Text { get; set; }

        [InternalLocalizedDisplayName(nameof(Resources.RowWasSkipped))]
        public bool RowWasSkipped { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.RowNumber))]
        public int RowNumber { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.RowStatus))]
        [NotMapped]
        public ImportStatusType RowStatus { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Columns))]
        public virtual ICollection<ImportColumnStatus> Columns { get; set; } = new List<ImportColumnStatus>();

        public override int GetHashCode() => HashCode.Combine(Id);
    }
}