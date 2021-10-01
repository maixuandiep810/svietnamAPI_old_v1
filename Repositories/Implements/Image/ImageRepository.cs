using svietnamAPI.Repositories.Interfaces.Image;
using svietnamAPI.Infastructure.Data;

namespace svietnamAPI.Repositories.Implements.Image
{
    public class ImageRepository : GenericRepository, IImageRepository
    {
        public ImageRepository(IDataConnectionFactory dataConnectionFactory)
        : base(dataConnectionFactory)
        {

        }
    }
}