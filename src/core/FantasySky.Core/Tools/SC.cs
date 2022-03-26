using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasySky.Core.Tools;

public static class SC
{
    public static string GetGuid() => Guid.NewGuid().ToString("N");
}
