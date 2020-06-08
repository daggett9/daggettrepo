using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Autotests.Models;

namespace Autotests.DBQueries
{
    class DocumentationRepository : DataBaseConnection
    {
        private readonly DataBaseConnection _conn;

        public DocumentationRepository(DataBaseConnection connection)
        {
            _conn = connection;
        }


        //list of db queries

        public DocumentationRepository CreateNewParentFolder()
        {
            _ = $@"  insert into [MPulseERP].[dbo].[DocumentFolder] (FolderName, SiteID, Createdate)
  VALUES ('ParentFolderFromAutoTest', '1', GETDATE());";
            return this;
        }
        public DocumentationRepository DeleteParentFolder()
        {
            _ = $@"  delete from [MPulseERP].[dbo].[DocumentFolder] where Foldername = 'ParentFolderFromAutoTest';";
            return this;
        }
    }
}
