using System.Threading.Tasks;
using Xamarin.Essentials;

namespace QPlanApp.Services.Geolocator
{
    public interface ILocationService
    {
        Task<Location> GetPositionAsync();
    }
}