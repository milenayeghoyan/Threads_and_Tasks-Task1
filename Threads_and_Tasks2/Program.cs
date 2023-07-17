
//Task1 - 
using System.Diagnostics;

try
{
    string file1 = "C:\\Users\\user\\Desktop\\File1.txt";
    string file2 = "C:\\Users\\user\\Desktop\\File2.txt";

    var task1 = Task.Run(() => CountFileLines(file1, 1));
    var task2 = Task.Run(() => CountFileLines(file2, 2));

    int fileOneLinesCount = task1.Result;
    int fileTwoLinesCount = task2.Result;

    int totalLines = fileOneLinesCount + fileTwoLinesCount;
    Console.WriteLine();
    Console.Write($"Total line counts of two files is :{totalLines}");

    Console.Read();
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
catch (IOException ex)
{
    Console.WriteLine(ex.Message);
}

catch (Exception ex)
{
    Console.WriteLine($"General error. Exception message is:{ex.Message}");
}

int CountFileLines(string filePath, int fileNumber)
{
    using (TextReader reader = new StreamReader(filePath))
    {
        int count = 0;
        string line = string.Empty;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while ((line = reader.ReadLine()) != null)
        {
            count++;
            Thread.Sleep(1000);
            Console.WriteLine($"For file: {fileNumber}. Elapsed time is:{stopwatch.ElapsedMilliseconds}");
        }

        stopwatch.Stop();

        return count;
    }
}
