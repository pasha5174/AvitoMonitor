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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using CsQuery;

namespace AvitoMonitor{
    internal static class Support {
        public static string ImageString = "https:";
        public static string[] Types = {
            "avtomobili", "akvarium", "audio_i_video", "bilety_i_puteshestviya", "bytovaya_tehnika",
            "bytovaya_elektronika", "vakansii", "vodnyy_transport", "velosipedy", "garazhi_i_mashinomesta",
            "gotoviy_biznes", "gruzoviki_i_spetstehnika", "detskaya_odezhda_i_obuv", "dlya_biznesa",
            "dlya_doma_i_dachi", "doma_dachi_kottedzhi", "drugie_zhivotnye", "zhivotnye",
            "zapchasti_i_aksessuary", "zemelnye_uchastki", "igry_pristavki_i_programmy", "kvartiry",
            "knigi_i_zhurnaly", "komnaty", "kollektsionirovanie", "koshki", "lichnye_veschi", "",
            "mebel_i_interer", "mototsikly_i_mototehnika", "muzykalnye_instrumenty", "nastolnye_kompyutery",
            "nedvizhimost", "nedvizhimost_za_rubezhom", "noutbuki", "oborudovanie_dlya_biznesa",
            "odezhda_obuv_aksessuary", "orgtehnika_i_rashodniki", "ohota_i_rybalka",
            "planshety_i_elektronnye_knigi", "posuda_i_tovary_dlya_kuhni", "ptitsy", "produkty_pitaniya",
            "rabota", "rasteniya", "remont_i_stroitelstvo", "sobaki", "sport_i_otdyh", "telefony",
            "tovary_dlya_detey_i_igrushki", "tovary_dlya_kompyutera", "tovary_dlya_zhivotnyh", "transport",
            "predlozheniya_uslug", "fototehnika", "hobbi_i_otdyh", "chasy_i_ukrasheniya"
            };
        public static string[] Cities = {
            "abakan", "azov", "aleksandrov", "aleksin", "almetevsk", "anapa", "angarsk", "anzhero-sudzhensk",
            "apatity", "arzamas", "armavir", "arsenev", "artem", "arhangelsk", "asbest", "astrahan", "achinsk",
            "balakovo", "balahna", "balashiha", "balashov", "barnaul", "bataysk", "belgorod", "belebey",
            "belovo", "amurskaya_oblast_belogorsk", "beloretsk", "belorechensk", "berdsk", "berezniki",
            "sverdlovskaya_oblast_berezovskiy", "biysk", "birobidzhan", "amurskaya_oblast_blagoveschensk",
            "bor", "borisoglebsk", "borovichi", "bratsk", "bryansk", "bugulma", "budennovsk", "buzuluk",
            "buynaksk", "velikie_luki", "velikiy_novgorod", "verhnyaya_pyshma", "vidnoe", "vladivostok",
            "vladikavkaz", "vladimir", "volgograd", "volgodonsk", "volzhsk", "volgogradskaya_oblast_volzhskiy",
            "vologda", "volsk", "vorkuta", "voronezh", "voskresensk", "votkinsk", "vsevolozhsk", "vyborg",
            "vyksa", "vyazma", "gatchina", "gelendzhik", "georgievsk", "glazov", "gorno-altaysk", "groznyy",
            "gubkin", "gudermes", "gukovo", "gus-hrustalnyy", "derbent", "dzerzhinsk", "dimitrovgrad", "dmitrov",
            "dolgoprudnyy", "domodedovo", "tulskaya_oblast_donskoy", "moskovskaya_oblast_dubna", "evpatoriya",
            "egorevsk", "eysk", "ekaterinburg", "elabuga", "elets", "essentuki",
            "krasnoyarskiy_kray_zheleznogorsk", "kurskaya_oblast_zheleznogorsk", "zhigulevsk", "zhukovskiy",
            "penzenskaya_oblast_zarechnyy", "krasnoyarskiy_kray_zelenogorsk", "zelenodolsk", "zlatoust",
            "ivanovo", "moskovskaya_oblast_ivanteevka", "izhevsk", "izberbash", "irkutsk", "iskitim", "ishim",
            "ishimbay", "yoshkar-ola", "kazan", "kaliningrad", "kaluga", "kamensk-uralskiy",
            "kamensk-shahtinskiy", "kamyshin", "kansk", "kaspiysk", "kemerovo", "kerch", "kineshma", "kirishi",
            "kirovskaya_oblast_kirov", "kirovo-chepetsk", "kiselevsk", "kislovodsk", "klin", "klintsy", "kovrov",
            "kogalym", "kolomna", "komsomolsk-na-amure", "kopeysk", "korolev", "kostroma", "kotlas",
            "moskovskaya_oblast_krasnogorsk", "krasnodar", "zabaykalskiy_kray_krasnokamensk", "krasnokamsk",
            "krasnoturinsk", "krasnoyarsk", "kropotkin", "krymsk", "kstovo", "kuznetsk", "kumertau", "kungur",
            "kurgan", "kursk", "kyzyl", "labinsk", "leninogorsk", "leninsk-kuznetskiy", "lesosibirsk", "lipetsk",
            "liski", "lobnya", "lysva", "lytkarino", "lyubertsy", "magadan", "magnitogorsk", "maykop",
            "mahachkala", "kemerovskaya_oblast_mezhdurechensk", "meleuz", "miass", "mineralnye_vody", "minusinsk",
            "volgogradskaya_oblast_mihaylovka", "stavropolskiy_kray_mihaylovsk", "michurinsk", "moskva",
            "murmansk", "murom", "mytischi", "naberezhnye_chelny", "nazarovo", "nazran", "nalchik","naro-fominsk",
            "nahodka", "nevinnomyssk", "neryungri", "neftekamsk", "nefteyugansk", "nizhnevartovsk", "nizhnekamsk",
            "nizhniy_novgorod", "nizhniy_tagil", "novoaltaysk", "novokuznetsk", "novokuybyshevsk", "novomoskovsk",
            "novorossiysk", "novosibirsk", "novotroitsk", "novouralsk", "novocheboksarsk", "novocherkassk",
            "novoshahtinsk", "novyy_urengoy", "noginsk", "norilsk", "noyabrsk", "nyagan", "obninsk", "odintsovo",
            "chelyabinskaya_oblast_ozersk", "bashkortostan_oktyabrskiy", "omsk", "orel", "orenburg",
            "orehovo-zuevo", "orsk", "nizhegorodskaya_oblast_pavlovo", "pavlovskiy_posad", "penza", "pervouralsk",
            "perm", "petrozavodsk", "petropavlovsk-kamchatskiy", "podolsk", "polevskoy", "prokopevsk",
            "prohladnyy", "pskov", "pushkino", "pyatigorsk", "ramenskoe", "sverdlovskaya_oblast_revda", "reutov",
            "rzhev", "roslavl", "rossosh", "rostov-na-donu", "rubtsovsk", "rybinsk", "ryazan", "salavat", "salsk",
            "samara", "sankt-peterburg", "saransk", "sarapul", "saratov", "sarov", "amurskaya_oblast_svobodnyy",
            "sevastopol", "severodvinsk", "seversk", "sergiev_posad", "serov", "serpuhov", "sertolovo", "sibay",
            "simferopol", "slavyansk-na-kubani", "smolensk", "solikamsk", "solnechnogorsk",
            "leningradskaya_oblast_sosnovyy_bor", "sochi", "stavropol", "staryy_oskol", "sterlitamak", "stupino",
            "surgut", "syzran", "syktyvkar", "taganrog", "tambov", "tver", "timashevsk", "tihvin", "tihvin",
            "tobolsk", "tolyatti", "tomsk", "chelyabinskaya_oblast_troitsk", "tuapse", "tuymazy", "tula",
            "tyumen", "uzlovaya", "ulan-ude", "ulyanovsk", "urus-martan", "usole-sibirskoe", "ussuriysk",
            "ust-ilimsk", "ufa", "uhta", "feodosiya", "fryazino", "habarovsk", "hanty-mansiysk", "hasavyurt",
            "himki", "chaykovskiy", "chapaevsk", "cheboksary", "chelyabinsk", "cheremhovo", "cherepovets",
            "cherkessk", "chernogorsk", "moskovskaya_oblast_chehov", "chistopol", "chita", "shadrinsk", "shali",
            "shahty", "ivanovskaya_oblast_shuya", "schekino", "schelkovo", "elektrostal", "elista", "engels",
            "yuzhno-sahalinsk", "yurga", "yakutsk", "yalta", "yaroslavl"
            };
        public static void CreationOfDataBase(string WAY) { 
            if (!File.Exists(WAY)) {
                SQLiteConnection.CreateFile(WAY);
                using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=AvitoMonitor.db; Version=3;")){
                    string commandText = "CREATE TABLE [AvitoMonitor] ( " +
                        //"[id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, " +
                        "[Название] CHAR(200) NOT NULL, " +
                        "[Город] CHAR(100) NOT NULL, " +
                        "[Время] CHAR(50) NOT NULL, " +
                        "[Тип] CHAR(500) NOT NULL, " +
                        "[Картинка] BLOB, " +
                        "[Формат картинки] VARCHAR(10), " +
                        "[Название картинки] NVARCHAR(128)" +
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
    }
}
