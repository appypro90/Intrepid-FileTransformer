using FileHelpers;

namespace Domain
{
    [DelimitedRecord(",")]
    public class OutputFormat
    {
        [FieldOrder(0)]
        public string Id { get; set; }
        [FieldOrder(3)]
        public string Description { get; set; }
        [FieldConverter(ConverterKind.Double, ".")]
        [FieldOrder(4)]
        public double Price { get; set; }
    }
}
