namespace FileSystemVisitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the start path: ");
            var startPath = Console.ReadLine();

            Console.Write("Enter the file name: ");
            var filterCriteria = Console.ReadLine();

            var visitor = new FileSystemVisitor(startPath);

            visitor.SearchStarted += (sender, e) => Console.WriteLine(e.Path);
            visitor.SearchFinished += (sender, e) => Console.WriteLine(e.Path);
            visitor.FileFound += (sender, e) => Console.WriteLine($"File found: {e.Path}");
            visitor.DirectoryFound += (sender, e) => Console.WriteLine($"Directory found: {e.Path}");

            string outputPath = @"C:\Users\Dzmitry_Skryliou\source\Logs\searchResults.json";
            visitor.SaveResultsAsJson(outputPath);
            Console.WriteLine($"Results saved to {outputPath}");
            Console.ReadKey();
        }
    }
}
