using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager2._0
{
    class OrderException : ApplicationException
    {
        public OrderException(string message) : base(message) { }
    }
}