﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CiklicnaMatrica
{
    internal class BottomLeftCounterClockwise
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
                for (int j = ColumnMin; j <= ColumnMax; j++) //left to right
                {
                    table[Row-RowMin, j-1] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                RowMin++;
                

                for (int j = RowMin; j <= RowMax; j++) //bottom to top
                {
                    table[Row-j, Column-ColumnMin] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                ColumnMin++;


                for (int j = ColumnMin; j <= ColumnMax; j++) // left to right
                {
                    table[RowMin-2, Column-j] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                RowMax--;
                ColumnMax--;

                for (int j = RowMin; j <= RowMax; j++) // top to bottom
                {
                    table[j-1, ColumnMin-2] = Value++;
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
