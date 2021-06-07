﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EageEye.Models
{
    public class ConsolidatedMovies
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public double AverageWatchDurationS { get; set; }
        public int Watches { get; set; }
        public int ReleaseYear { get; set; }
    }
}


