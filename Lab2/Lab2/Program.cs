using System;
using System.Text;

namespace Lab2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var lab2 = new Lab2();

            lab2.Task1();
            lab2.Task2();
            lab2.Task3();
            lab2.Task4();

            Tuple<int, int, int, char> Func5(int[] mas, string str)
            {
                if (mas?.Length == 0) throw new ArgumentException("mas is null or empty");
                if (str?.Length == 0) throw new ArgumentException("str is null or empty");

                var tuple = (min: mas[0], max: mas[0], sum: mas[0], firstLetter: str[0]);

                for (int i = 1; i < mas.Length; i++)
                {
                    var val = mas[i];

                    if (val < tuple.min)
                    {
                        tuple.min = val;
                    }

                    if (val > tuple.max)
                    {
                        tuple.max = val;
                    }

                    tuple.sum += val;
                }

                return tuple.ToTuple();
            }

            var (min, max, sum, firstLetter) = Func5(new[] { 1, -1, 3, 10, 0 }, "Sasha");

            Assert(min == -1);
            Assert(max == 10);
            Assert(sum == 13);
            Assert(firstLetter == 'S');
        }

        private static void Assert(bool successed, string message = "")
        {
            if (successed) return;

            var msg = $"Assert:{message}";

            Console.WriteLine(msg);

            throw new Exception(msg);
        }
    }

    class Lab2
    {
        private static void Assert(bool successed, string message = "")
        {
            if (successed) return;

            var msg = $"Assert:{message}";

            Console.WriteLine(msg);

            throw new Exception(msg);
        }

        public void Task1()
        {
            //a. Define and assign all primitive types

            bool successed = true;

            char someChar = '$';

            byte byteVar = 0x00000010;
            sbyte signedByte = -100;

            short shortVar = 10000;
            ushort unsignedShort = 60000;

            int intVar = int.MinValue;
            uint unsignedInt = uint.MaxValue;

            long longVar = long.MinValue;
            ulong unsignedLong = ulong.MaxValue;

            float floatValue = 0.5f;
            double doubleValue = 0.5;

            decimal decimalValue = 0.5m;

            //b. Do 5 operations explicit and implicit conversion
            longVar = byteVar;
            unsignedInt = unsignedShort;
            decimalValue = intVar;
            shortVar = byteVar;
            doubleValue = floatValue;

            floatValue = (float)doubleValue;
            decimalValue = (decimal)floatValue;
            shortVar = (short)someChar;
            unsignedShort = (ushort)shortVar;
            byteVar = (byte)shortVar;

            //c+d. Do boxing and unboxing. Keyword 'var'
            var someInteger = 100;
            var boxedValue = (object)someInteger;
            var unboxedValue = (int)boxedValue;

            Assert(someInteger == unboxedValue, "variables not same");

            //e. Example of nullable type
            int? age = null;

            if (int.TryParse(Console.ReadLine(), out int newAge))
            {
                age = newAge;
            }

            if (age.HasValue)
            {
                Console.WriteLine($"You are {age.Value} age old");
            }
            else
            {
                Console.WriteLine($"Sorry, but you don't specify age");
            }
        }

        public void Task2()
        {
            //a. define new strings
            var str1 = "abc";
            var str2 = "ABC";

            Assert(str1 != str2);

            //b. create 3 string.
            var thirdString = "aa bb cc";

            var concatenation = str1 + str2;

            Assert(concatenation == "abcABC");

            var copyOfConcatenation = concatenation;

            Assert(copyOfConcatenation == concatenation);

            var subString = concatenation.Substring(1, 2);

            Assert(subString == "bc", "subString not working");

            var splitExample = thirdString.Split(' ');

            Assert(splitExample[1] == "bb");

            var insert = concatenation.Insert(1, "123");

            Assert(insert == "a123bcABC");

            var deleted = concatenation.Remove(1, 2);

            Assert(deleted == "aABC");

            //c. Empty and null strings
            string emptyString = string.Empty;//or = "";
            string nullString = null;

            Assert(emptyString != nullString);
            Assert(emptyString.Length == 0);
            Assert(nullString == null);

            try
            {
                nullString.Insert(0, "not");
                Assert(false, "reference to null");
            }
            catch (Exception e)
            {
                Assert(e != null);
            }

            //d. StringBuilder

            var sb = new StringBuilder("some initial string");
            sb.Remove(0, 5);
            sb.Append('!');

            Assert(sb.ToString() == "initial string!");
        }

        public void Task3()
        {
            //a. matrix
            int matrixSize = 3;
            var matrix = new int[matrixSize, matrixSize];
            var rnd = new Random();

            //assign
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = rnd.Next(0, 10);
                }
            }

            //print
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write('\t');
                }

                Console.Write("\r\n");
            }

            //b.
            var strings = new string[] { "hello", "world", "People", "cat" };

            Console.WriteLine($"Strings count:{strings.Length}");
            Console.WriteLine(string.Join(",", strings));

            Console.WriteLine("Please, enter an index:");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (index < 0 || index > strings.Length)
                {
                    Console.WriteLine("Error: index out of range");
                }
                else
                {
                    Console.WriteLine("Please, enter a new value");
                    strings[index] = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Error: cannot parse index");
            }

            //c+d.
            Console.WriteLine("Work with array. Fill array:");
            const int stArraySize = 3;
            var stArray = new float[stArraySize][];

            for (int i = 0, cols = 2; i < stArraySize; i++)
            {
                stArray[i] = new float[cols];

                for (int j = 0; j < cols; j++)
                {
                    stArray[i][j] = float.Parse(Console.ReadLine());
                }

                cols++;
            }

            Console.WriteLine();

            for (int i = 0, cols = 2; i < stArraySize; i++)
            {
                stArray[i] = new float[cols];

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(stArray[i][j]);
                    Console.Write('\t');
                }

                Console.WriteLine("\r\n");
            }
        }

        public void Task4()
        {
            //a+b. tuple
            var tuple = (age: 18, firstName: "Alex", flag: 'b', lastName: "Sosnovskiy", balance: 1234567890m);

            Console.WriteLine(tuple.ToString());
            Console.WriteLine($"{tuple.firstName}: {tuple.age} age, balance:{tuple.balance}");

            var (age, firstName, flag, lastName, balance) = tuple;

            Console.WriteLine($"{firstName} {lastName}");

            var tuple1 = (1, 2);
            var tuple2 = (1, 2);

            Assert(tuple1.Equals(tuple2));

            tuple2.Item2++;

            Assert(!tuple1.Equals(tuple2));
        }
    }
}