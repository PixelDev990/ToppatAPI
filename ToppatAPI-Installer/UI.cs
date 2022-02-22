using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToppatAPI
{
    class UI
    {
        public static void SetButtonsEnabled(bool isEnabled)
        {
            applyButton.Enabled = isEnabled;
            revertButton.Enabled = isEnabled;
            browseButton.Enabled = isEnabled;
        }
    }
}
