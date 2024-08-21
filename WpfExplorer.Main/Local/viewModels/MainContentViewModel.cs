using WpfExplorer.Support.Local.Helpers;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Main.Local.viewModels
{
    public class MainContentViewModel
    {
        public List<FolderInfo> Roots { get; set; }

        public MainContentViewModel(FileService fileService)
        {
            Roots = fileService.GenerateRootNodes();
        }
    }
}
