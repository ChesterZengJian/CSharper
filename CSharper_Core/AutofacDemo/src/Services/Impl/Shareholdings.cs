using Microsoft.AspNetCore.Authentication.OAuth.Claims;

namespace AutofacDemo.Services.Impl
{
public class Shareholdings
{
    public delegate Shareholdings Factory(string symbol, uint holding);

    public string Symbol { get; set; }
    public uint Holding { get; set; }

    public Shareholdings(string symbol, uint holding)
    {
        Symbol = symbol;
        Holding = holding;
    }
}
}
