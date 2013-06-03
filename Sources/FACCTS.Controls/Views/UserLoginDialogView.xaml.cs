using FACCTS.Controls.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FACCTS.Controls
{
	/// <summary>
	/// Interaction logic for UserLoginDialogView.xaml
	/// </summary>

    [Export(typeof(IPasswordSupplier))]
	public partial class UserLoginDialogView : Window, IPasswordSupplier
	{
		public UserLoginDialogView()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        public string GetPassword()
        {
            return this.UserLoginView.PasswordBox.Password;
        }
    }
}