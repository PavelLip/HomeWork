using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskNumberOne();
            TaskNumberTwo();
        }

        //Задание №1                                                                                                    
        static void TaskNumberOne()
        {
            Console.WriteLine("Напишите нужную команду ( список всех доступных команд - 'ls' ");
            while (true)
            {
                menu();
            }
        }
        static void menu()
        {
            switch (Console.ReadLine())
            {
                case "ls":
                    Console.WriteLine("ls - показать все доступные команды");
                    Console.WriteLine("AddProc - добавить процессы");
                    Console.WriteLine("ShowProc - показать все процессы notepad");
                    Console.WriteLine("ShowProcName - показать все процессы по имени");
                    Console.WriteLine("ShowAllProc - показать все процессы");
                    Console.WriteLine("KillProcName - закрыть все процессы по имени");
                    Console.WriteLine("KillProcId - закрыть процесс по id");
                    Console.WriteLine("Exit - выйти из программы");
                    return;

                case "AddProc":
                    Console.Write("Введите кол-во процессов блокнота которые хотите запустить: ");
                    AddProcess(Convert.ToInt32(Console.ReadLine()));
                    return;
                case "ShowProc":
                    ShowProcess("notepad");
                    return;
                case "ShowProcName":

                        Console.Write("Введите название процесса который хотите запустить: ");
                        ShowProcess(Console.ReadLine());
                        return;

                case "ShowAllProc":
                    ShowAllProcess();
                    return;

                case "KillProcName":
                    Console.WriteLine("Введите имя процесса");
                    Process[] KillProcName = Process.GetProcessesByName(Console.ReadLine());
                    foreach (Process worker in KillProcName)
                    {
                        worker.Kill();
                        worker.WaitForExit();
                        worker.Dispose();
                    }
                    return;
                case "KillProcId":
                    Console.WriteLine("Введите ID процесса");
                    int idProc = Convert.ToInt32(Console.ReadLine());
                    Process KillProcId = Process.GetProcessById(idProc);
                    KillProcId.Kill();
                    return;
                case "Exit":
                    Process process = Process.GetCurrentProcess();
                    process.Kill();
                    return;
                default:
                    Console.WriteLine("Введена неправильная команда");
                    return;


            }
        }
        static void ShowAllProcess()
        {
            Process[] procList = Process.GetProcesses();
            WriteProcessConsoleData("ID process", "Name process", "Memory size (bytes)");
            string id;
            string name;
            string memorySize;
            for (int i = 0; i < procList.Length; i++)
            {
                id = Convert.ToString(procList[i].Id);
                name = procList[i].ProcessName;
                memorySize = Convert.ToString(procList[i].WorkingSet64);
                WriteProcessConsoleData(id, name, memorySize);
            }
        }
        static void ShowProcess(string nameProc)
        {
            Process[] procList = Process.GetProcessesByName(nameProc);
            WriteProcessConsoleData("ID process", "Name process", "Memory size (bytes)");

            string id;
            string name;
            string memorySize;
            for (int i = 0; i < procList.Length; i++)
            {
                id = Convert.ToString(procList[i].Id);
                name = procList[i].ProcessName;
                memorySize = Convert.ToString(procList[i].WorkingSet64);
                WriteProcessConsoleData(id, name, memorySize);
            }
        }
        static void WriteProcessConsoleData(string firstColumn, string secondColumn, string third)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(firstColumn);
            Console.SetCursorPosition(20, Console.CursorTop);
            Console.Write(secondColumn);
            Console.SetCursorPosition(60, Console.CursorTop);
            Console.WriteLine(third);
        }
        static void AddProcess(int Count)
        {
            string[,] ArrayProcess = new string[Count, 3];
            for (int i = 1; i <= Count; i++)
            {
                Process notePad = Process.Start("notepad.exe");
                ArrayProcess[i - 1, 0] = Convert.ToString(notePad.Id);
                ArrayProcess[i - 1, 1] = notePad.ProcessName;
                ArrayProcess[i - 1, 2] = Convert.ToString(notePad.WorkingSet64);
            }
        }

        //Задание №2
        static void TaskNumberTwo()
        {
            int countLineArray = 4;
            int countColumnArray = 4;
            string[,] Array = { { "11", "12", "13", "14" }, { "21", "22", "23", "24" }, { "31", "32", "33", "34" }, { "41", "42", "43", "44" } };

            try
            {
                ComplianceCheck(Array, countLineArray, countColumnArray);
                int summ = ConvertArray(Array, countLineArray, countColumnArray);
                Console.WriteLine($"Сумма всех элементов массива: {summ}");
                Console.ReadLine();
            }
            catch (MyArraySizeException ex) when (ex.Code == ErrorCode.LineArrayLess)
            {
                Console.WriteLine("В массиве меньше строк чем должно быть");
                Console.ReadLine();
            }
            catch (MyArraySizeException ex) when (ex.Code == ErrorCode.LineArrayMore)
            {
                Console.WriteLine("В массиве больше строк чем должно быть");
                Console.ReadLine();
            }
            catch (MyArraySizeException ex) when (ex.Code == ErrorCode.ColumnsArrayLess)
            {
                Console.WriteLine("В массиве меньше столбцов чем должно быть");
                Console.ReadLine();
            }
            catch (MyArraySizeException ex) when (ex.Code == ErrorCode.ColumnsArrayMore)
            {
                Console.WriteLine("В массиве больше столбцов чем должно быть");
                Console.ReadLine();
            }
            catch (MyArrayDataException)
            {
                Console.WriteLine($"В массиве присутствует посторонний символ в позиции x-{MyArrayDataException.LineArray} y-{MyArrayDataException.ColumnArray}");
                Console.ReadLine();
            }
        }
        static void ComplianceCheck(string[,] Array, int LineArray, int ColumnsArray)
        {
            //Почему мы ошибки записываем каждый в свой if а не продолжаем первый else if ?
            if (Array.GetLength(0) < LineArray)
            {
                throw new MyArraySizeException(ErrorCode.LineArrayLess);
            }
            if (Array.GetLength(0) > LineArray)
            {
                throw new MyArraySizeException(ErrorCode.LineArrayMore);
            }
            if (Array.GetLength(1) < ColumnsArray)
            {
                throw new MyArraySizeException(ErrorCode.ColumnsArrayLess);
            }
            if (Array.GetLength(1) > ColumnsArray)
            {
                throw new MyArraySizeException(ErrorCode.ColumnsArrayMore);
            }
        }
        static int ConvertArray(string[,] Array, int LineArray, int ColumnsArray)
        {
            int summ = 0;
            int[,] arrayNumber = new int[LineArray, ColumnsArray];

            for (int i = 0; i < LineArray; i++)
            {
                for (int j = 0; j < ColumnsArray; j++)
                {
                    if ((Regex.Match(Array[i, j], @"\d+").Value).Length == Array[i, j].Length)
                    // не совсем пониял эту строчку когда нашел ее в гуугле, что означает выражение "@"\d+" ?
                    {
                        arrayNumber[i, j] = Convert.ToInt32(Array[i, j]);
                        summ += arrayNumber[i, j];
                    }
                    else
                        throw new MyArrayDataException(j, i);
                }
            }
            return summ;
        }
    }
}
