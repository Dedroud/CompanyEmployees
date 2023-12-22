using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Comnata
    {
        [Column("ComnataId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Comnata name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }
        public ICollection<Human> Human { get; set; }

    }
}

