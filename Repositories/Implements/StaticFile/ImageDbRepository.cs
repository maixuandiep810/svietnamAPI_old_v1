using svietnamAPI.Repositories.Interfaces.StaticFile;
using svietnamAPI.Infastructure.Data;

namespace svietnamAPI.Repositories.Implements.StaticFile
{
    public class ImageDbRepository : GenericDbRepository, IImageDbRepository
    {
        public ImageDbRepository(IDataConnectionFactory dataConnectionFactory)
        : base(dataConnectionFactory)
        {

        }
    }
}