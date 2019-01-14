using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using CsQuery;

namespace AvitoMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                richTextBox1.AppendText("Downloading... ");
                string htmlCode = client.DownloadString("https://www.avito.ru/sergiev_posad/bytovaya_elektronika?s_trg=11&q=монитор");
                richTextBox1.AppendText("ok.\n");

                Encoding utf8 = Encoding.GetEncoding("UTF-8");
                Encoding win1251 = Encoding.GetEncoding("Windows-1251");

                byte[] utf8Bytes = win1251.GetBytes(htmlCode);
                byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);

                htmlCode = win1251.GetString(win1251Bytes);

                CQ dom = htmlCode;
                CQ items = dom.Select(".item");

                for (int i = 0; i < items.Count(); i++) {
                    CQ itm = items[i].InnerHTML;

                    CQ title = dom.Select(".item-description-title-link");
                    
                    richTextBox1.AppendText("***************\n");
                    richTextBox1.AppendText(title[0]["title"]);
                    richTextBox1.AppendText(" ");
                    richTextBox1.AppendText(itm[".price"].Text());

                    richTextBox1.AppendText("\n");
                }
            }
        }
    }
}
