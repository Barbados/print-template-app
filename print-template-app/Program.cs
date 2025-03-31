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

// in the case of multi-pages report:
// 1. copy initial template
// 2. find the necessary template's page by tag name
// 3. load the data from appropriate collection
// 4. export output file to pdf
// 5. repeat the process from 1. to 4.
// 6. concatenate all pdf files into one output with PdfSharp lib

// export a document to .pdf
const string documentName = "test.pdf";
using var pdfExport = new PDFSimpleExport();
pdfExport.Export(report, documentName);

Console.WriteLine("Hello, World!");