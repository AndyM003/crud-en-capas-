using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Atributos
{
    public class AttributesPeople
    {
        private int id;
        private string name;
        private string apellido;
        private string sexo;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Sexo { get => sexo; set => sexo = value; }
    }
}
