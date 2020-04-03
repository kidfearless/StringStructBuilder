using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StringStructBuilder
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] sizes = new int[] { 2, 4, 6, 8, 10, 12, 16, 24, 32, 64, 65, 100, 128, 200, 255, 256, 500, 512, 1000, 1024, 2000, 2048, 4000, 4096, 8000, 8192, 10000, 10240 };
			StreamWriter file = new StreamWriter(@"C:\sm_11\include\string_struct.inc");
			file.WriteLine("#if defined __strings_struct_included\n#endinput\n#endif\n#define __strings_struct_included\n");
			file.WriteLine(BuildBaseString());
			for (int i = 0; i < sizes.Length; i++)
			{
				file.WriteLine(BuildString(sizes[i]));
			}


			file.Flush();
			file.Close();
		}

		static string BuildString(int i)
		{
			return $"enum struct string_{i}" +
					"\n{" +
					"\n\t#define STRING_SIZE " + $"{i}" +
					"\n\t#include \"strings_include\"" +
					"\n}";
		}
		static string BuildBaseString()
		{
			return $"enum struct string" +
					"\n{" +
					"\n\t#define STRING_SIZE 2048" +
					"\n\t#include \"strings_include\"" +
					"\n}";
		}
	}
}
