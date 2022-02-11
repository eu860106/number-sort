//Selection Sort
//方法:挑出數列中最小的數值，將其與最前的數值交換，排除最前並重複前面的流程直到排序完畢


using System;
class Program
{
    public static void SelectionSort(int[] list)
    {
        int n = list.Length;

        for (int i = 0; i < n-1; i++)     //外部迴圈:總共進行n-1輪比較
        {
            int temp = i;       //暫存變數:初始設定為最前位

            for (int j = i+1; j < n; j++)       //內部迴圈:將除最前位的所有其他數值與暫存變數比較，若比較小則更改暫存變數
            {
                if (list[j] < list[temp])
                {
                    temp = j;
                }
            }

            if (temp > i)       //將最小數值與此輪最前位的數值交換
            {
                int tempValue = list[i];
                list[i] = list[temp];
                list[temp] = tempValue;
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

        SelectionSort(list);

        Console.WriteLine("\n排序數列");
        for (int n = 0; n < list.Length; n++)
            Console.Write(list[n] + " ");

        Console.ReadLine();
    }
}