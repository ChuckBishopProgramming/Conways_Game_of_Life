//create a grid
//get starting input
//validate starting input
//plot cells on buffer
//update initial arrays
//count neighbors of those on initial arrays
//
//No logic before start prompt
//start prompt
//apply logic


//rule logic trouble shoot
//grib update toggle

public class Program
{
    public static string[,] grid = new string[30, 120];
    public static string[,] bufferGrid = new string[30, 120];
    public static string[,] bufferGrid2 = new string[30, 120];
    public static string[,] currentGrid = new string[30, 120];
    public static string[,] futureGrid = new string[30, 120];

    public static int cycleCount = 0;

    const string HEADER = "CONWAY'S GAME OF LIFE";
    public const string fillingDead = ".";
    public const string fillingAlive = "O";

    const string lineDecor = "------------------------------------------------------------------------------------------------------------------------";

    static void Main(string[] args)
    {
        //GREETING
        Console.WriteLine("WELCOME, It's Alive!!!!");
        Line();

        //FILL GRID W DEAD CELLS
        Fill(grid, fillingDead);
        Fill(currentGrid, fillingDead);
        Fill(bufferGrid, fillingDead);
        Fill(bufferGrid2, fillingDead);

        //PROMPT FOR CELL #
        int noOfCells = PromptForCellNumber();
        Line();

        //CREATE INITIAL ARRAY
        Storage.CreateInitialArrays(noOfCells);

        //PLACE CELLS & FILL ARRAYS
        PromptAndPlaceCells(noOfCells, currentGrid);
        Line();

        //PRINT GRID
        Print2DString(currentGrid);
        Print2DString(grid);
        Line();

        //TESTING
        PrintArray(Storage.initialX);
        PrintArray(Storage.initialY);

        //START 
        ReadyToStart();

        //UPDATE BUFFER
        UpdateGrid();
        Print2DString(currentGrid);
        Console.ReadKey();
        UpdateGrid();
        Print2DString(currentGrid);
    }

    //CORE MECHANICS
    //++++++++++++++++++++++++++++++++++
    static public void PromptAndPlaceCells(int numberOfCells, string[,] arr)
    {
        for (int i = 0; i < numberOfCells; i++)
        {
            int x = GetXPos(i + 1);
            int y = GetYPos(i + 1);

            //fill initial arrays
            AddXYToArray(i, x, y);

            if (arr[x - 1, y - 1] == fillingAlive)
            {
                CellFilled();
                i--;
            }
            else
            {
                arr[x - 1, y - 1] = fillingAlive;
            }            
        }
    }
    static public void Fill(string[,] arr, string filling)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = filling;
            }
        }
    }    
    static public void UpdateGrid()
    {
        bool cellAlive = false;      
        Fill(futureGrid, fillingDead);

        for (int i = 0; i < currentGrid.GetLength(0); i++)
        {
            for (int j = 0; j < currentGrid.GetLength(1); j++)
            {
                int x = i;
                int y = j;

                int neighborCount = Neighbors.GetNeighborCountCell(currentGrid, i, j);
                cellAlive = Neighbors.LiveOrDieLogic(neighborCount);

                if (cellAlive)
                {
                    futureGrid[i, j] = fillingAlive;
                }
                else
                {
                    futureGrid[i, j] = fillingDead;
                }
            }
        }
        currentGrid = futureGrid;
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
    static public void IncrementCycleCount()
    {
        //SUS
        cycleCount++;
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
    static public void UpdateDisplay()
    {

    }

    //FORMATTING
    //++++++++++++++++++++++++++++++++++
    static public void Line()
    {
        Console.WriteLine(lineDecor);
    }
    static public void Space()
    {
        Console.WriteLine();
    }

    //PROMPT
    //++++++++++++++++++++++++++++++++++
    static public void ReadyToStart()
    {
        //Sketchy
        bool start = false;
        Console.WriteLine("Press Enter to Start or Escape to exit");

        while (!start)
        {
            ConsoleKeyInfo keyPress = Console.ReadKey();
            if (keyPress.Key == ConsoleKey.Enter)
            {
                //start stuff
                start = true;
            }
            else
            {
                if (keyPress.Key == ConsoleKey.Escape)
                {
                    //start stuff
                    start = false;
                    break;
                }
            }
        }
        Console.WriteLine("Starting things");
    }
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

