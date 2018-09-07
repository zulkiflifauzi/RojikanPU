﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RojikanPU.Base
{
    public class ResponseMessage
    {
        public bool IsError { get; set; }

        private List<string> _errorCodes = new List<string>();

        public List<string> ErrorCodes
        {
            get { return _errorCodes; }
            set { _errorCodes = value; }
        }

        public int CreatedId { get; set; }
    }
}