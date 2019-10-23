﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QPlanApp.Models
{
    public enum MenuItemType
    {
        Restaurants,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
