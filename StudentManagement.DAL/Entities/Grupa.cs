using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Grupa
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nazwa { get; set; }

        public virtual ICollection<Student> Studenci { get; set; }
    }
}