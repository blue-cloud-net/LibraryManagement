namespace FantasySky.Core.Operation;

public static class OperationalExtension
{
    public static Operational<TNewParameter> To<TOldParameter, TNewParameter>(this Operational<TOldParameter> operational, Func<TOldParameter, TNewParameter> converter)
    {
        var oldParameter = operational.Parameter;

        var newParameter = converter(oldParameter);

        return new Operational<TNewParameter>(newParameter);
    }
}
