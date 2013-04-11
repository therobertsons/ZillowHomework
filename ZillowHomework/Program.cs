using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZillowHomework
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("generate Tri tree for data 5, 4, 9, 5, 7, 2, 2");
            int[] values = new int[7]{5, 4, 9, 5, 7, 2, 2};
            
            TriTree tree = new TriTree();

            tree.Populate(values, 7);
            Console.WriteLine("hit any key");
            Console.ReadKey();

            Console.WriteLine("Generate Tri tree for a large random data set");
            List<int> data = CreateTestData();
            TriTree tree2 = new TriTree();
            tree2.Populate(data);
            Console.WriteLine("hit any key");
            Console.ReadKey();

            Console.WriteLine("Please Enter a value to convert into a long");
            string value = Console.ReadLine();
            long longvalue = StringToLong.ConvertString(value);
            long longvaluebuiltin = 0;
            Console.WriteLine("The long value via built in C# is:: ");
            long.TryParse(value,out longvaluebuiltin);
            Console.Write(longvaluebuiltin.ToString());
            Console.WriteLine();
            Console.WriteLine("The long value is:: ");
            Console.Write(longvalue.ToString());
            Console.WriteLine();
            Console.WriteLine("hit any key");
            Console.ReadKey();
        }

        static List<int> CreateTestData()
        {
            List<int> data = new List<int>();
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                data.Add(r.Next());
            }
            return data;
        }

    }

    public class TriTree
    {

        public void Populate(List<int> a)
        {
        TriTreeNode root = new TriTreeNode(a[0]);

        for (int i = 1; i < a.Count; i++)
        {
            Insert(root, a[i]);
        }

        Print(root);

        }

        public void Populate(int[] a, int n)
        {
        TriTreeNode root = new TriTreeNode(a[0]);

        for (int i = 1; i < n; i++)
        {
            Insert(root, a[i]);
        }

        Print(root);

        }

        public void Insert(TriTreeNode node, int value)
        {
            if (value < node.value)
            {
                if (node.left != null)
                {
                    Insert(node.left, value);
                }
                else
                {
                    node.left = new TriTreeNode(value);
                }
            }
            else if (value > node.value)
            {
                if (node.right != null)
                {
                    Insert(node.right, value);
                }
                else
                {
                    node.right = new TriTreeNode(value);
                }
            }
            else
            {
                if (node.middle != null)
                {
                    Insert(node.middle, value);
                }
                else
                {
                    node.middle = new TriTreeNode(value);
                }
            }
        }

        public TriTreeNode Delete(TriTreeNode node, int value)
        {
            if (node.value > value)
            {
                node.left = Delete(node.left, value);
            }
            else if(node.value < value)
            {
                node.right = Delete(node.right, value);
            }
            else
            {
                if (node.middle != null)
                {
                    node.middle = Delete(node.middle, value);
                }
                else if(node.right != null)
                {
                    int min = minimum(node.right).value;
                    node.value = min;
                    node.right = Delete(node.right, min);
                }
                else
                {
                    node = node.left;
                }
            }
            return node;
        }

        protected TriTreeNode minimum(TriTreeNode node)
        {
            if(node != null)
            {
                while (node.left != null)
                {
                    return minimum(node.left);
                }
            }

            return node;
        }

        public void Print(TriTreeNode root)
        {
            if (root != null)
            {
                Console.WriteLine("TriTreeNode value : " + root.value);
                Print(root.left);
                Print(root.middle);
                Print(root.right);
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class TriTreeNode
    {
      public TriTreeNode left;
      public TriTreeNode middle;
      public TriTreeNode right;

      public int value;

      public TriTreeNode(int value)
      {
          this.value = value;
      }

    }

    public class StringToLong
    {
        public static long ConvertString(string str)
        {
            int len = str.Length;
            bool blNegative = false;
            int index = blNegative ? 1 : 0;
            if (str[0].Equals("-"))
            {
                blNegative = true;
            }
            long lnResult = 0;
            do
            {
                lnResult *= 10;
                int i = str[index] - 48; //ASCII zero
                if (i < 0 | i > 9)
                    throw new FormatException();
                lnResult += i;
                index++;
            } while (len > index);
            return blNegative ? -lnResult : lnResult;
        }
    }
}
