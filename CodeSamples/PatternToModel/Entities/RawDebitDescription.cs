using System.ComponentModel.DataAnnotations;

namespace CodeSamples.PatternToModel.Entities;

public class RawDebitDescription
{
    [Key]
    public int DebitDescriptionId { get; set; }

    public string Name { get; set; } = "بدون نام";

    public string Description { get; set; } = "بدون نام";

    public bool InvoiceNo { get; set; }

    public bool InvoiceDate { get; set; }

    public bool QTY { get; set; }

    public bool Unit { get; set; }

    public bool PricePerUnit { get; set; }

}