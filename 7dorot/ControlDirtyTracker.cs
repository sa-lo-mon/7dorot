using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShevaDorot
{

    public class ControlDirtyTracker
    {
        public Control Control { get; set; }
        public string CleanValue { get; private set; }

        public static bool IsControlTypeSupported(Control ctl)
        {
            var Supported = new[] { typeof(TextBox), typeof(CheckBox), typeof(ComboBox), typeof(ListBox) };
            return Supported.Any(t => ctl.GetType() == t);
        }

        private string GetControlCurrentValue()
        {
            if (Control is TextBox) return (Control as TextBox).Text;
            if (Control is CheckBox) return (Control as CheckBox).Checked.ToString();
            if (Control is ComboBox) return (Control as ComboBox).Text;
            if (Control is ListBox) return (Control as ListBox).SelectedIndices.Cast<object>().Aggregate("", (s, w) => s += w.ToString() + ";");
            return "";
        }

        public ControlDirtyTracker(Control ctl)
        {
            if (ControlDirtyTracker.IsControlTypeSupported(ctl))
            {
                Control = ctl;
                CleanValue = GetControlCurrentValue();
            }
            else
                throw new NotSupportedException(string.Format("The control type for '{0}' is not supported by the ControlDirtyTracker class.", ctl.Name));
        }

        public void EstablishValueAsClean() { CleanValue = GetControlCurrentValue(); }


        public bool DetermineIfDirty() { return (string.Compare(CleanValue, GetControlCurrentValue(), false) != 0); }
    }
}
