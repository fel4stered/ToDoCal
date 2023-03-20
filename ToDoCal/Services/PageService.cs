﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ToDoCal.Services
{
    public class PageService
    {
        public event Action<Page> onPageChanged;
        public void ChangePage(Page page) => onPageChanged?.Invoke(page);
        public DateTime SelectDate { get; set; }
}
}
