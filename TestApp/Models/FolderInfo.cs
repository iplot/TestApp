using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class FolderInfo
    {
        public string HostName { get; set; }
        public string CurrentDir { get; set; }
        public IEnumerable<string> BrowseList { get; set; }
        public long LessThen10MbFilesAmount { get; set; }
        public long Between10And50MbFilesAmount { get; set; }
        public long MoreThen100MbFilesAmount { get; set; }
    }
}