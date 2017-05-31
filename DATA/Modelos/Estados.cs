using DATA.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Modelos
{
     public class Estados
    {
        public Estados()
        {
            cidade = new HashSet<Cidades>();
        }

        [Column(TypeName = "date")]
        public DateTime? dtcad { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataAlteracao { get; set; }

        [StringLength(50)]
        public string UF { get; set; }

        [StringLength(2)]
        public string SIgla { get; set; }

        [Key]
        public int codigo { get; set; }

       
        public virtual ICollection<Cidades> cidade { get; set; }
    }
}
