using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FideGames.Models;

namespace FideGames.Clases
{
    public class DetailInvoiceViewData
    {
        public invoice invoice { get; set; }
        public IEnumerable<invoice_detail> invoice_detail { get; set; }

        public IEnumerable<product> product { get; set; }

        public IEnumerable<product> productSell { get; set; }

    }
}