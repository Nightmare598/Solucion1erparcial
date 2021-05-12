using System;
using System.ComponentModel.DataAnnotations;

namespace fncPar.Models
{
    class Data
    {
        [Key]
        public int Random { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DataTime { get; set; }
    }
}
