namespace ApiRandom.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Data
    {
        [Key]
        public string RandNum { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EventDate { get; set; }

    }
}
