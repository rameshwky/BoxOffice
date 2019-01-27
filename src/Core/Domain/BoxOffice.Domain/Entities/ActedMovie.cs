using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Domain.Entities
{
    public class ActedMovie
    {       
        public Guid ActorId { get; set; }
        public Guid MovieId { get; set; }

        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
