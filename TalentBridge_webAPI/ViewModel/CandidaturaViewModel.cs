namespace talentbridge_webAPI.ViewModel
{
    public class CandidaturaViewModel
    {
        public int idVaga { get; set; }
        public string CPF { get; set; }
        public DateTime DataCandidatura { get; set; } = DateTime.Now;
        public string? Situacao { get; set; } = "Pendente";
    }
}
