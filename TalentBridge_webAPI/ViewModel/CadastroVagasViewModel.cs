namespace TalentBridge_webAPI.ViewModel
{
    public class CadastroVagasViewModel
    {
        public string? Cnpj { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public string? Descricao { get; set; }

        public string Titulo { get; set; } = null!;

        public bool Disponivel { get; set; }

        public string ModeloTrabalho { get; set; } = null!;

        public string Senioridade { get; set; } = null!;
    }
}
