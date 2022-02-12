//Merge Sort
//方法:第一輪2個一組比較，會產生(n+1)/2個排序好的組別；第二輪依前一輪結果，兩組兩組比較，會產生((n+1)/2+1)/2個排序好的組別，不斷持續相似的步驟直到排序完成
//Sort:Merge Sort比較的本體，依輸入的條件，將數列分組比較排序後回傳
//MergeSort:設置compare為一輪的總比較次數，compareN為一輪內每組數值的總數，將其丟到Sort去排序後，變更前述兩個變數，進行下一輪的比較，持續重複至排序完成


using System;
class Program
{
    public static void Sort(int[] list, int compare, int compareN)
    {
        int n = list.Length;
        
        for(int i = 0; i < compare; i++)
        {
            int temp1 = compareN * 2*i;             //temp1:左邊數列的位置
            int temp2 = compareN * (2*i + 1);       //temp2:右邊數列的位置
            int bound1 = temp2;                     //bound1:左邊數列的界線
            int bound2 = temp2 + compareN;          //bound2:右邊數列的界線
            int[] templist = new int[n];            //templist:暫存已經比較完畢數值的數列
            int j = 0;                              //j:暫存數列的位置

            while (true)
            {
                if(temp1 < bound1 && temp2 < bound2 && temp2 < n)       //若temp1和temp2未超過數列且temp2未大於數列長度則比較
                {
                    if (list[temp1] < list[temp2])      //若temp1的值<temp2的值，則將temp1的值存至templist，左邊數列位置+1
                    {
                        templist[j] = list[temp1];
                        temp1++;
                    }

                    else
                    {                                   //若不是，則將temp2的值存至templist，右邊數列位置+1
                        templist[j] = list[temp2];
                        temp2++;
                    }

                    j++;
                }

                else if(temp1 == bound1)        //若temp1已經到達界線，則將temp2剩下未比較的數值依序存入templist，中斷迴圈
                {
                    for (int k = 0; k < bound2 - temp2; k++)
                    {
                        if (temp2 + k < n)
                        {
                            templist[j + k] = list[temp2 + k];
                        }
                    }
                    break;
                }

                else if (temp2 == bound2 || temp2 >= n)     //若temp2已經到達界線或已經超出數列範圍，則將temp1剩下未比較的數值依序存入templist，中斷迴圈
                {
                    for (int k = 0; k < bound1 - temp1; k++)
                    {
                        if (temp1 + k < n)
                        {
                            templist[j + k] = list[temp1 + k];
                        }
                    }
                    break;
                }
            }

            for(int k = 0; k < compareN*2 ; k++)    //將templist儲存的值丟回原本的數列
            {
                if (bound1 - compareN + k < n)
                {
                    list[bound1 - compareN + k] = templist[k];
                }  
            }


            Console.WriteLine("compare=" + compare + " , " + "compareN=" + compareN);       //將步驟依序顯示，以方便檢驗錯誤
            for (int k = 0; k < list.Length; k++)
            {
                Console.Write(list[k] + " ");
            }
            Console.WriteLine("\n");
        }
    }



    public static void MergeSort(int[] list)
    {
        int n = list.Length;            //n為數列內數值總數
        int compare = (n + 1) / 2;      //compare:這一輪的總比較次數
        int compareN = 1;               //compareN:這一輪內每組數值的總數

        while(true)
        {
            Sort(list, compare, compareN);
            compare = (compare + 1) / 2;
            compareN = 2 * compareN;

            if (compareN >= n)
            {
                break;
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
        Console.Write("\n");

        MergeSort(list);

        Console.WriteLine("\n排序數列");
        for (int n = 0; n < list.Length; n++)
            Console.Write(list[n] + " ");

        Console.ReadLine();
    }
}