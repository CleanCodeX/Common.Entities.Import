using Common.Entities.Helpers;
using Common.Shared.Extensions;

namespace Common.Entities.Import.Models.Formatters
{
    public class ImportColumnStatusFormatter : IObjectFormatter<ImportColumnStatus>
    {
        public string Format(ImportColumnStatus arg, string? format = null)
        {
            var status = string.Empty;
            if (arg.ColumnStatus != ImportStatusType.None)
                status = $"[{arg.ColumnStatus.GetDisplayName()}]";

            var value = string.Empty;
            if (arg.Value is not null)
                value = @$" [{arg.Value}]";

            return @$"{status} ""{arg.Name}"":{value} {arg.Text}";
        }
    }
}