namespace WebAppPiagetRyan.Models
{
    /// <summary>
    /// Classe Professor
    /// </summary>
    public class Professor : Base
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }

        public Aluno? Aluno { get; set; }
    }
}
