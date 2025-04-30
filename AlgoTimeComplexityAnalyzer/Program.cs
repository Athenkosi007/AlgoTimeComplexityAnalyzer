using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;


namespace AlgoTimeComplexityAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Define input sizes to test
            int[] sizes = { 10, 100, 1000, 5000, 10000};

            //5.Main
            foreach (int size in sizes)
            {
                Console.WriteLine($"\n---- Array Size: {size} ----");
                int[] original = GenerateRandomArray(size);

                //Test Bubble Sort
                int[] bubbleArray = (int[])original.Clone();
                var bubbleWatch = Stopwatch.StartNew();
                BubbleSort(bubbleArray);
                bubbleWatch.Stop();
                Console.WriteLine($"Bubble Sort Time: {bubbleWatch.Elapsed.TotalMilliseconds} ms");

                // Test Merge Sort
                int[] mergeArray = (int[])original.Clone();
                var mergeWatch = Stopwatch.StartNew();
                MergeSort(mergeArray, 0, mergeArray.Length - 1);
                mergeWatch.Stop();
                Console.WriteLine($"Merge Sort Time: {mergeWatch.Elapsed.TotalMilliseconds} ms");

                // Test Insertion Sort
                int[] insertionArray = (int[])original.Clone();
                var insertionWatch = Stopwatch.StartNew();
                InsertionSort(insertionArray);
                insertionWatch.Stop();
                Console.WriteLine($"Insertion Sort Time: {insertionWatch.Elapsed.TotalMilliseconds} ms");

                // Test Quick Sort
                int[] quickArray = (int[])original.Clone();
                var quickWatch = Stopwatch.StartNew();
                QuickSort(quickArray, 0, quickArray.Length - 1);
                quickWatch.Stop();
                Console.WriteLine($"Quick Sort Time: {quickWatch.Elapsed.TotalMilliseconds} ms");

            }

        }

        //2. Generate an array of random integers
        static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(0,20000);
            }

            return array;

        }

        //3.Bubble Sort

        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0;i < n; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - 1; j++) 
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }

        //4.Merge Sort

        static void MergeSort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
            
        }
        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            Array.Copy(arr, left, L, 0, n1);
            Array.Copy(arr, mid + 1, R, 0, n2);

            int i = 0, j = 0, k = left;
            while (i < n1 && j< n2) 
            {
                if (L[i] <= R[j])
                    arr[k++] = L[i++];
                else 
                    arr[k++] = R[j++];

            }
            while (i < n1) 
            { 
                arr[k++] = L[i++]; 
            }
            while(j < n2)
            {
                arr[k++] = R[j++];
            }


        }

        //3.Insertion Sort

        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                int key = arr[i];
                int j = i -1;   
                while (j >= 0 && arr[j] > key)
                {
                    arr[j+1] = arr[j];
                    j--;
                    
                }
                arr[j + 1] = key;
            }
        }

        //4.Quick Sort

        static void QuickSort(int[] arr, int low, int high)
        {
            if(low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi -1);
                QuickSort(arr, pi +1,high);

            }
        }
        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    //swap arr[i] and arr[j]
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }

            }

            //swap arr[i+1} and arr[high] (pivot)

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
            
        }



    }

   

   

    
}
