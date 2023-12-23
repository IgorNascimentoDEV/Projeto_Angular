namespace back.Domain.Models
{
    public class SolicitacoesModel : Base
    {
        public string Solicitante { get; set; }
        public string Setor { get; set; }
        public int Quantidade { get; set; }
        public int CentroDeCusto { get; set; }
        public string DataSolicitacao { get; set; }
        public string Status { get; set; }

        public List<ItensModel> Itens { get; set; }
    }
}
