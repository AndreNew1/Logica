using System;
namespace Logica
{
    class CEP 
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Unidade { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }

        public DateTime Data = DateTime.Now;

        public override string ToString()
        {
            return Cep + "," + Logradouro + ","  +
                Bairro + "," + Uf+","+Data.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
