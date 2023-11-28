using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Conversie_b1_b2
{

    internal class Program
    {
        private static int Convert_parte_intreaga1_To_Decimal(string number, int fromBase)
        {
            string digits = "0123456789ABCDEF";

            int result = 0;

            int len = number.Length;
            foreach (char c in number)
            {
                int index = digits.IndexOf(c, 0, fromBase);
                if (index == -1)
                {
                    throw new ArgumentException($"Numarul {number} invalid in baza {fromBase}");
                }

                result = result + index * (int)Math.Pow(fromBase, len - 1);
                len--;
            }
            return result;
        }
        private static void Convert_parte_intreaga_To_b2(long n, int b2)
        {
            if (n != 0)
            {
                Convert_parte_intreaga_To_b2(n / b2, b2);
                if (n % b2 > 9)
                    switch (n % b2)
                    {
                        case 10:
                            Console.Write("A");
                            break;

                        case 11:
                            Console.Write("B");
                            break;

                        case 12:
                            Console.Write("C");
                            break;

                        case 13:
                            Console.Write("D");
                            break;

                        case 14:
                            Console.Write("E");
                            break;

                        case 15:
                            Console.Write("F");
                            break;
                    }

                else
                    Console.Write(n % b2);
            }

        }
        private static double Convert_parte_zecimala1_To_Decimal(string number, int fromBase)
        {

            string digits = "0123456789ABCDEF";

            double result = 0;

            int len = 0;
            foreach (char c in number)
            {
                int index = digits.IndexOf(c, 0, fromBase);
                if (index == -1)
                {
                    throw new ArgumentException($"Numarul {number} invalid in baza {fromBase}");
                }

                result = result + index * Math.Pow(fromBase, len - 1);

                len--;
            }
            return result;
        }
        private static void Convert_parte_zecimala_To_b2(double n, int b2)
        {
            List<decimal> nr = new List<decimal>();

            decimal d = new decimal(n);

            while ((double)d - Math.Truncate((double)d) * 1.0 > 0.0)
            {

                if (!nr.Contains(d))
                {
                    nr.Add(d);
                    d *= b2;
                    if ((int)Math.Truncate((double)d) > 9)
                    {
                        switch ((int)Math.Truncate((double)d))
                        {
                            case 10:
                                Console.Write("A");
                                break;

                            case 11:
                                Console.Write("B");
                                break;

                            case 12:
                                Console.Write("C");
                                break;

                            case 13:
                                Console.Write("D");
                                break;

                            case 14:
                                Console.Write("E");
                                break;

                            case 15:
                                Console.Write("F");
                                break;
                        }
                    }
                    else
                        Console.Write(Math.Truncate((double)d));
                    d = d % 1;

                }
                else///perioada
                {
                    Console.Write("    OBSERVATIE:");
                    Console.WriteLine($"parte intreaga din {(d * b2) % 1}, ( Math.Truncate((double)(d*b2)%1)) ) reprezinta inceput de perioada");
                    break;
                }
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Scrieti un numar convertit intr-o baza");
            string x = Console.ReadLine(), parte_intreaga1 = " ", parte_zecimala1 = " ";
            int b1, b2;
            Console.WriteLine("b1:");
            b1 = int.Parse(Console.ReadLine());
            Console.WriteLine("si o baza b2, ce va reprezenta rezultatul final:");
            b2 = int.Parse(Console.ReadLine());
            bool ok = true;

            if (!(b1 > 1 && b1 < 17) || !(b2 > 1 && b2 < 17))
            {
                Console.WriteLine("Date gresite");
                ok = false;
            }
            else
            {

                int sep = 0;
                foreach (char c in x)
                {
                    if (c == '.')
                        sep++;
                    if (sep > 1)
                    {
                        Console.WriteLine("Date gresite");
                        ok = false;
                        break;
                    }
                }
            }
            if (ok)
            {
                string digits = "0123456789ABCDEF";

                if (x.Contains("."))
                {
                    char[] spearator = { '.' };

                    String[] strlist = x.Split(spearator,
                           2, StringSplitOptions.None);

                    foreach (String s in strlist)
                    {

                        parte_intreaga1 = s;
                        break;

                    }
                    foreach (String s in strlist)
                    {

                        parte_zecimala1 = s;

                    }

                    foreach (char c in parte_intreaga1)
                    {
                        int index = digits.IndexOf(c, 0, b1);
                        if (index == -1)
                        {
                            Console.WriteLine("Date gresite");
                            ok = false;
                            break;
                        }

                    }
                    if (ok)
                        foreach (char c in parte_zecimala1)
                        {
                            int index = digits.IndexOf(c, 0, b1);
                            if (index == -1)
                            {
                                Console.WriteLine("Date gresite");
                                ok = false;
                                break;
                            }

                        }
                }

                else
                {
                    parte_intreaga1 = x;

                    foreach (char c in parte_intreaga1)
                    {
                        int index = digits.IndexOf(c, 0, b1);
                        if (index == -1)
                        {
                            Console.WriteLine("Date gresite");
                            ok = false;
                            break;
                        }

                    }
                }
                if (ok)
                {

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"NUMARUL {x} CONVERTIT DIN BAZA {b1} IN BAZA {b2} ESTE: ");
                    Console.WriteLine();
                    long parte_intreaga = Convert_parte_intreaga1_To_Decimal(parte_intreaga1, b1);
                    Convert_parte_intreaga_To_b2(parte_intreaga, b2);

                    if (x.Contains("."))
                    {
                        Console.Write(".");

                        double parte_zecimala = Convert_parte_zecimala1_To_Decimal(parte_zecimala1, b1);
                        Convert_parte_zecimala_To_b2(parte_zecimala, b2);

                    }
                }
            }

            Console.ReadKey();
        }

    }
}
