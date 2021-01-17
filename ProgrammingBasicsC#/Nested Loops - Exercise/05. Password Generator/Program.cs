using System;

namespace _05._Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 97; k < 97 + l; k++)
                    {
                        for (int m = 97; m < 97 + l; m++)
                        {
                            for (int q = 1; q <= n; q++)
                            {
                                if (q > i && q > j)
                                {
                                    Console.Write("{0}{1}{2}{3}{4} " ,i,j, Convert.ToChar(k),Convert.ToChar(m),q );
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
