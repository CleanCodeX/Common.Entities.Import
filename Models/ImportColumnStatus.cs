using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Import.Entities.Internal.Attributes;
using Common.Entities.Models;
using Common.Import.Entities.Properties;
using Common.Shared.Attributes;
using Res = Common.Entities.Properties.Resources;
using Common.Entities.Models.Bases;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace Common.Import.Entities.Models
{
    public record ImportColumnStatus : ValueObject, IHasId<int>
    {
        [InternalLocalizedDisplayName(nameof(Res.Id))]
        [InverseProperty(nameof(ImportRowStatus.Columns))]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DoNotCompare]
        [ForeignKey(nameof(Row) + nameof(ImportRowStatus.Id))]
        public virtual ImportRowStatus? Row { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Text))]
        public string? Text { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Name))]
        [StringLength(100)]
        public string? Name { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Value))]
        public string? Value { get; set; }

        [InternalLocalizedDisplayName(nameof(Resources.ColumnStatus))]
        public ImportStatusType ColumnStatus { get; set; }

        public ImportColumnStatus() { }
        public ImportColumnStatus(ImportStatusType columnStatus, string? text = null)
        {
            ColumnStatus = columnStatus;
            Text = text;
        }

        public override int GetHashCode() => HashCode.Combine(Id);

        public virtual bool Equals(ImportColumnStatus other) => base.Equals(other);
    }
}