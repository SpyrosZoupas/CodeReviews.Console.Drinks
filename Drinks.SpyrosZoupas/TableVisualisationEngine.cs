using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace Drinks.SpyrosZoupas
{
    public class TableVisualisationEngine
    {
        public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) 
        where T : class
        {
            tableName ??= string.Empty;

            Console.WriteLine("\n\n");
            ConsoleTableBuilder
                .From(tableData)
                .WithColumn(tableName)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine(TableAligntment.Center);
            Console.WriteLine("\n\n");
        }
    }
}
