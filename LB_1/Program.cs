using System;
using System.Collections;
using System.Collections.Generic;

namespace LB_1
{
    class Program
    {
        static void Main(string[] args)
        {
			long [] test = {45768794579889, 45634567878900, 8763456789054};
			 JIBitArray array = new JIBitArray(test);
			 Console.WriteLine(array.ToString());

			 foreach (long number in array.GetLong())
			 {

				 Console.Write(number + " ");
			 }
			 foreach (int number in array.GetInt())
			 {
				 Console.Write(number + " ");
			 }
			 foreach (short number in array.GetShorts())
			 {
				 Console.Write(number + " ");
			 }
			 foreach (byte number in array.GetBytes())
			 {
				 Console.Write(number + " ");
			 }
			 Console.WriteLine();
			 byte[] qwe = { 1 };
			 JIBitArray w = new JIBitArray(qwe);
			 Console.WriteLine(w.ToString());
			 w = w << 1;
			 Console.WriteLine(w.ToString());
			 w.Set(7,true);
			 Console.WriteLine(w.ToString());
			 w.Insert(2,true);
			 Console.WriteLine(w.ToString());
			 w = w.Not();
			 Console.WriteLine(w.ToString());
			
		}
    }
}
