using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CiklicnaMatrica
{
    internal class TopRightCounterClockwise
    {

        internal static int[,] DrawTable(int Row,
                                         int Column,
                                         int RowMin,
                                         int RowMax,
                                         int ColumnMin,
                                         int ColumnMax,
                                         int StartingValue)
        {
            int Value = StartingValue;
            int[,] table = new int[Row, Column];

            for (int i = Value; i <= (Row * Column); i++)
            {
                for (int j = ColumnMin; j <= ColumnMax; j++) //Right to left
                {
                    table[Row - RowMax, Column - j] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                RowMax--;
                ColumnMax--;

                for (int j = RowMin; j <= Row - RowMin; j++) //Top to bottom
                {
                    table[j, ColumnMin - 1] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                ColumnMin++;
                RowMin++;

                for (int j = ColumnMin; j <= ColumnMax + 1; j++) //Left to right
                {
                    table[RowMax, j - 1] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                for (int j = RowMin; j <= RowMax; j++) //Bottom to top
                {
                    table[Row - j, ColumnMax] = Value++;
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
