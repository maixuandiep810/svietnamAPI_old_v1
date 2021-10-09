using svietnamAPI.Repositories.Interfaces.StaticFile;
using svietnamAPI.Infastructure.Data;

namespace svietnamAPI.Repositories.Implements.StaticFile
{
    public class ImageRepository : GenericRepository, IImageRepository
    {
        public ImageRepository(IDataConnectionFactory dataConnectionFactory)
        : base(dataConnectionFactory)
        {

        }
    }
}