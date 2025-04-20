using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace Drinks.SpyrosZoupas
{
    public class TableVisualisationEngine
    {
        public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T :
        class
        {
            Console.Clear();

            if (tableName == null)
                tableName = string.Empty;

            Console.WriteLine("\n\n");
            ConsoleTableBuilder
                .From(tableData)
                .WithColumn(tableName)
                .ExportAndWriteLine();
            Console.WriteLine("\n\n");
        }
    }
}
