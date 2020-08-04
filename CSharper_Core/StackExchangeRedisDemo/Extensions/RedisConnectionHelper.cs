using StackExchange.Redis;

namespace StackExchangeRedisDemo.Extensions
{
    public class RedisConnectionHelper
    {
        private const string RedisConnectionString = "127.0.0.1:6379"; //"192.168.8.73,password=111111,connectTimeout=10000,abortConnect=false";// ConfigurationManager.AppSettings["RedisExchangeHosts"];
        private static readonly object Locker = new object();
        private static ConnectionMultiplexer _instance;

        /// <summary>
        /// 单例获取
        /// </summary>
        public static ConnectionMultiplexer Instance
        {
            get
            {
                if (_instance == null || !_instance.IsConnected)
                {
                    lock (Locker)
                    {
                        _instance = GetManager();
                    }
                }
                else if (_instance != null)
                {
                    //LogHelper.WriteToLog("获取连接 IsConnected：" + _instance.IsConnected, "RedisConnectionHelp");
                }
                return _instance;
            }
        }

        private static ConnectionMultiplexer GetManager(string connectionString = null)
        {
            connectionString ??= RedisConnectionString;
            var connect = ConnectionMultiplexer.Connect(connectionString);

            //LogHelper.WriteToLog("获取连接：" + connectionString, "RedisConnectionHelp");

            //注册如下事件
            connect.ConnectionFailed += MuxerConnectionFailed;
            connect.ConnectionRestored += MuxerConnectionRestored;
            connect.ErrorMessage += MuxerErrorMessage;
            connect.ConfigurationChanged += MuxerConfigurationChanged;
            connect.HashSlotMoved += MuxerHashSlotMoved;
            connect.InternalError += MuxerInternalError;

            return connect;
        }

        #region 事件

        /// <summary>
        /// 配置更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConfigurationChanged(object sender, EndPointEventArgs e)
        {
            //LogHelper.WriteToLog("Configuration changed: " + e.EndPoint, "RedisConnectionHelp");
        }

        /// <summary>
        /// 发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerErrorMessage(object sender, RedisErrorEventArgs e)
        {
            //LogHelper.WriteToLog("ErrorMessage: " + e.Message, "RedisConnectionHelp");
        }

        /// <summary>
        /// 重新建立连接之前的错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            //LogHelper.WriteToLog("ConnectionRestored: " + e.EndPoint, "RedisConnectionHelp");
        }

        /// <summary>
        /// 连接失败 ， 如果重新连接成功你将不会收到这个通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            //LogHelper.WriteToLog("重新连接：Endpoint failed: " + e.EndPoint + ", " + e.FailureType + (e.Exception == null ? "" : (", " + e.Exception.Message)), "RedisConnectionHelp");
        }

        /// <summary>
        /// 更改集群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerHashSlotMoved(object sender, HashSlotMovedEventArgs e)
        {
            //LogHelper.WriteToLog("HashSlotMoved:NewEndPoint" + e.NewEndPoint + ", OldEndPoint" + e.OldEndPoint, "RedisConnectionHelp");
        }

        /// <summary>
        /// redis类库错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerInternalError(object sender, InternalErrorEventArgs e)
        {
            //LogHelper.WriteToLog("InternalError:Message" + e.Exception.Message, "RedisConnectionHelp");
        }

        #endregion 事件

    }
}