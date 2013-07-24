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

namespace FACCTS.Controls.Views.Controls
{
	/// <summary>
	/// Interaction logic for PartyControlView.xaml
	/// </summary>
	public partial class PartyControlView : UserControl
	{
		public PartyControlView()
		{
			this.InitializeComponent();
		}

        #region IsParty1

        /// <summary>
        /// IsParty1 Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsParty1Property =
            DependencyProperty.Register("IsParty1", typeof(bool), typeof(PartyControlView),
                new FrameworkPropertyMetadata((bool)true));

        /// <summary>
        /// Gets or sets the IsParty1 property. This dependency property 
        /// indicates ....
        /// </summary>
        public bool IsParty1
        {
            get { return (bool)GetValue(IsParty1Property); }
            set { SetValue(IsParty1Property, value); }
        }

        #endregion



        
        
	}
}