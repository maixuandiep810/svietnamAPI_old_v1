using System.Data;
using System.Data.SqlClient;
using System.IO;
using svietnamAPI.Dtos.ValueDtos;

namespace svietnamAPI.Infastructure.Data
{
    public interface IDataConnectionFactory
    {
        SqlConnection CreateSqlDbConnection();
        (Stream stream, string location, string url) CreateWriteStaticFileStream(StaticFileFolderType folderType, string filename);
    }
}