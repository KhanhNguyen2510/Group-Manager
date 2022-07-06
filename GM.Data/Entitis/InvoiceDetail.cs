namespace GM.Data.Entitis;

public class InvoiceDetail : Entity
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    /// <summary>
    /// Mả sản phẩm
    /// </summary>
    public int ProductId { get; set; }
    public decimal Price { set; get; }
    /// <summary>
    /// Số lượng
    /// </summary>
    public int Quantity { get; set; }

    public Product Product { get; set; }
    public Invoice Invoice { get; set; }

}
