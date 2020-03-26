using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    class OrderException:ApplicationException
    {
        public OrderException(string message) : base(message) { }
    }
}
