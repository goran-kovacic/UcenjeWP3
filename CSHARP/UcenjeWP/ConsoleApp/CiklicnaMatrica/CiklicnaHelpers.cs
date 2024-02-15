internal static class CiklicnaHelpers
{

    internal static int[,] TableClockwise(int Value,
                                         int Row,
                                         int Column,
                                         int RowMin,
                                         int RowMax,
                                         int ColumnMin,
                                         int ColumnMax)
    {
        int[,] table = new int[Row, Column];

        for (int i = Value; i <= (Row * Column); i++)
        {
            for (int j = ColumnMin; j <= ColumnMax; j++) // right to left
            {
                table[Row - RowMin, Column - j] = Value++;
            }
            if (Value > (Row * Column) + Value - 1)
            {
                break;
            }

            RowMin++;

            for (int j = RowMin; j <= RowMax; j++) //bottom to top
            {
                table[Row - j, Column - ColumnMax] = Value++;
            }
            if (Value > (Row * Column) + Value - 1)
            {
                break;
            }

            for (int j = ColumnMin; j <= Column - ColumnMin; j++) // left to right
            {
                table[Row - RowMax, j] = Value++;
            }
            if (Value > (Row * Column) + Value - 1)
            {
                break;
            }
            ColumnMax--;

            for (int j = RowMin - 1; j <= Row - RowMin; j++) //top to bottom
            {
                table[j, ColumnMax] = Value++;
            }
            if (Value > (Row * Column) + Value - 1)
            {
                break;
            }
            RowMax--;
            ColumnMin++;


        }
        return table;
    }
    internal static int[,] TableCounterClockwise(int Value,
       int Row, int Column, int RowMin, int RowMax, int ColumnMin, int ColumnMax)
    {
        int[,] table = new int[Row, Column];

        for (int i = Value; i <= (Row * Column); i++)
        {
            for (int j = RowMin; j <= RowMax; j++) //bottom to top
            {
                table[Row - j, Column - ColumnMin] = Value++;
            }
            if (Value > (Row * Column) + Value - 1)
            {
                break;
            }

            ColumnMin++;

            for (int j = ColumnMin; j <= ColumnMax; j++) // right to left
            {
                table[Row - RowMax, Column - j] = Value++;
            }
            if (Value > (Row * Column) + Value - 1)
            {
                break;
            }

            RowMax--;

            for (int j = RowMin; j <= Row - RowMin; j++) //top to bottom
            {
                table[j, Column-ColumnMax] = Value++;
            }
            if (Value > (Row * Column) + Value - 1)
            {
                break;
            }
            RowMin++;
            ColumnMax--;

            for(int j= ColumnMin; j <= ColumnMax; j++) // left to right
            {
                table[RowMax, j-1] = Value++;
            }
            if(Value > (Row * Column) + Value - 1)
            {
                break;
            }

        }

            return table;
    }
}

   