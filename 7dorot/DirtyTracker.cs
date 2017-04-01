using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShevaDorot
{
    public class DirtyTracker
    {
        private Form frmTracked;
        private ControlDirtyTrackerCollection controlsTracked;

        public bool IsDirty { get { return controlsTracked.Any(cdt => cdt.DetermineIfDirty()); } }

        public List<Control> GetListOfDirtyControls() { return controlsTracked.GetListOfDirtyControls(); }

        public void MarkAsClean() { controlsTracked.MarkAllControlsAsClean(); }

        public DirtyTracker(Form frm)
        {
            frmTracked = frm;
            controlsTracked = new ControlDirtyTrackerCollection(frm);
        }

        internal void AddControlToTrack(Control c) { controlsTracked.AddControl(c); }
    }
}
