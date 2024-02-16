using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CiklicnaMatrica
{
    internal class BottomRightCounterClockwise
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
                for (int j = RowMin; j <= RowMax; j++) //bottom to top
                {
                    table[Row - j, Column - ColumnMin] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }

                ColumnMin++;

                for (int j = ColumnMin; j <= ColumnMax; j++) // right to left
                {
                    table[Row - RowMax, Column - j] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }

                RowMax--;

                for (int j = RowMin; j <= Row - RowMin; j++) //top to bottom
                {
                    table[j, Column - ColumnMax] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                RowMin++;
                ColumnMax--;

                for (int j = ColumnMin; j <= ColumnMax; j++) // left to right
                {
                    table[RowMax, j - 1] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }

            }

            return table;
        }

    }
}
