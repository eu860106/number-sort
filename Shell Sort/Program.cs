//Shell Sort
//方法:第i輪設置gap = n/(2^i)，將數列排列成matrix(R^2)，每個row有gap個數值，再將matrix中的每個column排序(InsertionSort)，重複前面步驟直到gap=1
//Swap:交換用參數，交換數列中任兩個位置的數值
//InsertionSort:將matrix中的column由小到大插入排序
//ShellSort:設置gap，將數列排列成matrix(R^2)，gap為matrix的column，再將其依序丟入InsertionSort排序



using System;
class Program
{
    public static void Swap(int[] list, int a, int b)
    {
        int temp = list[a];
        list[a] = list[b];
        list[b] = temp;
    }



    public static void InsertionSort(int[] list, int gap, int loop)
    {
        int n = list.Length / gap;
        int temp;

        for (int i = 1; i < n + 1; i++)     //第1層迴圈:設置總比較輪數
        {
            temp = i*gap + loop;        //temp:這輪欲比較的數值位置

            if (temp < list.Length)
            {
                for (int j = 0; j < i; j++)     //第二層迴圈:依序比較
                {
                    if (list[temp] < list[(j * gap) + loop])
                    {
                        for (int k = 0; k < i - j; k++)     //第三層迴圈:若temp比目前比較的位置數值還小，則插入，將整個數列項右移一格
                        {
                            Swap(list, (i - k) * gap + loop, (i - k - 1) * gap + loop);
                        }
                        break;
                    }
                }
            }
        }

        Console.WriteLine("gap=" + gap + " , " + "loop=" + loop);       //將步驟依序顯示，以方便檢驗錯誤
        for (int k = 0; k < list.Length; k++)
        {
            Console.Write(list[k] + " ");
        }
        Console.WriteLine("\n");
    }



    public static void ShellSort(int[] list)
    {
        int n = list.Length;
        int gap = n/2;      //初始的gap設置為數列/2

        while(true)     //若gap>0則重複迴圈
        {
            if (gap > 0)
            {
                for (int i = 0; i < gap; i++)
                {
                    InsertionSort(list, gap, i);
                }
                gap = gap / 2;      //插入排序完成後，更新gap
            }
            
            
            else { break; }
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
        Console.WriteLine("\n\n");

        ShellSort(list);

        Console.WriteLine("\n排序數列");
        for (int n = 0; n < list.Length; n++)
        {
            Console.Write(list[n] + " ");
        }

        Console.ReadLine();
    }
}