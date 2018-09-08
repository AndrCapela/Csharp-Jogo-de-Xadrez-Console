using System;
using Xadrez_Console.tabuleiro;


namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            Tabuleiro tab = new Tabuleiro(8, 8);
            Tela.imprimirTabuleiro(tab);



            Console.ReadLine();
        }
    }
}
