using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tab;
        private int turno;
        private Cor JogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            JogadorAtual = Cor.Branca;
            turno = 1;
            colocarPecas();
        }
        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQntMovimento();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);

        }
        private void colocarPecas() {
             tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a',8).toPosicao());

        }
    }
}
