using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using CodeSamples.PropertyPermissionSystem.Attributes;

namespace CodeSamples.PropertyPermissionSystem.Entity;

public class Debit
{
    [Key]
    [NullIgnore]
    public int DebitId { get; set; }

    // [NullIgnore]
    // public int CargoId { get; set; }

    [RequiresPermission("DebitDescription", PermissionType.Read)]
    [RequiresPermission("DebitDescriptionEdit", PermissionType.Edit)]
    public string Description { get; set; } = "";

    //public List<FilledDebitDescription> DebitDescriptions { get; set; } = new List<FilledDebitDescription>();

    [RequiresPermission("DebitTotalAmount", PermissionType.Read)]
    public decimal TotalAmount { get; set; }

    [RequiresPermission("DebitTotalAmountDirham", PermissionType.Read)]

    public decimal TotalAmountDirham { get; set; }

    [RequiresPermission("DebitTotalAmountToman", PermissionType.Read)]
    public decimal TotalAmountToman { get; set; }

    [RequiresPermission("DebitProfit", PermissionType.Read)]
    public decimal Profit { get; set; } = 0;

    [RequiresPermission("DebitCostOf", PermissionType.Read)]
    [RequiresPermission("DebitCostOfEdit", PermissionType.Edit)]
    public decimal CostOf { get; set; } = 0;

    [NullIgnore]
    public int? AccountantId { get; set; }

    //[ForeignKey("AccountantId")]
    //[RequiresPermission("DebitAccountant", PermissionType.Read)]
    //public AppUser? Accountant { get; set; }

    [NullIgnore]
    [RequiresPermission("DebitConfigEdit", PermissionType.Edit)]
    public int? ConfigId { get; set; }

    // [RequiresPermission("DebitConfig", PermissionType.Read)]
   // public Config? Config { get; set; }

    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
}