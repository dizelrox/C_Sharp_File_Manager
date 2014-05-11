using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
	public partial class MainForm : Form
	{
	    
		public MainForm()
		{
			InitializeComponent();
		}

        public SidePanel SidePanelLeft
        {
            get { return sidePanel1; }
        }

        public SidePanel SidePanelRight
        {
            get { return sidePanel2; }
        }

	}
}
