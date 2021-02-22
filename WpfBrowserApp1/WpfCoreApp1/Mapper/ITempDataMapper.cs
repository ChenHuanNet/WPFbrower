using System;
using System.Collections.Generic;
using System.Text;
using WpfCoreApp1.Entity;

namespace WpfCoreApp1.Mapper
{
    public interface ITempDataMapper
    {
        List<DesktopButtonVo> GetDesktopData();


        List<GridData> GetManageData();
      
    }
}
