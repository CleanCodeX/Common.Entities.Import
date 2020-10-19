using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Import.Entities.Internal.Attributes;
using Common.Import.Entities.Properties;
using Common.Entities.Models;
using Common.Shared.Attributes;
using Res = Common.Entities.Properties.Resources;
using Common.Entities.Models.Bases;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace Common.Import.Entities.Models
{
    public record ImportRowStatus : ValueObject, IHasId<int>
    {
        [InternalLocalizedDisplayName(nameof(Res.Id))]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), InverseProperty(nameof(ImportSummary.Rows))]
        public int Id { get; set; }

        [DoNotCompare]
        [ForeignKey(nameof(Summary) + nameof(ImportSummary.Id))]
        public virtual ImportSummary? Summary { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Text))]
        public string? Text { get; set; }

        [InternalLocalizedDisplayName(nameof(Resources.RowWasSkipped))]
        public bool RowWasSkipped { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.RowNumber))]
        public int RowNumber { get; set; }

        [InternalLocalizedDisplayName(nameof(Resources.RowStatus))]
        [NotMapped]
        public ImportStatusType RowStatus { get; set; }

        [InternalLocalizedDisplayName(nameof(Resources.Columns))]
        public virtual ICollection<ImportColumnStatus> Columns { get; set; } = new List<ImportColumnStatus>();

        public override int GetHashCode() => HashCode.Combine(Id);

        public virtual bool Equals(ImportRowStatus other) => base.Equals(other);
    }
}