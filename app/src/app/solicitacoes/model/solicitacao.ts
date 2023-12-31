export interface Solicitacao {
  id: string;
  solicitante: string;
  setor: string;
  quantidade: number;
  centroDeCusto: number;
  dataSolicitacao: string;
  status: string;
  codigoItem: number[];
}
