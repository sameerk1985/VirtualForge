using System.Collections.Generic;

namespace MusicaLog.DAL
{
    public class MusicaLogInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<MusicaLogContext>
    {
        protected override void Seed(MusicaLogContext context)
        {
            var data = new List<Common.Models.MusicaLog>
            {
                new Common.Models.MusicaLog { AlbumName = "Album1", Artist = "Artist1", Type = Common.Models.RecordType.CD, Stock = 10},
                new Common.Models.MusicaLog { AlbumName = "Album2", Artist = "Artist2", Type = Common.Models.RecordType.Vinyl, Stock = 20},
                new Common.Models.MusicaLog { AlbumName = "Album3", Artist = "Artist3", Type = Common.Models.RecordType.Vinyl, Stock = 30},
                new Common.Models.MusicaLog { AlbumName = "Album4", Artist = "Artist4", Type = Common.Models.RecordType.CD, Stock = 40},
                new Common.Models.MusicaLog { AlbumName = "Album5", Artist = "Artist5", Type = Common.Models.RecordType.CD, Stock = 50},
                new Common.Models.MusicaLog { AlbumName = "Album6", Artist = "Artist6", Type = Common.Models.RecordType.Vinyl, Stock = 60},
                new Common.Models.MusicaLog { AlbumName = "Album7", Artist = "Artist7", Type = Common.Models.RecordType.CD, Stock = 70},
                new Common.Models.MusicaLog { AlbumName = "Album8", Artist = "Artist8", Type = Common.Models.RecordType.Vinyl, Stock = 80},
                new Common.Models.MusicaLog { AlbumName = "Album9", Artist = "Artist9", Type = Common.Models.RecordType.CD, Stock = 90},
                new Common.Models.MusicaLog { AlbumName = "Album10", Artist = "Artist10", Type = Common.Models.RecordType.Vinyl, Stock = 100},
            };

            data.ForEach(d => context.MusicaLogs.Add(d));
            context.SaveChanges();
        }
    }
}
