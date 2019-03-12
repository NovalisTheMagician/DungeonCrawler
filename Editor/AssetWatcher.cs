using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    class AssetWatcher
    {
        private string assetRoot;
        public string AssetRoot
        {
            get
            {
                return assetRoot;
            }

            set
            {
                assetRoot = value;
                if (!Directory.Exists(assetRoot))
                    Directory.CreateDirectory(assetRoot);
                watcher.Path = assetRoot;
                watcher.EnableRaisingEvents = true;
            }
        }

        private FileSystemWatcher watcher;

        public AssetWatcher(Form formToSynchronize)
        {
            watcher = new FileSystemWatcher();

            watcher.Filter = "*.*"; // we only want to have image files (.bmp | .png | .jpg | etc)
                                    // unfortunatly FileSystemWatcher only accepts one filter
                                    // therefore we do the filtering in the event handlers

            //watcher.Path = assetRoot;
            watcher.NotifyFilter = NotifyFilters.FileName |    // we want to watch for name changes
                                    NotifyFilters.LastWrite;   // changed files

            watcher.IncludeSubdirectories = true;

            watcher.Created += FileCreated;
            watcher.Changed += FileChanged;
            watcher.Renamed += FileRenamed;
            watcher.Deleted += FileDeleted;

            watcher.SynchronizingObject = formToSynchronize;
        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath;
            Console.WriteLine($"File Created: '{path}'");
        }

        private void FileRenamed(object sender, RenamedEventArgs e)
        {
            string newPath = e.FullPath;
            string oldPath = e.OldFullPath;
            Console.WriteLine($"File Renamed from: '{oldPath}' to: '{newPath}'");
        }

        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath;
            Console.WriteLine($"File Removed: '{path}'");
        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            string path = e.FullPath;
            FileAttributes attr = File.GetAttributes(path);
            if(!attr.HasFlag(FileAttributes.Directory))
            {
                Console.WriteLine($"File Changed: '{path}'");
            }
        }
    }
}
