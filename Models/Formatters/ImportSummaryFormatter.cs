using System;
using System.Linq;
using System.Text;
using Common.Entities.Helpers;
using Common.Shared.Extensions;
using Common.Shared.Extensions.Enumerables.Specialized;
using Res = Common.Import.Entities.Properties.Resources;

namespace Common.Import.Entities.Models.Formatters
{
    public class ImportSummaryFormatter: IObjectFormatter<ImportSummary>
    {
        public string Format(ImportSummary arg, string? format = null)
        {
            var verbose = format == "verbose";

            var name = $@"""{arg.Title}""";

            if (arg.Title != arg.Filename)
                name = arg.Title += $@" (""{arg.Filename}"")";

            var errorCount = arg.Rows.Count(x => x.GetRowStatus() == ImportStatusType.Error);
            var importableCount = arg.RowCount - errorCount;

            var sb = new StringBuilder();

            sb.Append(name);

            if (arg.RowCount > 0)
            {
                sb.Append($" {Res.Importable}: {importableCount}/{arg.RowCount}");

                if (arg.Duration != default)
                    sb.Append($" | {Res.Duration}: {arg.Duration.Format(false)}");
            }

            if (verbose)
            {
                if (arg.RowCount > 0)
                    sb.Append(" | ");

                sb.Append($"{Res.Status}: {arg.GetStatus().GetDisplayName()}");
            }

            if (arg.Text.IsNotNullOrEmpty())
            {
                if (verbose)
                {
                    sb.AppendLine();
                    sb.AppendLine();
                }

                sb.Append(arg.Text);
            }

            if (verbose)
            {
                var identString = " ".Repeat(2);
                var rowStatusString = Environment.NewLine + identString + arg.Rows.Join(Environment.NewLine + identString);
                sb.AppendLine(rowStatusString);
            }

            return sb.ToString();
        }
    }
}