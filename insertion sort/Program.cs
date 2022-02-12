//Insertion Sort
//時間穩定性:O(n^2)  [第1輪比較1次+第2輪比較2次+...+第n輪比較n-1次 = n(n-1+1)/2 = n^2]
//額外空間複雜度:O(1)  [1個暫存變數temp]


using System;
class Program
{
    public static void InsertionSort(int[] list)   
    {
        int n = list.Length;  
        int temp;

        for (int i = 1; i < n; i++)     //第一個迴圈:依序將第i個數值與前面以排序好的數列進行比較
        {
            temp = list[i];     //暫存第i個數值
            for (int j = 0; j < i; j++)     //第二個迴圈:依序比較第i個前面的數值
            {
                if (temp < list[j])
                {
                    for(int k = 0; k < i-j; k++)       //第三個迴圈:若變數比前面的第j個數值還小，則之後的數列皆往右移1位，變數插入當前的第j個數值，中斷這輪的比較
                    {
                        list[i-k] = list[i-k-1];
                    }
                    list[j] = temp;
                    break;
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

        InsertionSort(list);

        Console.WriteLine("\n排序數列");
        for (int n = 0; n < list.Length; n++)
        {
            Console.Write(list[n] + " ");
        }

        Console.ReadLine();
    }
}