using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaVentasApp.Controllers;

namespace SistemaVentasApp.Views
{
    public partial class ClienteForm : Form
    {
        private readonly ApiClient _apiClient;

        public ClienteForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }
    }
}
