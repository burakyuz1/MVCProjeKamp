using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityLayer.ViewModels
{
    public class AlertViewModel
    {
        public bool Status { get; set; }
        public string AlertMessage { get; set; }
        public string URL { get; set; }
        public string LinkText { get; set; }

    }
}