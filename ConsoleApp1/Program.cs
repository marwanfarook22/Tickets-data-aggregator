using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;


var StartAppliction = new RunAppliction(
    new FormatingTextFile(),
    new ReadDirctoryFiles()
    );
StartAppliction.RunApplictoin();

 



decimal D = 10.05m;
Console.WriteLine(D);

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Press any Key to Esc");

Console.ReadKey();
public class RunAppliction(
    IFormatingTextFile formatingTextFile,
    IReadDirctoryFiles iReadDirctoryFiles
        )
{
    private readonly IFormatingTextFile _formatingTextFile = formatingTextFile;
    private readonly IReadDirctoryFiles _iReadDirctoryFiles = iReadDirctoryFiles;
    readonly string folderPath = @"E:\web developing\Backend (C#)\MyWork\Tickets data aggregator\Tickets";


    public void RunApplictoin()
    {
        StringBuilder R = _iReadDirctoryFiles.GetDirictoryFile(folderPath);
        var BuildPath = _formatingTextFile.BuildPath(folderPath, "aggregatedTickets.txt");
        _formatingTextFile.WriteTxt(R, BuildPath);
        Console.WriteLine($"Result saved to {BuildPath}");
    }


}

public interface IFormatingTextFile
{
    public void WriteTxt(StringBuilder L, string Path);
    public string BuildPath(string _folder, string path);
}

public class FormatingTextFile : IFormatingTextFile
{
    public string BuildPath(string _folder, string path)
    {
        return Path.Combine(_folder, path);
    }

    public void WriteTxt(StringBuilder L, string Path)
    {
        File.WriteAllText(Path, L.ToString());
    }

}

public interface IReadDirctoryFiles
{
    StringBuilder GetDirictoryFile(string folderPath);
    void MatchDataFormatter(MatchCollection matches);
    void PdfDocumentReader(string file);
}

public class ReadDirctoryFiles : IReadDirctoryFiles
{
    private readonly string pattern = @"Title:(?<title>.+?)Date:(?<date>\d{1,4}/\d{1,2}/\d{2,4})Time:(?<time>\d{1,2}:\d{2}(\s?[APMampm]*)?)";
    public StringBuilder stringBuilder = new StringBuilder();



    public StringBuilder GetDirictoryFile(string folderPath)
    {
        //string[] files = Directory.GetFiles(folderPath, "*.pdf");
        foreach (string file in Directory.GetFiles(folderPath, "*.pdf"))
        {
            PdfDocumentReader(file);
        }
        return stringBuilder;
    }

    public void PdfDocumentReader(string file)
    {
        using PdfDocument document = PdfDocument.Open(file);
        foreach (Page page in document.GetPages())
        {
            var text = page.Text;
            MatchCollection matches = Regex.Matches(text, pattern);
            MatchDataFormatter(matches);

        }

    }

    public void MatchDataFormatter(MatchCollection matches)
    {
        foreach (Match match in matches)
        {
            string Title = match.Groups["title"].ToString();
            string Date = match.Groups["date"].ToString();
            string Time = match.Groups["time"].ToString();
            var date = DateTime.Parse(Date).ToString("d", CultureInfo.InvariantCulture);
            var T1 = TimeOnly.Parse(Time).ToString("", CultureInfo.InvariantCulture);
            var TicketInfo = $"{Title,-40} | {date,-10} | {T1}";
            stringBuilder.AppendLine(TicketInfo);
        }

    }



}


