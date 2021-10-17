using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AulaSharp

{
    public class Hora
    {
        //propriedade auto-implementada
        public String hora { get; set; }

        public String minuto { get; set; }

        public String segundo { get; set; }




        public Hora() { }

        public Hora(String hora, String minuto, String segundo)
        {
            this.hora = hora;
            this.minuto = minuto;
            this.segundo = segundo;
        }

        public Hora(String hora, String minuto)
        {
            this.hora = hora;
            this.minuto = minuto;

        }


    }
}
