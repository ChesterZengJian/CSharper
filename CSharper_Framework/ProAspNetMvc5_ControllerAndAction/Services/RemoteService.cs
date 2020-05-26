using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ProAspNetMvc5_ControllerAndAction.Services
{
  public class RemoteService
  {
    public async Task<string> GetRemoteData()
    {
      return await Task<string>.Factory.StartNew(() =>
      {
        Thread.Sleep(2000);
        return "Hello Sleep";
      });
    }
  }
}