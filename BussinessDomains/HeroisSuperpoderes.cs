using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessDomains
{
    [Table("HeroisSuperpoderes")]
    public record HeroisSuperpoderes
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public  int HeroiId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public  List<int> SuperpoderId { get; set; }

      

    }

  

}
