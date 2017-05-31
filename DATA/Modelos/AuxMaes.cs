using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Modelos
{
   public class AuxMaes
    {
        public AuxMaes()
        {
            aluno = new HashSet<Alunos>();
        }

        [Column(TypeName = "date")]
        public DateTime? dtcad { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataAlteracao { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string profissao { get; set; }

        [StringLength(50)]
        public string cpf { get; set; }

        [StringLength(50)]
        public string rg { get; set; }

        [StringLength(50)]
        public string telefone { get; set; }

        [Key]
        public int codigo { get; set; }

       
        public virtual ICollection<Alunos> aluno { get; set; }
    }
}
