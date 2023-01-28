void MoveToRight(int[,] matrix, string[] array)
{
    string coords;
    for (int i = array.Length - 1; i >= 0; i--)
    {
        coords = array[i];
        string[] coordsString = coords.Split(".");
        int ind1 = int.Parse(coordsString[0]);
        int ind2 = int.Parse(coordsString[1]);
        if (ind2 == matrix.GetLength(1) - 2) break;
        int newInd2 = ind2 + 1;
        matrix[ind1, newInd2] = 1;
        matrix[ind1, ind2] = 0;
        array[i] = ind1.ToString() + "." + newInd2.ToString();
    }
}

void MoveToLeft(int[,] matrix, string[] array)
{
    string coords;
    for (int i = 0; i < array.Length; i++)
    {
        coords = array[i];
        string[] coordsString = coords.Split(".");
        int ind1 = int.Parse(coordsString[0]);
        int ind2 = int.Parse(coordsString[1]);
        if (ind2 == 1) break;
        int newInd2 = ind2 - 1;
        matrix[ind1, ind2] = 0;
        matrix[ind1, newInd2] = 1;
        array[i] = ind1.ToString() + "." + newInd2.ToString();
    }
}

void CreateLine(int[,] matrix, string[] array)
{
    int lineLength = 4;
    int middle = matrix.GetLength(1) / 2;
    int colInd = 0;
    for (int i = 0; i < lineLength; i++)
    {
        colInd = (middle - lineLength / 2) + i;
        matrix[1, colInd] = 1;
        array[i] = "1." + colInd.ToString();
    }
}

void ShowMenu()
{
    System.Console.WriteLine("Меню выбора действия:");
    System.Console.WriteLine("1 - переместить влево");
    System.Console.WriteLine("2 - переместить вправо");
    System.Console.WriteLine("3 - повернуть");
    System.Console.WriteLine("4 - закончить ход");
    System.Console.WriteLine("5 - выход из игры");
}

void CreateBorder(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        matrix[0, i] = 1;
        matrix[i, 0] = 1;
        matrix[i, matrix.GetLength(1) - 1] = 1;
        matrix[matrix.GetLength(1) - 1, i] = 1;
    }
}

void PrintMatrix(int[,] matrix)
{
    Console.Clear();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] == 0) System.Console.Write("  ");
            else System.Console.Write("+ ");
        }
        System.Console.WriteLine();
    }
}

int border = 20;
int[,] tetrisBoard = new int[border, border];
string[] figurePosition = new string[4];
CreateBorder(tetrisBoard);
CreateLine(tetrisBoard, figurePosition);
int actionNum = 0;
while (actionNum != 5)
{
    PrintMatrix(tetrisBoard);
    ShowMenu();
    System.Console.Write("Выберите нужный пункт: ");
    actionNum = int.Parse(Console.ReadLine());
    if (actionNum == 1) MoveToLeft(tetrisBoard, figurePosition);
    if (actionNum == 2) MoveToRight(tetrisBoard, figurePosition);

}