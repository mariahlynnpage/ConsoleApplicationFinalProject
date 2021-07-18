using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Repository
{
    public class RepoResult<T>
    {
        public RepoResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public RepoResult(T obj)
        {
            Successful = true;
            Object = obj;
        }
        public bool Successful { get; set; } = false;
        public string ErrorMessage { get; set; }
        public T Object { get; set; }
    }
}