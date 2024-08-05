namespace FileSystemVisitor
{
    public class FileSystemEventNotifier
    {
        public delegate void FileSystemVisitorHandler(object sender, FileSystemVisitorEventArgs e);

        public event FileSystemVisitorHandler SearchStarted;
        public event FileSystemVisitorHandler SearchFinished;
        public event FileSystemVisitorHandler FileFound;
        public event FileSystemVisitorHandler DirectoryFound;


        protected virtual void OnSearchStarted(FileSystemVisitorEventArgs e)
        {
            SearchStarted?.Invoke(this, e);
        }

        protected virtual void OnSearchFinished(FileSystemVisitorEventArgs e)
        {
            SearchFinished?.Invoke(this, e);
        }

        protected virtual void OnFileFound(FileSystemVisitorEventArgs e)
        {
            FileFound?.Invoke(this, e);
        }

        protected virtual void OnDirectoryFound(FileSystemVisitorEventArgs e)
        {
            DirectoryFound?.Invoke(this, e);
        }
    }
}
