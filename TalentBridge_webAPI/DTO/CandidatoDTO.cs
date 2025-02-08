namespace TalentBridge_webAPI.DTO
{
    public class CandidatoDTO
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Logradouro { get; set; }
        public string NumeroRes { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }
        public string TipoEndereco { get; set; }
        public string TipoContato { get; set; }
        public string Numero { get; set; } // Do Contato
    }
}
