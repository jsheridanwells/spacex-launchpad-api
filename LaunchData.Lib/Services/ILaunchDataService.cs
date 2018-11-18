using System.Threading.Tasks;
using LaunchData.Lib.Models;

namespace LaunchData.Lib.Services
{
    public interface ILaunchDataService
    {
         Task<Launch> GetLaunchData();
    }
}
