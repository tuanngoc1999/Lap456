using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lap456.Models
{
    public class Course
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }

        public ApplicationUser Lecture { get; set; }
        [Required]
        public string LectureId { get; set; }
        [Required]
        [StringLength(250)]
        public string Place { get; set; }
        public DateTime DateTime { get; set; }
        public Categlory Categlory { get; set; }
        [Required]
        public byte CategloryId { get; set; }
    }
}