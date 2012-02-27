using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Bti.Babble.Traffic
{
    /// <summary>
    /// Interaction logic for CircularButton.xaml
    /// </summary>
    public partial class CircularButton : UserControl
    {
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
            "Icon", 
            typeof(string), 
            typeof(CircularButton));

        public string Data
        {
            get { return (string)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public CircularButton()
        {
            InitializeComponent();
        }
    }
}
