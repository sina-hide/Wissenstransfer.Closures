using System;
using System.ComponentModel;

namespace Closures
{
    [Run(2)]
    public class Incrementer
    {
        public Incrementer()
        {
            Func<int> inc1 = GetIncrementer(1, 2);
            Func<int> inc2 = GetIncrementer(2);
            Console.WriteLine(inc1());
            Console.WriteLine(inc1());
            Console.WriteLine(inc1());
            Console.WriteLine(inc2());
            Console.WriteLine(inc2());
        }

        private static Func<int> GetIncrementer(
            int initial = 0,
            int step = 1)
        {
            int i = initial;
            return () =>
            {
                i += step;
                return i;
            };
        }

        private static Func<int> GetIncrementer2(int i = 0) => () => i++;

        private static Func<int> GetIncrementer3()
        {
            int i = 0;
            return Incrementer3;

            int Incrementer3() => i++;
        }

        private static Func<int> GetOutTest(out int parameter)
        {
            int i = 0;
            parameter = i;
            return () =>
            {
                i++;
                //parameter = i;
                return i;
            };
        }

        private class Data
        {
            public int Number { get; set; }

            public Data(int number)
            {
                Number = number;
            }
        }

        private static Func<int> GetIncrementerModifyingData(Data data)
        {
            int i = 0;
            return () =>
            {
                i++;
                data.Number = i;
                return i;
            };
        }

        private event PropertyChangedEventHandler PropertyChanged;

        private void TestEvent()
        {
            PropertyChanged += (sender, args) => { /* ... */ };

            //PropertyChanged -= ???
        }
    }
}