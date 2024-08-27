using CommunityToolkit.Mvvm.Input;
using Jamesnet.Wpf.Mvvm;
using WpfExplorer.Support.Local.Helpers;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Main.Local.viewModels
{
    public partial class MainContentViewModel : ObservableBase
    {
        // public ICommand FolderChangedCommand { get; init; }
        private readonly FileService _fileService;

        public List<FolderInfo> Roots { get; init; }

        public MainContentViewModel(FileService fileService)
        {
            _fileService = fileService;
            // FolderChangedCommand = new RelayCommand<FolderInfo>(FolderChanged);
            Roots = _fileService.GenerateRootNodes();
        }

        [RelayCommand]
        private void FolderChanged(FolderInfo info)
        {
            _fileService.RefreshSubdirectories(info);
            // MessageBox.Show($"Selected : {info.Name}");
        }
    }
}
