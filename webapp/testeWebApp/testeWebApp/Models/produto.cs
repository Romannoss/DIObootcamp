using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testeWebApp.Models
{
    public class produto
    {
        public int id { get; set; }
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        public int quantidade { get; set; }

        public int categoriaid { get; set; }

        public categoria categoria { get; set; }

      
        
    }
}
