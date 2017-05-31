using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Modelos
{
       public  class Usuarios
    {
        [Key]
        public int codigo { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string senha { get; set; }

        [StringLength(50)]
        public string cpf { get; set; }

        [StringLength(50)]
        public string telefone { get; set; }

        [StringLength(1)]
        public string sexo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dtcad { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataAlteracao { get; set; }

        [StringLength(50)]
        public string cidade { get; set; }
    }
}
