namespace talentbridge_webAPI.ViewModel
{
    public class CadastroCandidato
    {
        public string Cpf {  get; set; }
        public DateTime DataNascimento { get; set; }
        public CadastroUsuario Usuario { get; set; }
    }
}
