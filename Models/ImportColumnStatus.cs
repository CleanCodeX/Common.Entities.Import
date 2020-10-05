using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Entities.Import.Internal.Attributes;
using Common.Entities.Models.Bases;
using Res = Common.Entities.Properties.Resources;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace Common.Entities.Import.Models
{
    public class ImportColumnStatus : IHasId
    {
        [InternalLocalizedDisplayName(nameof(Res.Id))]
        [InverseProperty(nameof(ImportRowStatus.Columns))]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Row) + nameof(ImportRowStatus.Id))]
        public virtual ImportRowStatus? Row { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Text))]
        public string? Text { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Name))]
        [StringLength(100)]
        public string? Name { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.Value))]
        public string? Value { get; set; }

        [InternalLocalizedDisplayName(nameof(Res.ColumnStatus))]
        public ImportStatusType ColumnStatus { get; set; }

        public ImportColumnStatus() { }
        public ImportColumnStatus(ImportStatusType columnStatus, string? text = null)
        {
            ColumnStatus = columnStatus;
            Text = text;
        }

        public override int GetHashCode() => HashCode.Combine(Id);
    }
}