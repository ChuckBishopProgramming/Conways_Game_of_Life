public class Storage
{
    public static int[] initialX;
    public static int[] initialY;
    public static int[,] trackingArray;

    public static void CreateInitialArrays(int numberOfCells)
    {
        initialX = new int[numberOfCells];
        initialY = new int[numberOfCells];
    }
    public static void CreateInitialTrackingArray(int noOfCells)
    {
        trackingArray = new int[noOfCells, 2];
    }
}