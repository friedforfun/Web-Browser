using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;

namespace Web_Browser
{


    class FileWatcher
    {
        private string _path;
        private FileSystemWatcher watcher;

        public FileWatcher(string path)
        {
            _path = path;
            watcher = new FileSystemWatcher();
        }


        //[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Run()
        {
            Console.WriteLine("Watcher Running");

            // If a directory is not specified, exit program.
            //if (args.Length != 2)
            //{
            //    // Display the proper way to call the program.
            //   Console.WriteLine("Usage: Watcher.exe (directory)");
            //    return;
            //}

            // Create a new FileSystemWatcher and set its properties.

            watcher.Path = _path;

            // Watch for changes in LastWrite times
            /* Other filters: NotifyFilters.LastAccess | NotifyFilters.CreationTime | NotifyFilters.Attributes | NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.Security*/
            watcher.NotifyFilter = NotifyFilters.LastWrite;

            // Only watch text files.
            watcher.Filter = "*.xml";

            // Add event handlers.
            watcher.Changed += OnChanged;
            watcher.Error += OnError;

            // Begin watching.
            watcher.EnableRaisingEvents = true;
            

        }

        // Define the event handlers.
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            FileSystemEventHandler handler = FSEventHandler;
            handler(this, e);
        }


        private void OnError(object source, ErrorEventArgs e)
        {
            ErrorEventHandler handler = WatcherError;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event ErrorEventHandler WatcherError = delegate { };
        public event FileSystemEventHandler FSEventHandler = delegate { };
    }

}