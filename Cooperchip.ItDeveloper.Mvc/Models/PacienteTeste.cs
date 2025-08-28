namespace Cooperchip.ItDeveloper.Mvc.Models
{
    public class PacienteTeste
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public ICollection<Telefone> Telefones { get; set; }


        public PacienteTeste()
        {
            Id = Guid.NewGuid();
            Telefones = new HashSet<Telefone>();
        }
    }
}
