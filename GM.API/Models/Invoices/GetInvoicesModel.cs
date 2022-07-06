namespace GM.API.Models.Invoices;

public class GetInvoicesModel : QueryParameter
{
    public int? nccId { get; set; }
    public int? packageProductId { get; set; }
    public int? remain { get; set; }
    public Status? status { get; set; }
    public DateTime? startDate { get; set; }
    public DateTime? endDate { get; set; }
    public int? managerId { get; set; }
}
