using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace StackExchangeRedisDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuaScriptsController : ControllerBase
    {
        private readonly IDatabase m_db;
        private readonly IServer m_server;

        public LuaScriptsController(IDatabase db, IServer server)
        {
            m_db = db;
            m_server = server;
        }

        [HttpGet]
        public string Get()
        {
            var script = new StringBuilder();
            script.Append("redis.call('set', @key, @value)\n");
            script.Append("return redis.call('get', @key)");

            var prepared = LuaScript.Prepare(script.ToString());
            var result = m_db.ScriptEvaluate(prepared, new { key = (RedisKey)"mykey", value = (RedisKey)$"{DateTime.Now.ToString():yyyy-MM-dd hh:mm:ss}" });

            //var loaded = prepared.Load(m_server);
            //var result = loaded.Evaluate(m_db, new { key = (RedisKey)"mykey", value = (RedisKey)$"{DateTime.Now.ToString():yyyy-MM-dd hh:mm:ss}" });

            Console.WriteLine($"result={result}");

            return result.ToString();
        }
    }
}