using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dungeons_And_Dragon_Management
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            DDClient clientConnection = new DDClient("127.0.0.1", 1234);
        }
    }
}
