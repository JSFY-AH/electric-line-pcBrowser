using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public partial class Form1 : Form
    {
        public string[] desc = new string[100];
        public string[] status = new string[100];
        public void getData(int res)
        {
            string[] status_arr = { "正常", "短路", "接地" };
            for(int i = 0; i < 100; ++i)
            {
                desc[i] = "DescrptionFor" + i.ToString() + "<br>TEST";
            }
            Random random = new Random();
            for(int i = 0; i < 100; ++i)
            {
                int id = random.Next(0, 3);
                status[i] = status_arr[id];
            }
            string qr = desc[res];
            string qs = status[res];
            this.webBrowser1.Document.InvokeScript("updateNodeDesc", new object[] { qr });
            this.webBrowser1.Document.InvokeScript("updateNodeStatus", new object[] { qs });
        }
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ObjectForScripting = this;
            //string path = Application.StartupPath + @"\test.html";
            string path = "http://localhost:8089/graph?line_id=3&edit_right=1";
            //path = "http://www.jtopo.com/demo/helloworld.html";
            this.webBrowser1.Url = new System.Uri(path, System.UriKind.Absolute);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Document.InvokeScript("getNodeList", new object[] { "ce", "pl", "a", "b", "c" });
            Console.WriteLine("xxxxxxxxxxxxxxxxxxx");
            //Console.WriteLine(node_id_list);
            //MessageBox.Show(node_id_list.ToString());
        }
    }
}
