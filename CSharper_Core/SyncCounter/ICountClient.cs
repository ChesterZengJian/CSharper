﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SyncCounter
{
    public interface ICountClient
    {
        Task ReceiveSomeMessage(string msg);
    }
}
