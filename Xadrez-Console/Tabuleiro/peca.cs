﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Console.tabuleiro {
    class Peca {
        public Posicao posicao;
        public Cor cor { get; protected set; }
        public int qntMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Posicao posicao, Tabuleiro tab, Cor cor) {
            this.posicao = posicao;
            this.tab = tab;
            this.cor = cor;
            this.qntMovimentos = 0;
        }
    }
}
