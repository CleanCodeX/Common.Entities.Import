using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Common.Import.Entities.Models
{
    public static class ImportRowStatusExtensions
    {
        public static ImportStatusType GetRowStatus([NotNull] this ImportRowStatus source) => source.Columns.Count > 0 ? source.Columns.Max(m => m.ColumnStatus)! : source.RowStatus;

        public static IEnumerable<ImportColumnStatus> GetColumnInfos([NotNull] this ImportRowStatus source) => source.Columns.Where(m => m.ColumnStatus == ImportStatusType.Info);
        public static IEnumerable<ImportColumnStatus> GetColumnWarnings([NotNull] this ImportRowStatus source) => source.Columns.Where(m => m.ColumnStatus == ImportStatusType.Warning);
        public static IEnumerable<ImportColumnStatus> GetColumnErrors([NotNull] this ImportRowStatus source) => source.Columns.Where(m => m.ColumnStatus == ImportStatusType.Error);
    }
}