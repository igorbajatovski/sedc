using System;
using System.Collections.Generic;
using System.Text;

namespace ServerInterfaces
{
    public class QueryCollection
    {
        private readonly Dictionary<string, List<string>> queryCollection;

        public static QueryCollection Empty
        {
            get
            {
                return new QueryCollection();
            }
        }

        private QueryCollection()
        {
            this.queryCollection = new Dictionary<string, List<string>>();
        }

        public QueryCollection(string queryString)
        {
            this.queryCollection = new Dictionary<string, List<string>>();
            if (string.IsNullOrEmpty(queryString))
                return;

            string[] key_values = queryString.Split('&');

            foreach(var key_value in key_values)
            {
                if (string.IsNullOrEmpty(key_value))
                    throw new ApplicationException("Bad query string format");

                string[] keyValue = key_value.Split('=');
                if(keyValue.Length != 2)
                    throw new ApplicationException("Bad query string format");

                string key = keyValue[0];
                string value = keyValue[1];

                if (!this.queryCollection.ContainsKey(key))
                {
                    var list = new List<string>();
                    list.Add(value);
                    this.queryCollection.Add(key, list);
                }
                else
                {
                    this.queryCollection[key].Add(value);
                }

            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var keyValuePair in this.queryCollection)
            {
                foreach(var value in keyValuePair.Value)
                {
                    sb.AppendLine($"{keyValuePair.Key} = {value}");
                }
            }
            return sb.ToString();
        }

        public List<string> GetValue(string key)
        {
            return this.queryCollection[key];
        }
    }
}
