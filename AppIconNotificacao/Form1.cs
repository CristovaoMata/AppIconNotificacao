using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppIconNotificacao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RegisterInStartup();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Esconder o formulário ao iniciar
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;

            // Configurar o NotifyIcon
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Visible = true;
            notifyIcon1.Text = "Minha Aplicação em Segundo Plano";

            // Adicionar menu de contexto
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Sair");
            exitMenuItem.Click += ExitMenuItem_Click;
            contextMenu.Items.Add(exitMenuItem);
            notifyIcon1.ContextMenuStrip = contextMenu;
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false; // Esconder o ícone da área de notificação
            Application.Exit();
        }

        private void RegisterInStartup()
        {
            string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKey, true))
            {
                key.SetValue("BackgroundApp", "\"" + Application.ExecutablePath + "\"");
            }
        }

        
    }
}
