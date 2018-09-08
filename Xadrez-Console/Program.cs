using System;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.xadrez;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            /* try {
                 Tabuleiro tab = new Tabuleiro(8, 8);


                 tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                 tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 7));
                 tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 3));

                 Tela.imprimirTabuleiro(tab);
             }
             catch(TabuleiroException e) {
                 Console.WriteLine(e.Message);
             }
             */

            PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosicao());
            Console.ReadLine();
        }
    }
}
