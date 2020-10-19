using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Entities.Helpers;
using Common.Shared.Extensions;
using Common.Shared.Extensions.Enumerables.Specialized;
using Res = Common.Import.Entities.Properties.Resources;

namespace Common.Import.Entities.Models.Formatters
{
    public class ImportRowStatusFormatter : IObjectFormatter<ImportRowStatus>
    {
        private static readonly string IdentString = " ".Repeat(2);

        public string Format(ImportRowStatus arg, string? format = null)
        {
            var sb = new StringBuilder();

            if (arg.RowNumber > 0)
                sb.Append($"{Res.RowNumber} {arg.RowNumber} ");

            if (arg.Text is not null)
            {
                var rowStatus = arg.GetRowStatus();
                if (rowStatus != ImportStatusType.None)
                    sb.Append($"[{rowStatus.GetDisplayName()}] ");

                sb.Append(arg.Text);
            }

            var overallCount = arg.Columns.Count;

            Append(arg.GetColumnErrors());
            Append(arg.GetColumnWarnings());
            Append(arg.GetColumnInfos());

            return sb.ToString();

            void Append(IEnumerable<ImportColumnStatus> items)
            {
                // ReSharper disable once PossibleMultipleEnumeration
                var count = items.Count();
                if (count == 0) return;

                var text = (overallCount > 1 ? $"({count})" : null) + $"{InsertLinebreak(count)}{items.Join(IdentString)}";

                sb.Append(text);
            }
        }

        private static string InsertLinebreak(int count) => count > 1 ? IdentString : string.Empty;
    }
}