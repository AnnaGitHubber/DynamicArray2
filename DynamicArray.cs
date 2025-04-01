using System;
using System.Linq;

namespace DynamicArray2
{
    public class DynamicArray
    {
        private double[] array;
        private int size;

        public DynamicArray(int capacity = 10)
        {
            array = new double[capacity];
            size = 0;
        }

        public void Add(double value, int index = -1)
        {
            if (size == array.Length)
                Resize();

            if (index == -1 || index >= size)
            {
                array[size++] = value;
            }
            else
            {
                for (int i = size; i > index; i--)
                    array[i] = array[i - 1];

                array[index] = value;
                size++;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size) throw new IndexOutOfRangeException();

            for (int i = index; i < size - 1; i++)
                array[i] = array[i + 1];

            size--;
        }

        public double Get(int index)
        {
            if (index < 0 || index >= size) throw new IndexOutOfRangeException();
            return array[index];
        }

        public int IndexOf(double value)
        {
            for (int i = 0; i < size; i++)
                if (array[i] == value)
                    return i;
            return -1;
        }

        private void Resize()
        {
            Array.Resize(ref array, array.Length * 2);
        }

        public void Print()
        {
            Console.WriteLine(string.Join(", ", array.Take(size)));
        }

        public double SumPositive()
        {
            return array.Take(size).Where(x => x > 0).Sum();
        }

        public double ProductBetweenExtremes()
        {
            if (size < 2) return 0;

            int maxIndex = 0, minIndex = 0;
            for (int i = 1; i < size; i++)
            {
                if (Math.Abs(array[i]) > Math.Abs(array[maxIndex]))
                    maxIndex = i;
                if (Math.Abs(array[i]) < Math.Abs(array[minIndex]))
                    minIndex = i;
            }

            if (maxIndex > minIndex)
                (maxIndex, minIndex) = (minIndex, maxIndex);

            double product = 1;
            for (int i = maxIndex + 1; i < minIndex; i++)
                product *= array[i];

            return product;
        }

        public (double value, int length) LongestSequence()
        {
            if (size == 0) return (0, 0);

            double longestValue = array[0], currentVal = array[0];
            int longestLength = 1, currentLength = 1;

            for (int i = 1; i < size; i++)
            {
                if (array[i] == currentVal)
                    currentLength++;
                else
                {
                    if (currentLength > longestLength)
                    {
                        longestLength = currentLength;
                        longestValue = currentVal;
                    }
                    currentVal = array[i];
                    currentLength = 1;
                }
            }

            if (currentLength > longestLength)
            {
                longestLength = currentLength;
                longestValue = currentVal;
            }

            return (longestValue, longestLength);
        }
    }
}
