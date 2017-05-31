using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Modelos
{
 public   class Cidades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cidades()
        {
            alunos = new HashSet<Alunos>();
        }

        [Key]
        public int codigo { get; set; }

        [StringLength(50)]
        public string cidade { get; set; }

        public int? codigouf { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dtcad { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataAlteracao { get; set; }

        [StringLength(50)]
        public string Cep { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alunos> alunos { get; set; }

        public virtual Estados Estado { get; set; }
    }
}
