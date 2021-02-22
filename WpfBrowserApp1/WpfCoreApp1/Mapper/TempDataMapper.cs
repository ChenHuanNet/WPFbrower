using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;
using WpfCoreApp1.Entity;

namespace WpfCoreApp1.Mapper
{
    public class TempDataMapper
    {
        XmlUtil xmlUtil;
        public TempDataMapper()
        {
            Uri uri = new Uri("/Data/tmpdata.xml", UriKind.Relative);//这个就是所以的pack uri。

            StreamResourceInfo info = Application.GetResourceStream(uri);
            Stream s = info.Stream;
            //byte[] buffer = new byte[1024 * 1024];
            //int length;
            //StringBuilder sb = new StringBuilder();
            //while ((length = s.Read(buffer, 0, buffer.Length)) > 0)
            //{
            //    sb.Append(Encoding.UTF8.GetString(buffer, 0, length));
            //}

            //用字符串读取，中文编码会报错
            //string xml = sb.ToString().Trim();

            xmlUtil = new XmlUtil(s);
        }

        public List<DesktopButtonVo> GetDesktopData()
        {
            List<DesktopButtonVo> buttons = xmlUtil.GetList<DesktopButtonVo>("/Root/DesktopButtonList", "Button");
            return buttons;
        }


        public List<GridData> GetManageData()
        {
            List<GridData> datas = xmlUtil.GetList<GridData>("/Root/ManageData", "Item");
            return datas;
        }
    }

}
