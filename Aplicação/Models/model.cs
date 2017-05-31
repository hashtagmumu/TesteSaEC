using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Aplicação.Models
{
    public class Alunos
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
        [Required]
        public DateTime? dtnac { get; set; }

       
        public List<AuxPAis> AuxPAisa { get; set; }
        public List<AuxMAes> AuxMAes { get; set; }


    }
    public class AuxPAis
    {
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
    }
    public class AuxMAes
    {
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
    }
}