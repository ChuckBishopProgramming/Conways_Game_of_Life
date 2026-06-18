using Spectre.Console;

public class GameState
{ 


    public static void OneGenerationManual(int i)
    {
        int offByOneCorrector = 1;

        Console.Clear();
        Program.currentGrid = Program.UpdateGrid();
        Program.Print2DString(Program.currentGrid);
        AnsiConsole.MarkupLine($"[green]Generation {i + offByOneCorrector}[/]");
        Program.PromptGenAdvance();
        Console.ReadKey();
    }
    public static void OneGenerationAuto(int i)
    {
        int offByOneCorrector = 1;

        Console.Clear();
        Program.currentGrid = Program.UpdateGrid();
        Program.Print2DString(Program.currentGrid);
        AnsiConsole.MarkupLine($"[green]Generation {i + offByOneCorrector}[/]");
        //Program.Line();
        Thread.Sleep(1500);
    }
}
