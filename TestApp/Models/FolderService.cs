using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class FolderService
    {
        public FolderInfo GetFolderInfo(string path, string hostName)
        {
            try
            {
                FolderInfo info = new FolderInfo() {HostName = hostName, CurrentDir = path};

                if (path != "")
                {
                    if (!Directory.Exists(path))
                    {
                        throw new Exception("This is not directory");
                    }

                    var fileNames = Directory
                        .EnumerateFiles(path, "*", SearchOption.TopDirectoryOnly)
                        .Select(x => x.Substring(path.Length));

                    var directoriesNames = Directory
                        .EnumerateDirectories(path, "*", SearchOption.TopDirectoryOnly)
                        .Select(x => x.Substring(path.Length));

                    info.BrowseList = fileNames.Concat(directoriesNames);
                    countFiles(path, info);
                }
                else
                {
                    var test = DriveInfo.GetDrives().Select(x => x.Name).ToList();
                    test.ForEach(x => countFiles(x, info));
                    info.BrowseList = DriveInfo.GetDrives().Select(x => x.Name);
                }

                return info;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void countFiles(string path, FolderInfo info)
        {
            int mb = 1024*1024;
            var fileNames = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories).Select(x => x);
            
            foreach (string fileName in fileNames)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(fileName);

                    long size = fileInfo.Length;

                    if (size <= 10*mb)
                    {
                        info.LessThen10MbFilesAmount++;
                    }
                    else if (size <= 50*mb)
                    {
                        info.Between10And50MbFilesAmount++;
                    }
                    else
                    {
                        info.MoreThen100MbFilesAmount++;
                    }
                }
                catch (Exception ex)
                {
                }
            }            
        }
    }
}