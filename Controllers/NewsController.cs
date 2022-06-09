using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Services;
using MvcMovie.ViewModel;
using MvcMovie.Models.DataBase;

namespace MvcMovie.Controllers
 {
    public class NewsController : Controller
        {
            private readonly NewsService _service;
            public NewsController(NewsService service)
            {
                _service = service;
            }

            [HttpGet]
            public IActionResult Index()
            {
              var result =  _service.GetAll();
              return View(result.result);
            }
    //         [HttpPost]
    //        public IActionResult Create([FromForm] CreateFormStepViewmodel model)
    //        {
    //          if (ModelState.IsValid)
    //         {
    //         var result = _service.Create(model);
    //         if (result.successed)
    //         {
    //            return RedirectToAction("Index", new {id = model.InsurancePolicyId});
    //         }
    //         }
       
    //        return RedirectToAction("Index", new {id = model.InsurancePolicyId});

    //       }
    // [HttpPost]
    // public IActionResult Edit([FromForm]EditFormStepViewmodel model)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         var result = _service.Edit(model);
    //         if (result.successed)
    //         {
    //            return RedirectToAction("Index", new { message = result.message });
    //         }
    //     }
    //          return RedirectToAction("Index", model);

    // }
    
        } 
}