using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Compra_Consola
    {
        public int Id { get; set; }
        public Cliente ClienteID { get; set; }
        public Consola ConsolaID { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
    }
}
