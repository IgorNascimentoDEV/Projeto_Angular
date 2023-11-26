import { Solicitacao } from "../../solicitacoes/model/solicitacao";

export interface Item {
  _id: string;
  codigo: number;
  nome: string;
  preco: number;
  quantidade: number;
  solicitacoes: Solicitacao[];
}
