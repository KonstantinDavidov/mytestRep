using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FACCTS.Controls.Utils
{
    public class ListBoxBehavior
    {
        #region SelectedItems

        /// <summary>
        /// SelectedItems Attached Dependency Property
        /// </summary>
        private static readonly DependencyPropertyKey SelectedItemsPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly("SelectedItems", typeof(IList), typeof(ListBoxBehavior),
                new FrameworkPropertyMetadata((IList)null,
                    new PropertyChangedCallback(OnSelectedItemsChanged)));

        public static readonly DependencyProperty SelectedItemsProperty = SelectedItemsPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the SelectedItems property. This dependency property 
        /// indicates ....
        /// </summary>
        public static IList GetSelectedItems(DependencyObject d)
        {
            return (IList)d.GetValue(SelectedItemsProperty);
        }

        public static IList SetSelectedItems(DependencyObject d)
        {
            throw new Exception("This property is read-only. To bind to it you must use 'Mode=OneWayToSource'.");
        }

        

        /// <summary>
        /// Handles changes to the SelectedItems property.
        /// </summary>
        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListBox lb = d as ListBox;
            if (lb == null)
                return;
            lb.SelectionChanged += ListBox_SelectionChanged;


            IList oldSelectedItems = (IList)e.OldValue;
            IList newSelectedItems = (IList)d.GetValue(SelectedItemsProperty);
        }

        private static void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb == null)
                return;
            lb.SetValue(SelectedItemsPropertyKey, lb.SelectedItems);
        }

        #endregion

        
    }
}
