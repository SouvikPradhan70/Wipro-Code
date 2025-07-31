//SOLID Principles Refactoring - Simple and Beginner Friendly

using System;

//S - Single Responsibility Principle
// One class = one job

public class ReportGenerator
{
    public string GenerateReport()
    {
        return "This is your report content.";
    }
}

public class ReportSaver
{
    public void SaveReport(string content)
    {
        Console.WriteLine($"Saving Report: {content}"); // Output: Saving Report: This is your report content.
    }
}


//O - Open/Closed Principle
// Open to extension, closed to modification

public interface IFormatter
{
    void Format(string content);
}

public class PdfFormatter : IFormatter
{
    public void Format(string content)
    {
        Console.WriteLine("Formatting as PDF: " + content); // Output: Formatting as PDF: This is your report content.
    }
}

public class ExcelFormatter : IFormatter
{
    public void Format(string content)
    {
        Console.WriteLine("Formatting as Excel: " + content); // Output: Formatting as Excel: This is your report content.
    }
}

public class ReportFormatter
{
    public void FormatReport(IFormatter formatter, string content)
    {
        formatter.Format(content);
    }
}


//L - Liskov Substitution Principle
// Child classes should work the same as parent

public abstract class Report
{
    public abstract void Print();
}

public class PdfReport : Report
{
    public override void Print()
    {
        Console.WriteLine("Printing PDF Report"); // Output: Printing PDF Report
    }
}

public class ExcelReport : Report
{
    public override void Print()
    {
        Console.WriteLine("Printing Excel Report"); // Output: Printing Excel Report
    }
}


//I - Interface Segregation Principle
// Don't force to implement methods not needed

public interface IReportGenerator
{
    void Generate();
}

public interface IReportSaver
{
    void Save();
}

public class SimplePdfReport : IReportGenerator, IReportSaver
{
    public void Generate()
    {
        Console.WriteLine("Generating Simple PDF Report"); // Output: Generating Simple PDF Report
    }

    public void Save()
    {
        Console.WriteLine("Saving Simple PDF Report"); // Output: Saving Simple PDF Report
    }
}


//D - Dependency Inversion Principle
// High-level depends on interface, not on class

public interface IReportService
{
    void SaveReport();
}

public class ReportService : IReportService
{
    private readonly IReportSaver _reportSaver;

    public ReportService(IReportSaver reportSaver)
    {
        _reportSaver = reportSaver;
    }

    public void SaveReport()
    {
        _reportSaver.Save(); // Output: Saving Simple PDF Report
    }
}


//MAIN method to show everything working
class Program
{
    static void Main()
    {
        // SRP
        Console.WriteLine("This is from S....");
        var generator = new ReportGenerator();
        var saver = new ReportSaver();
        string reportContent = generator.GenerateReport();
        saver.SaveReport(reportContent); // Output: Saving Report: This is your report content.

        // OCP
        Console.WriteLine("This is from O....");
        var formatter = new ReportFormatter();
        formatter.FormatReport(new PdfFormatter(), reportContent); // Output: Formatting as PDF
        formatter.FormatReport(new ExcelFormatter(), reportContent); // Output: Formatting as Excel

        // LSP
        Console.WriteLine("This is from L....");
        Report pdf = new PdfReport();
        Report excel = new ExcelReport();
        pdf.Print();  // Output: Printing PDF Report
        excel.Print(); // Output: Printing Excel Report

        // ISP
        Console.WriteLine("This is from I....");
        IReportGenerator simplePdf = new SimplePdfReport();
        IReportSaver simpleSaver = new SimplePdfReport();
        simplePdf.Generate(); // Output: Generating Simple PDF Report
        simpleSaver.Save();   // Output: Saving Simple PDF Report

        // DIP
        Console.WriteLine("This is from D....");
        IReportSaver saverInterface = new SimplePdfReport();
        IReportService service = new ReportService(saverInterface);
        service.SaveReport(); // Output: Saving Simple PDF Report
    }
}
