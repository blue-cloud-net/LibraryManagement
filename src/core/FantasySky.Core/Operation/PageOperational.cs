using FantasySky.Core.Models;
using FantasySky.Core.Persistence;

namespace FantasySky.Core.Operation;

public class PageOperational<TQueryModel> : Operational<TQueryModel> where TQueryModel : IQueryModel
{
    public PageOperational(
        TQueryModel queryModel,
        int? skip = null,
        int? take = null,
        IOrderBy<IModel>? orderBies = null) : base(queryModel)
    {
        this.Page = Paging.Create(skip, take);
        this.OrderBies = orderBies;
    }

    public IPaging Page { get; set; }

    public IOrderBy<IModel>? OrderBies { get; set; }
}
