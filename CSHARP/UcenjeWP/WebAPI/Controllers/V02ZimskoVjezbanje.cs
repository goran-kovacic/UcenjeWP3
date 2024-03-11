using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data.Common;
using System.IO.Pipelines;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("V02")]
    public class V02ZimskoVjezbanje : ControllerBase
    {
        [HttpGet("01")]
        //Ruta ne prima niti jedan parametar i vraća zbroj prvih 100 brojeva
        public int zad1()
        {
            int sum = 0;
            for(int i = 1; i<=100; i++)
            {
                sum += i;
            }
            return sum;
        }
        [HttpGet("02")]
        //Ruta ne prima niti jedan parametar i vraća niz s svim parnim brojevima od 1 do 57
        public ArrayList zad2()
        {
            ArrayList arrayList = new ArrayList();
            for(int i = 1; i<=57; i++)
            {
                if(i%2==0)
                {
                    arrayList.Add(i);
                }
            }
            return arrayList;
        }
        [HttpGet("03")]
        //Ruta ne prima niti jedan parametar i vraća zbroj
        //svih parnih brojeva od 2 do 18
        public int zad3()
        {
            int sum = 0;
            for (int i = 2; i<=18; i++)
            {
                if( i%2==0)
                {
                    sum += i;
                }
            }
            return sum;
        }
        [HttpGet("04")]
        //Ruta prima jedan parametar koji je cijli broj i vraća
        //zbroj svih brojava od 1 do primljenog broja
        public int zad4(int a)
        {
            int sum = 0;    
            for(int i = 1; i<=a; i++)
            {
                sum += i;
            }
            return sum;
        }
        [HttpGet("05")]
        //Ruta prima dva parametra koji su cijeli brojevi i vraća
        //niz s svim parnim brojevima između primljenih brojeva
        public int[] zad5(int a, int b)
        {

            int manji = 0;
            int veci = 0;
            int index = 0;
            if (a > b)
            {
                veci = a;
                manji = b;
            }
            else if (a < b)
            {
                manji = a;
                veci = b;
            }
            int[] niz = new int[veci / 2];
            for (int i = manji; i <= veci; i++)
            {
                if (i % 2 == 0)
                {
                    niz[index++] = i;

                }
            }
            return niz;
        }
        [HttpGet("06")]
        //Ruta prima dva parametra koji su cijeli brojevi i vraća
        //niz s svim neparnim brojevima između primljenih brojeva
        public int[] zad6(int a, int b)
        {
            int manji = 0;
            int veci = 0;
            int index = 0;
            if (a > b)
            {
                veci = a;
                manji = b;
            }
            else if (a < b)
            {
                manji = a;
                veci = b;
            }
            int[] niz = new int[(veci / 2) + 1];
            for (int i = manji; i <= veci; i++)
            {
                if (i % 2 != 0)
                {
                    niz[index++] = i;

                }
            }
            return niz;
        }
        [HttpGet("07")]
        //Ruta prima dva parametra koji su cijeli brojevi i vraća
        //zbroj svih brojeva između primljenih brojeva
        public int zad7(int a, int b)
        {
            int manji = 0;
            int veci = 0;
            int sum = 0;
            if (a > b)
            {
                veci = a;
                manji = b;
            }
            else if (a < b)
            {
                manji = a;
                veci = b;
            }
            for (int i = manji; i <= veci; i++)
            {
                sum += i;
            }
            return sum;
        }
        [HttpGet("08")]
        //Ruta prima dva parametra koji su cijeli brojevi i vraća
        //zbroj svih brojeva između primljenih brojeva koji su cjelobrojno djeljivi s 3
        public int zad8(int a,int b)
        {
            int manji = 0;
            int veci = 0;
            int sum = 0;
            if (a > b)
            {
                veci = a;
                manji = b;
            }
            else if (a < b)
            {
                manji = a;
                veci = b;
            }
            for (int i = manji; i <= veci; i++)
            {
                if (i % 3 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
        [HttpGet("09")]
        //Ruta prima dva parametra koji su cijeli brojevi i vraća
        //zbroj svih brojeva između primljenih brojeva koji su cjelobrojno djeljivi s 3 i 5
        public int zad9(int a, int b)
        {
            int manji = 0;
            int veci = 0;
            int sum = 0;
            if (a > b)
            {
                veci = a;
                manji = b;
            }
            else if (a < b)
            {
                manji = a;
                veci = b;
            }
            for (int i = manji; i <= veci; i++)
            {
                if (i % 3 == 0 && i % 5 ==0)
                {
                    sum += i;
                }
            }
            return sum;
        }
        [HttpGet("10")]
        //Ruta prima dva parametra koji su cijeli brojevi i vraća
        //dvodimenzionalni niz(matricu) koja sadrži tablicu množenja za dva primljena broja
        public string zad10(int a,int b)
        {
            int[,] niz = new int[a,b];
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i< a; i++)
            {
                for (int j = 0; j< b; j++)
                {
                    niz[i,j] = (i+1)*(j+1);
                    sb.Append(niz[i,j] + "\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        [HttpGet("11")]
        //Ruta prima jedan parametar koji je cijeli broj i vraća
        //niz cijelih brojeva koji su složeni od primljenog broja do broja 1
        public int[] zad11(int a)
        {
            int[] niz = new int[a];
            int index = 0;
            for (int i = a; i>=1; i--)
            {
                niz[index++] = i;
            }
            return niz;
        }
        [HttpGet("12")]
        //Ruta prima cijeli broj i vraća
        //logičku istinu ako je primljeni broj prosti(prim - prime) broj, odnosno logičku laž ako nije
        public bool zad12(int number)
        {
             if (number <= 1)
        {
            return false;
        }

        
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true; 
        }

        [HttpGet("13")]
        //Ruta prima dva parametra koji su cijeli brojevi te vraća
        //dvodimenzionalni niz(matricu) cijelih brojeva koji su složeni prema slici zadatka: Ciklična matrica
        public string zad13(int row, int column)
        {
            StringBuilder sb = new StringBuilder();

            int[,] table = DrawTable(row, column, 1, row, 1, column, 1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    sb.Append($"{table[i, j],4}");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
        private static int[,] DrawTable(int Row,
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
