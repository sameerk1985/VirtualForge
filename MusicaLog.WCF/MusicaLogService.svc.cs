using MusicaLog.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MusicaLog.WCF
{
    public class MusicaLogService : IMusicaLogService
    {
        private readonly MusicaLogContext context;
        
        public MusicaLogService()
        {
            context = new MusicaLogContext();
        }
        
        public async Task<List<Common.Models.MusicaLog>> GetMusicaLogs()
        {
            try
            {
                var data = await context.MusicaLogs.ToListAsync();
                return data;
            }
            catch(Exception ex) {
                return null;
            }
        }

        public async Task<Common.Models.MusicaLog> GetMusicaLog(int? id)
        {
            return await context.MusicaLogs.FindAsync(id);
        }

        public async Task<int> AddMusicaLog(Common.Models.MusicaLog musicaLog)
        {
            context.MusicaLogs.Add(musicaLog);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateMusicaLog(Common.Models.MusicaLog musicaLog)
        {
            context.Entry(musicaLog).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteMusicaLog(int id)
        {
            Common.Models.MusicaLog musicaLog = await context.MusicaLogs.FindAsync(id);
            context.MusicaLogs.Remove(musicaLog);
            return await context.SaveChangesAsync();
        }
    }
}
