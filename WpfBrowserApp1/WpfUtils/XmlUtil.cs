using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WpfUtils.Vo;

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
                    T model = Activator.CreateInstance<T>();
                    //节点元素，有几个就是几项
                    foreach (var n in propertyNodes)
                    {
                        XmlNode pNode = (XmlNode)n;
                        foreach (var p in properties)
                        {
                            if (pNode.Name.Equals(p.Name))
                            {
                                //记录事件信息
                                if (pNode.Name.Equals("Events"))
                                {
                                    List<EventVo> events = new List<EventVo>();
                                    PropertyInfo[] eventProperties = typeof(EventVo).GetProperties();
                                    EventVo eventVo = new EventVo();
                                    foreach (var itemEvent in pNode.ChildNodes)
                                    {
                                        XmlNode rootEvents = (XmlNode)itemEvent;
                                        XmlNodeList xnlEvents = rootEvents.ChildNodes;

                                        foreach (var detailEvent in xnlEvents)
                                        {
                                            XmlNode de = (XmlNode)detailEvent;
                                            foreach (PropertyInfo eventProperty in eventProperties)
                                            {
                                                if (de.Name.Equals(eventProperty.Name))
                                                {
                                                    if (eventProperty.PropertyType.IsAssignableFrom(typeof(string)))
                                                        eventProperty.SetValue(eventVo, de.InnerText);
                                                }
                                            }
                                        }
                                        events.Add(eventVo);
                                    }

                                    p.SetValue(model, events);
                                }
                                else
                                {
                                    if (p.PropertyType.IsAssignableFrom(typeof(string)))
                                    {
                                        p.SetValue(model, pNode.InnerText);
                                        //typeof(T).InvokeMember(p.Name, BindingFlags.SetProperty, null, model, new object[] { pNode.InnerText });
                                    }
                                    else if (p.PropertyType.IsAssignableFrom(typeof(bool)))
                                    {
                                        bool.TryParse(pNode.InnerText, out bool result);
                                        p.SetValue(model, result);
                                    }
                                    //....其他先不加了
                                }
                                break;
                            }
                        }

                    }
                    if (model != null)
                    {
                        list.Add(model);
                    }
                }
            }

            return list;
        }


    }
}
