using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyAssistant.Models
{
    public class TypeOfQuestion
    {
        public int Id { get; set; }
        [StringLength(60, ErrorMessage = "Digite menos caracteres!")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Name { get; set; }
    }
}
