namespace back.Domain.Models
{
    public class SolicitacoesModel : Base
    {
        public string Solicitantes { get; set; }
        public string Setor { get; set; }
        public int quantidade { get; set; }
        public int centroDeCusto { get; set; }
        public string DataSolicitcao { get; set; }
        public string Status { get; set; } 
        public List<ItensModel> itens { get; set; }
    }
}
