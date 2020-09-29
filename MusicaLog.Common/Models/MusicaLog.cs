using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicaLog.Common.Models
{
    public class MusicaLog
    {
        public int Id { get; set; }

        public string AlbumName { get; set; }

        public string Artist { get; set; }

        public RecordType Type { get; set; }

        public int Stock { get; set; }
    }

    public enum RecordType
    {
        None = 0,
        Vinyl,
        CD
    }
}
