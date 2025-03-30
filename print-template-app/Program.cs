using System.Text.Json;
using FastReport;
using FastReport.Export.PdfSimple;
using print_template_app.Model;

var templatePath = string.Empty; // todo: provide path to the template
using var report = new Report();
// load report from template path
report.Load(templatePath);

// prepare data for the report
var reportData = new ReportData();
var reportDataObject = JsonSerializer.Serialize(reportData.Params);

// load report data as json data source
report.Dictionary.Connections[0].ConnectionString = reportDataObject;

report.Prepare();

// export a document to .pdf
const string documentName = "test.pdf";
using var pdfExport = new PDFSimpleExport();
pdfExport.Export(report, documentName);

Console.WriteLine("Hello, World!");