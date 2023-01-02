using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.IReposateres;

namespace TalabatReposatrey
{
    public class BasketReposatry : IBascketReposatry
    {
        private readonly IDatabase _redisDB;

        public BasketReposatry(IConnectionMultiplexer RedisDB)
        {
            _redisDB = RedisDB.GetDatabase();
        }
        public async Task<bool> DeletBasket(string BasketId)
        {
            return
             await _redisDB.KeyDeleteAsync(BasketId);

        }

        public async Task<CustmerBasket> GetBasketAsync(string BasketId)
        {
            var basket= await _redisDB.StringGetAsync(BasketId);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustmerBasket>(basket);
            

        }

        public async Task<CustmerBasket> UpdatBascket(CustmerBasket basket)
        {
            var CreatOrUpdat = await _redisDB.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (CreatOrUpdat == false) return null;
            return await GetBasketAsync(basket.Id); 

        }
    }
}
