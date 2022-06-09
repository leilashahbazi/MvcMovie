using System;
using System.Linq;
using System.Threading.Tasks;
using MvcMovie.ViewModel;
using MvcMovie.Models;
namespace MvcMovie.Services
{

    public class NewsService
    {
        private readonly ApplicationDbContext _db;
        public NewsService (ApplicationDbContext db)
        {
            _db = db;
        }
        
        public (bool successed, string message, List<NewsViewModel> result) GetAll()
        {
          try{
                
            var result = _db.News.Select(m => new NewsViewModel()
            {
                Id = m.Id,
                title = m.title,
                description = m.description,
                history = m.history
              
            }).ToList();

            return (true, "", result);
            }
            catch(Exception ex)
            {
                return(false,ex.Message,null);
            }

           
        }
        public (bool success, string message, NewsViewModel result) GetSingle(int id)
        {
           try{
                var result = _db.News.Where(m => m.Id==id).Select(m => new NewsViewModel()
            {
                Id = m.Id,
                title = m.title,
                description = m.description,
                history = m.history
              
            }).FirstOrDefault();

            return (true, "", result);

           } 
           catch(Exception ex)
           {
               return(false,ex.Message,null);
           }
        }
        public (bool successed, string message) Create(CreateNewsViewModel model)
        {
            try{
                var newItem = new CreateNewsViewModel() { 
                title = model.title,
                description = model.description,
                history= model.history };
                _db.Add(newItem);
                _db.SaveChanges();

            return (true, "ok");

            }
            catch(Exception ex)
            {
                return(false,ex.Message);
            }
            

        }
        public (bool successed, string message)Edit(EditNewsViewModel model)
        {
            try{
             var editItem = _db.News.Where(m => m.Id == model.Id).FirstOrDefault();
            if (editItem == null) return (false, "fail");
            editItem.title = model.title;
            editItem.description = model.description;
            _db.SaveChanges();

            return (true, "ok");

                
            }
            catch(Exception ex){
                return(false,ex.Message);

            }
          
        }
        public (bool successed, string message) Delete(NewsViewModel model)
        {
            try{
            var deleteItem = _db.News.Where(p => p.Id == model.Id ).FirstOrDefault();
           
            _db.Entry(deleteItem).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();

            return (true, "ok");

            }
            catch(Exception ex)
            {
                return(false,ex.Message);
            }
           

        }

    }
}