using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Compra_Accesorio
    {
            public int Id { get; set; }
            public Cliente ClienteID { get; set; }
            public Accesorios AccesoriosID { get; set; }
            public int Cantidad { get; set; }
            public int Total { get; set; }

    }
}
