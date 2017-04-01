using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShevaDorot
{
    public class ControlDirtyTrackerCollection : List<ControlDirtyTracker>
    {
        public ControlDirtyTrackerCollection() : base() { }
        public ControlDirtyTrackerCollection(Form frm) : base() { AddControlsFromForm(frm); }

        public void AddControlsFromForm(Form frm) { AddControlsFromCollection(frm.Controls); }

        public void AddControl(Control c)
        {
            if (ControlDirtyTracker.IsControlTypeSupported(c)) this.Add(new ControlDirtyTracker(c));
            if (c.HasChildren) AddControlsFromCollection(c.Controls);
        }

        public void AddControlsFromCollection(Control.ControlCollection coll) { coll.Cast<Control>().ForEach(c => AddControl(c)); }

        public List<Control> GetListOfDirtyControls() { return this.Where(cdt => cdt.DetermineIfDirty()).Select(cdt => cdt.Control).ToList(); }

        public void MarkAllControlsAsClean() { this.ForEach(cdt => cdt.EstablishValueAsClean()); }
    }
}
