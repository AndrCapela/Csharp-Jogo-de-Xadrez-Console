using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Console.tabuleiro {
    abstract class Peca {
        public Posicao posicao;
        public Cor cor { get; protected set; }
        public int qntMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor) {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qntMovimentos = 0;
        }
        public void incrementarQntMovimento() {
            qntMovimentos = qntMovimentos + 1;
        }
        public abstract bool[,] movimentosPossiveis();

    }
}
