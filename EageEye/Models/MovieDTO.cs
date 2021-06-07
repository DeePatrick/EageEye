using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EageEye.Models
{
    public class MovieDTO
    {

        public MovieDTO(string  Id, string MovieId, string Title, string Language, string Duration, string ReleaseYear)
        {
            this.Id = Id;
            this.MovieId = MovieId;
            this.Title = Title;
            this.Language = Language;
            this.Duration = Duration;
            this.ReleaseYear = ReleaseYear;
        }


        public string Id { get; set; }
        public string MovieId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public string ReleaseYear { get; set; }
       
    }
}
