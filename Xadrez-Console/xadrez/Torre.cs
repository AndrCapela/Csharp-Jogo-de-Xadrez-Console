using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez {
    class Torre : Peca {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) {

        }
        public override string ToString() {
            return "T";
        }
    }
}
