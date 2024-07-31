using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectiveTest.JogoGourmet.Models
{
    public class Prato
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }

        public IList<Prato> GerarPratos()
        {
            var list = new List<Prato>{
                new() { Nome = "pizza", Tipo = "Massa" },
                new() { Nome = "lasanha", Tipo = "Massa"},
                new() { Nome = "Bolo de chocolate", Tipo = "Bolo"}
            };

            return list;
        }
    }
}
