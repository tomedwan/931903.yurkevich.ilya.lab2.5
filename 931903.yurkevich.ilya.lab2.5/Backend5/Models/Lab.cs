using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backend5.Models
{
    public class Lab
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя требуется")]
        public string Name { get; set; } // название лаборатории
        [Required(ErrorMessage = "Адрес требуется")]
        public string Address { get; set; } // адрес лаборатории
        [Required(ErrorMessage = "Телефон требуется. P.S: Написание номера с 8")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"8+9+[0-9]{9}", ErrorMessage = "Номер недействительный")]
        public string Phone { get; set; } // телефон лаборатории
    }
}
