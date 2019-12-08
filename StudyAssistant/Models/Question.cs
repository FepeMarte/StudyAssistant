using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyAssistant.Models
{
    public class Question
    {
        public int Id { get; set; }

        [StringLength(1000, ErrorMessage = "Digite menos caracteres!")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Description { get; set; }
        public int RightAnswerId { get; set; }
        public int TypeOfQuestionId { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
