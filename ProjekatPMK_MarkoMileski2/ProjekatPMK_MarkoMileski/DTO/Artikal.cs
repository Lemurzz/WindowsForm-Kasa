using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatPMK_MarkoMileski.DTO
{
    public class Artikal
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public int Kategorija_Id { get; set; }
        public decimal Price { get; set; }
        public int Jedinica_Mere_Id { get; set; }
        public string? NazivJediniceMere { get; set; }


    }
}
