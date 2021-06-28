using System;

namespace Phoenix.Series
{
    public class Serie : EntityBase
    {
        //Atributes
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        //Methods
        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string result = "";
            result += "Genre: " + this.Genre + Environment.NewLine;
            result += "Title: " + this.Title + Environment.NewLine;
            result += "Description: " + this.Description + Environment.NewLine;
            result += "Year: " + this.Year + Environment.NewLine;
            result += "Deleted: " + this.Deleted;
            return result;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }

        public int ReturnId()
        {
            return this.Id;
        }

        public bool ReturnDeleted()
		{
			return this.Deleted;
		}

        public void Delet()
        {
            this.Deleted = true;
        }
    }

}