using Spectre.Console;

//   Notes: Working MVP
//          auto loop added
//          autoshape complete
//          adding formatting and consol

public class Program
{
    //these are 0-29 and 0-119
    public static string[,] grid = new string[30, 120];
    public static string[,] currentGrid = new string[30, 120];
    public static string[,] futureGrid = new string[30, 120];

    //premade shapes
    public readonly static int[,] p24GG = new int[72, 2]
    {
        { 1, 3 },
        { 2, 3 },
        { 2, 4 },
        { 2, 5 },
        { 2, 19 },
        { 2, 20 },
        { 3, 6 },
        { 3, 16 },
        { 3, 17 },
        { 3, 20 },
        { 4, 5 },
        { 4, 6 },
        { 4, 15 },
        { 4, 17 },
        { 4, 19 },
        { 5, 17 },
        { 5, 19 },
        { 5, 20 },
        { 6, 19 },
        { 7, 8 },
        { 7, 13 },
        { 7, 16 },
        { 7, 19 },
        { 8, 8 },
        { 8, 14 },
        { 8, 16 },
        { 8, 18 },
        { 8, 19 },
        { 8, 21 },
        { 9, 6 },
        { 9, 10 },
        { 9, 15 },
        { 9, 16 },
        { 9, 20 },
        { 9, 21 },
        { 10, 6 },
        { 10, 8 },
        { 10, 9 },
        { 10, 17 },
        { 10, 18 },
        { 11, 17 },
        { 12, 8 },
        { 12, 19 },
        { 13, 7 },
        { 13, 8 },
        { 13, 13 },
        { 13, 14 },
        { 13, 18 },
        { 13, 19 },
        { 14, 6 },
        { 14, 7 },
        { 14, 9 },
        { 14, 13 },
        { 14, 15 },
        { 15, 7 },
        { 15, 8 },
        { 15, 9 },
        { 15, 15 },
        { 16, 8 },
        { 16, 15 },
        { 16, 16 },
        { 17, 4 },
        { 18, 2 },
        { 18, 5 },
        { 19, 2 },
        { 19, 5 },
        { 20, 3 },
        { 21, 12 },
        { 21, 14 },
        { 22, 13 },
        { 22, 14 },
        { 23, 13 }
    };

    public static int cycleCount = 0;

    const string HEADER = "CONWAY'S GAME OF LIFE";
    public const string fillingDead = ".";
    public const string fillingAlive = "O";

    const string lineDecor = "------------------------------------------------------------------------------------------------------------------------";

