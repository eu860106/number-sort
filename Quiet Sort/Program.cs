//Cocktail Sort
//時間穩定性:O(n^2)  [第1輪向右比較(n-1)次+第2輪向左比較(n-2)次+...+第n輪比較1次 = n(n-1+1)/2 =n^2]
//額外空間複雜度:O(1)  [1個暫存變數temp]



using System;
class Program
{
    public static int Partition(int[] list, int front,int end)
    {
        int n = end - front +1;
        int leftlenght = 0;
        int temp;

        for(int i=0; i<n-1; i++)
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

        if (end != front + leftlenght)
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
            QuietSort(list, front, pivot - 1);
            QuietSort(list, pivot + 1, end);
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