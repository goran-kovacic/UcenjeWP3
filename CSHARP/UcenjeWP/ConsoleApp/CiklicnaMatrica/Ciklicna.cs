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
            int StartingValue = Dev ? 1 : int.Parse(Console.ReadLine());

            Console.Write("(1) Clockwise or (2) Counterclockwise: ");
            int direction = int.Parse(Console.ReadLine());

            Console.WriteLine();

            
            int RowMax = Row, ColumnMax = Column;
            int RowMin = 1, ColumnMin = 1;
            int[,] table = new int[Row,Column];

            if (direction == 1)
            {
                table = CiklicnaHelpers.BottomRightClockwise(Row, Column, RowMin, RowMax, ColumnMin, ColumnMax, StartingValue);
            }else if (direction==2)
            {
                table = CiklicnaHelpers.BottomRightCounterClockwise(Row, Column, RowMin, RowMax, ColumnMin, ColumnMax, StartingValue);
            }

            //int[,] table = CiklicnaHelpers.TableClockwise(Value, Row, Column, RowMin, RowMax, ColumnMin, ColumnMax);

            //int[,] table = CiklicnaHelpers.TableCounterClockwise(Value, Row, Column, RowMin, RowMax, ColumnMin, ColumnMax);

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
