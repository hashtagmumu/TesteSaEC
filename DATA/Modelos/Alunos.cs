using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Modelos
{
       public  class Alunos
    {
        [Key]
        public int codigo { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string email { get; set; }



        [StringLength(50)]
        public string matricula { get; set; }

        [StringLength(50)]
        public string endcompleto { get; set; }

        [StringLength(50)]
        public string rg { get; set; }

        public int? idade { get; set; }

        [StringLength(50)]
        public string cpf { get; set; }

        [StringLength(50)]
        public string telefone { get; set; }

        [StringLength(50)]
    
        public string sexo { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? dtcad { get; set; }
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? dtnac { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataAlteracao { get; set; }

        public int? idcidade { get; set; }

        public int? idusuario { get; set; }

        public int? idmae { get; set; }

        public int? idpai { get; set; }

        public virtual Cidades cidades { get; set; }

        public virtual AuxMaes AuxMae { get; set; }

        public virtual AuxPais AuxPai { get; set; }
    }
}
