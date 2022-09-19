using System;
using System.Linq;

namespace start
{
    public class Closure
    {
        private readonly Action _other;
        private readonly int _threeHundred;
        public Closure(int threeHundred, Action other)
        {
            _other = other;
            _threeHundred = threeHundred;
        }

        public void Run()
        {
            _other();
            System.Console.WriteLine(_threeHundred);
        }
    }
}