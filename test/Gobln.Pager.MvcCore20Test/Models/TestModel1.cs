using System;
using System.ComponentModel.DataAnnotations;

namespace Gobln.Pager.MvcCore20Test.Models
{
    public class TestModel1
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Creation Date", Description = "Date when this is created")]
        public DateTime Date { get; set; }
    }
}
