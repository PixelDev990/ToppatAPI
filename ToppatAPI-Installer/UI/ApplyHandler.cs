﻿using ToppatAPI.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToppatAPI.UI
{
    class ApplyHandler
    {
        private Button applyButton;

        public ApplyHandler(Button applyButton)
        {

            this.applyButton = applyButton;
            this.applyButton.Click += new System.EventHandler(this.onClick);
            MapHandler.onLoad += this.onLoad;
        }

        public void onClick(object sender, EventArgs e)
        {
            this.applyButton.Enabled = false;
            MapApplicator.Apply();
            this.applyButton.Enabled = true;
        }

        public void onLoad(object sender, EventArgs e)
        {
            this.applyButton.Enabled = true;
        }
    }
}
