﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using CsQuery;

namespace AvitoMonitor{
    internal static class Support {
        public static bool Marker = false;
        public static string htmlCode;
        public static string WAY = @"AvitoMonitor.db";
        public static string WAY_FOR_NEW_ADDS = @"AvitoMonitorNew.db";
        public static string WAY_FOR_SUPPORT_DB = @"AvitoMonitorSupport.db";
        public static string PATHtoIMG = @"Image Maker";
        public static string ImageString = "https:";
        public static string MainLink = @"https://www.avito.ru";
        public static string SEARCHstring = "https://www.avito.ru";
        public static string conectString = "Data Source=AvitoMonitor.db;Version=3;New=False;Compress=True;";
        public static string conectStringForNewDB = "Data Source=AvitoMonitorNew.db;Version=3;New=False;Compress=True;";
        public static void CreationOfDataBase(string WAY) { 
            if (!File.Exists(WAY)) {
                SQLiteConnection.CreateFile(WAY);
                using (SQLiteConnection connection = 
                new SQLiteConnection(@"Data Source=AvitoMonitor.db; Version=3;")){
                    string commandText = "CREATE TABLE [AvitoMonitor] ( " +
                        //"[id] CHAR(10) NOT NULL, " +
                        "[Время] CHAR(50) NOT NULL, " +
                        "[Название] CHAR(200) NOT NULL, " +
                        "[Цена] CHAR(12) NOT NULL, " +
                        "[Город] CHAR(100) NOT NULL, " +
                        "[Опубликовано] CHAR(50) NOT NULL, " +
                        "[Тип] CHAR(500) NOT NULL, " +
                        "[Картинка] BLOB, " +
                        "[Формат картинки] VARCHAR(10), " +
                        "[Ссылка на Объявление] NVARCHAR(128)" +
                        ")";
                    SQLiteCommand Command = new SQLiteCommand(commandText, connection);
                    connection.Open(); 
                    Command.ExecuteNonQuery(); 
                    connection.Close(); 
                }
            } 
        }
        public static void CreationOfDataBaseForNewAdds(string WAY_FOR_NEW_ADDS){ 
            if (!File.Exists(WAY_FOR_NEW_ADDS)) {
                SQLiteConnection.CreateFile(WAY_FOR_NEW_ADDS);
                using (SQLiteConnection connection = 
                new SQLiteConnection(@"Data Source=AvitoMonitorNew.db; Version=3;")){
                    string commandText = "CREATE TABLE [AvitoMonitorNew] ( " +
                        //"[id] CHAR(10) NOT NULL, " +
                        "[Время] CHAR(50) NOT NULL, " +
                        "[Название] CHAR(200) NOT NULL, " +
                        "[Цена] CHAR(12) NOT NULL, " +
                        "[Город] CHAR(100) NOT NULL, " +
                        "[Опубликовано] CHAR(50) NOT NULL, " +
                        "[Тип] CHAR(500) NOT NULL, " +
                        "[Картинка] BLOB, " +
                        "[Формат картинки] VARCHAR(10), " +
                        "[Ссылка на Объявление] NVARCHAR(128)" +
                        ")";
                    SQLiteCommand Command = new SQLiteCommand(commandText, connection);
                    connection.Open(); 
                    Command.ExecuteNonQuery(); 
                    connection.Close(); 
                }
            } 
        }
        public static void CreationOfDirectory(string PATHtoIMG) { 
            if (!Directory.Exists(PATHtoIMG)) {
                DirectoryInfo directoryInfo = new DirectoryInfo(PATHtoIMG);
                directoryInfo.Create();
            } 
        }
        public static void DeleteDB(string WAY) {
            if (File.Exists(WAY)) { 
                File.Delete(WAY);
            }
        }
        public static void ImageStringDefault() { 
            ImageString = "https:";
        }
        public static void SEARCHstringDefault() {
            SEARCHstring = "https://www.avito.ru";
        }
        public static Dictionary<string, string> Cities = new Dictionary<string, string> {
            ["Абакан"] = "abakan",
            ["Азов"] = "azov",
            ["Александров"] = "aleksandrov",
            ["Алексин"] = "aleksin",
            ["Альметьевск"] = "almetevsk",
            ["Анапа"] = "anapa",
            ["Ангарск"] = "angarsk",
            ["Анжеро-Судженск"] = "anzhero-sudzhensk",
            ["Апатиты"] = "apatity",
            ["Арзамас"] = "arzamas",
            ["Армавир"] = "armavir",
            ["Арсеньев"] = "arsenev",
            ["Артем"] = "artem",
            ["Архангельск"] = "arhangelsk",
            ["Асбест"] = "asbest",
            ["Астрахань"] = "astrahan",
            ["Ачинск"] = "achinsk",
            ["Балаково"] = "balakovo",
            ["Балахна"] = "balahna",
            ["Балашиха"] = "balashiha",
            ["Балашов"] = "balashov",
            ["Барнаул"] = "barnaul",
            ["Батайск"] = "bataysk",
            ["Белгород"] = "belgorod",
            ["Белебей"] = "belebey",
            ["Белово"] = "belovo",
            ["Белогорск (Амурская область)"] = "amurskaya_oblast_belogorsk",
            ["Белорецк"] = "beloretsk",
            ["Белореченск"] = "belorechensk",
            ["Бердск"] = "berdsk",
            ["Березники"] = "berezniki",
            ["Березовский (Свердловская область)"] = "sverdlovskaya_oblast_berezovskiy",
            ["Бийск"] = "biysk",
            ["Биробиджан"] = "birobidzhan",
            ["Благовещенск (Амурская область)"] = "amurskaya_oblast_blagoveschensk",
            ["Бор"] = "bor",
            ["Борисоглебск"] = "borisoglebsk",
            ["Боровичи"] = "borovichi",
            ["Братск"] = "bratsk",
            ["Брянск"] = "bryansk",
            ["Бугульма"] = "bugulma",
            ["Буденновск"] = "budennovsk",
            ["Бузулук"] = "buzuluk",
            ["Буйнакск"] = "buynaksk",
            ["Великие Луки"] = "velikie_luki",
            ["Великий Новгород"] = "velikiy_novgorod",
            ["Верхняя Пышма"] = "verhnyaya_pyshma",
            ["Видное"] = "vidnoe",
            ["Владивосток"] = "vladivostok",
            ["Владикавказ"] = "vladikavkaz",
            ["Владимир"] = "vladimir",
            ["Волгоград"] = "volgograd",
            ["Волгодонск"] = "volgodonsk",
            ["Волжск"] = "volzhsk",
            ["Волжский"] = "volgogradskaya_oblast_volzhskiy",
            ["Вологда"] = "vologda",
            ["Вольск"] = "volsk",
            ["Воркута"] = "vorkuta",
            ["Воронеж"] = "voronezh",
            ["Воскресенск"] = "voskresensk",
            ["Воткинск"] = "votkinsk",
            ["Всеволожск"] = "vsevolozhsk",
            ["Выборг"] = "vyborg",
            ["Выкса"] = "vyksa",
            ["Вязьма"] = "vyazma",
            ["Гатчина"] = "gatchina",
            ["Геленджик"] = "gelendzhik",
            ["Георгиевск"] = "georgievsk",
            ["Глазов"] = "glazov",
            ["Горно-Алтайск"] = "gorno-altaysk",
            ["Грозный"] = "groznyy",
            ["Губкин"] = "gubkin",
            ["Гудермес"] = "gudermes",
            ["Гуково"] = "gukovo",
            ["Гусь-Хрустальный"] = "gus-hrustalnyy",
            ["Дербент"] = "derbent",
            ["Дзержинск"] = "dzerzhinsk",
            ["Димитровград"] = "dimitrovgrad",
            ["Дмитров"] = "dmitrov",
            ["Долгопрудный"] = "dolgoprudnyy",
            ["Домодедово"] = "domodedovo",
            ["Донской"] = "tulskaya_oblast_donskoy",
            ["Дубна"] = "moskovskaya_oblast_dubna",
            ["Евпатория"] = "evpatoriya",
            ["Егорьевск"] = "egorevsk",
            ["Ейск"] = "eysk",
            ["Екатеринбург"] = "ekaterinburg",
            ["Елабуга"] = "elabuga",
            ["Елец"] = "elets",
            ["Ессентуки"] = "essentuki",
            ["Железногорск (Красноярский край)"] = "krasnoyarskiy_kray_zheleznogorsk",
            ["Железногорск (Курская область)"] = "kurskaya_oblast_zheleznogorsk",
            ["Жигулевск"] = "zhigulevsk",
            ["Жуковский"] = "zhukovskiy",
            ["Заречный"] = "penzenskaya_oblast_zarechnyy",
            ["Зеленогорск"] = "krasnoyarskiy_kray_zelenogorsk",
            ["Зеленодольск"] = "zelenodolsk",
            ["Златоуст"] = "zlatoust",
            ["Иваново"] = "ivanovo",
            ["Ивантеевка"] = "moskovskaya_oblast_ivanteevka",
            ["Ижевск"] = "izhevsk",
            ["Избербаш"] = "izberbash",
            ["Иркутск"] = "irkutsk",
            ["Искитим"] = "iskitim",
            ["Ишим"] = "ishim",
            ["Ишимбай"] = "ishimbay",
            ["Йошкар-Ола"] = "yoshkar-ola",
            ["Казань"] = "kazan",
            ["Калининград"] = "kaliningrad",
            ["Калуга"] = "kaluga",
            ["Каменск-Уральский"] = "kamensk-uralskiy",
            ["Каменск-Шахтинский"] = "kamensk-shahtinskiy",
            ["Камышин"] = "kamyshin",
            ["Канск"] = "kansk",
            ["Каспийск"] = "kaspiysk",
            ["Кемерово"] = "kemerovo",
            ["Керчь"] = "kerch",
            ["Кинешма"] = "kineshma",
            ["Кириши"] = "kirishi",
            ["Киров (Кировская область)"] = "kirovskaya_oblast_kirov",
            ["Кирово-Чепецк"] = "kirovo-chepetsk",
            ["Киселевск"] = "kiselevsk",
            ["Кисловодск"] = "kislovodsk",
            ["Клин"] = "klin",
            ["Клинцы"] = "klintsy",
            ["Ковров"] = "kovrov",
            ["Когалым"] = "kogalym",
            ["Коломна"] = "kolomna",
            ["Комсомольск-на-Амуре"] = "komsomolsk-na-amure",
            ["Копейск"] = "kopeysk",
            ["Королев"] = "korolev",
            ["Кострома"] = "kostroma",
            ["Котлас"] = "kotlas",
            ["Красногорск"] = "moskovskaya_oblast_krasnogorsk",
            ["Краснодар"] = "krasnodar",
            ["Краснокаменск"] = "zabaykalskiy_kray_krasnokamensk",
            ["Краснокамск"] = "krasnokamsk",
            ["Краснотурьинск"] = "krasnoturinsk",
            ["Красноярск"] = "krasnoyarsk",
            ["Кропоткин"] = "kropotkin",
            ["Крымск"] = "krymsk",
            ["Кстово"] = "kstovo",
            ["Кузнецк"] = "kuznetsk",
            ["Кумертау"] = "kumertau",
            ["Кунгур"] = "kungur",
            ["Курган"] = "kurgan",
            ["Курск"] = "kursk",
            ["Кызыл"] = "kyzyl",
            ["Лабинск"] = "labinsk",
            ["Лениногорск"] = "leninogorsk",
            ["Ленинск-Кузнецкий"] = "leninsk-kuznetskiy",
            ["Лесосибирск"] = "lesosibirsk",
            ["Липецк"] = "lipetsk",
            ["Лиски"] = "liski",
            ["Лобня"] = "lobnya",
            ["Лысьва"] = "lysva",
            ["Лыткарино"] = "lytkarino",
            ["Люберцы"] = "lyubertsy",
            ["Магадан"] = "magadan",
            ["Магнитогорск"] = "magnitogorsk",
            ["Майкоп"] = "maykop",
            ["Махачкала"] = "mahachkala",
            ["Междуреченск"] = "kemerovskaya_oblast_mezhdurechensk",
            ["Мелеуз"] = "meleuz",
            ["Миасс"] = "miass",
            ["Минеральные Воды"] = "mineralnye_vody",
            ["Минусинск"] = "minusinsk",
            ["Михайловка"] = "volgogradskaya_oblast_mihaylovka",
            ["Михайловск (Ставропольский край)"] = "stavropolskiy_kray_mihaylovsk",
            ["Мичуринск"] = "michurinsk",
            ["Москва"] = "moskva",
            ["Мурманск"] = "murmansk",
            ["Муром"] = "murom",
            ["Мытищи"] = "mytischi",
            ["Набережные Челны"] = "naberezhnye_chelny",
            ["Назарово"] = "nazarovo",
            ["Назрань"] = "nazran",
            ["Нальчик"] = "nalchik",
            ["Наро-Фоминск"] = "naro-fominsk",
            ["Находка"] = "nahodka",
            ["Невинномысск"] = "nevinnomyssk",
            ["Нерюнгри"] = "neryungri",
            ["Нефтекамск"] = "neftekamsk",
            ["Нефтеюганск"] = "nefteyugansk",
            ["Нижневартовск"] = "nizhnevartovsk",
            ["Нижнекамск"] = "nizhnekamsk",
            ["Нижний Новгород"] = "nizhniy_novgorod",
            ["Нижний Тагил"] = "nizhniy_tagil",
            ["Новоалтайск"] = "novoaltaysk",
            ["Новокузнецк"] = "novokuznetsk",
            ["Новокуйбышевск"] = "novokuybyshevsk",
            ["Новомосковск"] = "novomoskovsk",
            ["Новороссийск"] = "novorossiysk",
            ["Новосибирск"] = "novosibirsk",
            ["Новотроицк"] = "novotroitsk",
            ["Новоуральск"] = "novouralsk",
            ["Новочебоксарск"] = "novocheboksarsk",
            ["Новочеркасск"] = "novocherkassk",
            ["Новошахтинск"] = "novoshahtinsk",
            ["Новый Уренгой"] = "novyy_urengoy",
            ["Ногинск"] = "noginsk",
            ["Норильск"] = "norilsk",
            ["Ноябрьск"] = "noyabrsk",
            ["Нягань"] = "nyagan",
            ["Обнинск"] = "obninsk",
            ["Одинцово"] = "odintsovo",
            ["Озерск (Челябинская область)"] = "chelyabinskaya_oblast_ozersk",
            ["Октябрьский"] = "bashkortostan_oktyabrskiy",
            ["Омск"] = "omsk",
            ["Орел"] = "orel",
            ["Оренбург"] = "orenburg",
            ["Орехово-Зуево"] = "orehovo-zuevo",
            ["Орск"] = "orsk",
            ["Павлово"] = "nizhegorodskaya_oblast_pavlovo",
            ["Павловский Посад"] = "pavlovskiy_posad",
            ["Пенза"] = "penza",
            ["Первоуральск"] = "pervouralsk",
            ["Пермь"] = "perm",
            ["Петрозаводск"] = "petrozavodsk",
            ["Петропавловск-Камчатский"] = "petropavlovsk-kamchatskiy",
            ["Подольск"] = "podolsk",
            ["Полевской"] = "polevskoy",
            ["Прокопьевск"] = "prokopevsk",
            ["Прохладный"] = "prohladnyy",
            ["Псков"] = "pskov",
            ["Пушкино"] = "pushkino",
            ["Пятигорск"] = "pyatigorsk",
            ["Раменское"] = "ramenskoe",
            ["Ревда"] = "sverdlovskaya_oblast_revda",
            ["Реутов"] = "reutov",
            ["Ржев"] = "rzhev",
            ["Рославль"] = "roslavl",
            ["Россия"] = "rossiya",
            ["Россошь"] = "rossosh",
            ["Ростов-на-Дону"] = "rostov-na-donu",
            ["Рубцовск"] = "rubtsovsk",
            ["Рыбинск"] = "rybinsk",
            ["Рязань"] = "ryazan",
            ["Салават"] = "salavat",
            ["Сальск"] = "salsk",
            ["Самара"] = "samara",
            ["Санкт-Петербург"] = "sankt-peterburg",
            ["Саранск"] = "saransk",
            ["Сарапул"] = "sarapul",
            ["Саратов"] = "saratov",
            ["Саров"] = "sarov",
            ["Свободный"] = "amurskaya_oblast_svobodnyy",
            ["Севастополь"] = "sevastopol",
            ["Северодвинск"] = "severodvinsk",
            ["Северск"] = "seversk",
            ["Сергиев Посад"] = "sergiev_posad",
            ["Серов"] = "serov",
            ["Серпухов"] = "serpuhov",
            ["Сертолово"] = "sertolovo",
            ["Сибай"] = "sibay",
            ["Симферополь"] = "simferopol",
            ["Славянск-на-Кубани"] = "slavyansk-na-kubani",
            ["Смоленск"] = "smolensk",
            ["Соликамск"] = "solikamsk",
            ["Солнечногорск"] = "solnechnogorsk",
            ["Сосновый Бор"] = "leningradskaya_oblast_sosnovyy_bor",
            ["Сочи"] = "sochi",
            ["Ставрополь"] = "stavropol",
            ["Старый Оскол"] = "staryy_oskol",
            ["Стерлитамак"] = "sterlitamak",
            ["Ступино"] = "stupino",
            ["Сургут"] = "surgut",
            ["Сызрань"] = "syzran",
            ["Сыктывкар"] = "syktyvkar",
            ["Таганрог"] = "taganrog",
            ["Тамбов"] = "tambov",
            ["Тверь"] = "tver",
            ["Тимашевск"] = "timashevsk",
            ["Тихвин"] = "tihvin",
            ["Тихорецк"] = "tihvin",
            ["Тобольск"] = "tobolsk",
            ["Тольятти"] = "tolyatti",
            ["Томск"] = "tomsk",
            ["Троицк"] = "chelyabinskaya_oblast_troitsk",
            ["Туапсе"] = "tuapse",
            ["Туймазы"] = "tuymazy",
            ["Тула"] = "tula",
            ["Тюмень"] = "tyumen",
            ["Узловая"] = "uzlovaya",
            ["Улан-Удэ"] = "ulan-ude",
            ["Ульяновск"] = "ulyanovsk",
            ["Урус-Мартан"] = "urus-martan",
            ["Усолье-Сибирское"] = "usole-sibirskoe",
            ["Уссурийск"] = "ussuriysk",
            ["Усть-Илимск"] = "ust-ilimsk",
            ["Уфа"] = "ufa",
            ["Ухта"] = "uhta",
            ["Феодосия"] = "feodosiya",
            ["Фрязино"] = "fryazino",
            ["Хабаровск"] = "habarovsk",
            ["Ханты-Мансийск"] = "hanty-mansiysk",
            ["Хасавюрт"] = "hasavyurt",
            ["Химки"] = "himki",
            ["Чайковский"] = "chaykovskiy",
            ["Чапаевск"] = "chapaevsk",
            ["Чебоксары"] = "cheboksary",
            ["Челябинск"] = "chelyabinsk",
            ["Черемхово"] = "cheremhovo",
            ["Череповец"] = "cherepovets",
            ["Черкесск"] = "cherkessk",
            ["Черногорск"] = "chernogorsk",
            ["Чехов"] = "moskovskaya_oblast_chehov",
            ["Чистополь"] = "chistopol",
            ["Чита"] = "chita",
            ["Шадринск"] = "shadrinsk",
            ["Шали"] = "shali",
            ["Шахты"] = "shahty",
            ["Шуя"] = "ivanovskaya_oblast_shuya",
            ["Щекино"] = "schekino",
            ["Щелково"] = "schelkovo",
            ["Электросталь"] = "elektrostal",
            ["Элиста"] = "elista",
            ["Энгельс"] = "engels",
            ["Южно-Сахалинск"] = "yuzhno-sahalinsk",
            ["Юрга"] = "yurga",
            ["Якутск"] = "yakutsk",
            ["Ялта"] = "yalta",
            ["Ярославль"] = "yaroslavl",
        };
        public static Dictionary<string, string> Types = new Dictionary<string, string> {
            ["Автомобили"] = "avtomobili",
            ["Аквариум"] = "akvarium",
            ["Аудио и видео"] = "audio_i_video",
            ["Билеты и путешествия"] = "bilety_i_puteshestviya",
            ["Бытовая техника"] = "bytovaya_tehnika",
            ["Бытовая электроника"] = "bytovaya_elektronika",
            ["Вакансии"] = "vakansii",
            ["Водный транспорт"] = "vodnyy_transport",
            ["Велосипеды"] = "velosipedy",
            ["Гаражи и машиноместа"] = "garazhi_i_mashinomesta",
            ["Готовый бизнес"] = "gotoviy_biznes",
            ["Грузовики и спецтехника"] = "gruzoviki_i_spetstehnika",
            ["Детская одежда и обувь"] = "detskaya_odezhda_i_obuv",
            ["Для бизнеса"] = "dlya_biznesa",
            ["Для дома и дачи"] = "dlya_doma_i_dachi",
            ["Дома, дачи, коттеджи"] = "doma_dachi_kottedzhi",
            ["Другие животные"] = "drugie_zhivotnye",
            ["Животные"] = "zhivotnye",
            ["Запчасти и аксессуары"] = "zapchasti_i_aksessuary",
            ["Земельные участки"] = "zemelnye_uchastki",
            ["Игры, приставки и программы"] = "igry_pristavki_i_programmy",
            ["Квартиры"] = "kvartiry",
            ["Книги и журналы"] = "knigi_i_zhurnaly",
            ["Комнаты"] = "komnaty",
            ["Коллекционирование"] = "kollektsionirovanie",
            ["Кошки"] = "koshki",
            ["Личные вещи"] = "lichnye_veschi",
            ["Любая категория"] = "",
            ["Мебель и интерьер"] = "mebel_i_interer",
            ["Мотоциклы и мототехника"] = "mototsikly_i_mototehnika",
            ["Музыкальные инструменты"] = "muzykalnye_instrumenty",
            ["Настольные компьютеры"] = "nastolnye_kompyutery",
            ["Недвижимость"] = "nedvizhimost",
            ["Недвижимость за рубежом"] = "nedvizhimost_za_rubezhom",
            ["Ноутбуки"] = "noutbuki",
            ["Оборудование для бизнеса"] = "oborudovanie_dlya_biznesa",
            ["Одежда, обувь, акскссуары"] = "odezhda_obuv_aksessuary",
            ["Оргтехника и расходники"] = "orgtehnika_i_rashodniki",
            ["Охота и рыбалка"] = "ohota_i_rybalka",
            ["Планшеты и электронные книги"] = "planshety_i_elektronnye_knigi",
            ["Посуда и товары для кухни"] = "posuda_i_tovary_dlya_kuhni",
            ["Птицы"] = "ptitsy",
            ["Продукты питания"] = "produkty_pitaniya",
            ["Работа"] = "rabota",
            ["Растения"] = "rasteniya",
            ["Ремонт и строительство"] = "remont_i_stroitelstvo",
            ["Собаки"] = "sobaki",
            ["Спорт и отдых"] = "sport_i_otdyh",
            ["Телефоны"] = "telefony",
            ["Товары для детей и игрушки"] = "tovary_dlya_detey_i_igrushki",
            ["Товары для компьютера"] = "tovary_dlya_kompyutera",
            ["Товары для животных"] = "tovary_dlya_zhivotnyh",
            ["Транспорт"] = "transport",
            ["Услуги"] = "predlozheniya_uslug",
            ["Фототехника"] = "fototehnika",
            ["Хобби и отдых"] = "hobbi_i_otdyh",
            ["Часы и украшения"] = "chasy_i_ukrasheniya"
        };
    }
}
