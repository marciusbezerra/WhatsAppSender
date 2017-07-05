using System;
using System.Text;
using System.Windows.Forms;
using WhatsAppApi;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var from = "85988559171";
            var to = textBox1.Text;
            var msg = textBox2.Text;

            var whatsApp = new WhatsApp(from, "%a0%c2%06%29rz%16%3f%f5%0a%cef%81%5dd%20%7dd%cb", "Marcius", false, false);

            whatsApp.OnConnectSuccess += () =>
            {
                MessageBox.Show("Contectado ao Whatsapp!");
            };

            whatsApp.OnLoginSuccess += (number, data) =>
            {
                whatsApp.SendMessage(to, msg);
                MessageBox.Show("Mensagem enviada! " + Encoding.ASCII.GetString(data));
            };

            whatsApp.OnLoginFailed += data =>
            {
                MessageBox.Show("Erro no login: " + data);
            };

            whatsApp.Login();

        }
    }
}
