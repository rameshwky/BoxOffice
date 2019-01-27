using BoxOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOffice.Persistence
{
    public class BoxOfficeInitializer
    {
        private readonly Dictionary<int, Actor> Actors = new Dictionary<int, Actor>();
        private readonly Dictionary<int, Producer> Producers = new Dictionary<int, Producer>();
        private readonly Dictionary<int, Movie> Movies = new Dictionary<int, Movie>();
        private readonly Dictionary<int, ActedMovie> ActedMovies = new Dictionary<int, ActedMovie>();

        public static void Initialize(BoxOfficeDbContext context)
        {
            var initializer = new BoxOfficeInitializer();
            initializer.SeedEverything(context);
        }

        private void SeedEverything(BoxOfficeDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movies.Any())
            {
                return; // Db has been seeded
            }

            SeedActors(context);
            SeedProducers(context);
            SeedMovies(context);
            SeedActedMovies(context);
        }
               
        private void SeedProducers(BoxOfficeDbContext context)
        {
            var producers = new[]
            {
                new Producer{ Id = Guid.Parse("fdb0518a-a29e-4710-9917-2b224e82cabf"), Name = "Emma Thomas", Sex = "F", Dob = Convert.ToDateTime("1971-12-09"), Bio = "Emma Thomas (born 9 December 1971) is a British film producer, known for co-producing films such as The Prestige (2006), Inception (2010), the Dark Knight trilogy (2005–2012), Interstellar (2014) and Dunkirk (2017). She frequently collaborates with her husband, filmmaker Christopher Nolan."},
                new Producer{ Id = Guid.Parse("9585aea4-d804-4f97-811b-412fbb502e8e"), Name = "Martin Scorsese", Sex = "M", Dob = Convert.ToDateTime("1942-11-17"), Bio = "Martin Charles Scorsese is an Italian and American filmmaker and historian, whose career spans more than 50 years. Scorsese''s body of work addresses such themes as Sicilian-American identity, Roman Catholic concepts of guilt and redemption, faith, machismo, modern crime, and gang conflict. Many of his films are also known for their depiction of violence and liberal use of profanity."},
                new Producer{ Id = Guid.Parse("d934eba1-44d7-4f61-b0f1-6a9a66b0a458"), Name = "Arnon Milchan", Sex = "M", Dob = Convert.ToDateTime("1944-12-06"), Bio = "Arnon Milchan is an Israeli billionaire businessman and film producer. He has been involved in over 130 full-length motion pictures[2] and is the founder of production company Regency Enterprises. Regency''s film credits include Oscar winners and nominees, as well as popular financial hits, including 12 Years a Slave, JFK, Heat, Fight Club, Mr. and Mrs. Smith, and many more."},
                new Producer{ Id = Guid.Parse("6b628c66-5cd6-46b2-af20-d17cb25eb6bb"), Name = "James Cameron", Sex = "M", Dob = Convert.ToDateTime("1954-07-16"), Bio = "James Francis Cameron is a Canadian filmmaker, philanthropist, and deep-sea explorer. After working in special effects, he found major success after directing and writing the science fiction action film The Terminator (1984). He then became a popular Hollywood director and was hired to write and direct Aliens (1986); three years later he followed up with The Abyss (1989)."}
            };

            context.Producers.AddRange(producers);

            context.SaveChanges();
        }

        private void SeedActors(BoxOfficeDbContext context)
        {
            var actors = new[]
            {
                new Actor{ Id = Guid.Parse("c0a380fd-1493-407f-a8df-1cd7d9ea5e81"), Name = "Leonardo DiCaprio", Sex = "M", Dob = Convert.ToDateTime("1974-11-11"), Bio = "Leonardo Wilhelm DiCaprio is an American actor and film producer. DiCaprio began his career by appearing in television commercials in the late 1980s. He next had recurring roles in various television series, such as the soap opera Santa Barbara and the sitcom Growing Pains."},
                new Actor{ Id = Guid.Parse("0a8bf9aa-c7da-4f53-801f-289505afc102"), Name = "Billy Zane", Sex = "M", Dob = Convert.ToDateTime("1966-02-24"), Bio = "William George Zane Jr is an American actor and producer. He is best known for his role in the epic romantic disaster film Titanic (1997), as well as roles in the science fiction comedies Back to the Future (1985) and Back to the Future Part II (1989), Dead Calm (1989), the television series Twin Peaks (1991), the western film Tombstone (1993), the horror film Demon Knight (1995), the first Kingdom Hearts video game (2002) as Ansem, Seeker of Darkness, and the comedy-drama CQ (2001)."},
                new Actor{ Id = Guid.Parse("c614b028-437c-4439-959e-2b15575ee0bd"), Name = "Kate Winslet", Sex = "F", Dob = Convert.ToDateTime("1975-10-05"), Bio = "Kate Elizabeth Winslet is an English actress. She is particularly known for her work in period dramas and tragedies, and is often drawn to portraying troubled women. Winslet is the recipient of several accolades, including three British Academy Film Awards, and is among the few performers to have won Academy, Emmy, and Grammy Awards."},
                new Actor{ Id = Guid.Parse("3214b8ca-c75d-42ec-a2af-a6c4dd70912e"), Name = "Tom Hardy", Sex = "M", Dob = Convert.ToDateTime("1977-08-15"), Bio = "Edward Thomas Hardy is an English actor, producer, and former model."}
            };

            context.Actors.AddRange(actors);

            context.SaveChanges();
        }

        private void SeedMovies(BoxOfficeDbContext context)
        {
            var movies = new[]
            {
                new Movie{ Id = Guid.Parse("8b5f424b-9093-43c3-8e6f-0fbe82ed9e3b"), Name="Titanic", YearOfRelease = 1997, Poster = null, ProducerId = Guid.Parse("6b628c66-5cd6-46b2-af20-d17cb25eb6bb"), Plot = "Titanic is a 1997 American epic romance and disaster film directed, written, co-produced and co-edited by James Cameron. A fictionalized account of the sinking of the RMS Titanic, it stars Leonardo DiCaprio and Kate Winslet as members of different social classes who fall in love aboard the ship during its ill-fated maiden voyage." },
                new Movie{ Id = Guid.Parse("6ff5a9df-1435-4601-ad44-1fc0c36b6ad4"), Name="Inception", YearOfRelease = 2010, Poster = null, ProducerId = Guid.Parse("fdb0518a-a29e-4710-9917-2b224e82cabf"), Plot = "Dominick 'Dom' Cobb and Arthur are 'extractors', who perform corporate espionage using an experimental military technology to infiltrate the subconscious of their targets and extract valuable information through a shared dream world. Their latest target, Japanese businessman Saito, reveals that he arranged their mission himself to test Cobb for a seemingly impossible job: planting an idea in a person''s subconscious, or 'inception'." },
                new Movie{ Id = Guid.Parse("f9035a2e-55bb-4216-9093-5b8bd039bba6"), Name="The Revenant", YearOfRelease = 2015, Poster = null, ProducerId = Guid.Parse("d934eba1-44d7-4f61-b0f1-6a9a66b0a458"), Plot = "The Revenant is a 2015 American semi-biographical epic western film directed by Alejandro G. Iñárritu. The screenplay by Mark L. Smith and Iñárritu is based in part on Michael Punke''s 2002 novel of the same name, describing frontiersman Hugh Glass''s experiences in 1823. That novel is in turn based on the 1915 poem The Song of Hugh Glass. The film stars Leonardo DiCaprio, Tom Hardy, Domhnall Gleeson, and Will Poulter." },
                new Movie{ Id = Guid.Parse("5c2fbfac-0040-4419-8ba5-d8687cf90c13"), Name="Shutter Island", YearOfRelease = 2010, Poster = null, ProducerId = Guid.Parse("9585aea4-d804-4f97-811b-412fbb502e8e"), Plot = "In 1954, U.S. Marshals Edward 'Teddy' Daniels and his new partner Chuck Aule travel to the Ashecliffe Hospital for the criminally insane on Shutter Island in Boston Harbor. They are investigating the disappearance of patient Rachel Solando, who was incarcerated for drowning her three children. Their only clue is a cryptic note found hidden in Solando''s room: 'The law of 4; who is 67 ? ' They arrive just before a storm hits, preventing their return to the mainland for a few days." },
                new Movie{ Id = Guid.Parse("bc30895a-e78a-4e88-9313-f8e5e9230991"), Name="The Wolf of Wall Street", YearOfRelease = 2013, Poster = null, ProducerId = Guid.Parse("9585aea4-d804-4f97-811b-412fbb502e8e"), Plot = "The Wolf of Wall Street is a 2013 American biographical black comedy crime film directed by Martin Scorsese and written by Terence Winter, based on the memoir of the same name by Jordan Belfort. It recounts Belfort''s perspective on his career as a stockbroker in New York City and how his firm Stratton Oakmont engaged in rampant corruption and fraud on Wall Street that ultimately led to his downfall." }
            };

            context.Movies.AddRange(movies);

            context.SaveChanges();
        }

        private void SeedActedMovies(BoxOfficeDbContext context)
        {
            var actedMovies = new[]
            {
                new ActedMovie{ActorId = Guid.Parse("0a8bf9aa-c7da-4f53-801f-289505afc102"), MovieId = Guid.Parse("8b5f424b-9093-43c3-8e6f-0fbe82ed9e3b")},
                new ActedMovie{ActorId = Guid.Parse("c0a380fd-1493-407f-a8df-1cd7d9ea5e81"), MovieId = Guid.Parse("5c2fbfac-0040-4419-8ba5-d8687cf90c13")},
                new ActedMovie{ActorId = Guid.Parse("c614b028-437c-4439-959e-2b15575ee0bd"), MovieId = Guid.Parse("8b5f424b-9093-43c3-8e6f-0fbe82ed9e3b")},
                new ActedMovie{ActorId = Guid.Parse("c0a380fd-1493-407f-a8df-1cd7d9ea5e81"), MovieId = Guid.Parse("f9035a2e-55bb-4216-9093-5b8bd039bba6")},
                new ActedMovie{ActorId = Guid.Parse("3214b8ca-c75d-42ec-a2af-a6c4dd70912e"), MovieId = Guid.Parse("6ff5a9df-1435-4601-ad44-1fc0c36b6ad4")},
                new ActedMovie{ActorId = Guid.Parse("3214b8ca-c75d-42ec-a2af-a6c4dd70912e"), MovieId = Guid.Parse("f9035a2e-55bb-4216-9093-5b8bd039bba6")},
                new ActedMovie{ActorId = Guid.Parse("c0a380fd-1493-407f-a8df-1cd7d9ea5e81"), MovieId = Guid.Parse("bc30895a-e78a-4e88-9313-f8e5e9230991")},
                new ActedMovie{ActorId = Guid.Parse("c0a380fd-1493-407f-a8df-1cd7d9ea5e81"), MovieId = Guid.Parse("6ff5a9df-1435-4601-ad44-1fc0c36b6ad4")},
                new ActedMovie{ActorId = Guid.Parse("c0a380fd-1493-407f-a8df-1cd7d9ea5e81"), MovieId = Guid.Parse("8b5f424b-9093-43c3-8e6f-0fbe82ed9e3b")}
            };

            context.ActedMovies.AddRange(actedMovies);

            context.SaveChanges();
        }

    }

}
