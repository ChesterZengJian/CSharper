using System.ServiceModel;

namespace SOA.WCF.Service
{
    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        void SayHello();
    }
}