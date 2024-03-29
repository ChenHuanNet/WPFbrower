﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCoreApp1.Entity;
using WpfCoreApp1.Mapper;

namespace WpfCoreApp1.Sevices
{
    public class ManageSevice
    {
        public ITempDataMapper tempDataMapper { get; set; }
        public ManageSevice()
        {

        }

        public List<GridData> GetManageData()
        {
            var datas = tempDataMapper.GetManageData();
            return datas;
        }


        public ObservableCollection<GridData> GetObservableData()
        {
            ObservableCollection<GridData> samplePersons = new ObservableCollection<GridData>();
            var datas = GetManageData();
            foreach (var item in datas)
            {
                samplePersons.Add(item);
            }
            return samplePersons;
        }
    }
}
