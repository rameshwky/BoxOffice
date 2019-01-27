using System;

namespace BoxOffice.Application.Actors.Models
{
    public class ActorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Dob { get; set; }
        public string Bio { get; set; }
    }
}
