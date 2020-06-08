using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotests.Models
{
    public interface IFolderRepository
    {
        void Create(Folder folder);
        void Delete(string FolderName);
        Folder Get(int id);
        List<Folder> GetFolders();
        void Update(Folder folder);
    }
    public class FolderRepository : IFolderRepository
    {
        int folderID;
        string connectionString = null;
        public FolderRepository(string conn)
        {
            connectionString = conn;
        }

        public List<Folder> GetFolders()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Folder>("SELECT * FROM [MPulseERP].[dbo].[DocumentFolder]").ToList();
            }
        }

        public Folder Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Folder>("SELECT * FROM [MPulseERP].[dbo].[DocumentFolder] WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Folder folder)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO [MPulseERP].[dbo].[DocumentFolder] (FolderName, SiteID, Createdate) VALUES(@FolderName, @SiteID, @Createdate);";
                db.Execute(sqlQuery, folder);
            }
        }
        public int CreateAndGetId(Folder folder)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //если мы хотим получить id добавленного фолдера
                var sqlQuery = "INSERT INTO DocumentFolder (FolderName, SiteID, Createdate) VALUES(@FolderName, @SiteID, @Createdate); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? folderId = db.Query<int>(sqlQuery, folder).FirstOrDefault();
                folderID = folderId.Value;
            }
            return folderID;
        }

        public void Update(Folder folder)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE [MPulseERP].[dbo].[DocumentFolder] SET FolderName = @FolderName, SiteID = @SiteID, Createdate = @Createdate WHERE Id = @Id";
                db.Execute(sqlQuery, folder);
            }
        }

        public void Delete(string FolderName)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM [MPulseERP].[dbo].[DocumentFolder] WHERE FolderName = @FolderName";
                db.Execute(sqlQuery, new { FolderName });
            }
        }
    }
}
