//Quiet Sort
//partition:以數列最後一個數為pivot，將比pivot小的移到數列右邊，將比pivot大的移到數列左邊，最後插入兩者的中間並回傳pivot的位置
//QuietSort:快速排序的程式本體

using System;
class Program
{
    public static int Partition(int[] list, int front,int end)
    {
        int n = end - front +1;     //n:要比較的數列長度
        int leftlenght = 0;     //leftlenght:計算左邊數列的長度
        int temp;   //temp:交換用的暫存變數

        for(int i=0; i<n-1; i++)    //迴圈:將數列劃分為兩項
        {
            if(list[front + i] < list[end])
            {
                if (front + i != front + leftlenght)
                {
                    temp = list[front + i];
                    list[front + i] = list[front + leftlenght];
                    list[front + leftlenght] = temp;
                }
                leftlenght++;
            }
        }

        if (end != front + leftlenght)      //將基準插入兩個數列中間
        {
            temp = list[end];
            list[end] = list[front + leftlenght];
            list[front + leftlenght] = temp;
        }
        return front + leftlenght;
    }


    public static void QuietSort(int[] list, int front, int end)
    {
        if(front < end)
        { 
            int pivot = Partition(list, front, end);
            QuietSort(list, front, pivot - 1);      //左邊數列快速排序
            QuietSort(list, pivot + 1, end);        //右邊序列快速排序
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

        QuietSort(list,0, list.Length-1);

        Console.WriteLine("\n排序數列");
        for (int n = 0; n < list.Length; n++)
            Console.Write(list[n] + " ");

        Console.ReadLine();
    }
}