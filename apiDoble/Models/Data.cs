using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiDoble.Models
{
    public class Data
    {
        [Key]
        public int Random { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DataTime { get; set; }
    }
}
