using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Options;
using svietnamAPI.Dtos.ValueDtos;
using svietnamAPI.StartupConfiguration.AppSetting;

namespace svietnamAPI.Infastructure.Data
{
    public class DataConnectionFactory : IDataConnectionFactory
    {
        private readonly ServerSetting _serverSetting;
        private readonly string _dbConnectionString;
        private readonly StaticFileInfo _staticFileInfo;

        public DataConnectionFactory(IOptions<ServerSetting> serverSetting)
        {
            _serverSetting = serverSetting.Value;
            _dbConnectionString = _serverSetting.DataConnection.DbConnectionString;
            _staticFileInfo = _serverSetting.StaticFileInfo;
        }

        public SqlConnection CreateSqlDbConnection()
        {
            SqlConnection connection = new SqlConnection(_dbConnectionString);
            return connection;
        }

        public (Stream stream, string location, string url) CreateWriteAppFileStream(int folderType, string filename)
        {
            string folderLocation = "";
            Uri folderUrl = null;
            switch (folderType)
            {
                case PhysicalFolderType.CategoryImage:
                    folderLocation = _staticFileInfo.CategoryImageLocation;
                    folderUrl = new Uri(_staticFileInfo.CategoryImageUrl);
                    break;
                default:
                    break;
            }
            var fileLocation = Path.Combine(folderLocation, filename);
            var fileUrl = new Uri(folderUrl, filename);
            Stream fileStream = new FileStream(fileLocation, FileMode.Create);
            var result = (stream: fileStream, location: fileLocation, url: fileUrl.ToString());
            return result;
        }

        public void PrepareSqlDatabase()
        {

        }

        public void PrepareStaticFilesFolder()
        {
            CreateRelativeFolderIfNotExits(_staticFileInfo.BaseLocation);
            CreateRelativeFolderIfNotExits(_staticFileInfo.CategoryImageLocation);
        }

        private void CreateRelativeFolderIfNotExits(string relativePath)
        {
            if (!Directory.Exists(relativePath))
            {
                Directory.CreateDirectory(relativePath);
            }
        }
    }
}