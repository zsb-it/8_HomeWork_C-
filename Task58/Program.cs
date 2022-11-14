// Задача 58: Задайте две матрицы.
// Напишите программу, которая
// будет находить произведение двух матриц.

// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

bool CheckingMatrix(int[,] matrixA, int[,] matrixB)
{
    bool check = true;
    if (matrixA.GetLength(1) != matrixB.GetLength(0))
    {
        check = false;
    }
    return check;
}

void PrintTwoMatrix(int[,] matrixA, int[,] matrixB)
{
    int TotalLengthString = matrixA.GetLength(1) + matrixB.GetLength(1); // сумма количества столбцов двух матриц

    for (int i = 0; i < matrixA.GetLength(0); i++)
    {
        for (int j = 0; j < TotalLengthString; j++)
        {
            if (j < matrixA.GetLength(1) - 1) Console.Write($"{matrixA[i, j],4} ");
            else if (j < matrixA.GetLength(1)) Console.Write($"{matrixA[i, j],4} |");

            else if (i == matrixB.GetLength(0) && j < TotalLengthString - 1) Console.Write(string.Empty);
            else if (i == matrixB.GetLength(0) && j < TotalLengthString) Console.WriteLine(string.Empty);
            else if (i > matrixB.GetLength(0) && j < TotalLengthString - 1) Console.Write(string.Empty);
            else if (i > matrixB.GetLength(0) && j < TotalLengthString) Console.WriteLine(string.Empty);

            else if (j < TotalLengthString - 1) Console.Write($"{matrixB[i, j - matrixA.GetLength(1)],3} ");
            else if (j < TotalLengthString) Console.WriteLine($"{matrixB[i, j - matrixA.GetLength(1)],3}");
        }
    }
}

void PrintCheckingMatrix(int[,] matrixA, int[,] matrixB)
{
    bool checkingMatrix = CheckingMatrix(matrixA, matrixB);
    if (checkingMatrix == true)
    {
        Console.WriteLine("Результат произведения двух матриц:");
        Console.WriteLine(string.Empty);
        int[,] multiplicationMatrix = MultiplicationMatrix(matrixA, matrixB);
        PrintMatrix(multiplicationMatrix);
    }
    else
    {
        Console.WriteLine("Произведение матриц найти нельзя, т. к.");
        Console.WriteLine("количество столбцов матрицы A не совпадает");
        Console.WriteLine("с количеством строк матрицы B.");
    }
}

int[,] MultiplicationMatrix(int[,] matrixA, int[,] matrixB)
{
    int[,] matrix = new int[matrixA.GetLength(0), matrixB.GetLength(1)];    

    for (int i = 0; i < matrixA.GetLength(0); i++)
    {
        for (int j = 0; j < matrixB.GetLength(1); j++)
        {
            for (int m = 0; m < matrixA.GetLength(1); m++)
            {                
                matrix[i, j] = matrix[i, j] + matrixA[i, m] * matrixB[m, j];
            }            
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
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],3} ");
            else Console.WriteLine($"{matrix[i, j],3} ");
        };
    }
}

int[,] matrixOne = CreateMatrixRndInt(5, 6, 1, 10);
int[,] matrixTwo = CreateMatrixRndInt(3, 4, 1, 10);

PrintTwoMatrix(matrixOne, matrixTwo);
Console.WriteLine(string.Empty);
PrintCheckingMatrix(matrixOne, matrixTwo);