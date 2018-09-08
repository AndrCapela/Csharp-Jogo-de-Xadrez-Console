using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;
namespace Xadrez_Console.xadrez {
    class Cavalo : Peca {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }
        public override string ToString() {
            return "C";
        }
    }
}
