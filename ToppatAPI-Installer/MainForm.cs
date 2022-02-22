using ToppatAPI.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToppatAPI
{
    public partial class ToppatAPI : Form
    {
        ApplyHandler  apply;
        BrowseHandler browse;
        RevertHandler revert;

        public ToppatAPI()
        {
            InitializeComponent();

            this.apply  = new ApplyHandler(applyButton);
            this.browse = new BrowseHandler(browseButton, mapLabel);
            this.revert = new RevertHandler(revertButton);
        }
    }
}
