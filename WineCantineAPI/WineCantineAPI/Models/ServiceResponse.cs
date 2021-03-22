using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineCantineAPI.Models
{
    //<T> Is the actual type of data we want to send back
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        //Tell in front-end if everAything went right
        public bool Success { get; set; } = true;

        //Message property to display message in case of error 
        public string Message { get; set; } = null;


    }
}
