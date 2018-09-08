using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Console.tabuleiro {
    class Tabuleiro {
        public int linhas;
        public int colunas;
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
    }
}
