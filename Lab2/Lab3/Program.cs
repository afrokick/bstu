using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    partial class Vector
    {
        private readonly List<int> Elements = new List<int>();

        private static int InstanceCount;

        public const string Name = "Vector";

        public int this[int i]
        {
            get => Elements[i];
            set => Elements[i] = value;
        }

        public int Count => Elements.Count;

        public int Count2
        {
            get
            {

                return 0;

            }
        }

        public int Sum => Elements.Sum();

        static Vector()
        {
            Console.WriteLine("Vector is here!");
        }

        private Vector()
        {
            //some init work
            InstanceCount++;
        }

        public Vector(int i) : this()
        {

        }

        public Vector(IEnumerable<int> list) : this()
        {
            Elements.AddRange(list);
        }

        public Vector(IEnumerable<int> list, int capacity = 64) : this()
        {
            Elements = new List<int>(capacity);
            Elements.AddRange(list);
        }

        public Vector AddElement(int val)
        {
            Elements.Add(val);

            return this;
        }

        public Vector RemoveElement(int val)
        {
            Elements.Remove(val);

            return this;
        }

        public Vector Add(int scalar)
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                Elements[i] += scalar;
            }

            return this;
        }

        public Vector Subtract(int scalar)
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                Elements[i] -= scalar;
            }

            return this;
        }

        public void GetMaxElement(out int max)
        {
            max = Elements.Max();
        }

        public void InsertIntoList(ref List<int> list)
        {
            list.AddRange(Elements);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("(");

            sb.Append(string.Join(",", Elements));

            sb.Append(")");

            return sb.ToString();
        }

        public static void PrintInfo()
        {
            Console.WriteLine($"Instance count:{InstanceCount}");
        }

        public override int GetHashCode()
        {
            int hash = Sum;

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var v2 = obj as Vector;

            if (v2 == null) return false;

            return this.GetHashCode() == obj.GetHashCode();
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Assert(new Vector(new[] { 1, 3, 5 }).ToString() == "(1,3,5)");

            Assert(new Vector(new[] { 1, 3, 5 }).Add(2).ToString() == "(3,5,7)");

            var vectors = new Vector[]
            {
                new Vector(new [] {1,3,5}),
                new Vector(new [] {2,4,2}),
                new Vector(new [] {10,30,5}),
            };

            Vector max = vectors[0];

            foreach (var v in vectors)
            {
                bool odd = true;
                bool even = true;

                for (int i = 0; i < v.Count; i++)
                {
                    even &= v[i] % 2 == 0;
                    odd &= v[i] % 2 != 0;
                }

                if (odd)
                {
                    Console.WriteLine($"odd: {v}");
                }

                if (even)
                {
                    Console.WriteLine($"even: {v}");
                }

                if (max.Sum < v.Sum)
                {
                    max = v;
                }
            }

            Console.WriteLine($"max sum: {max}");


            var v1 = new Vector(new[] { 1, 3, 5 });

            int maxVal;
            v1.GetMaxElement(out maxVal);

            Assert(maxVal == 5);

            var list = new List<int>();

            v1.InsertIntoList(ref list);

            Assert(list[1] == 3);

            Vector.PrintInfo();

            Assert(new Vector(new[] { 1, 2, 3 }).Equals(new Vector(new[] { 1, 1, 4 })));


            var anonType = new
            {
                Count = 0,
                Elements = new List<int>(),
            };

            Console.WriteLine(typeof(Vector).ToString());
        }

        private static void Assert(bool successed, string message = "")
        {
            if (successed) return;

            var msg = $"Assert:{message}";

            Console.WriteLine(msg);

            throw new Exception(msg);
        }

    }
}
