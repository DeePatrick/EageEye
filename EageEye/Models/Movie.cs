using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EageEye.Models
{
    public class Movie
    {
        private int v1;
        private string v2;
        private string v3;
        private string v4;
        private int v5;

        public Movie(int v1, string v2, string v3, string v4, int v5)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public int ReleaseYear { get; set; }
    }
}

