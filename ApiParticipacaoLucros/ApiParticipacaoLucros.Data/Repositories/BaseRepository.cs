using ApiParticipacaoLucros.Data.Context;
using ApiParticipacaoLucros.Domain.Interfaces;
using FireSharp;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiParticipacaoLucros.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private FirebaseContext fbCtx = new FirebaseContext();
        private FirebaseClient _client;

        public BaseRepository()
        {
            _client = fbCtx.InstanciarClientFirebase();
        }

        public async Task<T> InsertFirebaseAsync(string path, T item)
        {
            try
            {
                SetResponse response = await _client.SetTaskAsync(path, item);
                T result = response.ResultAs<T>();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetFirebaseAsync(string path)
        {
            try
            {
                FirebaseResponse response = await _client.GetTaskAsync(path);
                if (response.Body != "null")
                {
                    T result = response.ResultAs<T>();
                    return result;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> UpdateFirebaseAsync(string path, T item)
        {
            try
            {
                FirebaseResponse response = await _client.UpdateTaskAsync(path, item);
                if (response.Body != "null")
                {
                    T result = response.ResultAs<T>();
                    return result;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteFirebaseAsync(string path)
        {
            try
            {
                FirebaseResponse response = await _client.DeleteTaskAsync(path);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Dictionary<string, T>> GetAllFirebaseAsync(string path)
        {
            try
            {
                FirebaseResponse response = await _client.GetTaskAsync(path);
                if (response.Body != "null")
                {
                    Dictionary<string, T> result = response.ResultAs<Dictionary<string, T>>();
                    return result;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
