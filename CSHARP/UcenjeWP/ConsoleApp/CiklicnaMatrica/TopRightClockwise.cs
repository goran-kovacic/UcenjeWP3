using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CiklicnaMatrica
{
    internal class TopRightClockwise
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
                for(int j = RowMin; j <= RowMax; j++)
                {
                    table[j - 1, ColumnMax-1] = Value++;
                }
                if (Value > (Row * Column) + StartingValue - 1)
                {
                    break;
                }
                ColumnMax--;
            }

            return table;
        }
    }
}
