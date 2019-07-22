using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    class Show
    {
        public void Tela(List<CEP> BuscaCep,string s)
        {
            //Define as paginas
            Console.WriteLine("Digite o numero de elementos por pagina");
            int sa = Convert.ToInt32(Console.ReadLine());
            //Quantidade de paginas
            int resu = BuscaCep.Count / sa;
            //Caso numero quebrar
            if (BuscaCep.Count % sa != 0) { resu += 1; }
            //Imprime as paginas
            while (s == "s")
            {
                if (resu != 0)
                {
                    for (int i = 0; i < resu; i++)
                    {
                        Console.WriteLine($"Digite {i + 1} para pagina{i + 1}");
                    }
                    int.TryParse(Console.ReadLine(), out int Lis);
                    Console.WriteLine();
                    if (Lis <= 0 || Lis > resu)
                    {
                        Console.WriteLine("Digite uma pagina valida");
                    }
                    else
                    {
                        var Pagina = BuscaCep.OrderBy(x => x.Uf).ThenBy(x => x.Data).Skip((Lis - 1) * sa).Take(sa).ToList();
                        Print(Pagina);
                    }
                }
                else { Console.WriteLine("Não ha CEPs"); }
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Deseja ver outra pagina?(s/n)");
                    s = Console.ReadLine().ToLower().Trim();
                } while (s != "s" && s != "n");
            }
        }
        static void Print(List<CEP> s)
        {
            foreach (var a in s)
            {
                Console.WriteLine(a.ToString());
            }
        }
    }
}
