using System;

namespace HelpDeskAI.Models
{
    public class Chamado
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        // Categoria como string (igual está no seu banco)
        public string Categoria { get; set; }

        // PRIORIDADE: Baixa / Média / Alta
        public string Prioridade { get; set; }

        public string Status { get; set; } = "Aberto";

        public DateTime DataAbertura { get; set; } = DateTime.Now;
    }
}
