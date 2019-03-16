using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace QuickSorter
{
    class Program
    {
        public static void QuickSort(int[] array, int start, int end)
        {
            if (end == start) return;
            var pivot = array[end];
            var storeIndex = start;
            for (int i = start; i <= end - 1; i++)
                if (array[i] <= pivot)
                {
                    var t = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = t;
                    storeIndex++;
                }

            var n = array[storeIndex];
            array[storeIndex] = array[end];
            array[end] = n;
            if (storeIndex > start) QuickSort(array, start, storeIndex - 1);
            if (storeIndex < end) QuickSort(array, storeIndex + 1, end);
        }

        public static void QuickSort(int[] array)
        {
            if (array.Length > 0)
                QuickSort(array, 0, array.Length - 1);
        }

        public static void GenerateArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next();
        }

        public static void Main()
        {

        }
    }

    [TestFixture]
    class Test
    {
        [Test]
        public static void Test1()
        {
            var array = new int[3];
            Program.GenerateArray(array);
            Program.QuickSort(array);
            bool flag = true;
            if (!(array is null))
                for (int i = 0; i < array.Length - 1; i++)
                    if (array[i + 1] < array[i])
                    {
                        flag = false;
                        break;
                    }
            Assert.IsTrue(flag);
        }

        [Test]
        public static void Test2()
        {
            var array = new int[100];
            Program.GenerateArray(array);
            Program.QuickSort(array);
            bool flag = true;
            if (!(array is null))
                for (int i = 0; i < array.Length - 1; i++)
                    if (array[i + 1] < array[i])
                    {
                        flag = false;
                        break;
                    }
            Assert.IsTrue(flag);
        }

        [Test]
        public static void Test3()
        {
            var array = new int[1000];
            Program.GenerateArray(array);
            Program.QuickSort(array);
            bool flag = true;
            Random rnd = new Random();
            for (int num = 0; num < 10; num++)
            {
                int i = rnd.Next(0, array.Length);
                int j = rnd.Next(0, array.Length);

                if (i != j)
                    if (i > j && array[j] > array[i])
                    {
                        flag = false;
                        break;
                    }
                    else if (j > i && array[i] > array[j])
                    {
                        flag = false;
                        break;
                    }
                    else continue;
            }
            Assert.IsTrue(flag);
        }

        [Test]
        public static void Test4()
        {
            var array = new int[0];
            Program.GenerateArray(array);
            Program.QuickSort(array);
            bool flag = true;
            if (!(array is null))
                for (int i = 0; i < array.Length - 1; i++)
                    if (array[i + 1] < array[i])
                    {
                        flag = false;
                        break;
                    }
            Assert.IsTrue(flag);
        }

        [Test]
        public static void Test5()
        {
            var array = new int[150000000];
            Program.GenerateArray(array);
            Program.QuickSort(array);
            bool flag = true;
            if (!(array is null))
                for (int i = 0; i < array.Length - 1; i++)
                    if (array[i + 1] < array[i])
                    {
                        flag = false;
                        break;
                    }
            Assert.IsTrue(flag);
        }
    }
}
