using System.Collections.Generic;
using TesteArgo.Models;


namespace TesteArgo
{
    /// <summary>
    /// Nessa classe deve ser feito o acesso a banco de dados SQL SERVER
    /// Dados de conexao do banco de dados
    /// host: den1.mssql6.gear.host
    /// base: testecore
    /// user:testecore
    /// senha : Dz2iI~!U1Edq
    /// 
    /// Tabela Destino
    /// 
    /// Colunas:
    /// DestinoId inteiro 
    /// Nome texto nulavel
    /// Dia data nulavel
    /// 
    /// </summary>
    public class teste4
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        DestinoDAL destinoDAL = new DestinoDAL();

        public List<Destino> ListarDestino()
        {
              
            return destinoDAL.GetDestinos();
        }

        public Destino buscarPorId(int id)
        {
            return destinoDAL.GetDestino(id);
        }

    }
}
