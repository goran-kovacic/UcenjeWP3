using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CiklicnaMatrica
{
    internal class TopLeftCounterClockwise
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
                for (int j = RowMin; j <= RowMax; j++) //top to bottom
                {
                    table[j-1, Column-ColumnMax] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                RowMin++;
                ColumnMin++;

                for (int j = ColumnMin; j <= ColumnMax; j++) //left to right
                {
                    table[RowMax-1,j-1] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }



                for (int j = RowMin; j <= RowMax; j++) // bottom to top
                {
                    table[Row-j, ColumnMax-1] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                RowMax--;
                ColumnMax--;

                for (int j = ColumnMin; j <= ColumnMax; j++) // right to left
                {
                    table[RowMin-2, Column-j] = Value++;
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
