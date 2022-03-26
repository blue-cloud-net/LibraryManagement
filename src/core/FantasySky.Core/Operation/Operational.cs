namespace FantasySky.Core.Operation;

public class Operational
{

}

public class Operational<TParameter> : Operational
{
    public Operational(TParameter parameter)
    {
        this.Parameter = parameter;
    }

    public TParameter Parameter { get; set; }
}