    static void Main(string[] args)
    {
        //__________________________________________________________________________________________________________
        //SPECTRE CONSOLE LAB
        //string userSelect = AnsiConsole.Prompt(
        //new SelectionPrompt<string>()
        //.Title("[green]PROMPT[/]:")
        //.AddChoices("Option 1", "Option 2", "Option 3"));

        //AnsiConsole.MarkupLine($"User select is: [gold1]{userSelect}[/]");


        ////_________________________________________________________________________________________________
        //GREETING
        Console.WriteLine("WELCOME, It's Alive!!!!");
        Line();

        //FILL GRID W DEAD CELLS
        Fill(grid, fillingDead);
        Fill(currentGrid, fillingDead);

        //GIVE OPTION FOR PREMADE 
        PremadeSelector();

        //PRINT GRID
        Console.Clear();
        Line();
        Print2DString(currentGrid);
        Line();

        //TESTING


        //START 
        ReadyToStart();
        Console.Clear();

        //UPDATE BUFFER

        //AUTO OR MANUAL TURNS
        ManualAutoSplit();         
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
        //GetLength returns the number of elements
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = filling;
            }
        }
    }
    static public string[,] UpdateGrid()
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
                cellAlive = Logic.LiveOrDieLogic(neighborCount, currentGrid, i, j);

                if (cellAlive)
                {
                    futureGrid[i, j] = fillingAlive;
                }
            }
        }

        //INSTEAD
        Array.Copy(futureGrid, currentGrid, futureGrid.Length);
        return currentGrid;
    }
    static public void ManualAdvance(int generations)
    {
        for (int i = 0; i < generations; i++)
        {            
            Console.Clear();
            GameState.OneGenerationManual(i);
        }
    }
    static public void AutoAdvance(int generations)
    {
        for (int i = 0; i < generations; i++)
        {
            Console.Clear();
            GameState.OneGenerationAuto(i);
        }
    }
    static public void ManualAutoSplit()
    {
        string userSelect = PromptAutoMan();


        if (userSelect.Trim().ToUpper() == "MANUAL")
        {
            ManualAdvance(PromptGenerations());
        }
        else if (userSelect.Trim().ToUpper() == "AUTOMATIC")
        {
            AutoAdvance(PromptGenerations());
        }
    }
    static public void PremadeSelector()
    {
        string userResponse = PromptPremade();
        if (userResponse.Trim().ToUpper() == "YES")
        {
            string userSelect = PromptPremadeSelect();

            if (userSelect.Trim().ToUpper() == "PERIOD 24 GLIDER GUN")
            {
                int noOfCellsPeriod24 = 72;

                //CREATE INITIAL ARRAY
                Storage.CreateInitialArrays(noOfCellsPeriod24);

                //PLACE SHAPE AND FILL ARRAY
                PlacePeriod24GliderGun(p24GG, currentGrid);
            }

        }
        else if (userResponse.Trim().ToUpper() == "NO")
        {
            //PROMPT FOR CELL #
            int noOfCells = PromptForCellNumber();
            Line();

            //CREATE INITIAL ARRAY
            Storage.CreateInitialArrays(noOfCells);

            //PLACE CELLS & FILL ARRAYS
            PromptAndPlaceCells(noOfCells, currentGrid);
            Line();
        }
        else
        {
            Console.WriteLine($"Please enter Y or N");
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
        string userSelect = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Are you ready to start?")
            .AddChoices("Start", "Quit")
            );

        bool start = false;

        while (!start)
        {            
            if (userSelect.Trim().ToUpper() == "START")
            {
                //start stuff
                start = true;
            }
            else
            {
                if (userSelect.Trim().ToUpper() == "QUIT")
                {
                    //start stuff
                    start = false;
                    Environment.Exit(0);
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
            AnsiConsole.MarkupLine("[green]How many cells do you want to place?[/]");
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

            AnsiConsole.MarkupLine($"[green]{msg}[/]");

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
    static public string PromptAutoMan()
    {
        string userSelect = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("[green]Please select advancement type[/]")
            .AddChoices("Automatic", "Manual"));
        return userSelect;
    }
    static public int PromptGenerations()
    {        
        string generationsQuery = "How many generations do you want to simulate?";
        string generationsQueryFail = "can't fail - not true";
        int gen = GetNumberFromUser(generationsQuery, generationsQueryFail, 30);

        if (gen < 0)
        {
            AnsiConsole.MarkupLine($"negative number not allowed, setting to 1 generation");
            gen = 1;
        }
        return gen;
    }
    static public string PromptPremade()
    {
        string userSelect = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[green]Do you want to use to a premade shape?[/]:")
        .AddChoices("Yes", "No"));

        return userSelect;
    }
    static public string PromptPremadeSelect()
    {
        string userSelect = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[green]Which pre-made shape would you like to place?[/]:")
        .AddChoices("Period 24 glider gun"));

        return userSelect;
    }
    static public void PromptGenAdvance()
    {
        AnsiConsole.MarkupLine("[green]Press any button for the next generation[/]");
    }

    //SHAPES 
    //++++++++++++++++++++++++++++++++++
    static public void PlacePeriod24GliderGun(int[,] intArr, string[,] display)
    {
        //72 cells
        //length = total items
        //GetLength(//dimension number) = specific array's total items
        for (int i = 0; i < intArr.GetLength(0); i++)
        {
            int x = intArr[i, 0];
            int y = intArr[i, 1];

            //fill initial arrays
            AddXYToArray(i, x, y);

            if (display[x - 1, y - 1] == fillingAlive)
            {
                CellFilled();
                i--;
            }
            else
            {
                display[x - 1, y - 1] = fillingAlive;
            }
        }
    }


}

