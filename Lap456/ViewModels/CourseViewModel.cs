using Lap456.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lap456.ViewModels
{
    public class CourseViewModel
    {
        [Required]
        public string Place { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public byte Categlory { get; set; }
        public IEnumerable<Categlory> Categlories { get; set; }
        public string Heading { get; set; }
        public string Action
        {
            get { return (Id != 0) ? "Update" : "Create"; }
        }

        public int Id { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}