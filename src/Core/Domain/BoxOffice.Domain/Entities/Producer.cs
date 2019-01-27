using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOffice.Domain.Entities
{
    public class Producer
    {
        public Producer()
        {
            Movie = new HashSet<Movie>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Dob { get; set; }
        public string Bio { get; set; }

        public ICollection<Movie> Movie { get; private set; }
    }
}
