using System.Diagnostics;

namespace workshop.models;
[DebuggerDisplay("{Id}-{Operation}-{Result}")]
public class Calculation
{
    public int Id { get; set; }
    public string Operation { get; set; } = string.Empty;
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
    public int Result { get; set; }
}
