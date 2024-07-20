using Jamesnet.Wpf.Controls;
using System.Windows;

namespace WpfExplorer.Support.UI.Units
{
    public class DarkWindow : JamesWindow
    {
        // commit test
        static DarkWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkWindow), new FrameworkPropertyMetadata(typeof(DarkWindow)));
        }
    }
}
