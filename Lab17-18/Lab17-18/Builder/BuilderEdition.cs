using System;
using System.Collections.Generic;
using System.Text;

namespace Lab17_18
{
    public interface AbstractFactory
    {
        public Author CreateAuthor(string name);
        public Edition CreateEdition(string name, DateTime date, float cost);
    }

    public class EditionFactory : AbstractFactory 
    {
        public Author CreateAuthor(string name)
        {
            return new Author(name);
        }
        public Edition CreateEdition(string name, DateTime date, float cost)
        {
            return new Edition(name, date, cost);
        }
    }
    public class AuthorsEdition
    {
        private Author author;
        private Edition edition;
        public AuthorsEdition(EditionFactory factory, string authname, string edname, DateTime date, float cost)
        {
            author = factory.CreateAuthor(authname);
            edition = factory.CreateEdition(edname, date, cost);
        }
        public override string ToString()
        {
            return $"Автор: {author.Name}\nИздание: {edition.ToString()}";
        }
    }
    //---------------------------------------------------------------
    public abstract class BuilderEdition
    {
        public Edition Edition = new Edition();
        public abstract void SetName(string name);
        public abstract void SetDate(DateTime data);
        public abstract void SetCost(float cost);
    }

    public class JournalBuilder: BuilderEdition
    {
        public override void SetCost(float cost)
        {
            Edition.Cost = cost;
        }

        public override void SetDate(DateTime data)
        {
            Edition.Date = data;
        }

        public override void SetName(string name)
        {
            Edition.Name = name;
        }
    }
    
    public class Administrator
    {
        public Edition Create(BuilderEdition builderEdition, string name, DateTime date, float cost)
        {
            builderEdition.SetName(name);
            builderEdition.SetDate(date);
            builderEdition.SetCost(cost);
            return builderEdition.Edition;
        }
    }
}
