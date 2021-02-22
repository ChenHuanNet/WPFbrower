using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBrowserApp1.Entity;
using WpfBrowserApp1.Mapper;

namespace WpfBrowserApp1.Sevices
{
    public class ManageSevice
    {
        TempDataMapper tempDataMapper;
        public ManageSevice()
        {
            tempDataMapper = new TempDataMapper();
        }

        public List<GridData> GetManageData()
        {
            var datas = tempDataMapper.GetManageData();
            return datas;
        }
    }
}
