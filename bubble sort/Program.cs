//bubble Sort
//時間穩定性:O(n^2)  [第1輪(n-1)+第2輪(n-2)+...+第n輪1 = n(n-1+1)/2 =n^2]
//額外空間複雜度:O(1)  [1個變數temp]



using System;
class Program
{
    public static void bubblesort(int[] list)   //bubble sort描述
    {
        int n = list.Length;    //n為數列內數值總數
        int temp;   //temp為比較中的暫存變數

        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < n - i + 1; j++)     //第1輪總共比較n-1次，第2輪比較n-2次，...，第n輪比較n-i次
            {
                if (list[j] < list[j - 1])      //相鄰兩數比較，若右邊<左邊，則兩數數值互換
                {
                    temp = list[j];
                    list[j] = list[j - 1];
                    list[j - 1] = temp;
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

        bubblesort(list);

        Console.WriteLine("\n排序數列");
        for (int n = 0; n < list.Length; n++)
            Console.Write(list[n] + " ");

        Console.ReadLine();
    }
}