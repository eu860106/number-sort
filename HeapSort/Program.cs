//Heap Sort
//方法:數列建構二元樹，root數值一定都>child數值，建構完成後最前面的數值一定最大，將之與最後一位交換後忽略，重複前面的流程直到數列排序完成
//Swap:交換用參數，交換數列中任兩個位置的數值
//Heapity:建構二元樹，使其root數值一定都>child數值
//HeapSort:重複建構二元樹的流程


using System;
class Program
{
    public static void Swap(int[] list, int a,int b)
    {
        int temp = list[a];
        list[a] = list[b];
        list[b] = temp;
    }

    public static void Heapity(int[] list,int length)
    {
        int rootNumber = length / 2;    //完整二元樹的root總數為length/2
        int root;
        
        for(int i = 0; i < rootNumber; i++)     //迴圈:由最底下的root依序往前做，確保最後樹的最上層的數值為最大
        {
            root = rootNumber-1-i;
            int leftchild = root*2+1;
            int rightchild = root*2+2;

            if (leftchild<length && list[leftchild] > list[root])       //若child在數列中存在，且child>root，則交換位置
            {
                Swap(list, root, leftchild);
            }

            if (rightchild < length && list[rightchild] > list[root])
            {
                Swap(list, root, rightchild);
            }
        }
    }

    public static void HeapSort(int[] list, int length)
    {
        Heapity(list, length);      //建構二元樹
        Swap(list, 0, length - 1);      //交換數列最前與最後的數值
        if (length - 1 > 1)     //排除數列最後一位，若排除後數列>2，則重複建構的過程
        {
            HeapSort(list, length - 1);
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
        int length = list.Length;

        Console.WriteLine("\n\n原始數列");
        for (int n = 0; n < list.Length; n++)
        {
            Console.Write(list[n] + " ");
        }

        HeapSort(list, length);

        Console.WriteLine("\n排序數列");
        for (int n = 0; n < list.Length; n++)
            Console.Write(list[n] + " ");

        Console.ReadLine();
    }
}