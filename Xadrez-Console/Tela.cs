using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.xadrez;

namespace Xadrez_Console {
    class Tela {

        public static void imprimirTabuleiro(Tabuleiro tab) {
            Console.WriteLine("  a b c d e f g h");
            for (int i = 0; i < tab.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j <= tab.colunas; j++) {
                    if (j == tab.colunas) {
                        
                    }
                    else {
                        imprimirPeca(tab.peca(i, j), i, j);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void imprimirPartida(PartidaDeXadrez partida) {
            imprimirTabuleiro(partida.tab);
            imprimirPecasCapturadas(partida);
            Console.WriteLine("\nTurno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
            if (partida.xeque) {
                Console.WriteLine("XEQUE!");
            }
        }
        private static void imprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("\nPretas: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void imprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            string cap = " ";
            foreach (Peca X in conjunto) {
                if (cap.Length == 1) {
                    cap = cap.Remove(cap.Length - 1) + X + " ";
                }
                else {
                    cap = cap + X + " ";
                }
            }
            Console.Write(cap.Remove(cap.Length - 1) + "]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis) {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j), i, j);
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }
        public static PosicaoXadrez lerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void imprimirPeca(Peca peca, int linha, int coluna) {
            if (peca == null) {
                if ((linha + coluna) % 2 != 0) {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("—");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else {
                if (peca.cor == Cor.Branca) {
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }

            }
            Console.Write(" ");
        }
    }
}
