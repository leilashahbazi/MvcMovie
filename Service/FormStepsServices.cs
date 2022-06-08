using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MvcMovie.Services
{

    public class FormSteps
    {
        private readonly ApplicationDbContext _db;
        public FormSteps(ApplicationDbContext db)
        {
            _db = db;
        }
         public (bool successed, string message, List<FormStepViewmodel> result) GetInsurance(int id)
        {
           var result = _db.FormSteps.Where(m => m.InsurancePolicyId == id).Select(m => new FormStepViewmodel()
            {
                Id = m.Id,
                Title = m.Title,
                IconUrl = m.IconUrl,
                InsurancePolicyId = m.InsurancePolicyId,
                InsurancePolicy = new InsurancePolicyViewmodel()
                {
                    Title = m.InsurancePolicy.Title,
                    Id = m.InsurancePolicy.Id,
                    CreateDateTime = m.InsurancePolicy.CreateDateTime,
                },
                Sections = m.Sections.Select(s => new SectionViewmodel() { Title = s.Title, Id = s.Id }).ToList()
            }).ToList();

            return (true, "", result);
        }
        
        public (bool successed, string message, List<FormStepViewmodel> result) GetAll(string searchOption)
        {
            var result = _db.FormSteps.Where(m =>(!string.IsNullOrEmpty(searchOption)?  m.Title.Contains(searchOption):true)).Select(m => new FormStepViewmodel()
            {
                Id = m.Id,
                Title = m.Title,
                IconUrl = m.IconUrl,
                InsurancePolicyId = m.InsurancePolicyId,
                InsurancePolicy = new InsurancePolicyViewmodel()
                {
                    Title = m.InsurancePolicy.Title,
                    Id = m.InsurancePolicy.Id,
                    CreateDateTime = m.InsurancePolicy.CreateDateTime,
                },
                Sections = m.Sections.Select(s => new SectionViewmodel() { Title = s.Title, Id = s.Id }).ToList()
            }).ToList();

            return (true, "", result);
        }
        public (bool success, string message, FormStepViewmodel result) GetSingle(int id)
        {
            var result = _db.FormSteps.Where(m => m.Id==id).Select(m => new FormStepViewmodel()
            {
                Id = m.Id,
                Title = m.Title,
                IconUrl = m.IconUrl,
                InsurancePolicyId = m.InsurancePolicyId,
                InsurancePolicy = new InsurancePolicyViewmodel()
                {
                    Title = m.InsurancePolicy.Title,
                    Id = m.InsurancePolicy.Id,
                    CreateDateTime = m.InsurancePolicy.CreateDateTime,
                },
                Sections = m.Sections.Select(s => new SectionViewmodel() { Title = s.Title, Id = s.Id }).ToList()
            }).FirstOrDefault();

            return (true, "", result);
        }
        public (bool successed, string message) Create(CreateFormStepViewmodel model)
        {
            var newItem = new FormStep() { Title = model.Title, IconUrl = model.IconUrl,InsurancePolicyId=model.InsurancePolicyId };
            _db.Add(newItem);
            _db.SaveChanges();

            return (true, "آیتم جدید با موفقیت اضافه شد");

        }
        public (bool successed, string message)Edit(EditFormStepViewmodel model)
        {
            var editItem = _db.FormSteps.Where(m => m.Id == model.Id).FirstOrDefault();
            if (editItem == null) return (true, "آیتم وارد شده در سیستم وجود ندارد");
            editItem.Title = model.Title;
            editItem.IconUrl = model.IconUrl;
            _db.SaveChanges();

            return (true, "آیتم جدید با موفقیت ویرایش شد");

        }
        public (bool successed, string message) Delete(FormStepViewmodel model)
        {
            var deleteItem = _db.FormSteps.Where(p => p.Id == model.Id ).FirstOrDefault();
           
            _db.Entry(deleteItem).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();

            return (true, "آیتم جدید با موفقیت حذف شد");

        }

    }
}