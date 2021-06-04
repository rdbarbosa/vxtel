using System;
using System.Collections.Generic;
using System.Text;

namespace VxTel.Entities.Entities
{
    public class Tarifa
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Valor { get; set; }
    }
}
