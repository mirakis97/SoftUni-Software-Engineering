
public class Program
{
    public static void Main()
    {
        var rows = int.Parse(Console.ReadLine());
        var cols = int.Parse(Console.ReadLine());

        var lab = new char[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            var line = Console.ReadLine();
            for (int c = 0; c < line.Length; c++)
            {
                lab[r, c] = line[c];
            }
        }
        var directions = new List<char>();
        FindAllPath(lab, 0, 0, directions,'\0');
    }

    private static void FindAllPath(char[,] lab, int row, int col,List<char> directions,char direction)
    {
        if (IsOutside(lab,row,col) || IsWall(lab,row,col) || IsVisited(lab,row,col))
        {
            return;
        }

        directions.Add(direction);
        if (lab[row,col] == 'e')
        {
            Console.WriteLine(string.Join("",directions));
            directions.RemoveAt(directions.Count - 1);
            return;
        }
        lab[row,col] = 'e';
        FindAllPath(lab, row - 1, col + 1, directions, 'R');
        FindAllPath(lab, row - 1, col,directions,'U');
        FindAllPath(lab, row + 1, col,directions,'D');
        FindAllPath(lab, row - 1, col - 1,directions,'L');

        directions.RemoveAt(directions.Count - 1);
        lab[row, col] = '-';
    }

    private static bool IsVisited(char[,] lab, int row, int col)
    {
        return lab[row, col] == 'e';
    }

    private static bool IsWall(char[,] lab, int row, int col)
    {
        return lab[row,col] == '*';
    }

    private static bool IsOutside(char[,] lab, int row, int col)
    {
        return row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1);
    }
}

