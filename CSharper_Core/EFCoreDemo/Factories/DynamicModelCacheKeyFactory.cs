using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCoreDemo.Factories
{
    public class DynamicModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
        {
            return context is SchoolContext schoolContext
                ? (context.GetType(), schoolContext.IsUseCoursePartition)
                : (object)context.GetType();
        }
    }
}