namespace HelpDeskAI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public string? Telefone { get; set; }
        public string Perfil { get; set; }
    }
}
