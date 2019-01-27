using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Domain.Entities
{
    public class Movie
    {
        public Movie()
        {
            ActedMovies = new HashSet<ActedMovie>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public byte[] Poster { get; set; }
        public Guid ProducerId { get; set; }

        public Producer Producer { get; set; }
        public ICollection<ActedMovie> ActedMovies { get; private set; }
    }
}
