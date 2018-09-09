using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tab;
        public int turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez() {
            tab = new Tabuleiro(8, 8);
            JogadorAtual = Cor.Branca;
            turno = 1;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();

        }

        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQntMovimento();
            Peca pecaCapturada = tab.retirarPeca(destino);
            if (pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
            tab.colocarPeca(p, destino);

        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        private void mudaJogador() {
            if (JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            }
            else { JogadorAtual = Cor.Branca; }
        }

        public void validarPosicaoDeOrigem(Posicao pos) {
            if (pos.linha < 0 || pos.linha > 7 || pos.coluna < 0 || pos.coluna > 7) {
                throw new TabuleiroException("Fora do tabuleiro!");
            }
                if (tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (tab.peca(pos).cor != JogadorAtual) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (tab.peca(pos).existeMovimentosPossiveis() == false) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida");
            }
        }
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (destino.linha < 0 || destino.linha > 7 || destino.coluna < 0 || destino.coluna > 7) {
                throw new TabuleiroException("Fora do tabuleiro!");
            }
            if (tab.peca(origem).podeMoverPara(destino) == false) {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);

        }

        private void colocarPecas() {
            colocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Rainha(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Rei(tab, Cor.Preta));
            colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));

            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Rainha(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(tab, Cor.Branca));
            colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
        }
    }
}
