using EageEye.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace EageEye.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        //GET /movies/stats
        [Route("/stats")]
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            string line;
            List<Movie> movies = new List<Movie>();

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"c:\metadata.csv");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                movies.Add(new Movie(int.Parse(words[0]), words[1], words[2], words[3], int.Parse(words[4])));
            }

            file.Close();

            return movies;
        }


        [HttpGet("{id}")]
        //GET /metadata/:movieId
        [Route("/metadata/:movieId")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST /metadata
        [HttpPost]
        [Route("/metadata")]
        public ActionResult Create(Movie movie)
        {
            return View();
        }



    }
}
