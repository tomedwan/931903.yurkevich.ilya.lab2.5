using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backend5.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя требуется")]
        public string Name { get; set; } // название доктора
        [Required(ErrorMessage = "Специальность требуется")]
        public string Speciality { get; set; } // специальность доктора

    }
}
