using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaSharp
{
  //A classe Aluno herda de Pessoa
   public class Despertador: Hora
    {
       public string emSegundos { get; set; }
        
     

        public Despertador(String hora, String minuto, String segundo)
           : base(hora, minuto, segundo) // chamada ao construtor da classe pai (super em java)
        {
            this.hora = minuto;
        }
    }
}
