using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfBrowserApp1.Mapper;
using WpfCustomControlLibrary1;

namespace WpfBrowserApp1
{
    public class DesktopSevice
    {
        TempDataMapper tempDataMapper;

        public DesktopSevice()
        {
            tempDataMapper = new TempDataMapper();
        }


        public void AutoCreateDesktopButton(Canvas canvas, double width, double height)
        {
            List<DesktopButtonVo> buttons = tempDataMapper.GetDesktopData();

            int i = 0;
            int left = 20;
            int top = 20;
            foreach (DesktopButtonVo item in buttons)
            {
                i++;
                IconButton iconButton = new IconButton();
                iconButton.Name = "iconButton" + i;
                iconButton.Margin = new Thickness(left, top, 0, 0);
                if (string.IsNullOrWhiteSpace(item.Icon))
                {
                    ResourceDictionary resource = (from dict in Application.Current.Resources.MergedDictionaries
                                                   where dict.Contains("DesktopIcon")
                                                   select dict).FirstOrDefault();

                    if (resource != null && resource["DesktopIcon"] != null)
                    {
                        iconButton.Icon = resource["DesktopIcon"].ToString();
                    }
                }
                else
                {
                    iconButton.Icon = item.Icon;
                }

                iconButton.Height = 100;
                iconButton.Width = 80;
                iconButton.VerticalAlignment = VerticalAlignment.Top;
                iconButton.HorizontalAlignment = HorizontalAlignment.Left;
                iconButton.Content = item.Title;
                iconButton.IsDrag = item.IsDrag;

                if (iconButton.Margin.Top > height - 120)
                {
                    top = 20;
                    left += 100;
                    iconButton.Margin = new Thickness(left, top, 0, 0);
                }


                while (true)
                {
                    bool isFind = false;
                    UIElementCollection children = canvas.Children;
                    foreach (UIElement child in children)
                    {
                        Control c = (Control)child;
                        if (c.Margin.Top == top && c.Margin.Left == left && c.Name != iconButton.Name)
                        {
                            isFind = true;

                            top += 120;
                            if (top > height - 120)
                            {
                                top = 20;
                                left += 100;
                            }

                            break;
                        }
                    }

                    if (!isFind)
                    {
                        break;
                    }
                }

                top += 120;

                if (item.Events != null)
                {
                    foreach (var itemEvent in item.Events)
                    {
                        if (itemEvent.EventType.Equals("DoubleClick"))
                        {
                            if (itemEvent.EventName.Equals("OpenNewWindow"))
                            {
                                string windowName = itemEvent.WindowName;
                                string namespaceName = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;
                                iconButton.AddHandler(Button.MouseDoubleClickEvent, new MouseButtonEventHandler((o, e) =>
                                {
                                    Type type = Type.GetType(namespaceName + "." + windowName);
                                    object obj = Activator.CreateInstance(type);
                                    Window window = (Window)obj;
                                    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                                    window.Show();
                                }), true);//注册事件 
                            }
                        }
                    }
                }

                canvas.Children.Add(iconButton);
            }
        }
    }
}
