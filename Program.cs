

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == 0) System.Console.Write(" ");
            else System.Console.Write("+ ");
        }
        System.Console.WriteLine();
    }
}

int border = 3;
int[,] tetrisBoard = new int[border, border];
PrintMatrix(tetrisBoard);