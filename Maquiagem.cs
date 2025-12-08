using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
     class Maquiagem

    {
       String  nomeMaquiagem;
       String  marcaMaquiagem;
       int     quantidadeMaquiagem;
       int     estoqueMaquiagem;

        public string NomeMaquiagem { get => nomeMaquiagem; set => nomeMaquiagem = value; }
        public string MarcaMaquiagem { get => marcaMaquiagem; set => marcaMaquiagem = value; }
        public int QuantidadeMaquiagem { get => quantidadeMaquiagem; set => quantidadeMaquiagem = value; }
        public int EstoqueMaquiagem { get => estoqueMaquiagem; set => estoqueMaquiagem = value; }
    }
}
