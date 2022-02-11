//Cocktail Sort
//時間穩定性:O(n^2)  [第1輪向右比較(n-1)次+第2輪向左比較(n-2)次+...+第n輪比較1次 = n(n-1+1)/2 =n^2]
//額外空間複雜度:O(1)  [1個暫存變數temp]



using System;
class Program
{
    public static void Cocktailsort(int[] list)   //Cocktail sort描述
    {
        int n = list.Length;    //n為數列內數值總數
        int temp;   //temp為比較中的暫存變數

        for (int i = 1; i < n; i++)     //外層迴圈:總共進行n-1輪比較
        {
            if (i % 2 != 0)     //內層迴圈1:若i為奇數，則向右兩兩比較，將最大值擠壓至右邊
            {
                for (int j = (i+1)/2; j < n-((i+1)/2)+1; j++)
                {
                    if (list[j] < list[j-1])
                    {
                        temp = list[j];
                        list[j] = list[j-1];
                        list[j - 1] = temp;
                    }
                }
            }

            else        //內層迴圈2:若i為偶數，則向左兩兩比較，將最小值擠壓至右邊
            {
                for (int j = i/2; j < n-(i/2); j++)
                {
                    if (list[n-j-1] < list[n-j-2])
                    {
                        temp = list[n-j-1];
                        list[n-j-1] = list[n-j-2];
                        list[n-j-2] = temp;
                    }
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int[] sequence = new int[100];  //sequence為存放輸入數值的陣列
        int i = 0;
        string temp;    //temp為暫存輸入數值的變數

        Console.Write("請依序輸入數列數值，若數值以輸入完畢請輸入f\n");

        while (true)    //迴圈執行輸入數值和儲存數值
        {
            Console.Write("數列第" + (i + 1) + "個數值:");
            temp = Console.ReadLine();
            if (temp.All(char.IsDigit))     //判斷輸入是否為數字，若是則存取，若不是則中斷迴圈
            {
                sequence[i] = Int32.Parse(temp);
            }
            else
            {
                Array.Resize(ref sequence, (i));
                break;
            }
            i++;
        }

        int[] list = sequence;
        Console.WriteLine("\n\n原始數列");
        for (int n = 0; n < list.Length; n++)
        {
            Console.Write(list[n] + " ");
        }

        Cocktailsort(list);

        Console.WriteLine("\n排序數列");
        for (int n = 0; n < list.Length; n++)
            Console.Write(list[n] + " ");

        Console.ReadLine();
    }
}