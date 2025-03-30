// See https://aka.ms/new-console-template for more information


using System.Dynamic;
using System.Text.Json;
using FastReport;
using FastReport.Export.PdfSimple;
using print_template_app.Model;

var templatePath = string.Empty; // todo: provide path to the template
var report = new Report();
// load report from template path
report.Load(templatePath);

// prepare data for the report
var reportData = new ReportData();
var reportDataObject = JsonSerializer.Serialize(reportData.Params);
// load report data as json data source
report.Dictionary.Connections[0].ConnectionString = reportDataObject;

report.Prepare();

var pdfExport = new PDFSimpleExport();


Console.WriteLine("Hello, World!");