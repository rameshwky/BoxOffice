using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Domain.Entities
{
    public class Actor
    {
        public Actor()
        {
            ActedMovies = new HashSet<ActedMovie>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Dob { get; set; }
        public string Bio { get; set; }

        public ICollection<ActedMovie> ActedMovies { get; private set; }
    }
}
