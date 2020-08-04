using System;
using System.Collections.Generic;
using StackExchange.Redis;
using StackExchangeRedisDemo.Extensions;

namespace StackExchangeRedisDemo.Repositories
{
    public class RedisHandler
    {
        private IDatabase m_database;
        private readonly int m_dbId;
        private RedisHandler(int dbId = 0)
        {
            m_dbId = dbId;
        }

        public IDatabase DataBase => GetRedisConn().GetDatabase(m_dbId);


        private static RedisHandler _instance;

        /// <summary>
        /// 实例列表，每个redis的每个db建立一个Instance
        /// </summary>
        private static Dictionary<int, RedisHandler> _insList;

        /// <summary>
        /// 单例访问
        /// </summary>
        public static RedisHandler Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new RedisHandler();
                if (null == _insList)
                    _insList = new Dictionary<int, RedisHandler> { [0] = _instance };
                return _instance;
            }
        }

        public RedisHandler this[int dbId]
        {
            get
            {
                if (dbId > 255 || dbId < 0)
                    throw new ArgumentOutOfRangeException(nameof(dbId), @"must be integer between 0 to 255");
                if (null == _insList)
                    _insList = new Dictionary<int, RedisHandler>();

                if (!_insList.ContainsKey(dbId))
                    _insList.Add(dbId, new RedisHandler(dbId));

                var ins = _insList[dbId];
                return ins;
            }
        }

        public ConnectionMultiplexer GetRedisConn()
        {
            return RedisConnectionHelper.Instance;
        }

        public int RetryTimes { get; set; } = 1;


        #region 字符串操作

        /// <summary>
        /// 获取字符串类型的redis值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public RedisValue StringGet(RedisKey key)
        {
            var errCount = 0;
            redo:
            try
            {
                return DataBase.StringGet(key);
            }
            catch (Exception)
            {
                if (errCount >= RetryTimes) throw;
                errCount++;
                goto redo;
            }
        }


        /// <summary>
        /// 添加带无生命周期的数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool StringSet(RedisKey key, RedisValue value)
        {
            var errCount = 0;
            redo:
            try
            {
                var ret = DataBase.StringSet(key, value);
                return ret;
            }
            catch
            {
                if (errCount >= RetryTimes) throw;
                errCount++;
                goto redo;
            }
        }

        #endregion

        #region 哈希值操作

        public bool HashSet(RedisKey key, RedisValue hashField, RedisValue value)
        {
            var errCount = 0;
            redo:
            try
            {
                return DataBase.HashSet(key, hashField, value);
            }
            catch (Exception)
            {
                if (errCount >= RetryTimes) throw;
                errCount++;
                goto redo;
            }
        }

        public RedisValue[] HashValues(RedisKey key)
        {
            var errCount = 0;
            redo:
            try
            {
                return DataBase.HashValues(key);
            }
            catch (Exception)
            {
                if (errCount >= RetryTimes) throw;
                errCount++;
                goto redo;
            }
        }

        #endregion
    }
}