using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MvcMovie.ViewModel
{
    public class NewsViewModel
    {
        public int Id {get;set;}
        public string title {get;set;}
        public string description{get;set;}
        public DateTime history {get;set;}
    }
}