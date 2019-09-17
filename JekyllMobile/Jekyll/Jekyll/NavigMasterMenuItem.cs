using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jekyll
{

    public class NavigMasterMenuItem
    {
        public NavigMasterMenuItem()
        {
            TargetType = typeof(NavigMasterMenuItem);
        }
        public string Title { get; set; }
        public string Image { get; set; }

        public Type TargetType { get; set; }
    }
}