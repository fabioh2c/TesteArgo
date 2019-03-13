using System;
using System.Collections.Generic;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TesteArgo.Models;

namespace TesteArgo
{
    class ConexaoAPI
    {
        const string ApiKey = "18693fd6";
        const string URL = "https://www.omdbapi.com/";
        static HttpClient client = new HttpClient();

        public  List<Filme> GetFilmes(string filtro)
        {
            try
            {
                List<Filme> filmes = new List<Filme>();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(filtro + "&apikey=" + ApiKey + "&type=movie").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    ListaDataObject listadataobject = JsonConvert.DeserializeObject<ListaDataObject>(json);

                    foreach (var movie in listadataobject.Search)
                    {
         
                            Filme filme = new Filme
                            {
                                Titulo = movie.Title,
                                Ano = Convert.ToInt32(movie.Year),
                                ID = movie.imdbID,
                                Imagem = movie.Poster
                            };
                            filmes.Add(filme);

                    }
                }

                return filmes;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao listar os Filmes: " + e.Message);
            }
            finally
            {
                client.Dispose(); ;
            }

        }


        public Filme GetFilme(string filtro)
        {

            try
            {
                Filme filme = new Filme();
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(filtro + "&apikey=" + ApiKey).Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    DataObject movie = JsonConvert.DeserializeObject<DataObject>(json);
                    filme.Titulo = movie.Title;
                    filme.ID = movie.imdbID;
    
                    return filme;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao listar Filme: " + e.Message);
            }
            finally
            {
                client.Dispose();
            }
            
        }


    }

    internal class ListaDataObject
    {
        public List<DataObject> Search { get; set; }
    }

    internal class DataObject
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Poster { get; set; }
        public string Type { get; set; }
    }



}


