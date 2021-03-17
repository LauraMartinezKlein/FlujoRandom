using System;
using System.ComponentModel.DataAnnotations;

namespace fncImpar.Models
{
    public class Data
    {
        [Key]
        public string RandNum { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EventDate { get; set; }

    }
}

