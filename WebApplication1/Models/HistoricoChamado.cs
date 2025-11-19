namespace HelpDeskAI.Models
{
    public class HistoricoChamado
    {
        public int Id { get; set; }
        public int ChamadoId { get; set; }
        public DateTime DataEvento { get; set; }
        public string Acao { get; set; }
        public string Observacao { get; set; }
    }
}
