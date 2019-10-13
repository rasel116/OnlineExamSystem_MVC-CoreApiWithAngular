using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add New
using Microsoft.Practices.Unity;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsChoice : IDataAccessRepository<Choice, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var choice = db.Choices.Find(id);
            if (choice != null)
            {
                db.Choices.Remove(choice);
                db.SaveChanges();
            }
        }

        public IEnumerable<Choice> Get()
        {
            return db.Choices.ToList();
        }

        public Choice Get(int id)
        {
            return db.Choices.Find(id);
        }

        public void Post(Choice entity)
        {
            // We have to keep the Unique Question ID in the cache OR in a hidden field Which will update.

            Choice choice = db.Choices.Where(s => s.Label == "UniqueQuestionID").FirstOrDefault(); //=========================== We have to delete it and have to take value form cache when implement.

            entity.UniqueQuestionID = choice.UniqueQuestionID;
            db.Choices.Add(entity);
            db.SaveChanges();
        }

        public void Put(int id, Choice entity)
        {
            var choice = db.Choices.Find(id);
            if (choice != null)
            {
                choice.Label = entity.Label;
                choice.Points = entity.Points;
                choice.IsActive = entity.IsActive;
                db.SaveChanges();
            }
        }
    }
}