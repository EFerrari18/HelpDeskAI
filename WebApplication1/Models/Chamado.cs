namespace HelpDeskAI.Models
{
    public class Chamado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string NomeUsuario { get; set; }
        public string Categoria { get; set; }
        public string Prioridade { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } = "Pendente";
    }
}
