﻿using Jamesnet.Wpf.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using WpfExplorer.Support.Local.Models;

namespace WpfExplorer.Support.Local.Helpers
{
    public class FileService
    {
        private readonly DirectoryManager _directoryManager;

        public FileService(DirectoryManager directoryManager)
        {
            _directoryManager = directoryManager;
        }

        public List<FolderInfo> GenerateRootNodes()
        {
            List<FolderInfo> roots = new()
            {
                CreateFolderInfo(1, "Download", IconType.ArrowDownBox, _directoryManager.DownloadDirectory),
                CreateFolderInfo(1, "Documents", IconType.TextBox, _directoryManager.DocumentsDirectory),
                CreateFolderInfo(1, "Pictures", IconType.Image, _directoryManager.PicturesDirectory),
            };

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                var name = $"{drive.VolumeLabel} ({drive.RootDirectory.FullName.Replace("\\", "")})";
                roots.Add(CreateFolderInfo(1, name, IconType.MicrosoftWindows, drive.Name));
            }
            return roots;
        }

        private static FolderInfo CreateFolderInfo
            (int depth, string name, IconType iconType, string fullPath)
        {
            return new FolderInfo
            {
                Depth = depth,
                Name = name,
                IconType = iconType,
                FullPath = fullPath,
                Children = new()
            };
        }

        public void RefreshSubdirectories(FolderInfo parent)
        {
            var newChildern = FetchSubdirectories(parent);
            var oldChildrenDict = parent.Children.ToDictionary(x => x.FullPath);
            var newChildrenDict = newChildern.ToDictionary(x => x.FullPath);

            var added = newChildern.Where(x => !oldChildrenDict.ContainsKey(x.FullPath)).ToList();
            var removed = parent.Children.Where(x => !newChildrenDict.ContainsKey(x.FullPath)).ToList();

            parent.Children.AddRange(added);
            foreach (var child in removed)
            {
                parent.Children.Remove(child);
            }
        }

        private static List<FolderInfo> FetchSubdirectories(FolderInfo parent)
        {
            var children = new List<FolderInfo>();
            try
            {
                var subDirs = Directory.GetDirectories(parent.FullPath);
                foreach (var dir in subDirs)
                {
                    children.Add(new FolderInfo
                    {
                        Depth = parent.Depth + 1,
                        Name = Path.GetFileName(dir),
                        IconType = IconType.Folder,
                        FullPath = dir,
                        Children = new()
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return children;
        }
    }
}
