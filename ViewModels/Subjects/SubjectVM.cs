using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Subjects
{
    public class SubjectVM
    {
        [Key]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "* Please enter subject name")]
        [StringLength(100)]
        public string SubjectName { get; set; } = string.Empty;

        [Required(ErrorMessage = "* Please enter subject description")]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public List<Quiz> Quizzes { get; set; }
    }
}
