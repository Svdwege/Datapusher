using System.Text;
using System.Linq;
using addDataToDB.DB;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace csvparser
{
    
public class CsvDBDataMapping: CsvMapping<TestPattern>{

    public CsvDBDataMapping() : base(){
        MapProperty(0, x => x.ChunkID);
        MapProperty(1, x => x.coordX);
        MapProperty(2, x => x.coordY);
        MapProperty(3, x => x.coordZ);
        MapProperty(4, x => x.gripperOpen);
    }

}


class CSVWrapper
{
    
    public List<TestPattern>  result;

    public CSVWrapper(string filename)
    {
        CsvParserOptions options = new CsvParserOptions(true, ';');
        CsvDBDataMapping mapping = new CsvDBDataMapping();
        CsvParser<TestPattern> parser = new CsvParser<TestPattern>(options, mapping);
        
        var res = parser.ReadFromFile(filename, Encoding.ASCII).ToList();
        var query = from r in res 
            where r.IsValid
            select r.Result; 
         result = query.OfType<TestPattern>().ToList();
    }
    
}


}


