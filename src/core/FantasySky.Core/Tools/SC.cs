namespace FantasySky.Core.Tools;

public static class SC
{
    public static string GetGuid() => Guid.NewGuid().ToString("N");
}
