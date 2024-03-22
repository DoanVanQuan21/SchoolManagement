﻿using Avalonia.Controls;

namespace SchoolManagement.Core.Models
{
    public class AppMenu
    {
        public string? Label { get; set; }
        public string? ViewName { get; set; }
        public Type? Type { get; set; }
        public UserControl? View => (UserControl)Activator.CreateInstance(Type);
        public string? Geometry { get; set; }
    }
}