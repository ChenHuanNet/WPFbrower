using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfCoreApp1
{
    public class DesktopButtonVo
    {
        public string Title { get; set; }

        public string Icon { get; set; }

        public bool IsDrag { get; set; }


        public List<EventVo> Events { get; set; }
    }
}
