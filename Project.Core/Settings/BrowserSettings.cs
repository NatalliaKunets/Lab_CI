using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Enums;

namespace Project.Core.Settings
{
    public class BrowserSettings
	{
        public BrowserType browserType{ get; set; }
        public string URL { get; set; }
    }
}
