using System.Collections.Generic;
using TesteArgo.Models;


namespace TesteArgo
{
    public class teste3
    {
        
        ConexaoAPI conexaoapi = new ConexaoAPI();

        /// <summary>
        /// By Search
        /// www.omdbapi.com/?s=titulo&apikey=18693fd6
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<Filme> ListarFilmes(string filtro)
        {

            return conexaoapi.GetFilmes("?s=" + filtro);
        }

        /// <summary>
        /// By ID or Title
        /// www.omdbapi.com/?i=tt0372784&apikey=18693fd6
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Filme ListarPorId(string id)
        {
            return conexaoapi.GetFilme("?i=" + id);
        }

    }  
}
