using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Logica
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Show show = new Show();
            string s="s";
            List<CEP> BuscaCep = new List<CEP>();
            string path = @"C:\Users\Treinamento 2\Documents\Ceps.txt";

            try
            {
                using (StreamReader an = File.OpenText(path))
                {
                    string[] Rest = File.ReadAllLines(path);
                    for (int i = 0; i < Rest.Length; i++)
                    {
                        var cep = JsonConvert.DeserializeObject<CEP>(await Http(Rest[i]));
                        BuscaCep.Add(cep);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("CEPs Cadastrados: " + BuscaCep.Count);
            show.Tela(BuscaCep,s);
           

        }
        static async Task<string> Http(string Rest)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://viacep.com.br/ws/" + Rest.Replace("-","") + "/json");
                response.EnsureSuccessStatusCode();
                string Res = await response.Content.ReadAsStringAsync();
                return Res;
            }
            catch (HttpRequestException e)
            {
                return $"Message :{e.Message}";
            }
        }
    }
}
