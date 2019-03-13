using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteArgo
{
    public class teste2
    {
        const int item = 3;

        public List<int> CriarLista(int quantidade)
        {
            List<int> lista = new List<int>();

            for(int cont=0; cont<quantidade; cont++)
            {
                lista.Add(cont);
            }

            return lista;
        }

        public List<int> OrdenarLista(params int[] valores)
        {
            List<int> lista = valores.ToList();
            lista[lista.IndexOf(item)] = lista[0];
            lista[0] = item;
            return lista;
        
        }
    }
}
