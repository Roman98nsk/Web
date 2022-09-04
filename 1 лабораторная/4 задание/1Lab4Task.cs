/*string inputFile = @"path/File.xls";
string outputFile = @"path/File.csv";

using (Converter converter = new Converter(inputFile)) {
    Spread
}*/

PM> Install-Package GroupDocs.Conversion

string inputFile = @"path/spreadsheet.xlsx";
string outputFile = @"path/comma-sparated-values.csv";

using (Converter converter = new Converter(inputFile))
{
    SpreadsheetConvertOptions options = new SpreadsheetConvertOptions
    {
        PageNumber = 2,
        PagesCount = 1,
        Format = SpreadsheetFileType.Csv // Specify the conversion format
    };
    converter.Convert(outputFile, options);
}