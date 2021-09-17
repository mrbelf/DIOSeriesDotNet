using System;

namespace Series
{
    public class Series : BaseEntity
    {
        private Genre _genre;
        private string _title;
        private string _description;
        private int _year;

        public Genre Genre { get => _genre; }
        public string Title { get => _title; }
        public string Description { get => _description; }
        public int Year { get => _year; }
        public int ID { get => id;}

        public Series(int id, Genre genre, string title, string description, int year)
        {
            base.id = id;
            _genre = genre;
            _title = title;
            _description = description;
            _year = year;
        }

        public override string ToString()
        {
            string value = "";

            value += "Genre: " + Genre + Environment.NewLine;
            value += "Title: " + Title + Environment.NewLine;
            value += "Description: " + Description + Environment.NewLine;
            value += "Year: " + Year + Environment.NewLine;
            
            return value;
        }
    }
}