using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for AttorneysPartyView.xaml
    /// </summary>
    public partial class AttorneysPartyView : UserControl
    {
        public AttorneysPartyView()
        {
            InitializeComponent();
        }

        #region DisplayName

        /// <summary>
        /// DisplayName Dependency Property
        /// </summary>
        public static readonly DependencyProperty DisplayNameProperty =
            DependencyProperty.Register("DisplayName", typeof(string), typeof(AttorneysPartyView),
                new FrameworkPropertyMetadata("AttorneysPartyView"));

        /// <summary>
        /// Gets or sets the DisplayName property. This dependency property 
        /// indicates ....
        /// </summary>
        public string DisplayName
        {
            get { return (string)GetValue(DisplayNameProperty); }
            set { SetValue(DisplayNameProperty, value); }
        }

        #endregion

        
    }
}
