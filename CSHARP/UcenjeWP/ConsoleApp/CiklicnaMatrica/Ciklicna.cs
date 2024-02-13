using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CiklicnaMatrica
{
    internal class Ciklicna
    {

        public static void Run()
        {
            bool Dev = false;

            Console.Write("Enter number of rows: ");
            int Row = Dev ? 5 : int.Parse(Console.ReadLine());
            
            Console.Write("Enter number of columns: ");
            int Column = Dev ? 5 : int.Parse(Console.ReadLine());

            Console.Write("Enter starting value: ");
            int Value = int.Parse(Console.ReadLine());

            Console.WriteLine();

            
            int RowMax = Row, ColumnMax = Column;
            int RowMin = 1, ColumnMin = 1;
            

            int[,] table = CiklicnaHelpers.TableClockwise(Value, Row, Column, RowMin, RowMax, ColumnMin, ColumnMax);

            for (int i = 0; i < Row; i++)
            {
                for(int j=0;j<Column; j++)
                {
                    Console.Write($"{table[i,j],4}");                   
                }
                Console.WriteLine();
            }

        }
    }
}
