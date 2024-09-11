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

namespace ValheimServer.Components
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml.
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        /// <summary>
        /// Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register(
                "Password",
                typeof(string),
                typeof(BindablePasswordBox),
                new PropertyMetadata(string.Empty, PasswordPropertyChanged));

        private bool _isPasswordChanging;

        /// <summary>
        /// Initializes a new instance of the <see cref="BindablePasswordBox"/> class.
        /// </summary>
        public BindablePasswordBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindablePasswordBox passwordBox)
            {
                passwordBox.UpdatePassword();
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _isPasswordChanging = true;
            Password = passwordBox.Password;
            _isPasswordChanging = false;
        }

        private void UpdatePassword()
        {
            if (!_isPasswordChanging)
            {
                passwordBox.Password = Password;
            }
        }
    }
}
