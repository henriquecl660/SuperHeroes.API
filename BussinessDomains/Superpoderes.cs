using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessDomains
{
    public record Superpoderes
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Superpoder { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Descricao { get; set; } = string.Empty;

        
    }
}
