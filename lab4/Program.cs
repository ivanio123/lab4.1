using System;
using System.IO;

namespace lab4
{
    class Program
    {
            static void Main(string[] args)
            {
                string s1;
                string s2;
                int s1num, s2num, dobutok;
                long sum = 0;
                int counter = 0;
                for (int i = 10; i < 30; i++)
                {
                    string path = $@"{Directory.GetCurrentDirectory()}\files\" + i + ".txt";
                    try
                    {
                        StreamReader f = new StreamReader(path);
                        s1 = f.ReadLine();
                        s1num = Convert.ToInt32(s1);
                        s2 = f.ReadLine();
                        s2num = Convert.ToInt32(s2);
                        checked
                        {
                            dobutok = s1num * s2num;
                        }
                        Console.WriteLine("Product of numbers in the file named " + i + ".txt" + " equals: " + dobutok);
                        sum += dobutok;
                        counter++;
                        f.Close();
                    }
                    catch (FileNotFoundException)
                    {
                        using (StreamWriter no_file = new StreamWriter($@"{Directory.GetCurrentDirectory()}\files\no_file.txt", true, System.Text.Encoding.Default))
                        {
                            no_file.WriteLine(i + ".txt");
                        }
                    }
                    catch (FormatException)
                    {
                        using (StreamWriter bad_data = new StreamWriter($@"{Directory.GetCurrentDirectory()}\files\bad_data.txt", true, System.Text.Encoding.Default))
                        {
                            bad_data.WriteLine(i + ".txt");
                        }
                    }
                    catch (OverflowException)
                    {
                        using (StreamWriter overflow = new StreamWriter($@"{Directory.GetCurrentDirectory()}\files\overflow.txt", true, System.Text.Encoding.Default))
                        {
                            overflow.WriteLine(i + ".txt");
                        }
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Немає доступу до файлу.");
                        break;
                    }
                }
                Console.WriteLine("Коректних файлів: {0}. Арифметичне середнє чисел з коректних файлів: {1}", counter, sum / (double)counter);
                Console.ReadKey();
            }
        }
}
