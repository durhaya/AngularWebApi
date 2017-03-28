using System;
using System.Data.Entity;

namespace Repositories
{
    public interface IDataContext
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void ExecuteCommand(string command, params object[] parameters);
    }
}
