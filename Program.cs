// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2


Console.WriteLine("***Задача 54:***");
int[,] array = new int[5, 5];
Random rand = new Random();
Console.WriteLine("Исходный массив: ");
for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        array[i, j] = rand.Next(0, 100);
        Console.Write("{0,4}", array[i, j]);
    }
    Console.WriteLine();
}
void Sort(int[,] array, int rowIndex)
{
    for (int i = 0; i < array.GetLength(1) - 1; i++)
    {
        int max = int.MinValue;
        int indexMax = 0;
        for (int j = i; j < array.GetLength(1); j++)
        {
            if (array[rowIndex, j] > max)
            {
                max = array[rowIndex, j];
                indexMax = j;
            }
        }
        array[rowIndex, indexMax] = array[rowIndex, i];
        array[rowIndex, i] = max;
    }
}
Console.WriteLine("Упорядоченный массив: ");
for (int i = 0; i < 5; i++)
{
    Sort(array, i);
    for (int j = 0; j < array.GetLength(1); j++)
    {
        Console.Write("{0,4}", array[i, j]);
    }
    Console.WriteLine();
}


// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с 
// наименьшей суммой элементов: 1 строка


Console.WriteLine("***Задача 56:***");
int[,] array2 = new int[3, 3];
Console.WriteLine("Исходный массив: ");
for (int i = 0; i < array2.GetLength(0); i++)
{
    for (int j = 0; j < array2.GetLength(1); j++)
    {
        array2[i, j] = new Random().Next(10);
        Console.Write("{0,4}", array2[i, j]);
    }
    Console.WriteLine();
}

int RowsSum(int[,] array2, int rowIndex)
{
    int sum = 0;
    for (int j = 0; j < array2.GetLength(1); j++)
    {
        sum += array2[rowIndex, j];
    }
    return sum;
}
int minSum = int.MaxValue;
int minSumIndex = 0;
for (int i = 0; i < array2.GetLength(0); i++)
{
    int sum = RowsSum(array2, i);
    if (sum < minSum)
    {
        minSumIndex = i;
        minSum = sum;
    }
}
Console.Write("Строка с наименьшей суммой элементов (нумерация начинается с 0): ");
System.Console.WriteLine(minSumIndex);


// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


Console.WriteLine("***Задача 58:***");
Console.Write("Введи кол-во строк 1 массива: ");
int rowsA = int.Parse(Console.ReadLine()!);
Console.Write("Введи кол-во столбцов 1 массива: ");
int columnsA = int.Parse(Console.ReadLine()!);
Console.Write("Введи кол-во строк 2 массива: ");
int rowsB = int.Parse(Console.ReadLine()!);
Console.Write("Введи кол-во столбцов 2 массива: ");
int columnsB = int.Parse(Console.ReadLine()!);
if (columnsA != rowsB)
{
    Console.WriteLine("Такие матрицы умножать нельзя!");
    return;
}
int[,] A = GetArray(rowsA, columnsA, 0, 10);
int[,] B = GetArray(rowsB, columnsB, 0, 10);
PrintArray(A);
Console.WriteLine();
PrintArray(B);
Console.WriteLine();
PrintArray(GetMultiplicationMatrix(A, B));
int[,] GetArray(int m, int n, int min, int max)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(min, max + 1);
        }

    }
    return result;
}
void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]} ");
        }
        Console.WriteLine();
    }
}
int[,] GetMultiplicationMatrix(int[,] arrayA, int[,] arrayB)
{
    int[,] arrayC = new int[arrayA.GetLength(0), arrayB.GetLength(1)];
    for (int i = 0; i < arrayA.GetLength(0); i++)
    {
        for (int j = 0; j < arrayB.GetLength(1); j++)
        {
            for (int g = 0; g < arrayA.GetLength(1); g++)
            {
                arrayC[i, j] += arrayA[i, g] * arrayB[g, j];
            }
        }
    }
    return arrayC;
}


// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


Console.WriteLine("***Задача 60***");
Console.WriteLine($"Введи размер массива m x n x k:");
int m = InputNumbers("Введи m: ");
int n = InputNumbers("Введи n: ");
int k = InputNumbers("Введи k: ");
Console.WriteLine("");
int[,,] array3D = new int[m, n, k];
CreateArray(array3D);
printArray(array3D);
int InputNumbers(string input)
{
    Console.Write(input);
    int output = Convert.ToInt32(Console.ReadLine());
    return output;
}
void printArray(int[,,] array3D)
{
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            Console.Write($"m({i}) n({j}) ");
            for (int g = 0; g < array3D.GetLength(2); g++)
            {
                Console.Write($"k({g})={array3D[i, j, g]}; ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
void CreateArray(int[,,] array3D)
{
    int[] temp = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];
    int number;
    for (int i = 0; i < temp.GetLength(0); i++)
    {
        temp[i] = new Random().Next(10, 100);
        number = temp[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (temp[i] == temp[j])
                {
                    temp[i] = new Random().Next(10, 100);
                    j = 0;
                    number = temp[i];
                }
                number = temp[i];
            }
        }
    }
    int count = 0;
    for (int m = 0; m < array3D.GetLength(0); m++)
    {
        for (int n = 0; n < array3D.GetLength(1); n++)
        {
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                array3D[m, n, k] = temp[count];
                count++;
            }
        }
    }
}


// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07



Console.WriteLine($"***Задача 62***");
void FillRow(int[,] array3, int row, int startIndex, int finishIndex, ref int curentNumber)
{
    bool direction = startIndex < finishIndex;
    for (int i = startIndex;
        direction ? i <= finishIndex : i >= finishIndex;
        i = direction ? i + 1 : i - 1)
    {
        array3[row, i] = curentNumber++;
    }
}
void FillColumn(int[,] array3, int column, int startIndex, int finishIndex, ref int curentNumber)
{
    bool direction = startIndex < finishIndex;
    for (int i = startIndex;
        direction ? i <= finishIndex : i >= finishIndex;
        i = direction ? i + 1 : i - 1)
    {
        array3[i, column] = curentNumber++;
    }
}
void PrintArray2(int[,] array3)
{
    for (int i = 0; i < array3.GetLength(0); i++)
    {
        for (int j = 0; j < array3.GetLength(1); j++)
        {
            Console.Write("{0,4}", array3[i, j]);
        }
        Console.WriteLine();
    }
}
int[,] array3 = new int[4, 4];
int curentNumber = 0;
FillRow(array3, 0, 0, 3, ref curentNumber);
FillColumn(array3, 3, 1, 3, ref curentNumber);
FillRow(array3, 3, 2, 0, ref curentNumber);
FillColumn(array3, 0, 2, 1, ref curentNumber);
FillRow(array3, 1, 1, 2, ref curentNumber);
FillRow(array3, 2, 2, 1, ref curentNumber);
PrintArray2(array3);
