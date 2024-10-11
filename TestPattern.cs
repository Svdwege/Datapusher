using System;
using System.Collections.Generic;

namespace addDataToDB;

public partial class TestPattern
{
    public int Id { get; set; }

    public int ChunkId { get; set; }

    public double? CoordX { get; set; }

    public double? CoordY { get; set; }

    public double? CoordZ { get; set; }

    public bool? GripperOpen { get; set; }
}
