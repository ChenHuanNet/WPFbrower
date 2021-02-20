using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WpfUtils
{
    public class XmlUtil
    {
        XmlDocument doc;
        public XmlUtil(Stream stream)
        {
            doc = new XmlDocument();
            doc.Load(stream);
        }

        public List<T> GetList<T>(string xpath, string node)
        {
            List<T> list = new List<T>();
            XmlNode xn = doc.SelectSingleNode(xpath);
            XmlNodeList xnl = xn.ChildNodes;

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (object item in xnl)
            {
                XmlNode itemNode = (XmlNode)item;
                if (itemNode.Name.Equals(node))
                {
                    XmlNodeList propertyNodes = itemNode.ChildNodes;
                    //节点元素，有几个就是几项
                    foreach (var n in propertyNodes)
                    {
                        T model = Activator.CreateInstance<T>();
                        XmlNode pNode = (XmlNode)n;
                        foreach (var p in properties)
                        {
                            if (pNode.Name.Equals(p.Name))
                            {
                                p.SetValue(model, pNode.InnerText);
                                //typeof(T).InvokeMember(p.Name, BindingFlags.SetProperty, null, model, new object[] { pNode.InnerText });
                                break;
                            }
                        }
                        if (model != null)
                        {
                            list.Add(model);
                        }
                    }
                }
            }

            return list;
        }
    }
}
