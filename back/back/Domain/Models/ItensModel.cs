namespace back.Domain.Models
{
    public class ItensModel : Base
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
