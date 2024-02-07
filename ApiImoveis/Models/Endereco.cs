namespace ApiImoveis.Models
{
    public class Endereco
    {
        public Endereco(string cep, string estado, string cidade, string bairro, string rua, string numero, string? complemento = null)
        {
            CEP = cep;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
        }

        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
    }
}
