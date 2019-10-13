using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamCoreApi.Models.Repository
{
    public class ClsExhibit : IDataAccessRepository<Exhibit>
    {
        readonly CrudInCoreWebApiDbContext _exhibitContext;
        public ClsExhibit(CrudInCoreWebApiDbContext context)
        {
            _exhibitContext = context;
        }
        public void Add(Exhibit entity)
        {
            Question question = new Question();
            question.ExhibitId = entity.ExhibitId;
            _exhibitContext.Questions.Add(question);

            _exhibitContext.Exhibits.Add(entity);
            _exhibitContext.SaveChanges();
        }

        public void Delete(Exhibit entity)
        {
            _exhibitContext.Exhibits.Remove(entity);
            _exhibitContext.SaveChanges();
        }

        public Exhibit Get(long id)
        {
            return _exhibitContext.Exhibits.FirstOrDefault(e => e.ExhibitId == id);
        }

        public IEnumerable<Exhibit> GetAll()
        {
            return _exhibitContext.Exhibits.ToList();
        }

        public void Update(Exhibit exhibit, Exhibit entity)
        {
            exhibit.ExhibitData = entity.ExhibitData;
            _exhibitContext.SaveChanges();
        }
    }
}
