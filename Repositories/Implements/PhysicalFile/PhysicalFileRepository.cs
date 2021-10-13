using System;
using System.IO;
using System.Threading.Tasks;
using svietnamAPI.Dtos.ValueDtos;
using svietnamAPI.Helper;
using svietnamAPI.Infastructure.Data;
using svietnamAPI.Repositories.Interfaces.PhysicalFile;

namespace svietnamAPI.Repositories.Implements.PhysicalFile
{
    public class PhysicalFileRepository : GenericRepository, IPhysicalFileRepository
    {
        public PhysicalFileRepository(IDataConnectionFactory dataConnectionFactory) : base(dataConnectionFactory)
        {
        }

        public async Task WriteFileAsync(Stream sourceFileStream, Stream destFileStream)
        {
            using (sourceFileStream)
            using (destFileStream)
            {
                await sourceFileStream.CopyToAsync(destFileStream);
            }
        }


        public async Task WriteStaticFileAsync(StaticFileFolderType folderType, Stream sourceFileStream, string fileExtension, string filename)
        {
            filename = $"{GuidHepler.GenerateGuid()}-{folderType.ToString()}--{filename}";
            filename = RegexHelper.StandardizeFilename(filename);
            filename = $"{filename}.{fileExtension}";
            var destFileInfo = _dataConnectionFactory.CreateWriteStaticFileStream(StaticFileFolderType.CategoryImage, filename);
            await WriteFileAsync(sourceFileStream, destFileInfo.stream);
        }
    }
}