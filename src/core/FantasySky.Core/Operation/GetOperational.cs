using FantasySky.Core.Models;

namespace FantasySky.Core.Operation;

public class GetOperational<TGetModel> : Operational<TGetModel> where TGetModel : IGetModel
{
    public GetOperational(
        TGetModel parameter) : base(parameter)
    {
    }
}
