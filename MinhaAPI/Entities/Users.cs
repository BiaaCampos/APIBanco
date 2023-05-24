
namespace MinhaAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public double Saldo { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(double saldo)
        {
            Saldo = saldo;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}