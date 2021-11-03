using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradesAPI.Models
{
    public class Grades
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string StudentName { get; set; }

        [Required]
        [StringLength(20)]
        public string Course { get; set; }
        [Required]
        public int Grade { get; set; }
    }
}
