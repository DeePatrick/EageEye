using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EageEye.Models
{
    public class Movie
    {

        //public Movie(int MovieId, string Title, string Language, string Duration, int ReleaseYear)
        //{
        //    this.MovieId = MovieId;
        //    this.Title = Title;
        //    this.Language = Language;
        //    this.Duration = Duration;
        //    this.ReleaseYear = ReleaseYear;
        //}



        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public int ReleaseYear { get; set; }
        
    }
}



