using System.Text.Json;

namespace FileSystemVisitor
{
    public class FileSystemVisitor : FileSystemEventNotifier
    {
        private readonly string _startPath;

        public FileSystemVisitor(string startPath)
        {
            if (string.IsNullOrWhiteSpace(startPath))
                throw new ArgumentException("The start path cannot be null or empty", nameof(startPath));

            if (!Directory.Exists(startPath))
                throw new DirectoryNotFoundException($"The directory '{startPath}' does not exist");

            _startPath = startPath;
        }

        public IEnumerator<string> GetEnumerator()
        {
            OnSearchStarted(new FileSystemVisitorEventArgs("Search started"));

            foreach (var item in TraverseDirectory(_startPath))
                yield return item;

            OnSearchFinished(new FileSystemVisitorEventArgs("Search finished"));
        }

        private IEnumerable<string> TraverseDirectory(string currentPath)
        {
            var dirArgs = new FileSystemVisitorEventArgs(currentPath);
            OnDirectoryFound(dirArgs);
            yield return currentPath;

            foreach (var file in Directory.GetFiles(currentPath))
            {
                var fileArgs = new FileSystemVisitorEventArgs(file);
                OnFileFound(fileArgs);
                yield return file;
            }
        }

        public void SaveResultsAsJson(string outputPath)
        {
            var results = new List<string>();

            foreach (var item in this)
                results.Add(item);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(results, options);

            File.WriteAllText(outputPath, json);
        }
    }
}
