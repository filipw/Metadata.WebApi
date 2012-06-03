using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using webapi_metadata.Models;
using webapi_metadata.Filters;

namespace webapi_metadata.Controllers
{
    public class UrlController : ApiController
    {
        private readonly IUrlRepository urlRepo = new UrlRepository();

        [CustomQueryableAttribute]
        public IQueryable<Url> Get()
        {
            return urlRepo.GetAll();
        }

        public Url Get(int id)
        {
            return urlRepo.Get(id);
        }
    }
}