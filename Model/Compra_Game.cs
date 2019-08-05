using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Compra_Game
    {
        public int Id { get; set; }
        public Cliente ClienteID { get; set; }
        public Games GamesID { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
    }
}
