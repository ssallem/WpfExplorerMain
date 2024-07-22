using System.IO;

namespace WpfExplorer.Support.Local.Helpers
{
    public class DirectoryManager
    {
        public string DownloadDirectory { get; set; }
        public string DocumentsDirectory { get; set; }
        public string PicturesDirectory { get; set; }

        public DirectoryManager()
        {
            var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            DownloadDirectory = Path.Combine(userPath, "Downloads");
            DocumentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            PicturesDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }
    }
}
