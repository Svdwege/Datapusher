using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using addDataToDB;

// See https://aka.ms/new-console-template for more information
// Replace with your connection string.
// Replace with your server version and type.
// Use 'MariaDbServerVersion' for MariaDB.
// Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
// For common usages, see pull request #1233.
var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));
// Replace 'YourDbContext' with the name of your own DbContext derived class.
var db = new S3digitalTwinContext();

//for (int i = 0; i < 10; i++)
//{
//    db.Add(new TestPattern { ChunkId = i, CoordX = i, CoordY = i, CoordZ = i, GripperOpen = (i % 2 == 0) });
//}
//
//db.SaveChanges();
//
//var testPatterns = db.TestPatterns;
//
//var query = from tp in testPatterns
//            where tp.GripperOpen == true select tp;
//
//foreach (var tp in query)
//{
//    Console.WriteLine($"{tp.Id} {tp.ChunkId} {tp.CoordX} {tp.CoordY} {tp.CoordZ} {tp.GripperOpen}");
//}


var tpdelete = db.TestPatterns;
foreach(var tpd in tpdelete){
    db.Remove(tpdelete);
}
db.SaveChanges();


Console.WriteLine("Hello, World!");
