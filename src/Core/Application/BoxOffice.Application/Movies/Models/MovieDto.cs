using System;
using System.Collections.Generic;

namespace BoxOffice.Application.Movies.Models
{
    public class MovieDto
    {
        public MovieDto()
        {
            Actors = new List<MovieActorDto>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int YearOfRelease { get; set; }

        public Guid ProducerId { get; set; }

        public string ProducerName { get; set; }

        public ICollection<MovieActorDto> Actors { get; set; }
    }
}
