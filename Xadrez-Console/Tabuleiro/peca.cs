using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Console.tabuleiro {
    abstract class Peca {
        public Posicao posicao;
        public Cor cor { get; protected set; }
        public int qntMovimentos { get; protected set; }
        public Tabuleiro tab { get; set; }

        public Peca(Tabuleiro tab, Cor cor) {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qntMovimentos = 0;
        }
        public void incrementarQntMovimento() {
            qntMovimentos++;
        }

        public void decrementarQntMovimento() {
            qntMovimentos--;
        }

        public abstract bool[,] movimentosPossiveis();
        public bool existeMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++) {
                for(int j = 0; j < tab.colunas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }

            }
            return false;
        }
        public bool movimentoPossivel(Posicao pos) {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
    }
}
