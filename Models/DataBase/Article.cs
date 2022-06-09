using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace MvcMovie.Models.DataBase
{
    public class Article
    {
        [Key]
        public int id {get;set;}
        public string title {get;set;}
        public string description{get;set;}
        public DateTime history {get;set;}

    }
}