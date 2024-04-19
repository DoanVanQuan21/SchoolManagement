using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
//using System.Drawing.Imaging;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace SchoolManagement.UI.Controls.PropertyGrid.Editors
//{
//    public abstract class PropertyEditorBase : AvaloniaObject
//    {
//        public abstract Control CreateElemement(PropertyInfo propertyInfo);
//        public virtual void CreateBinding(PropertyInfo propertyInfo, AvaloniaObject element) =>
//            BindingOperations.Apply(element, GetAvaloniaProperty(), InstancedBinding($"{propertyInfo.Name}")
//            {
//                Source = propertyInfo.GetValue(null),
//                Converter = GetConverter(propertyInfo)
//            },null);
//        public abstract AvaloniaProperty GetAvaloniaProperty();
//        protected virtual IValueConverter GetConverter(PropertyInfo propertyInfo) => null;
//    }
//}
