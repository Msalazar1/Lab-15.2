using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using Dapper;

namespace Lab_15._2.Models
{
    public class Movie
    {
        [Table("Movies")]

        public class Movies
        {
            
            public long id { get; set; }
            public string Name { get; set; }
            public string Star { get; set; }
            public string Director { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }

            private static string connection = "Server=BW18Q13\\SQLEXPRESS;Database=MovieList;user id=test;password=password";
            public static Movies Create(string name, string star, string director, string category, string description)
            {
                Movies movie = new Movies()
                {
                    Name = name,
                    Star = star,
                    Director = director,
                    Category = category,
                    Description = description,
                };
                IDbConnection db = new SqlConnection(connection);
                
                return movie;

            }

            public static Movie Read(long id)
            {
                IDbConnection database = new SqlConnection(connection);
                Movie movie = database.Get<Movie>(id);
                return movie;
            }

            public static List<Movie> Read(string category)
            {
                IDbConnection database = new SqlConnection(connection);
                List<Movie> movies = database.Query<Movie>($"select * from Movie where Category = '{category}'").ToList();
                return movies;
            }

            public static List<string> ReadCategories()
            {
                IDbConnection database = new SqlConnection(connection);
                List<Movie> movies = database.Query<Movie>($"select distinct Category from Movie").AsList();
                List<string> categories = new List<string>();
                foreach (Movie movie in movies)
                {
                    categories.Add(movie.Category);
                }
                return categories;
            }

            public static List<Movie> Read()
            {
                IDbConnection database = new SqlConnection(connection);
                return movies;
                
            }

        }
    }
}
