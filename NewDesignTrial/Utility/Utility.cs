using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace NewDesignTrial.Utility
{
    class Utility
    {
        public static string validEmptyInput(Grid data)
        {
            string message = null;
            foreach (Control ctl in data.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)ctl;
                    if (tb.Text.Length == 0)
                    {
                        message = message + "Please enter value for " + tb.Uid + "\n";
                        tb.Background = Brushes.Aqua;
                    }
                    else
                    {
                        tb.Background = Brushes.White;
                    }
                }
            }
            return message;
        }
    }
}
