using System;

namespace Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public string Genre { get; set; }

        public Movie(int id, string name, int length, string genre)
        {
            ID = id;
            Name = name;
            Length = length;
            Genre = genre;
        }

        public Movie()
        {

        }

    }
}
