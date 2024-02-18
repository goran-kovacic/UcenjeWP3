using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CiklicnaMatrica
{
    internal class BottomLeftClockwise
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
                for (int j = RowMin; j <= RowMax; j++) //bottom to top
                {
                    table[Row-j, Column-ColumnMax] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                RowMin++;
                ColumnMin++;

                for (int j = ColumnMin; j <= ColumnMax; j++) //left to right
                {
                    table[Row-RowMax, j-1] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }



                for (int j = RowMin; j <= RowMax; j++) // top to botttom
                {
                    table[j-1, ColumnMax-1] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                RowMax--;
                ColumnMax--;

                for (int j = ColumnMin; j <= ColumnMax; j++) // right to left
                {
                    table[RowMax, Column-j] = Value++;
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
