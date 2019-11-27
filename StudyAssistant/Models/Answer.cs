using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyAssistant.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [StringLength(1000, ErrorMessage = "Digite menos caracteres!")]
        [Required(ErrorMessage ="Campo obrigatório!")]
        public string Description { get; set; }

        public int QuestionId { get; set; }
    }
}
