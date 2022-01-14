using FileHelpers;

namespace Domain
{

    [DelimitedRecord("\t")]
    [IgnoreFirst]
    public class InputFormat: OutputFormat
    {
        [FieldOrder(1)]
        public Status Status { get; set; }
        [FieldOrder(2)]
        public Category Category { get; set; }
    }
}
