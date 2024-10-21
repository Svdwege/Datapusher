using Ookii.CommandLine;
using System.ComponentModel;
using addDataToDB.DB;
using csvparser;

// Replace with your connection string.
// Replace with your server version and type.
// Use 'MariaDbServerVersion' for MariaDB.
// Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
// For common usages, see pull request #1233.

[GeneratedParser]
    partial class Argumentparser
    {

        [CommandLineArgument(IsPositional = true)]
        [Description("The source data file.")]
        public required string SourceFile{get;set;}

        
    }
    

internal static class Program
{
    static int Main(string[] args)
    {

        var parser = Argumentparser.Parse();
        if(parser == null){
            return 1;
        }

        CSVWrapper csv = new CSVWrapper(parser.SourceFile); 

        var dbctx = new S3DigitalTwinContext();
        DBWrapper dbwrapper = new DBWrapper(dbctx);
        dbwrapper.Reset();
        
        dbwrapper.LoadData(csv.result);

        var tmp = dbwrapper.db.TestPatterns.Find(12);

        if(tmp != null){
            Console.WriteLine($"{tmp.ChunkID} {tmp.coordX} {tmp.coordY} {tmp.coordZ} {tmp.gripperOpen}");
        }

        return 0;
    }
}

//for (int i = 0; i < 1000; i++)
//{
//    db.TestPatterns.Add(new TestPattern
//    {
//        ChunkID = i,
//        coordX = i,
//        coordY = i,
//        coordZ = i,
//        gripperOpen = (i % 2 == 0)
//    });
//}
//db.TestPatternTwos.Add(new TestPatternTwo { ChunkID = 0, coordX = 0, coordY = 0, coordZ = 0, gripperOpen = true });
//db.SaveChanges();
//show all data in db
//foreach (dynamic tp in db.TestPatterns.ToList()){
//    Console.WriteLine($"{tp.ChunkId} {tp.CoordX} {tp.CoordY} {tp.CoordZ} {tp.GripperOpen}");
//}

// deletea all data from db
//db.RemoveRange(db.TestPatterns);
//db.SaveChanges();
//try
//{
//    foreach (TestPattern tp in db.TestPatterns.ToList())
//    {
//        Console.WriteLine($"{tp.ChunkID} {tp.coordX} {tp.coordY} {tp.coordZ} {tp.gripperOpen}");
//    }
//}
//catch (Exception e)
//{
//    Console.WriteLine(e);
//}
/*
while (true)
{
    try
    {

        var tpdelete = db.TestPatterns.OrderBy(x => x.Id).First();
        db.Remove(tpdelete);
        db.SaveChanges();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        db.SaveChanges();
        break;
    }

}

*/
