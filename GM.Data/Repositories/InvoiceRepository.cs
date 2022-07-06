namespace GM.Data.Repositories;

public interface IInvoiceRepository : IDataRepository<Invoice>
{
}

public class InvoiceRepository : DataRepository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(GMDbContext context) : base(context)
    {
    }
}
