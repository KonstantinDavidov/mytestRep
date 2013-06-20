using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace FACCTS.Controls
{
    public class ExtendedDatePicker : DatePicker
    {
        public static readonly DependencyProperty EditableProperty = DependencyProperty.Register("Editable", typeof(bool),
            typeof(ExtendedDatePicker), new PropertyMetadata(true));
        public bool Editable
        {
            get { return (bool)GetValue(EditableProperty); }
            set { SetValue(EditableProperty, value); }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var textBox = GetTemplateChild("PART_TextBox") as DatePickerTextBox;
            var binding = new Binding { Source = this, Path = new PropertyPath(ExtendedDatePicker.EditableProperty) };
            textBox.SetBinding(DatePickerTextBox.FocusableProperty, binding);
            var button = GetTemplateChild("PART_Button") as Button;
            button.SetBinding(Button.IsEnabledProperty, new Binding()
                {
                    Source = this,
                    Path = new PropertyPath(ExtendedDatePicker.EditableProperty)
                });
        }
    }
}
