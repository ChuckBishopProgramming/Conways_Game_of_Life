//create a grid
//get starting input
//validate starting input
//plot cells and update initial arrays
//count neighbors of those on initial arrays
//

public class Program
{
    public static string[,] grid = new string[30, 120];
    public static string[,] bufferGrid = new string[30, 120];    

    const string HEADER = "CONWAY'S GAME OF LIFE";
    const string fillingDead = ".";
    const string fillingAlive = "O";

    static void Main(string[] args)
    {
        //GREETING
        Console.WriteLine("WELCOME, It's Alive!!!!");
        Line();

        //FILL GRID W DEAD CELLS
        Fill(fillingDead);

        //PROMPT FOR CELL #
        int noOfCells = PromptForCellNumber();
        Line();

        //CREATE INITIAL ARRAY
        Storage.CreateInitialArrays(noOfCells);
        Storage.CreateInitialTrackingArray(noOfCells);

        //PLACE CELLS & FILL ARRAYS
        PromptAndPlaceCells(noOfCells);
        Line();

        //PRINT GRID
        Print2DString(grid);
        PrintArray(Storage.initialX);
        PrintArray(Storage.initialY);

        //GET NEIGHBOR COUNT
        int neighborCount = Neighbors.GetNeighborCountArray(grid, Storage.initialX, Storage.initialY);
        Console.WriteLine(neighborCount);

        //TESTING:
        Print2DInt(Storage.trackingArray);
    }

    //CORE MECHANICS
    //++++++++++++++++++++++++++++++++++
    static public void PromptAndPlaceCells(int numberOfCells)
    {
        for (int i = 0; i < numberOfCells; i++)
        {

            int x = GetXPos(i + 1);
            int y = GetYPos(i + 1);
            //Print(grid);

            //fill array
            AddXYToArray(i, x, y);
            FillTracking(Storage.trackingArray, i, x, y);

            if (grid[x - 1, y - 1] == fillingAlive)
            {
                CellFilled();
                i--;                
            }
            else
            {
                grid[x - 1, y - 1] = fillingAlive;
            }
        }
    }
    static public void Fill(string filling)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = filling;
            }
        }
    }
    static public void FillTracking(int[,] trackingArray, int i,  int x, int y)
    {
        for (int j = 0; j < trackingArray.GetLength(1); j++)
        {
            if (j == 0)
            {
                trackingArray[i, j] = x;
            }
            if (j == 1)
            {
                trackingArray[i, j] = y;
            }
        }
    }

    //MECHANICAL HELPERS
    //++++++++++++++++++++++++++++++++++
    static public void AddXYToArray(int i, int x, int y)
    {
        Storage.initialX[i] = x;
        Storage.initialY[i] = y;
    }
    static public void ConsoleReset()
    {
        Console.Clear();
        Console.WriteLine(HEADER);
        Print2DString(grid);
    }
    //DISPLAY
    //++++++++++++++++++++++++++++++++++
    static public void Print2DString(string[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i, j]);
            }
            Console.Write("\n");
        }
    }
    static public void Print2DInt(int[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i, j]);
            }
            Console.Write("\n");
        }
    }
    static public void PrintArray(int[] arr)
    {
        foreach (int number in arr)
        {
            Console.WriteLine(number);
        }
    }

    //FORMATTING
    //++++++++++++++++++++++++++++++++++
    static public void Line()
    {
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
    }
    static public void Space()
    {
        Console.WriteLine();
    }

    //PROMPT
    //++++++++++++++++++++++++++++++++++
    static public void CellFilled()
    {
        Console.WriteLine("That cell was already activated, please pick another. Press Enter to Continue");
        Console.ReadKey();
    }
    static public int PromptForCellNumber()
    {
        bool userInputValidNumber = false;
        int number = 0;

        while (!userInputValidNumber)
        {
            Console.Write("How many cells do you want to place? ");
            string userInput = Console.ReadLine();

            userInputValidNumber = int.TryParse(userInput, out number);
        }
        return number;
    }
    static public int GetNumberFromUser(string prompt, string failPrompt, int failPromptLength)
    {
        bool userInputValidNumber = false;

        int number = 0;
        int badInput = 0;

        string msg = prompt;

        while (!userInputValidNumber)
        {
            if (msg.Length > failPromptLength)
            {
                msg = prompt + failPrompt;
            }

            //ConsoleReset();

            Console.Write(msg);

            string userInput = Console.ReadLine();

            userInputValidNumber = int.TryParse(userInput, out number);

            msg += failPrompt;
        }

        return number;
    }
    static public int GetXPos(int cellNo)
    {
        string startingPosPrompt = $"Please enter the x position for cell {cellNo}: (1 to 30): ";
        string startingPosFPrompt = "\nPlease enter a valid number";

        int maxLength = startingPosPrompt.Length + startingPosFPrompt.Length;
        int xPos = 0;

        bool xPosValid = false;

        while (!xPosValid)
        {
            xPos = GetNumberFromUser(startingPosPrompt, startingPosFPrompt, maxLength);
            if (!(xPos < 0 || xPos > 31))
            {
                xPosValid = true;
            }
        }
        return xPos;
    }
    static public int GetYPos(int cellNo)
    {
        string startingPosPrompt = $"Please enter the y position for cell {cellNo}: (1 to 120): ";
        string startingPosFPrompt = "\nPlease enter a valid number";

        int maxLength = startingPosPrompt.Length + startingPosFPrompt.Length;
        int yPos = 0;

        bool yPosValid = false;

        while (!yPosValid)
        {
            yPos = GetNumberFromUser(startingPosPrompt, startingPosFPrompt, maxLength);
            if (!(yPos < 0 || yPos > 121))
            {
                yPosValid = true;
            }
        }
        return yPos;
    }    
}

