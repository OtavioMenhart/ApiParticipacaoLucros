using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> InsertFirebaseAsync(string path, T item);
        Task<T> GetFirebaseAsync(string path);
        Task<T> UpdateFirebaseAsync(string path, T item);
        Task<bool> DeleteFirebaseAsync(string path);
    }
}
