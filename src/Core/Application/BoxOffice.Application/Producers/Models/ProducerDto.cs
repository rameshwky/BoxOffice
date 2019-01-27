using System;

namespace BoxOffice.Application.Producers.Models
{
    public class ProducerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime Dob { get; set; }
        public string Bio { get; set; }
    }
}
