namespace RedisTest.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using EasyCaching.Core;
    
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IEasyCachingProvider _provider;

        public ValuesController(IEasyCachingProvider provider)
        {
            this._provider = provider;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            var activity = new Activity
            { 
                VoteTime = Convert.ToDateTime("2018-2-12 12:11")
            };

            _provider.Set("key",activity,TimeSpan.FromSeconds(30));

            var time = _provider.Get<Activity>("key");

            return time.Value.VoteTime?.ToString("yyyy-MM-dd HH:mm:ss");
        }

        [Serializable]
        public class Activity
        {
            public DateTime? VoteTime { get; set; }
        }
    }
}
