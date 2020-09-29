using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MusicaLog.WCF
{
    [ServiceContract]
    public interface IMusicaLogService
    {
        [OperationContract]
        Task<List<Common.Models.MusicaLog>> GetMusicaLogs();

        [OperationContract]
        Task<Common.Models.MusicaLog> GetMusicaLog(int? id);

        [OperationContract]
        Task<int> AddMusicaLog(Common.Models.MusicaLog musicaLog);

        [OperationContract]
        Task<int> UpdateMusicaLog(Common.Models.MusicaLog musicaLog);

        [OperationContract]
        Task<int> DeleteMusicaLog(int id);
    }
}
