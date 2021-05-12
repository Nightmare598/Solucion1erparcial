using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fncImpar.Models
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
