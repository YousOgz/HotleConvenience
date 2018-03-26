using System;
using System.Collections.Generic;
using System.Text;

namespace HotleConvenience.Lib.Xss
{
    public class XssInspector
    {
        public bool Check(string html) {
            return true;
        }

        public string GetSafeHtml(string html) {
            return html;
        }
    }
}
