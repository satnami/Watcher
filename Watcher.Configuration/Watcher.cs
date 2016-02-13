using System;
using System.Diagnostics;
using System.IO;

namespace Watcher.Configuration
{
    public class Watcher
    {
        private readonly string _folderPathUri;
        private readonly string _filter;
        private readonly string _onCreateActionUri;
        private readonly string _onDeleteActionUri;
        private readonly string _onRenameActionUri;
        private readonly string _onChangeActionUri;

        public Watcher(Service service)
        {
            _filter = service.Filter;
            _folderPathUri = service.WatchedFolderPathUri;
            _onCreateActionUri = service.OnCreateActionUri;
            _onDeleteActionUri = service.OnDeleteActionUri;
            _onRenameActionUri = service.OnRenameActionUri;
            _onChangeActionUri = service.OnChangeActionUri;
        }

        public void Initialize()
        {
            //Create a new FileSystemWatcher.
            var watcher = new FileSystemWatcher
            {
                Path = @"" + _folderPathUri,
                Filter = _filter,
                NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime |
                               NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess |
                               NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size
            };

            //Subscribe to the Created event.
            watcher.Created += new FileSystemEventHandler(OnFileCreated);
            watcher.Deleted += new FileSystemEventHandler(OnFileDeleted);
            watcher.Changed += new FileSystemEventHandler(OnFileChanged);
            watcher.Renamed += new RenamedEventHandler(OnFileRenamed);

            //Enable the FileSystemWatcher events.
            watcher.EnableRaisingEvents = true;
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("A new file has been Created!");
            try
            {
                if (_onCreateActionUri != "")
                    Process.Start(@"" + _onCreateActionUri);
            }
            catch (Exception)
            {
            }
        }

        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("A new file has been Deleted!");
            try
            {
                if (_onDeleteActionUri != "")
                    Process.Start(@"" + _onDeleteActionUri);
            }
            catch (Exception)
            {
            }
        }

        private void OnFileChanged(object source, FileSystemEventArgs e)
        {
            //Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            try
            {
                if(_onChangeActionUri != "")
                    Process.Start(@"" + _onChangeActionUri);
            }
            catch (Exception)
            {
            }
        }

        private void OnFileRenamed(object source, RenamedEventArgs e)
        {
            //Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            try
            {
                if (_onRenameActionUri != "")
                    Process.Start(@"" + _onRenameActionUri);
            }
            catch (Exception)
            {
            }
        }
    }
}
