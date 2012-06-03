using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Runtime.Serialization;

namespace webapi_metadata.Models
{
    [DataContract]
    public class Metadata<T> where T : class
    {
        [DataMember]
        public int TotalResults { get; set; }

        [DataMember]
        public int ReturnedResults { get; set; }

        [DataMember]
        public T[] Results { get; set; }

        [DataMember]
        public DateTime Timestamp { get; set; }

        [DataMember]
        public string Status { get; set; }

        public Metadata(HttpResponseMessage httpResponse, bool isIQueryable)
        {
            this.Timestamp = DateTime.Now;

            if (httpResponse.Content != null && httpResponse.IsSuccessStatusCode)
            {
                this.TotalResults = 1;
                this.ReturnedResults = 1;
                this.Status = "Success";

                if (isIQueryable)
                {
                    IEnumerable<T> enumResponseObject;
                    httpResponse.TryGetContentValue<IEnumerable<T>>(out enumResponseObject);
                    this.Results = enumResponseObject.ToArray();
                    this.ReturnedResults = enumResponseObject.Count();
                }
                else
                {
                    T responseObject;
                    httpResponse.TryGetContentValue<T>(out responseObject);
                    this.Results = new T[] {responseObject};
                }
            }

            else
            {
                this.Status = "Error";
                this.ReturnedResults = 0;
            }
        }
    }
}
