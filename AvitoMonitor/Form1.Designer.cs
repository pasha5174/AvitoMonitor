namespace AvitoMonitor
{
    partial class AvitoMonitor
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.search = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.searchtextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.loadbd = new System.Windows.Forms.Button();
            this.comboBoxForCity = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(447, 15);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 0;
            this.search.Text = "Поиск";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(429, 460);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // searchtextBox
            // 
            this.searchtextBox.Location = new System.Drawing.Point(12, 15);
            this.searchtextBox.Name = "searchtextBox";
            this.searchtextBox.Size = new System.Drawing.Size(429, 20);
            this.searchtextBox.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(447, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(603, 460);
            this.dataGridView1.TabIndex = 3;
            // 
            // loadbd
            // 
            this.loadbd.Location = new System.Drawing.Point(528, 15);
            this.loadbd.Name = "loadbd";
            this.loadbd.Size = new System.Drawing.Size(143, 23);
            this.loadbd.TabIndex = 4;
            this.loadbd.Text = "Загрузить базу данных";
            this.loadbd.UseVisualStyleBackColor = true;
            this.loadbd.Click += new System.EventHandler(this.loadbd_Click);
            // 
            // comboBoxForCity
            // 
            this.comboBoxForCity.FormattingEnabled = true;
            this.comboBoxForCity.Items.AddRange(new object[] {
            "Абакан",
            "Азов",
            "Александров",
            "Алексин",
            "Альметьевск",
            "Анапа",
            "Ангарск",
            "Анжеро-Судженск",
            "Апатиты",
            "Арзамас",
            "Армавир",
            "Арсеньев",
            "Артем",
            "Архангельск",
            "Асбест",
            "Астрахань",
            "Ачинск",
            "Балаково",
            "Балахна",
            "Балашиха",
            "Балашов",
            "Барнаул",
            "Батайск",
            "Белгород",
            "Белебей",
            "Белово",
            "Белогорск (Амурская область)",
            "Белорецк",
            "Белореченск",
            "Бердск",
            "Березники",
            "Березовский (Свердловская область)",
            "Бийск",
            "Биробиджан",
            "Благовещенск (Амурская область)",
            "Бор",
            "Борисоглебск",
            "Боровичи",
            "Братск",
            "Брянск",
            "Бугульма",
            "Буденновск",
            "Бузулук",
            "Буйнакск",
            "Великие Луки",
            "Великий Новгород",
            "Верхняя Пышма",
            "Видное",
            "Владивосток",
            "Владикавказ",
            "Владимир",
            "Волгоград",
            "Волгодонск",
            "Волжск",
            "Волжский",
            "Вологда",
            "Вольск",
            "Воркута",
            "Воронеж",
            "Воскресенск",
            "Воткинск",
            "Всеволожск",
            "Выборг",
            "Выкса",
            "Вязьма",
            "Гатчина",
            "Геленджик",
            "Георгиевск",
            "Глазов",
            "Горно-Алтайск",
            "Грозный",
            "Губкин",
            "Гудермес",
            "Гуково",
            "Гусь-Хрустальный",
            "Дербент",
            "Дзержинск",
            "Димитровград",
            "Дмитров",
            "Долгопрудный",
            "Домодедово",
            "Донской",
            "Дубна",
            "Евпатория",
            "Егорьевск",
            "Ейск",
            "Екатеринбург",
            "Елабуга",
            "Елец",
            "Ессентуки",
            "Железногорск (Красноярский край)",
            "Железногорск (Курская область)",
            "Жигулевск",
            "Жуковский",
            "Заречный",
            "Зеленогорск",
            "Зеленодольск",
            "Златоуст",
            "Иваново",
            "Ивантеевка",
            "Ижевск",
            "Избербаш",
            "Иркутск",
            "Искитим",
            "Ишим",
            "Ишимбай",
            "Йошкар-Ола",
            "Казань",
            "Калининград",
            "Калуга",
            "Каменск-Уральский",
            "Каменск-Шахтинский",
            "Камышин",
            "Канск",
            "Каспийск",
            "Кемерово",
            "Керчь",
            "Кинешма",
            "Кириши",
            "Киров (Кировская область)",
            "Кирово-Чепецк",
            "Киселевск",
            "Кисловодск",
            "Клин",
            "Клинцы",
            "Ковров",
            "Когалым",
            "Коломна",
            "Комсомольск-на-Амуре",
            "Копейск",
            "Королев",
            "Кострома",
            "Котлас",
            "Красногорск",
            "Краснодар",
            "Краснокаменск",
            "Краснокамск",
            "Краснотурьинск",
            "Красноярск",
            "Кропоткин",
            "Крымск",
            "Кстово",
            "Кузнецк",
            "Кумертау",
            "Кунгур",
            "Курган",
            "Курск",
            "Кызыл",
            "Лабинск",
            "Лениногорск",
            "Ленинск-Кузнецкий",
            "Лесосибирск",
            "Липецк",
            "Лиски",
            "Лобня",
            "Лысьва",
            "Лыткарино",
            "Люберцы",
            "Магадан",
            "Магнитогорск",
            "Майкоп",
            "Махачкала",
            "Междуреченск",
            "Мелеуз",
            "Миасс",
            "Минеральные Воды",
            "Минусинск",
            "Михайловка",
            "Михайловск (Ставропольский край)",
            "Мичуринск",
            "Москва",
            "Мурманск",
            "Муром",
            "Мытищи",
            "Набережные Челны",
            "Назарово",
            "Назрань",
            "Нальчик",
            "Наро-Фоминск",
            "Находка",
            "Невинномысск",
            "Нерюнгри",
            "Нефтекамск",
            "Нефтеюганск",
            "Нижневартовск",
            "Нижнекамск",
            "Нижний Новгород",
            "Нижний Тагил",
            "Новоалтайск",
            "Новокузнецк",
            "Новокуйбышевск",
            "Новомосковск",
            "Новороссийск",
            "Новосибирск",
            "Новотроицк",
            "Новоуральск",
            "Новочебоксарск",
            "Новочеркасск",
            "Новошахтинск",
            "Новый Уренгой",
            "Ногинск",
            "Норильск",
            "Ноябрьск",
            "Нягань",
            "Обнинск",
            "Одинцово",
            "Озерск (Челябинская область)",
            "Октябрьский",
            "Омск",
            "Орел",
            "Оренбург",
            "Орехово-Зуево",
            "Орск",
            "Павлово",
            "Павловский Посад",
            "Пенза",
            "Первоуральск",
            "Пермь",
            "Петрозаводск",
            "Петропавловск-Камчатский",
            "Подольск",
            "Полевской",
            "Прокопьевск",
            "Прохладный",
            "Псков",
            "Пушкино",
            "Пятигорск",
            "Раменское",
            "Ревда",
            "Реутов",
            "Ржев",
            "Рославль",
            "Россошь",
            "Ростов-на-Дону",
            "Рубцовск",
            "Рыбинск",
            "Рязань",
            "Салават",
            "Сальск",
            "Самара",
            "Санкт-Петербург",
            "Саранск",
            "Сарапул",
            "Саратов",
            "Саров",
            "Свободный",
            "Севастополь",
            "Северодвинск",
            "Северск",
            "Сергиев Посад",
            "Серов",
            "Серпухов",
            "Сертолово",
            "Сибай",
            "Симферополь",
            "Славянск-на-Кубани",
            "Смоленск",
            "Соликамск",
            "Солнечногорск",
            "Сосновый Бор",
            "Сочи",
            "Ставрополь",
            "Старый Оскол",
            "Стерлитамак",
            "Ступино",
            "Сургут",
            "Сызрань",
            "Сыктывкар",
            "Таганрог",
            "Тамбов",
            "Тверь",
            "Тимашевск",
            "Тихвин",
            "Тихорецк",
            "Тобольск",
            "Тольятти",
            "Томск",
            "Троицк",
            "Туапсе",
            "Туймазы",
            "Тула",
            "Тюмень",
            "Узловая",
            "Улан-Удэ",
            "Ульяновск",
            "Урус-Мартан",
            "Усолье-Сибирское",
            "Уссурийск",
            "Усть-Илимск",
            "Уфа",
            "Ухта",
            "Феодосия",
            "Фрязино",
            "Хабаровск",
            "Ханты-Мансийск",
            "Хасавюрт",
            "Химки",
            "Чайковский",
            "Чапаевск",
            "Чебоксары",
            "Челябинск",
            "Черемхово",
            "Череповец",
            "Черкесск",
            "Черногорск",
            "Чехов",
            "Чистополь",
            "Чита",
            "Шадринск",
            "Шали",
            "Шахты",
            "Шуя",
            "Щекино",
            "Щелково",
            "Электросталь",
            "Элиста",
            "Энгельс",
            "Южно-Сахалинск",
            "Юрга",
            "Якутск",
            "Ялта",
            "Ярославль"});
            this.comboBoxForCity.Location = new System.Drawing.Point(688, 16);
            this.comboBoxForCity.Name = "comboBoxForCity";
            this.comboBoxForCity.Size = new System.Drawing.Size(121, 21);
            this.comboBoxForCity.TabIndex = 5;
            this.comboBoxForCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxForCity_KeyPress);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Автомобили",
            "Аквариум",
            "Аудио и видео",
            "Билеты и путешествия",
            "Бытовая техника",
            "Бытовая электроника",
            "Вакансии",
            "Водный транспорт",
            "Велосипеды",
            "Гаражи и машиноместа",
            "Готовый бизнес",
            "Грузовики и спецтехника",
            "Детская одежда и обувь",
            "Для бизнеса",
            "Для дома и дачи",
            "Дома, дачи, коттеджи",
            "Другие животные",
            "Животные",
            "Запчасти и аксессуары",
            "Земельные участки",
            "Игры,приставки и программы",
            "Квартиры",
            "Книги и журналы",
            "Комнаты",
            "Коллекционирование",
            "Кошки",
            "Личные вещи",
            "Любая категория",
            "Мебель и интерьер",
            "Мотоциклы и мототехника",
            "Музыкальные инструменты",
            "Настольные компьютеры",
            "Недвижимость",
            "Недвижимость за рубежом",
            "Ноутбуки",
            "Оборудование для бизнеса",
            "Одежда, обувь, акскссуары",
            "Оргтехника и расходники",
            "Охота и рыбалка",
            "Планшеты и электонные книги",
            "Посуда и товары для кухни",
            "Птицы",
            "Продукты питания",
            "Работа",
            "Растения",
            "Ремонт и строительство",
            "Собаки",
            "Спорт и отдых",
            "Телефоны",
            "Товары для детей и игрушки",
            "Товары для компьютера",
            "Товары для животных",
            "Транспорт",
            "Услуги",
            "Фототехника",
            "Хобби и отдых",
            "Часы и украшения"});
            this.comboBoxType.Location = new System.Drawing.Point(825, 15);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxType.TabIndex = 6;
            this.comboBoxType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxType_KeyPress);
            // 
            // AvitoMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 521);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.comboBoxForCity);
            this.Controls.Add(this.loadbd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchtextBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.search);
            this.Name = "AvitoMonitor";
            this.Text = "AvitoMonitor";
            this.Load += new System.EventHandler(this.AvitoMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox searchtextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button loadbd;
        private System.Windows.Forms.ComboBox comboBoxForCity;
        private System.Windows.Forms.ComboBox comboBoxType;
    }
}

