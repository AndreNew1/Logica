using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    class Show
    {
        public void Tela(List<CEP> BuscaCep)
        {
            int sa=0;
            //Define as paginas
            while (sa <= 0 || sa > BuscaCep.Count)
            {
                Console.WriteLine("Digite o numero de elementos por pagina");
                int.TryParse(Console.ReadLine(), out sa);
            }
            //Quantidade de paginas
            int resu = BuscaCep.Count / sa;
            //Caso numero quebrar
            if (BuscaCep.Count % sa != 0) { resu += 1; }
            int Lis = 0;
            //Imprime as paginas
            TelaPaginas(resu,sa, BuscaCep,Lis);
        }
        public void TelaPaginas(int resu,int sa,List<CEP>BuscaCep,int Lis)
        {
            string s="0";
            if (resu != 0)
            {
                Console.Write("Paginas:");
                for (int i = 0; i < resu; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (Lis - 1 == i) { Console.ForegroundColor = ConsoleColor.Green; }
                    Console.Write($"|{i + 1}|");
                }
                Console.WriteLine("\nOu Digite n para sair");
                Console.ResetColor();
                s = Console.ReadLine().ToLower().Trim();
                if (s != "n")
                {
                    int.TryParse(s, out  Lis);
                    Console.WriteLine();
                    //Validação das paginas
                    if (Lis <= 0 || Lis > resu) { Console.WriteLine("Digite uma pagina valida"); }
                    else
                    {   //Definição da pagina
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        var Pagina = BuscaCep.OrderBy(x => x.Uf).ThenBy(x => x.Data).Skip((Lis - 1) * sa).Take(sa).ToList();
                        Print(Pagina);
                        Console.ResetColor();
                    }
                    TelaPaginas(resu, sa, BuscaCep,Lis);
                }
            }
            else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Não ha CEPs"); }
        }
        //Impressão 
        static void Print(List<CEP> s)
        {
            foreach (var a in s)
            {
                Console.WriteLine(a.ToString());
            }
        }
    }
}
