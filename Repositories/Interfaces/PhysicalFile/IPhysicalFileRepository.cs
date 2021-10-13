using System.IO;
using System.Threading.Tasks;
using svietnamAPI.Dtos.ValueDtos;

namespace svietnamAPI.Repositories.Interfaces.PhysicalFile
{
    public interface IPhysicalFileRepository : IGenericRepository
    {
        Task WriteFileAsync(Stream sourceFileStream, Stream destFileStream);
        Task WriteStaticFileAsync(StaticFileFolderType folderType, Stream sourceFileStream, string fileExtension, string filename);

    }
}