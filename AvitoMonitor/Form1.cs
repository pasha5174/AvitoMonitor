using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using CsQuery;

namespace AvitoMonitor{
    public partial class AvitoMonitor : Form{
        string WAY = @"AvitoMonitor.db";
        string PATHtoIMG = @"Image Maker";
        string conectString = "Data Source=AvitoMonitor.db;Version=3;New=False;Compress=True;";
        string SEARCHstring = "https://www.avito.ru";
        string htmlCode;
        SQLiteConnection connection;
        SQLiteCommand command;
        SQLiteDataAdapter DB;
        DataSet DS = new DataSet();
        DataTable DT = new DataTable();
        public AvitoMonitor(){
            InitializeComponent();
            Support.CreationOfDataBase(WAY);
            Support.CreationOfDirectory(PATHtoIMG);
        }

        private void button1_Click(object sender, EventArgs e){
            using (WebClient client = new WebClient()){
                richTextBox1.AppendText("Downloading... ");
                htmlCode = client.DownloadString("https://www.avito.ru/sergiev_posad/bytovaya_elektronika?s_trg=11&q=монитор");
                richTextBox1.AppendText("ok.\n");

                Encoding utf8 = Encoding.GetEncoding("UTF-8");
                Encoding win1251 = Encoding.GetEncoding("Windows-1251");

                byte[] utf8Bytes = win1251.GetBytes(htmlCode);
                byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);

                htmlCode = win1251.GetString(win1251Bytes);

                CQ dom = htmlCode;
                CQ items = dom.Select(".item");

                for (int i = 0; i < items.Count(); i++) {
                    CQ item = items[i].InnerHTML;

                    CQ title = dom.Select(".item-description-title-link");
                    CQ itemphoto = dom.Select(".large-picture-img");
                     
                    richTextBox1.AppendText("***************\n");
                    try { 
                        richTextBox1.AppendText(title[i]["title"].Replace("в Сергиевом Посаде", ""));
                        richTextBox1.AppendText("\n");
                        richTextBox1.AppendText(Support.ImageString + itemphoto[i]["src"]);
                        Support.ImageStringDefault();
                    } catch (Exception){ 
                        continue;
                    }
                    richTextBox1.AppendText(" ");
                    richTextBox1.AppendText(item[".price"].Text().Replace("?",""));

                    richTextBox1.AppendText("\n");
                }
            }
        }
        void ExecuteQuery(string txtQuery) {
            SetConnection();
            command = new SQLiteCommand();
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = txtQuery;
            command.ExecuteNonQuery();
            connection.Close();
        }
        void LoadData() {
            SetConnection();
            connection.Open();
            command = connection.CreateCommand();
            string ComandText = "select *from AvitoMonitor";
            DB = new SQLiteDataAdapter(ComandText, connection);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            connection.Close();
        }
        void SetConnection() {
            connection = new SQLiteConnection(conectString);
        }

        private void AvitoMonitor_Load(object sender, EventArgs e){
            
        }

        private void loadbd_Click(object sender, EventArgs e){
            if (!File.Exists(WAY))
                Support.CreationOfDataBase(WAY);
            LoadData();
        }

        private void comboBoxType_KeyPress(object sender, KeyPressEventArgs e){
            ((ComboBox)sender).DroppedDown = true;
            if (char.IsControl(e.KeyChar))
                return;
            string Str = ((ComboBox)sender).Text.Substring(0, ((ComboBox)sender).SelectionStart) 
                + e.KeyChar.ToString();
            int Index = ((ComboBox)sender).FindStringExact(Str);
            if (Index == -1)
                Index = ((ComboBox)sender).FindString(Str);
            ((ComboBox)sender).SelectedIndex = Index;
            ((ComboBox)sender).SelectionStart = Str.Length;
            ((ComboBox)sender).SelectionLength = 
                ((ComboBox)sender).Text.Length - ((ComboBox)sender).SelectionStart;
            e.Handled = true;
        }

        private void comboBoxForCity_KeyPress(object sender, KeyPressEventArgs e){
            ((ComboBox)sender).DroppedDown = true;
            if (char.IsControl(e.KeyChar))
                return;
            string Str = ((ComboBox)sender).Text.Substring(0, ((ComboBox)sender).SelectionStart)
                + e.KeyChar.ToString();
            int Index = ((ComboBox)sender).FindStringExact(Str);
            if (Index == -1)
                Index = ((ComboBox)sender).FindString(Str);
            ((ComboBox)sender).SelectedIndex = Index;
            ((ComboBox)sender).SelectionStart = Str.Length;
            ((ComboBox)sender).SelectionLength =
                ((ComboBox)sender).Text.Length - ((ComboBox)sender).SelectionStart;
            e.Handled = true;
        }

        private void DeleteDB_Click(object sender, EventArgs e){
            if (File.Exists(WAY)){
                try { 
                    dataGridView1.DataSource = null;
                    DB.Dispose();
                    connection = null;
                    Support.DeleteDB(WAY);
                    MessageBox.Show("База данных успешно удалена", "Удаление прошло успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.None);
                } catch (Exception ex) { 
                    MessageBox.Show(ex.Message, "Ошибка при удалении базы данных", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Вы не можите удалить базу данных, которой не существует",
                    "Ошибка при удалении базы данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}