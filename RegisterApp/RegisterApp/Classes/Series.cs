using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterApp
{
    public class Series : BaseEntity
    {
        // Attributes

        private Gender Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        private bool Excluded { get; set; }

        //Methods

        public Series(int id, Gender gender, string title, string description, int year)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }

        public override string ToString()
        {
            //Environment.NewLine: https://docs.microsoft.com/en-us/api/system/.environment/newline?view=netcore-3.1

            string retorno = "";
            retorno += "Gender: " + this.Gender + Environment.NewLine;
            retorno += "Title: " + this.Title + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Year: " + this.Year + Environment.NewLine;
            retorno += "Excluded: " + this.Excluded + Environment.NewLine;

            return retorno;
        }

        //Encapsulation 

        public string returnTitle()
        {
            return this.Title;
        }

        internal int returnId()
        {
            return this.Id;
        }
        internal bool returnExcluded()
        {
            return this.Excluded;
        }
        public void Exclude()
        {
            this.Excluded = true;
        }
    }
}
