using System;
using System.Collections.Generic;

namespace BoxOffice.Application.Movies.Models
{
    public class MovieInfoDto
    {
        public MovieInfoDto()
        {
            Actors = new List<MovieActorDto>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int YearOfRelease { get; set; }

        public string Plot { get; set; }

        public byte[] Poster { get; set; }

        public Guid ProducerId { get; set; }

        public ICollection<MovieActorDto> Actors { get; private set; }
    }
}
