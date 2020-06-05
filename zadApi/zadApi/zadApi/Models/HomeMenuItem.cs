﻿using System;
using System.Collections.Generic;
using System.Text;

namespace zadApi.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Covid
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
