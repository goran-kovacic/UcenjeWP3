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

            int Row = Dev ? 5 : CiklicnaHelpers.InputPositiveInteger("Enter number of rows: ");
            int Column = Dev ? 5 : CiklicnaHelpers.InputPositiveInteger("Enter number of columns: ");
            int StartingValue = Dev ? 1 : CiklicnaHelpers.InputInteger("Enter starting value: ");

            int RowMax = Row, ColumnMax = Column;
            int RowMin = 1, ColumnMin = 1;
            int[,] table = new int[Row, Column];

            Console.Write("Select (1) Clockwise or (2) Counterclockwise: ");
            int rotation = 0;

            while (true)
            {
                try
                {
                    rotation = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }
                if (rotation == 1 || rotation == 2)
                {
                    break;
                }
                Console.WriteLine("Enter 1 or 2!");
            }

            Console.WriteLine();
            Console.WriteLine("Select starting position: ");
            Console.WriteLine("1. Top left");
            Console.WriteLine("2. Top right");
            Console.WriteLine("3. Bottom left");
            Console.WriteLine("4. Bottom right");

            if (rotation == 1)
            {
                int position = 0;

                while (true)
                {
                    try
                    {
                        position = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                    }
                    if (position <= 4 && position >= 1)
                    {
                        break;
                    }
                    Console.WriteLine("Enter a value between 1 and 4!");
                }
                switch (position)
                {
                    case 1:
                        table = TopLeftClockwise.DrawTable(Row, Column, RowMin, RowMax, ColumnMin, ColumnMax, StartingValue);
                        Console.WriteLine("\n*** Starting at top left - clockwise ***\n");
                        break;
                    case 2:
                        table = TopRightClockwise.DrawTable(Row, Column, RowMin, RowMax, ColumnMin, ColumnMax, StartingValue);
                        Console.WriteLine("\n*** Starting at top right - clockwise ***\n");
                        break;
                    case 3:
                        table = BottomLeftClockwise.DrawTable(Row, Column, RowMin, RowMax, ColumnMin, ColumnMax, StartingValue);
                        Console.WriteLine("\n*** Starting at bottom left - clockwise ***\n");
                        break;
                    case 4:
                        table = BottomRightClockwise.DrawTable(Row, Column, RowMin, RowMax, ColumnMin, ColumnMax, StartingValue);
                        Console.WriteLine("\n*** Starting at botton right - clockwise ***\n");
                        break;
                }

            }
            else if (rotation == 2)
            {
                int position = 0;

                while (true)
                {
                    try
                    {
                        position = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                    }
                    if (position <= 4 && position >= 1)
                    {
                        break;
                    }
                    Console.WriteLine("Enter a value between 1 and 4!");
                }
                switch (position)
                {
                    case 1:
                        table = TopLeftCounterClockwise.DrawTable(Row, Column, RowMin, RowMax, ColumnMin, ColumnMax, StartingValue);
                        Console.WriteLine("\n*** Starting at top left - counterclockwise ***\n");
                        break;
                    case 2:
                        table = TopRightCounterClockwise.DrawTable(Row, Column, RowMin, RowMax, ColumnMin, ColumnMax, StartingValue);
                        Console.WriteLine("\n*** Starting at top right - counterclockwise ***\n");
                        break;
                    case 3:
                        table = BottomLeftCounterClockwise.DrawTable(Row, Column, RowMin, RowMax, ColumnMin, ColumnMax, StartingValue);
                        Console.WriteLine("\n*** Starting at bottom left - counterclockwise ***\n");
                        break;
                    case 4:
                        table = BottomRightCounterClockwise.DrawTable(Row, Column, RowMin, RowMax, ColumnMin, ColumnMax, StartingValue);
                        Console.WriteLine("\n*** Starting at bottom right - counterclockwise ***\n");
                        break;
                }
            }

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    Console.Write($"{table[i, j],4}");
                }
                Console.WriteLine();
            }
        }
    }
}
