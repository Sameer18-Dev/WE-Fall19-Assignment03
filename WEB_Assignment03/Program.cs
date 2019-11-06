using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_Assignment03
{
    class Program
    {
                                     /*   Assignment#03   */

        static int N;

        static void Print(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.Write("\n");
            }
        }


        static Boolean SetorNot(int[,] board, int row, int col)
        {
            int i, j;
            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1) return false;
            }
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1) return false;
            }
            for (i = row, j = col; j >= 0 && i < N; i++, j--)
            {
                if (board[i, j] == 1) return false;
            }
            return true;
        }



        static Boolean Solver(int[,] board, int col)
        {
            if (col >= N) return true;
            for (int i = 0; i < N; i++)
            {
                if (SetorNot(board, i, col))
                {
                    board[i, col] = 1;
                    if (Solver(board, col + 1)) return true;
                    board[i, col] = 0;
                }
            }
            return false;
        }




        static void Main(string[] args)
        {
            Console.WriteLine("The N Queen Problem");
            Console.WriteLine("Enter the value of N : ");

            N = Convert.ToInt32(Console.ReadLine());
            
            int[,] board = new int[N, N];
            
            if (!Solver(board, 0))   //   If method returns false
            {
                Console.WriteLine("Sol Not Found!");
            }

            Print(board);
            
            Console.ReadLine();
        }
    }
}
