using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace balancing
{
    class Program
    {
        public static int caunter = 0;
        public static int rightElements = 0;
        static void Main(string[] args)
        {
            SortedList elemK = new SortedList();
            SortedList right = new SortedList();
            int[] number = new int[50];
            int[] koeff = new int[50];
            string tempstring;
            char plus = '+', equal = '=', star = '*';
            List<List<int>> Mas = new List<List<int>>();
            List<int> row = new List<int>();
            Fourth:
            int j, temp, tempEq = 0, koef = 1, colomns = 0, p = 0;
            bool k;
            Console.Clear();
            Console.WriteLine("Введите уравнение.\n\nВсе формулы должны быть введены в нормальном виде (например CaSO4*0.5H2O) и не должны содержать больше 1 пары круглых и 1 пары квадратных скобок, а так же одного символа «*». Вещества разделяются знаками «+» или «=». Допустимо любое число пробелов.");
            string eq = Console.ReadLine();
            eq = eq.Replace(" ", string.Empty);
            for (int i = 0; i < eq.Length; i++)
            {
                if (eq[i].ToString() == equal.ToString())
                    tempEq++;
            }
            if (tempEq > 1)
            {
                Console.WriteLine("Введено два знака равно. Проверьте уравнение и нажмите Enter для повторого ввода.\n");
                ConsoleKeyInfo clr = Console.ReadKey();
                goto Fourth;
            }

            for (int i = 0; i < eq.Length; i++)
            {
                Third:
                bool y = Int32.TryParse(eq[i].ToString(), out koeff[i]);
                //KOEFF___________________________________________________________________________________________________________
                if (y && i + 1 < eq.Length && caunter == 0)
                {
                    for (j = i + 1; j < eq.Length; j++)
                    {
                        y = Int32.TryParse(eq[j].ToString(), out koeff[j]);
                        if (y == false)
                            goto First;
                    }

                    First:
                    koef = koeff[i];
                    for (int g = i + 1; g < j; g++)
                    {
                        koef = Int32.Parse(koef.ToString() + koeff[g].ToString());
                    }
                    caunter++;
                }

                //ELEMENTS________________________________________________________________________________________________

                else if (System.Char.IsUpper(eq[i]) == true)
                {

                    if (i + 1 < eq.Length)
                    {
                        bool l = Int32.TryParse(eq[i + 1].ToString(), out number[i]);

                        //TWO LETTERS__________________________________________________________________________________________________
                        if (System.Char.IsLower(eq[i + 1]) == true)
                        {
                            Console.WriteLine("Two letters.");
                            tempstring = eq[i].ToString() + eq[i + 1].ToString();
                            if (i + 2 < eq.Length && Int32.TryParse(eq[i + 2].ToString(), out number[i]) == true)
                            {
                                for (j = i + 3; j < eq.Length; j++)
                                {
                                    k = Int32.TryParse(eq[j].ToString(), out number[j - 2]);
                                    if (k == false)
                                        goto Second;
                                }

                                Second:
                                temp = number[i];
                                for (int g = i + 3; g < j; g++)
                                {
                                    temp = Int32.Parse(temp.ToString() + number[g - 2].ToString());
                                }
                                if (elemK.ContainsKey(eq[i].ToString() + eq[i + 1].ToString()) == false)
                                {
                                    p++;
                                    if (caunter > 0)
                                    {
                                        if (rightElements > 0)
                                        {
                                            right.Add(eq[i].ToString() + eq[i + 1].ToString(), p);
                                            Mas[p][colomns] = - koef * temp;
                                        }
                                        else
                                        {
                                            elemK.Add(eq[i].ToString() + eq[i + 1].ToString(), p);
                                            Mas[p][colomns] = koef * temp;
                                        }

                                    }
                                    else if (rightElements > 0)
                                    {
                                        right.Add(eq[i].ToString() + eq[i + 1].ToString(), p);
                                        Mas[p][colomns] = - temp;
                                    }
                                    else
                                    {
                                        elemK.Add(eq[i].ToString() + eq[i + 1].ToString(), p);
                                        Mas[p][colomns] = temp;
                                    }
                                }
                                else
                                {
                                    if (caunter > 0)
                                    {
                                        if (rightElements > 0)
                                        {
                                            Mas[Int32.Parse((right.GetByIndex(right.IndexOfValue(eq[i].ToString() + eq[i + 1].ToString()))).ToString())][colomns] = -koef * temp;
                                        }
                                        else
                                        {
                                            Mas[Int32.Parse((elemK.GetByIndex(elemK.IndexOfValue(eq[i].ToString() + eq[i + 1].ToString()))).ToString())][colomns] = koef * temp;
                                        }

                                    }
                                    else if (rightElements > 0)
                                    {
                                        Mas[Int32.Parse((right.GetByIndex(right.IndexOfValue(eq[i].ToString() + eq[i + 1].ToString()))).ToString())][colomns] = -temp;
                                    }
                                    else
                                    {
                                        Mas[Int32.Parse((elemK.GetByIndex(elemK.IndexOfValue(eq[i].ToString() + eq[i + 1].ToString()))).ToString())][colomns] = temp;
                                    }
                                }
                            }
                            else
                            {
                                if (elemK.ContainsKey(eq[i].ToString() + eq[i + 1].ToString()) == false)
                                {
                                    p++;
                                    if (caunter > 0)
                                    {
                                        if (rightElements > 0)
                                        {
                                            right.Add(eq[i].ToString() + eq[i + 1].ToString(), p);
                                            Mas[p][colomns] = -koef;
                                        }
                                        else
                                        {
                                            elemK.Add(eq[i].ToString() + eq[i + 1].ToString(), p);
                                            Mas[p][colomns] = koef;
                                        }

                                    }
                                    else if (rightElements > 0)
                                    {
                                        right.Add(eq[i].ToString() + eq[i + 1].ToString(), p);
                                        Mas[p][colomns] = -koef;

                                    }
                                    else
                                    {
                                        elemK.Add(eq[i].ToString() + eq[i + 1].ToString(), p);
                                        Mas[p][colomns] = koef;
                                    }
                                }
                                else
                                {
                                    if (caunter > 0)
                                    {
                                        if (rightElements > 0)
                                        {
                                            Mas[Int32.Parse((right.GetByIndex(right.IndexOfValue(eq[i].ToString() + eq[i + 1].ToString()))).ToString())][colomns] = -koef;
                                        }
                                        else
                                        {
                                            Mas[Int32.Parse((elemK.GetByIndex(elemK.IndexOfValue(eq[i].ToString() + eq[i + 1].ToString()))).ToString())][colomns] = koef;
                                        }

                                    }
                                    else if (rightElements > 0)
                                    {
                                        Mas[Int32.Parse((right.GetByIndex(right.IndexOfValue(eq[i].ToString() + eq[i + 1].ToString()))).ToString())][colomns] = -1;
                                    }
                                    else
                                    {
                                        Mas[Int32.Parse((elemK.GetByIndex(elemK.IndexOfValue(eq[i].ToString() + eq[i + 1].ToString()))).ToString())][colomns] = 1;
                                    }
                                }
                            }
                        }

                        //ONE LETTERS AND KOEFF_____________________________________________________________________________________
                        else if (l)
                        {
                            Console.WriteLine("One letter + koeff - {0}.", eq[i]);
                            for (j = i + 2; j < eq.Length; j++)
                            {
                                l = Int32.TryParse(eq[j].ToString(), out number[j - 1]);
                                if (l == false)
                                    goto Second;
                            }

                            Second:
                            temp = number[i];
                            for (int g = i + 2; g < j; g++)
                            {
                                temp = Int32.Parse(temp.ToString() + number[g - 1].ToString());
                            }

                            if((elemK.ContainsKey(eq[i].ToString()) == false))
                            {
                                p++;
                                if (caunter > 0)
                                {
                                    if (rightElements > 0)
                                    {
                                        right.Add(eq[i].ToString(), koef * temp);
                                        Mas[p][colomns] = koef * temp;
                                    }
                                    else
                                    {
                                        elemK.Add(eq[i].ToString(), koef * temp);
                                        Mas[p][colomns] = koef * temp;
                                    }

                                }
                                else if (rightElements > 0)
                                {
                                    right.Add(eq[i].ToString(), temp);
                                    Mas[p][colomns] = koef * temp;
                                }
                                else
                                {
                                    elemK.Add(eq[i].ToString(), temp);
                                    Mas[p][colomns] = koef * temp;
                                }
                            }
                           
                        }

                        //ONE LETTER_________________________________________________________________________________________________
                        else
                        {
                            Console.WriteLine("One letter - {0}.", eq[i]);
                            if (caunter > 0)
                            {
                                if (rightElements > 0)
                                {
                                    Console.WriteLine("add to the right");
                                    right.Add(eq[i].ToString(), koef);
                                }
                                else
                                {
                                    Console.WriteLine("add to the left");
                                    elemK.Add(eq[i].ToString(), koef);
                                }

                            }
                            else if (rightElements > 0)
                                right.Add(eq[i].ToString(), 1);
                            else
                            {

                                Console.WriteLine("add to the left");
                                elemK.Add(eq[i].ToString(), 1);
                            }

                            Console.WriteLine("caunter: {0}, koeff: {1}", caunter, koef);
                        }
                    }
                }

                //SIGNS_________________________________________________________________________________________________
                else if (eq[i].ToString() == plus.ToString() || eq[i].ToString() == star.ToString())
                {
                    colomns++;
                    ++i;
                    caunter--;
                    goto Third;
                }
                else if (eq[i].ToString() == equal.ToString())
                {
                    colomns++;
                    ++rightElements;
                    ++i;
                    caunter--;
                    goto Third;
                }
            }


            for (int u = 0; u < elemK.Count; u++)
            {
                Console.WriteLine("\t{0}:\t{1}", elemK.GetKey(u), elemK.GetByIndex(u));
            }

            for (int u = 0; u < right.Count; u++)
            {
                Console.WriteLine("the right side");
                Console.WriteLine("\t{0}:\t{1}", right.GetKey(u), right.GetByIndex(u));
            }

        }
    }
}
