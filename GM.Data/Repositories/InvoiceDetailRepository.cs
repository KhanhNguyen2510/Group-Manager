namespace GM.Data.Repositories;

public interface IInvoiceDetailRepository : IDataRepository<InvoiceDetail>
{
}

public class InvoiceDetailRepository : DataRepository<InvoiceDetail>, IInvoiceDetailRepository
{
    public InvoiceDetailRepository(GMDbContext context) : base(context)
    {
    }
}
