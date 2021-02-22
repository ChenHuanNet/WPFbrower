using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCoreApp1.Entity;
using WpfCoreApp1.Mapper;

namespace WpfCoreApp1.Sevices
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
