﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Result
{
    public class Result : Iresult
    {

        public Result(bool success,string message):this(success) {
            Message = message;
        }

        public Result(bool success)
        {
            this.Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
