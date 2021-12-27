using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testeWebApp.Models
{
    public class categoria 
    {
        [Column("categoriaId")] 
        [Key]
        public int id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "campo obrigatório")]
        public string descricao { get; set; }

        public decimal? valor { get; set; } 
    }
}
