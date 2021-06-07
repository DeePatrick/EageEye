using EageEye.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace EageEye.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;
        string line;
        List<MovieDTO> movies = new List<MovieDTO>();
        List<Stats> stats = new List<Stats>();
        List<Movie> moviesDB = new List<Movie>();
        List<ConsolidatedMovies> allMovieStats = new List<ConsolidatedMovies>();
        public MoviesController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        //GET /movies/stats
        [Route("/stats")]
        [HttpGet]
        public ActionResult<List<ConsolidatedMovies>> Get()
        {
            // Read the file and display it line by line.
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "metadata.csv");
            StreamReader file = new StreamReader(path);
   
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                movies.Add(new MovieDTO(words[0], words[1], words[2], words[3], words[4], words[5]));
            }
            var movieResults  = movies.Skip(1);

            file.Close();


            var query = (from t in movieResults
                         group t by new { t.MovieId, t.Title, t.ReleaseYear }
             into grp
                         select new
                         {
                             grp.Key.MovieId,
                             grp.Key.Title,
                             grp.Key.ReleaseYear,
                             AverageWatchDurationS = (grp.Sum(t => (TimeSpan.Parse(t.Duration).TotalSeconds)) / grp.Count())
                         }).ToList();

            //var orderResult = resultOfMovie.OrderByDescending(m => m.Watches).ToList();

            // Read the second file and display it line by line.
            var secondPath = Path.Combine(_hostingEnvironment.WebRootPath, "stats.csv");
            StreamReader secondFile = new StreamReader(secondPath);

            while ((line = secondFile.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                stats.Add(new Stats(words[0], words[1]));
            }
            var statResult = stats.Skip(1);

            secondFile.Close();


            var results = from p in statResult
                          group p.WatchDurationMs by p.MovieId into g
                          select new { MovieId = g.Key, Watches = g.ToList() };



            List<ConsolidatedMovies> finalList = results.Join(
                                query,
                                item => item.MovieId,
                                item1 => item1.MovieId,
                                (item, item1) => new ConsolidatedMovies() 
                                { 
                                    MovieId = int.Parse(item.MovieId),
                                    Title = item1.Title ,  
                                    AverageWatchDurationS = item1.AverageWatchDurationS, 
                                    Watches = item.Watches, 
                                    ReleaseYear = int.Parse(item1.ReleaseYear)
                                }).Take(5).ToList();






            return finalList;
        }



        [HttpGet("metatData/{id}")]
        //GET /metadata/:movieId
        public ActionResult<List<Movie>> Details(int id)
        {

            // Read the file and display it line by line.
            StreamReader file = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, "metadata.csv"));

            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                movies.Add(new MovieDTO(words[0], words[1], words[2], words[3], words[4], words[5]));
            }

            movies.Skip(1);
            var newresults = movies.Where(m => m.Id.Contains(id.ToString())).ToList()
                .Select(x => new Movie() { MovieId = int.Parse(x.MovieId), Title = x.Title, Duration = x.Duration, Language = x.Language, ReleaseYear = int.Parse(x.ReleaseYear) })
                .ToList();

            file.Close();

            return newresults;
        }

        //// POST /metadata
        //[HttpPost]
        //[Route("/metadata")]
        //public ActionResult Create(Movie movie)
        //{
        //    return View();
        //}



    }
}
