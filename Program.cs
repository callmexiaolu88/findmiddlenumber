using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace findmiddlenumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var a = new int[] { 1, 2, 3, 4, 2, 2, 3, 1, 4, 5, 7, 8, 6, 9};
            var index = Find(a);
            System.Console.WriteLine(index);
        }

        public static string Find(int[] items)
        {
            Stack<Tuple<int,int>> stack = new Stack<Tuple<int,int>>();
            int maxValue = items.First();
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] >= maxValue)
                {
                    maxValue = items[i];
                }
                if (i == 0)
                {
                    if (items[i + 1] > items[i])
                    {
                        stack.Push(new Tuple<int, int>(i,items[i]));
                    }
                }
                else
                {
                    if (items[i] >= items[i - 1])
                    {
                        if (i != items.Length - 1)
                        {
                            if (items[i] <= items[i + 1])
                            {
                                if (items[i] >= maxValue)
                                {
                                    stack.Push(new Tuple<int, int>(i,items[i]));
                                }
                            }
                            else
                            {
                                while (stack.Count > 0)
                                {
                                    var v = stack.Peek();
                                    if (v.Item2 > items[i + 1])
                                    {
                                        stack.Pop();
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (items[i] >= maxValue)
                            {
                                stack.Push(new Tuple<int, int>(i,items[i]));
                            }
                        }
                    }
                    else
                    {
                        while (stack.Count > 0)
                        {
                            var v = stack.Peek();
                            if (v.Item2 > items[i])
                            {
                                stack.Pop();
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            if (stack.Count==0)
            {
                return "-1";
            }else
            {
              return  stack.Select(i=>$"|index:{i.Item1},\tvalue:{i.Item2}|\n").Aggregate((i,j)=>i+j);
            }
            
        }
    }
}
