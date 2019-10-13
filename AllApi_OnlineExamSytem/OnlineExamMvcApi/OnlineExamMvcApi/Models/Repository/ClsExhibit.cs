using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add New
using Microsoft.Practices.Unity;

namespace OnlineExamMvcApi.Models.Repository
{
    public class ClsExhibit : IDataAccessRepository<Exhibit, int>
    {
        [Dependency]
        public ApplicationDbContext db { get; set; }

        public void Delete(int id)
        {
            var exhibit = db.Exhibits.Find(id);
            if (exhibit != null)
            {
                db.Exhibits.Remove(exhibit);
                db.SaveChanges();
            }
        }

        public IEnumerable<Exhibit> Get()
        {
            return db.Exhibits.ToList();
        }

        public Exhibit Get(int id)
        {

            return db.Exhibits.Find(id);
        }

        public void Post(Exhibit entity)
        {
            Question question = new Question();
            //question.ExhibitId = entity.ExhibitId;
            db.Questions.Add(question);


            db.Exhibits.Add(entity);
            db.SaveChanges(); ;
        }

        public void Put(int id, Exhibit entity)
        {
            var exhibit = db.Exhibits.Find(id);
            if (exhibit != null)
            {
                exhibit.ExhibitData = entity.ExhibitData;
                db.SaveChanges();
            }
        }
    }
}