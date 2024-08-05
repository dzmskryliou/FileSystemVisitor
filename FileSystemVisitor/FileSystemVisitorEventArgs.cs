namespace FileSystemVisitor
{
    public class FileSystemVisitorEventArgs
    {
        public string Path { get; }

        public FileSystemVisitorEventArgs(string path)
        {
            Path = path;
        }
    }
}
