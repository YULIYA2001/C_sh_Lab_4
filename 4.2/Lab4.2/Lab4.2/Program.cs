using System;
using System.Runtime.InteropServices;

namespace Lab4._2
{
    class Program
    {
        static void Main(string[] args)
        {
			int x = 0;
			int y = 0;

			do
			{
				Console.WriteLine("Welcome to simple calculations. Choose action:");
				Console.WriteLine($"1 - x+y\n2 - x-y\n3 - x*y\n4 - x/y\n5 - x?y\n6 - x^y\n7 - |x|\n0 - exit");
				switch (Console.ReadLine())
				{
					case "1":
						{
							Input(ref x);
							Input(ref y);
							Console.WriteLine($"Sum of numbers: {x} + ({y}) = {Addition(x, y)}\n");
							break;
						}
					case "2":
						{
							Input(ref x);
							Input(ref y);
							Console.WriteLine($"Difference of numbers: {x} - ({y}) = {Subtraction(x, y)}\n");
							break;
						}
					case "3":
						{
							Input(ref x);
							Input(ref y);
							Console.WriteLine($"Product of numbers: {x} * ({y}) = {Multiplication(x, y)}\n");							
							break;
						}
					case "4":
						{
							Input(ref x);
							Input(ref y);
							double rez = Division(x, y);
							if (rez == -666.0)
							{
								Console.WriteLine("Error. Division by 0.");
							}
							else
							{
								Console.WriteLine($"Division of numbers: {x} / ({y}) = {rez}\n");
							}
							break;
						}
					case "5":
						{
							Input(ref x);
							Input(ref y);
							int rez = Compare(x, y);
							char zn = '?';
							if (rez == 0)
							{
								zn = '=';
							}
							if (rez == 1)
							{
								zn = '>';
							}
							if (rez == -1)
							{
								zn = '<';
							}
							Console.WriteLine($"Comparison of numbers: {x} {zn} {y}\n");
							break;
						}
					case "6":
						{
							Input(ref x);
							Input(ref y);
							Console.WriteLine($"Exponentiation: ({x}) ^ ({y}) = {Power(x, y)}\n");							
							break;
						}
					case "7":
						{
							Input(ref x);
							Console.WriteLine($"ABS of number: |{x}| = {ABS(x)}\n");
							break;
						}
					case "0":
						{
							return;
						}
					default:
						{
							Console.WriteLine("Wrong input. Try again.");
							break;
						}
				}
			} while (true);
		}

		//проверка на правильный ввод целого числа
		static void Input(ref int x)
		{
			bool stop;
			do
			{
				stop = true;
				Console.WriteLine("Enter an integer: ");
				try
				{
					x = Convert.ToInt32(Console.ReadLine());
				}
				catch (FormatException)
				{
					Console.WriteLine("Wrong input. Try again.");
					stop = false;
				}
			} while (!stop);
		}

		[DllImport("DLL42.dll", CallingConvention = CallingConvention.StdCall)]
		static extern int Addition(int x, int y);

		[DllImport("DLL42.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern int Subtraction(int x, int y);

		[DllImport("DLL42.dll", CallingConvention = CallingConvention.StdCall)]
		static extern int Multiplication(int x, int y);

		[DllImport("DLL42.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern double Division(int x, int y);

		[DllImport("DLL42.dll", CallingConvention = CallingConvention.StdCall)]
		static extern int Compare(int x, int y);

		[DllImport("DLL42.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern double Power(int x, int y);

		[DllImport("DLL42.dll", CallingConvention = CallingConvention.StdCall)]
		static extern int ABS(int x);	
	}
}
