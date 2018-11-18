using System.Collections.Generic;
using System.Threading.Tasks;
using LaunchData.Lib.Models;

namespace LaunchData.Lib.LaunchData
{
    public interface IGetLaunchData
    {
         Task<List<Launch>> ReturnLaunchData();
    }
}
