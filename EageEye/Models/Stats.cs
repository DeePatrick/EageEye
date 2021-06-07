using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EageEye.Models
{
    public class Stats
    {
        public Stats(string MovieId, string WatchDurationMs)
        {
            this.MovieId = MovieId;
            this.WatchDurationMs = WatchDurationMs;

        }

        public string MovieId { get; set; }
        public string WatchDurationMs { get; set; }

    }
}

