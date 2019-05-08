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
        string MainLink = @"https://www.avito.ru";
        string WAY = @"AvitoMonitor.db";
        string PATHtoIMG = @"Image Maker";
        string conectString = "Data Source=AvitoMonitor.db;Version=3;New=False;Compress=True;";
        string SEARCHstring = "https://www.avito.ru";
        string htmlCode;
        public AvitoMonitor(){
            InitializeComponent();
            Support.CreationOfDataBase(WAY);
            Support.CreationOfDirectory(PATHtoIMG);
        }

        private void button1_Click(object sender, EventArgs e){
            try { 
                using (WebClient client = new WebClient()){
                    if (comboBoxForCity.Text.Trim() != "") { 
                        SEARCHstring += "/" + Support.Cities[comboBoxForCity.Text];    
                    } else {
                        MessageBox.Show("Ошибка поиска, город не выбран",
                        "Вы должны выбрать город", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        SEARCHstring = "https://www.avito.ru";
                        return;
                    }
                    if (comboBoxType.Text.Trim() != "") { 
                        SEARCHstring += "/" + Support.Types[comboBoxType.Text];
                    } else {
                        MessageBox.Show("Ошибка поиска, категория не выбрана",
                        "Вы должны выбрать тип(категорию)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        SEARCHstring = "https://www.avito.ru";
                        return;
                    }
                    if (searchtextBox.Text.Replace(" ", "") != "") { 
                        SEARCHstring += "?s_trg=11&q=" + searchtextBox.Text;
                    } else if (searchtextBox.Text.Replace(" ", "") == "") {
                        SEARCHstring += "?s_trg=11";
                    } /*else {
                        MessageBox.Show("Ошибка поиска, текст поиска отсутствует",
                        "Вы должны ввести текст поиска", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        SEARCHstring = "https://www.avito.ru";
                        return;
                    }*/
                    
                    Support.CreationOfDataBase(WAY);
                    Support.CreationOfDirectory(PATHtoIMG);
                    richTextBox1.AppendText("Downloading... ");
                    try { 
                        htmlCode = client.DownloadString(SEARCHstring);
                    } catch {
                        richTextBox1.AppendText(SEARCHstring);
                        return;
                    }
                
                    richTextBox1.AppendText("ok.\n");

                    Encoding utf8 = Encoding.GetEncoding("UTF-8");
                    Encoding win1251 = Encoding.GetEncoding("Windows-1251");

                    byte[] utf8Bytes = win1251.GetBytes(htmlCode);
                    byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);

                    htmlCode = win1251.GetString(win1251Bytes);

                    CQ dom = htmlCode;
                    CQ items = dom.Select(".item");
                    int j = 0;
                    CQ title = dom.Select(".item-description-title-link");
                    CQ itemphoto = dom.Select(".large-picture-img");
                    CQ itemtime = dom.Select(".js-item-date");
                    for (int i = 0; i < items.Count(); i++) {
                        CQ item = items[i].InnerHTML;
                        if (item == null || title == null || itemphoto == null || itemtime == null) {
                            MessageBox.Show("Ошибка поиска, По вашему запросу ничего не найдено",
                            "Ничего не найдено", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            SEARCHstring = "https://www.avito.ru";
                            return;
                        }

                        richTextBox1.AppendText("***************\n");
                        try { 
                            richTextBox1.AppendText(title[i]["title"]);
                            richTextBox1.AppendText("\n");
                            richTextBox1.AppendText(Support.ImageString + itemphoto[j]["src"]);
                            j += item.Select(".large-picture-img").Count();
                            richTextBox1.AppendText("\n");
                            richTextBox1.AppendText(DateTime.Now.ToString());
                            richTextBox1.AppendText(item[".price"].Text().Replace("?", ""));
                            richTextBox1.AppendText("\n");
                            richTextBox1.AppendText(itemtime[i]["data-relative-date"]);
                            richTextBox1.AppendText("\n");
                            richTextBox1.AppendText(title[i]["href"]);

                            if (title[i]["title"] != "" && itemphoto[i]["src"] != "" &&
                                item[".price"].Text().Replace("?", "").Replace(" ", "") != "" &&
                                itemtime[i]["data-relative-date"] != "" && title[i]["href"] != "") {
                                string path = AppDomain.CurrentDomain.BaseDirectory +
                                        @"\" + PATHtoIMG + @"\" + "img.jpg";
                                using (WebClient clientimg = new WebClient()){

                                    client.DownloadFile(Support.ImageString + itemphoto[j]["src"], 
                                        path);
                                    FileInfo _imgInfo = new FileInfo(path);
                                    long _numBytes = _imgInfo.Length;
                                    FileStream _fileStream = new FileStream(path, FileMode.Open, FileAccess.Read); // читаем изображение
                                    BinaryReader _binReader = new BinaryReader(_fileStream);
                                    byte[] _imageBytes = _binReader.ReadBytes((int)_numBytes); // изображение в байтах

                                    string imgFormat = Path.GetExtension(path).Replace(".", "").ToLower(); // запишем в переменную расширение изображения в нижнем регистре, не забыв удалить точку перед расширением, получим «jpg»
                                    string imgName = Path.GetFileName(path).Replace(Path.GetExtension(path), ""); // запишем в переменную имя файла, не забыв удалить расширение с точкой, получим «img»

                                    // записываем информацию в базу данных


                                    using (SQLiteConnection Connect = new SQLiteConnection(
                                        @"Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"\" 
                                        + WAY + @"; Version=3;")){
                                        // в запросе есть переменные, они начинаются на @, обратите на это внимание
                                        string commandText = "INSERT INTO [AvitoMonitor] ([Время], [Название], [Цена], [Город], [Опубликовано], [Тип], [Картинка], [Формат картинки], [Ссылка на Объявление]) " +
                                            "VALUES(@time, @name, @price, @city, @addtime, @type, @image, @format, @add_link)";
                                        SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
                                        Command.Parameters.AddWithValue("@time", DateTime.Now.ToString());
                                        Command.Parameters.AddWithValue("@name", title[i]["title"]);
                                        Command.Parameters.AddWithValue("@price", item[".price"].Text().Replace("?", "P"));
                                        Command.Parameters.AddWithValue("@city", comboBoxForCity.Text);
                                        Command.Parameters.AddWithValue("@addtime", itemtime[i]["data-relative-date"]);
                                        Command.Parameters.AddWithValue("@type", comboBoxType.Text);
                                        Command.Parameters.AddWithValue("@image", _imageBytes); // присваиваем переменной значение
                                        Command.Parameters.AddWithValue("@format", imgFormat);
                                        Command.Parameters.AddWithValue("@add_link", MainLink + title[i]["href"]);
                                        Connect.Open();
                                        Command.ExecuteNonQuery();
                                        Connect.Close();


                                    }
                                    _fileStream.Close();
                                    File.Delete(path);
                                }
                                
                                
                            } 



                            Support.ImageStringDefault();
                        } catch (Exception ex){ 
                            //MessageBox.Show(ex.Message);
                            continue;
                        }
                        richTextBox1.AppendText("\n");
                    }
                }
            } catch (Exception) {
                MessageBox.Show("Нет соеденения с интернетом",
                    "Подключение к сети отсутствует", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        void ExecuteQuery(string txtQuery) {
            using(SQLiteConnection connection = new SQLiteConnection(conectString)) {
                SQLiteCommand command = new SQLiteCommand();
                command = connection.CreateCommand();
                command.CommandText = txtQuery;
                command.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
                command.Dispose();
                command = null;
            }
        }
        void LoadData() {
            using(SQLiteConnection connection = new SQLiteConnection(conectString)) {
                SQLiteCommand command = connection.CreateCommand();
                string ComandText = "select *from AvitoMonitor";
                SQLiteDataAdapter DB = new SQLiteDataAdapter(ComandText, connection);
                DataSet DS = new DataSet();
                DS.Reset();
                DB.Fill(DS);
                DataTable DT;
                DT = DS.Tables[0];
                dataGridView1.DataSource = DT;
                DT = null;
                DS = null;
                DB = null;
                command = null;
                connection.Close();
                connection.Dispose();
            }
        }

        private void AvitoMonitor_Load(object sender, EventArgs e){
            this.WindowState = FormWindowState.Maximized;
            dataGridView1.Width = ClientSize.Width/3*2;
            dataGridView1.Height = ClientSize.Height/4*3;
        }

        private void loadbd_Click(object sender, EventArgs e){
            if (!File.Exists(WAY))
                Support.CreationOfDataBase(WAY);
            LoadData();
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();

            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
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
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
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

        private void копироватьБазуДанныхToolStripMenuItem_Click(object sender, EventArgs e){
            if (true){
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.InitialDirectory = @"C:\";
                savedialog.Title = "Сохранить Базу Данных как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "DataBase files(*.db)|*.db";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) { 
                    try{
                        string sourcePath = AppDomain.CurrentDomain.BaseDirectory;
                        string targetPath = Path.GetFullPath(savedialog.FileName);
                        string sourceFile = Path.Combine(sourcePath, WAY);
                        string destFile = Path.Combine(targetPath, savedialog.FileName);
                        File.Copy(sourceFile, destFile, true);
                    } catch (Exception ex){
                        MessageBox.Show("Невозможно сохранить базу данных, возможно вы её удалили \n" 
                            + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AvitoMonitor_Resize(object sender, EventArgs e){
            //dataGridView1.Size = new Size(this.Width, this.Height);
        }
    }
}