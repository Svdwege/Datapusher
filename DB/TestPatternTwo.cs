using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace addDataToDB.DB{

[Table("TestPatternTwo")]
public partial class TestPatternTwo
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int ID { get; set; }

    [Column(TypeName = "int(11)")]
    public int ChunkID { get; set; }

    public double? coordX { get; set; }

    public double? coordY { get; set; }

    public double? coordZ { get; set; }

    public bool? gripperOpen { get; set; }
}
}
