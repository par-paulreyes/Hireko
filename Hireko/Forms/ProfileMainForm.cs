using Hireko.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hireko.Forms
{
    public partial class ProfileMainForm : Form
    {
        private string connectionString = DatabaseInitializer.GetConnectionString();

        public ProfileMainForm()
        {
            InitializeComponent();
        }

        private void ProfileMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
