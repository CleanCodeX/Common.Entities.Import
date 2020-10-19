using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Common.Import.Entities.Internal.Attributes;

using Res = Common.Import.Entities.Properties.Resources;

namespace Common.Import.Entities.Models
{
    public static class ImportSummaryExtensions
    {
        public static ICollection<ImportRowStatus> GetRowErrors([NotNull] this ImportSummary source) =>
            source.Rows.Where(i => i.GetRowStatus() == ImportStatusType.Error).ToList();

        public static ImportRowStatus AddErrorRow([NotNull] this ImportSummary source, string text, bool skipped = false) => AddRow(source, text, ImportStatusType.Error, skipped);
        public static ImportRowStatus AddWarningRow([NotNull] this ImportSummary source, string text, bool skipped = false) => AddRow(source, text, ImportStatusType.Warning, skipped);
        public static ImportRowStatus AddInfoRow([NotNull] this ImportSummary source, string text, bool skipped = false) => AddRow(source, text, ImportStatusType.Info, skipped);
        public static ImportRowStatus AddRow([NotNull] this ImportSummary source, string text, ImportStatusType statusType, bool skipped = false)
        {
            var rowStatus = new ImportRowStatus
            {
                Text = text,
                RowWasSkipped = skipped,
                RowStatus = statusType
            };

            source.Rows.Add(rowStatus);

            return rowStatus;
        }

        [InternalLocalizedDisplayName(nameof(Res.RowStatus))]
        public static ImportStatusType GetStatus([NotNull] this ImportSummary source) => source.Rows.Count > 0 ? source.Rows.Max(m => m.GetRowStatus())! : default;
    }
}