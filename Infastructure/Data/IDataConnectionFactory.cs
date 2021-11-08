using System.Data;
using System.Data.SqlClient;
using System.IO;
using svietnamAPI.Dtos.ValueDtos;

namespace svietnamAPI.Infastructure.Data
{
    public interface IDataConnectionFactory
    {
        void PrepareSqlDatabase();
        void PrepareStaticFilesFolder();

        SqlConnection CreateSqlDbConnection();
        (Stream stream, string location, string url) CreateWriteAppFileStream(PhysicalFolderType pscFolderType, string filename);
    
    }
}