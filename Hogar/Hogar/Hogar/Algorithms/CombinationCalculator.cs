using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogar.Algorithms
{
    public static class CombinationCalculator<T>
    {
        static public List<List<T>> GenerateCombinations(List<T> s, int count)
        {
            return GenerateCombinations(s, 0, count, new List<List<T>>(), new Stack<T>());
        }

        static private List<List<T>> GenerateCombinations(List<T> s, int index, int count, List<List<T>> list, Stack<T> stack)
        {
            for (int i = index; i < s.Count; ++i)
            {
                stack.Push(s[i]);

                if (stack.Count == count)
                {
                    list.Add(stack.ToList());
                }
                else
                {
                    GenerateCombinations(s, i + 1, count, list, stack);
                }

                stack.Pop();
            }

            return list;
        }
    }
}
