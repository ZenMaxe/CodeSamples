namespace CodeSamples.PatternToModel.Entities;

public class DebitDescriptionCreateViewModel
{
    public string Details { get; set; }

    public int RawDebitDescriptionId { get; set; }
    public int DebitId { get; set; }
    public string? InvoiceNo { get; set; }

    public DateTimeOffset? InvoiceDate { get; set; }

    public int? QTY { get; set; }

    public string? Unit { get; set; }

    public decimal? PricePerUnit { get; set; }

    public decimal Amount { get; set; }
}