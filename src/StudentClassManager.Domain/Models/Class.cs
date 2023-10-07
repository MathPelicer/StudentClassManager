namespace StudentClassManager.Domain.Models
{
    public class Class
    {
        public int Id { get; set; }

        public int CursoId { get; set; }

        public string Turma { get; set; }

        public int Ano { get; set; }
    }
}
