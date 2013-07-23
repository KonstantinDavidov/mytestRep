using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FACCTS.Controls
{
	/// <summary>
	/// Interaction logic for RestrainingPartyIDInfoControlView.xaml
	/// </summary>
	public partial class RestrainingPartyIDInfoControlView : UserControl
	{
		public RestrainingPartyIDInfoControlView()
		{
			this.InitializeComponent();
		}

        #region IDTypeItemsSource

        /// <summary>
        /// IDTypeItemsSource Dependency Property
        /// </summary>
        public static readonly DependencyProperty IDTypeItemsSourceProperty =
            DependencyProperty.Register("IDTypeItemsSource", typeof(System.Collections.IEnumerable), typeof(RestrainingPartyIDInfoControlView),
                new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the IDTypeItemsSource property. This dependency property 
        /// indicates ....
        /// </summary>
        public System.Collections.IEnumerable IDTypeItemsSource
        {
            get { return (System.Collections.IEnumerable)GetValue(IDTypeItemsSourceProperty); }
            set { SetValue(IDTypeItemsSourceProperty, value); }
        }

        #endregion

        
	}
}