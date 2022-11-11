// Задача 56: Задайте прямоугольный двумерный массив.
// Напишите программу, которая
// будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)
{
    var matrix = new int[rows, columns];
    var rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],3}, ");
            else Console.WriteLine($"{matrix[i, j],3} ");
        };
    }
}

int NumString(int[,] matrix)
{
    int temp = 0;
    int summ = 0;
    int numberString = 1;
    int i = 0;
    int j = 0;
    
    for (j = 0; j < matrix.GetLength(1); j++)
    {
        summ = summ + matrix[i, j];
    }
    temp = summ;

    for (i = 1; i <= matrix.GetLength(0) - 1; i++)
    {
        summ = 0;
        for (j = 0; j < matrix.GetLength(1); j++)
        {
            summ = summ + matrix[i, j];
        }
        if (summ < temp)
        {
            numberString = i + 1;
            temp = summ;
        }
    }
    return numberString;
}

int[,] createMatrixRndInt = CreateMatrixRndInt(4, 4, 1, 10);
PrintMatrix(createMatrixRndInt);
Console.WriteLine(string.Empty);

int numString = NumString(createMatrixRndInt);
Console.WriteLine($"Наименьшая сумма элементов в {numString}-ой строке");