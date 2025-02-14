namespace AlunoAPI.models
{
    public class AlunoModel
    {
        public AlunoModel()
        {
            Id = Guid.Empty;
            Nome = string.Empty;
            Email = string.Empty;
            DataNascimento = string.Empty;
            Telefone = string.Empty;
            DataInicioCurso = DateTime.Now;
            DataFimCurso = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInicioCurso { get; set; }
        public DateTime DataFimCurso { get; set; }
    }
}