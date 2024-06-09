using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sube1.EntityApp
{
    [Table("DERSLER")]
    internal class Ders
    {
        public int dersid { get; set; }

        [Column(TypeName ="varchar")]
        [MaxLength(40)]
        [Required]
        public string dersadi { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(12)]
        [Required]
        public string? derskodu { get; set; }

    }
}
