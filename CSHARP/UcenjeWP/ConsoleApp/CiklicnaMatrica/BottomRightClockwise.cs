using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CiklicnaMatrica
{
    internal class BottomRightClockwise
    {

        internal static int[,] DrawTable(int Row,
                                         int Column,
                                         int RowMin,
                                         int RowMax,
                                         int ColumnMin,
                                         int ColumnMax,
                                         int StartingValue)
        {
            int[,] table = new int[Row, Column];
            int Value = StartingValue;

            for (int i = Value; i <= (Row * Column); i++)
            {
                for (int j = ColumnMin; j <= ColumnMax; j++) // right to left
                {
                    table[Row - RowMin, Column - j] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }

                RowMin++;

                for (int j = RowMin; j <= RowMax; j++) //bottom to top
                {
                    table[Row - j, Column - ColumnMax] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }

                for (int j = ColumnMin; j <= Column - ColumnMin; j++) // left to right
                {
                    table[Row - RowMax, j] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                ColumnMax--;

                for (int j = RowMin - 1; j <= Row - RowMin; j++) //top to bottom
                {
                    table[j, ColumnMax] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                RowMax--;
                ColumnMin++;


            }
            return table;
        }
    }
}
