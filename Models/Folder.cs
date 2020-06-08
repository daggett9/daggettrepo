using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string FolderName { get; set; }
        public int Sequence { get; set; }
        public string Description { get; set; }
        public int SiteId { get; set; }
        public byte IsActive { get; set; }
        public DateTime Createdate { get; set; }
        public byte IsHide { get; set; }
        public int ParentFolderID { get; set; }

    }
}
