using System;
using System.Text;
using System.IO;


namespace Kursovik
{
   
    class Program
    {
        class Avtor
        {
            protected string stroka;

            private string p_fam;
            private string p_name;
            private string p_otch;


            public Avtor()
            {
                stroka = "Фамилия Имя Отчество";

            }

            public Avtor(string stroka)
            {
                this.stroka_ = stroka;
            }
            public string stroka_
            {
                get
                {
                    return stroka;
                }
                set
                {
                    if (value != "")
                    {
                        stroka = Correcting(value);
                    }
                    else
                    {
                        stroka = "Unknown";
                    }

                }
            }
            public string fam
            {
                get
                {
                    return sub_fam();
                }
            }
            private string sub_fam()
            {

                string NewStr;

                string[] words =Correcting( Correcting(stroka).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                p_fam = words[0];
                int startindex = 1, length = p_fam.Length;
                string substring = p_fam.Substring(startindex, length - 1).ToLower();
                NewStr = (p_fam[0].ToString().ToUpper() + substring.ToString());


                return NewStr;

            }

            public string name
            {
                get
                {
                    return sub_name();
                }
            }
            private string sub_name()
            {
                string NewStr;
                string[] words = Correcting(Correcting(stroka).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                Array.Resize(ref words, 3);

                p_name = words[1];

                int startindex = 1, length = p_name.Length;
                string substring = p_name.Substring(startindex, length - 1);

                NewStr = (p_name[0].ToString().ToUpper() + substring.ToString());
                return NewStr;

            }

            public string otch
            {
                get
                {
                    return sub_otch();
                }

            }


            private string sub_otch()
            {
                string NewStr;

                string[] words = Correcting(Correcting(stroka).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                p_otch = words[2];
                int startindex = 1, length = p_otch.Length;
                string substring = p_otch.Substring(startindex, length - 1);

                NewStr = (p_otch[0].ToString().ToUpper() + substring.ToString());
                return NewStr;

            }

            public string fio
            {
                get
                {
                    return fam + ' ' + name[0] + '.' + otch[0] + '.';
                }
            }
            public string iof
            {
                get
                {

                    return name[0].ToString() + '.' + otch[0].ToString() + '.' + ' ' + fam;
                }
            }



            private string Correcting(string str)
            {

                var n_string = new StringBuilder();
                foreach (char c in str)
                {
                    if ((c == '\'' || c == '-') || c == ' ' || Char.IsLetter(c) == true)
                    {
                        n_string.Append(c);
                    }
                }
                str = n_string.ToString();
                return str;

            }

            private string [] Correcting( string []  str)
            {

                Array.Resize(ref str, 3);
                for (byte i = 0; i < str.Length; i++)
                {
                    if (str[i] == null)
                    {
                        str[i] = "Unknown";
                    }


                }
                return str ;

            }

            ~Avtor()
            {Console.WriteLine("Объекты уничтожены");
            }
        }

        class Book
        {
            protected Avtor fio;
            protected string main_name;
            protected string city;
            protected string izdatelstvo;
            protected ushort year;
            protected ushort pages;

            public Book()
            {
                fio = new Avtor("");
                main_name = "Нет названия";
                city = "Город неизвестен";
                izdatelstvo = "Издательство неизвестно";
                year = 9999;
                pages = 9999;
            }

            public Book(string fio, string main_name, string city, string izdatelstvo, ushort year, ushort pages)
            {
                this.fio = new Avtor(fio);
                this.main_name_ = main_name;
                this.city_ = city;
                this.izdatelstvo_ = izdatelstvo;
                this.year_ = year;
                this.pages_ = pages;
            }

            public ushort pages_
            {
                get
                {
                    return pages;

                }

                set
                {
                    if ((value < 0) || (value > 5000) || (value == 0))
                    {
                        pages = 100;
                    }
                    else
                    {
                        pages = value;
                    }
                }
            }


            public string izdatelstvo_
            {
                get
                {
                    return izdatelstvo;
                }
                set
                {if (value != "")
                    { izdatelstvo = CorrectingN(value); }
                else
                    {
                        izdatelstvo = "Unknown";
                    }
                }
            }

            public string main_name_
            {
                get
                {
                    return main_name;
                }
                set
                {
                    main_name = (CorrectingName(value));
                }
            }
            protected string CorrectingName(string str)
            {

                string[] newstr0 = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string newstr = String.Join(' ', newstr0);
                var n_string = new StringBuilder();
                foreach (char c in newstr)
                {
                    if ((c == '\'' || c == '-') || c == ' ' || Char.IsLetter(c) == true || Char.IsNumber(c) == true || c == ',' || c == ':' || c == '.')
                    {
                        n_string.Append(c);
                    }
                }
                newstr = n_string.ToString();


                return newstr;
            }


            public string city_
            {
                get
                {
                    return city;
                }
                set
                {

                    if (value != "")
                    {

                        city = CorrectingN(value);
                        string substring = city.Substring(1).ToLower();
                        char[] city1 = city.ToCharArray();

                        city = city1[0].ToString() + substring;
                    }
                    else
                    {
                        city = "Unknown";
                    }


                }
            }

            public ushort year_
            {
                get
                {
                    return year;
                }
                set
                {
                    DateTime m = DateTime.Now;

                    if ((value < 0) || (value > m.Year))
                    {

                        year = 2022;
                        return;
                    }

                    year = value;


                }
            }




            protected virtual string ResultStr()
            {

                return $"{fio.fio} {main_name} – {city}: {izdatelstvo}, {year}г. – {pages} с.";
            }

            public void Show()
            {
                Console.WriteLine(ResultStr());
            }

            protected string CorrectingN(string str)
            {



                string newstr = str.Trim(); 
                var n_string = new StringBuilder();
                foreach (char c in newstr)
                {
                    if ((c == '\'' || c == '-') || c == ' ' || Char.IsLetter(c) == true || Char.IsNumber(c) == true)
                    {
                        n_string.Append(c);
                    }
                }
                newstr = n_string.ToString();


                return newstr;

            }

            public void WriteInToFileTXT()
            {

                string file_p = "../../../../filesToWrite/filetowrite.txt";


                if (File.Exists(file_p) != true)
                {

                    FileStream fs = new FileStream(file_p, FileMode.OpenOrCreate);
                    fs.Close();

                }

                //Open the File
                StreamWriter sw = new StreamWriter(file_p, true); //Если вместо true стоит false, то при новом запуске весь текст переписывается, удаляется старый добавленный и добавляется новый

                //Write out on the same line.

                sw.WriteLine("----------ВЫПОЛНЕНО {0}----------", DateTime.Now);
                sw.WriteLine();

                sw.WriteLine(ResultStr());

                sw.WriteLine();
                sw.WriteLine("------------Made by Andrei 04.06.2022--------------");
                sw.WriteLine();
                sw.WriteLine();
                //close the file
                sw.Close();
            }
            ~Book()
            {

                Console.WriteLine("Объекты уничтожены");


            }

            public static string operator %(Book Object, Book Object2)
            {

                float percent = 0;
                if (Object.fio.fio == Object2.fio.fio)
                {
                    percent += 20;
                }
                if (Object.main_name == Object2.main_name)
                {
                    percent += 16;
                }
                if (Object.city == Object2.city)
                {
                    percent += 16;
                }
                if (Object.izdatelstvo == Object2.izdatelstvo)
                {
                    percent += 16;
                }
                if (Object.year == Object2.year)
                {
                    percent += 16;
                }

                if (Object.pages == Object2.pages)
                {
                    percent += 16;
                }
              if (percent > 100)
                {
                    percent = 100;
                }
                return "Процент схожести двух книг - " + percent.ToString() + '%'; ;

            }

            public static Book operator +(Book Object, Book Object2)
            {

                string fio; string main_name; string city; string izdatelstvo; ushort year; ushort pages;

                if (Object.fio.stroka_.Length >= Object2.fio.stroka_.Length)
                {
                    fio = Object.fio.stroka_;
                }
                else
                {
                    fio = Object2.fio.stroka_;
                }

                if (Object.main_name.Length >= Object2.main_name.Length)
                {
                    main_name = Object.main_name;
                }
                else
                {
                    main_name = Object2.main_name;
                }

                if (Object.city.Length >= Object2.city.Length)
                {
                    city = Object.city;
                }
                else
                {
                    city = Object2.city;
                }
                if (Object.izdatelstvo.Length >= Object2.izdatelstvo.Length)
                {
                    izdatelstvo = Object.izdatelstvo;
                }
                else
                {
                    izdatelstvo = Object2.izdatelstvo;
                }


                if (Object.year >= Object2.year)
                {
                    year = Object.year;
                }
                else
                {
                    year = Object2.year;
                }
                if (Object.pages >= Object2.pages)
                {
                    pages = Object.pages;
                }
                else
                {
                    pages = Object2.pages;
                }

                Book b = new Book(fio, main_name, city, izdatelstvo, year, pages);


                return b;

            }

            public static bool operator <(Book Object, Book Object2)
            {
                if (Object.pages < Object2.pages)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            public static bool operator >(Book Object, Book Object2)
            {
                if (Object.pages > Object2.pages)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }

        class Statement : Book
        {
            protected string journalName;
            protected byte nomerIzd;
            protected ushort straniciN;
            protected ushort straniciE;

            public Statement() : base()
            {
                journalName = "Неизвестный журнал";
                nomerIzd = 100;
                straniciN = 0;
                straniciE = 9999;


            }

            public Statement(string fio, string main_name, string journalName, ushort year, byte nomerIzd, ushort straniciN, ushort straniciE)
            {
                this.fio = new Avtor(fio);
                this.main_name = main_name;
                this.journalName_ = journalName;
                this.year = year;
                this.nomerIzd = nomerIzd;
                this.straniciN_ = straniciN;
                this.straniciE_ = straniciE;
            }
            public string journalName_
            {
                get
                {
                    return journalName;
                }
                set
                {   if (value != "")
                    {
                        journalName = CorrectingNameJour(value);
                    }
                    else
                    {
                        journalName = "Журнал unknown";
                    }
                }
            }
            public ushort straniciN_
            {
                get
                {
                    return straniciN;
                }

                set
                {
                    if (value > straniciE)
                    {
                        var temp = straniciE;
                        straniciE = value;
                        straniciN = temp;
                    }
                    else
                    {
                        straniciN = value;
                    }
                }
            }
            public ushort straniciE_
            {
                get
                {
                    return straniciE;
                }

                set
                {
                    if (straniciN > value)
                    {
                        var temp = value;
                        straniciE_ = straniciN;
                        straniciN = value;
                    }
                    else
                    {
                        straniciE = value;
                    }
                }
            }
            private string CorrectingNameJour(string str)
            {

                string[] newstr0 = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string newstr = String.Join(' ', newstr0);
                var n_string = new StringBuilder();
                foreach (char c in newstr)
                {
                    if ((c == '\'' || c == '-') || c == ' ' || Char.IsLetter(c) == true || Char.IsNumber(c) == true || c == ',' || c == ':' || c == '.' || c == '+' || c == '=' || c == '@')
                    {
                        n_string.Append(c);
                    }
                }
                newstr = n_string.ToString();


                return newstr;
            }



            protected override string ResultStr()
            {


                return $"{fio.fio} {main_name} // {journalName}. – {year}г. – №{nomerIzd}. – С.{straniciN}-{straniciE}";
            }
            ~Statement()
            {
                Console.WriteLine("Объекты уничтожены");
            }
            public static string operator %(Statement Object, Statement Object2)
            {


                float percent = 0;
                if (Object.fio.fio == Object2.fio.fio)
                {
                    percent += 20;
                }
                if (Object.main_name == Object2.main_name)
                {
                    percent += 16;
                }
                if (Object.journalName == Object2.journalName)
                {
                    percent += 16;
                }
                if (Object.nomerIzd == Object2.nomerIzd)
                {
                    percent += 16;
                }
                if (Object.year == Object2.year)
                {
                    percent += 16;
                }

                if (Object.straniciN == Object2.straniciN)
                {
                    percent += 8;
                }

                if (Object.straniciE == Object2.straniciE)
                {
                    percent += 8;
                }
                if (percent > 100)
                {
                    percent = 100;
                }
                return "Процент схожести двух книг - " + percent.ToString() + '%'; ;

            }

            public static Statement operator +(Statement Object, Statement Object2)
            {

                string fio; string main_name; string journalName; ushort year; byte nomerIzd; ushort straniciN; ushort straniciE;

                if (Object.fio.stroka_.Length >= Object2.fio.stroka_.Length)
                {
                    fio = Object.fio.stroka_;
                }
                else
                {
                    fio = Object2.fio.stroka_;
                }

                if (Object.main_name.Length >= Object2.main_name.Length)
                {
                    main_name = Object.main_name;
                }
                else
                {
                    main_name = Object2.main_name;
                }

                if (Object.journalName.Length >= Object2.journalName.Length)
                {
                    journalName = Object.journalName;
                }
                else
                {
                    journalName = Object2.journalName;
                }

                if (Object.year >= Object2.year)
                {
                    year = Object.year;
                }
                else
                {
                    year = Object2.year;
                }
                if (Object.nomerIzd >= Object2.nomerIzd)
                {
                    nomerIzd = Object.nomerIzd;
                }
                else
                {
                    nomerIzd = Object2.nomerIzd;
                }
                if (Object.straniciN >= Object2.straniciN)
                {
                    straniciN = Object.straniciN;
                }
                else
                {
                    straniciN = Object2.straniciN;
                }
                if (Object.straniciE >= Object2.straniciE)
                {
                    straniciE = Object.straniciE;
                }
                else
                {
                    straniciE = Object2.straniciE;
                }


                Statement b = new Statement(fio, main_name, journalName, year, nomerIzd, straniciN, straniciE);


                return b;

            }
            public static bool operator <(Statement Object, Statement Object2)
            {
                if ((Object.straniciE - Object.straniciN + 1) < (Object2.straniciE - Object2.straniciN + 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator >(Statement Object, Statement Object2)
            {
                if ((Object.straniciE - Object.straniciN + 1) > (Object2.straniciE - Object2.straniciN + 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class StatSborConference : Statement
        {


            protected string nameConference;


            public StatSborConference()
            {
                nameConference = "Неизвестная конференция";
            }

            public StatSborConference(string fio, string main_name, string nameConference, string city, string izdatelstvo, ushort year, ushort straniciN, ushort straniciE)
            {
                this.fio = new Avtor(fio);
                this.main_name_ = main_name;
                this.nameConference_ = nameConference;
                this.city_ = city;
                this.izdatelstvo_ = izdatelstvo;
                this.year_ = year;
                this.straniciN_ = straniciN;
                this.straniciE_ = straniciE;

            }


            public string nameConference_
            {
                get
                {

                    return nameConference;

                }

                set
                {
                    if (value != "")
                    {
                        nameConference = CorrectingName(value);
                    }
                    else
                    {
                        nameConference = "Неизвестная конференция";
                    }
                }

            }



            protected override string ResultStr()
            {

                return $"{fio.fio} {main_name} // {nameConference}: материалы науч.конф. – {city} : {izdatelstvo}, {year}г. – С.{straniciN}-{straniciE}";
            }

            ~StatSborConference()
            {
                Console.WriteLine("Объекты уничтожены");
            }
            public static string operator %(StatSborConference Object, StatSborConference Object2)
            {


                float percent = 0;
                if (Object.fio.fio == Object2.fio.fio)
                {
                    percent += 20;
                }
                if (Object.main_name == Object2.main_name)
                {
                    percent += 16;
                }
                if (Object.nameConference == Object2.nameConference)
                {
                    percent += 8;
                }
                if (Object.izdatelstvo == Object2.izdatelstvo)
                {
                    percent += 8;
                }
                ////
                if (Object.city == Object2.city)
                {
                    percent += 16;
                }
                if (Object.year == Object2.year)
                {
                    percent += 16;
                }

                if (Object.straniciN == Object2.straniciN)
                {
                    percent += 8;
                }

                if (Object.straniciE == Object2.straniciE)
                {
                    percent += 8;
                }
                if (percent > 100)
                {
                    percent = 100;
                }
                return "Процент схожести двух книг - " + percent.ToString() + '%'; ;

            }

            public static StatSborConference operator +(StatSborConference Object, StatSborConference Object2)
            {

                string fio; string main_name; string nameConference; string city; string izdatelstvo; ushort year; ushort straniciN; ushort straniciE;

                if (Object.fio.stroka_.Length >= Object2.fio.stroka_.Length)
                {
                    fio = Object.fio.stroka_;
                }
                else
                {
                    fio = Object2.fio.stroka_;
                }

                if (Object.main_name.Length >= Object2.main_name.Length)
                {
                    main_name = Object.main_name;
                }
                else
                {
                    main_name = Object2.main_name;
                }

                if (Object.nameConference.Length >= Object2.nameConference.Length)
                {
                    nameConference = Object.nameConference;
                }
                else
                {
                    nameConference = Object2.nameConference;
                }

                if (Object.year >= Object2.year)
                {
                    year = Object.year;
                }
                else
                {
                    year = Object2.year;
                }
                if (Object.city.Length >= Object2.city.Length)
                {
                    city = Object.city;
                }
                else
                {
                    city = Object2.city;
                }
                if (Object.straniciN >= Object2.straniciN)
                {
                    straniciN = Object.straniciN;
                }
                else
                {
                    straniciN = Object2.straniciN;
                }
                if (Object.straniciE >= Object2.straniciE)
                {
                    straniciE = Object.straniciE;
                }
                else
                {
                    straniciE = Object2.straniciE;
                }
                if (Object.izdatelstvo.Length >= Object2.izdatelstvo.Length)
                {
                    izdatelstvo = Object.izdatelstvo;
                }
                else
                {
                    izdatelstvo = Object2.izdatelstvo;
                }

                StatSborConference b = new StatSborConference( fio,  main_name,  nameConference,  city,  izdatelstvo,  year,  straniciN,  straniciE);


                return b;

            }
            public static bool operator <(StatSborConference Object, StatSborConference Object2)
            {
                if ((Object.straniciE - Object.straniciN + 1) < (Object2.straniciE - Object2.straniciN + 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator >(StatSborConference Object, StatSborConference Object2)
            {
                if ((Object.straniciE - Object.straniciN + 1) > (Object2.straniciE - Object2.straniciN + 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        

        class StatSborConfPech : StatSborConference
        {
            private string sborName;
            protected Avtor iof;
            public StatSborConfPech() : base()
            {
                sborName = "Сборник неизвестен";
                iof = new Avtor();

            }
            public StatSborConfPech(string fio, string main_name, string sborName,string iof, string city, string izdatelstvo, ushort year, ushort straniciN, ushort straniciE):base( fio,  main_name, sborName,  city,  izdatelstvo,  year,  straniciN,  straniciE)
            {
                this.sborName_ = sborName;
                this.iof = new Avtor(iof);
            }
            protected override string ResultStr()
            {

                return $"{fio.fio} {main_name} // {sborName}: сб. науч.труд. – / под ред. {iof.iof} – {city} : {izdatelstvo}, {year}г. – С.{straniciN}-{straniciE}";
            }

            public string sborName_
            {
                get
                {
                    return sborName;
                }
                set
                {if (value != "")
                    {
                        sborName = CorrectingName(value);
                    }
                    else
                    {
                        sborName = "Неизвестны сборник";
                    }
                   
                }
            }


            ~StatSborConfPech()
            {
              Console.WriteLine("Объекты уничтожены");
            }
            public static string operator %(StatSborConfPech Object, StatSborConfPech Object2)
            {
                float percent = 0;
                if (Object.fio.fio == Object2.fio.fio)
                {
                    percent += 10;
                }
                if (Object.fio.iof == Object2.fio.iof)
                {
                    percent += 10;
                }
                if (Object.main_name == Object2.main_name)
                {
                    percent += 16;
                }
                if (Object.sborName == Object2.sborName)
                {
                    percent += 8;
                }
                if (Object.izdatelstvo == Object2.izdatelstvo)
                {
                    percent += 8;
                }
                ////
                if (Object.city == Object2.city)
                {
                    percent += 16;
                }
                if (Object.year == Object2.year)
                {
                    percent += 16;
                }

                if (Object.straniciN == Object2.straniciN)
                {
                    percent += 8;
                }

                if (Object.straniciE == Object2.straniciE)
                {
                    percent += 8;
                }
                if (percent > 100)
                {
                    percent = 100;
                }
                return "Процент схожести двух книг - " + percent.ToString() + '%'; ;

            }
            public static StatSborConfPech operator +(StatSborConfPech Object, StatSborConfPech Object2)
            {

                string fio; string main_name; string sborName; string iof; string city; string izdatelstvo; ushort year; ushort straniciN; ushort straniciE;

                if (Object.fio.stroka_.Length >= Object2.fio.stroka_.Length)
                {
                    fio = Object.fio.stroka_;
                }
                else
                {
                    fio = Object2.fio.stroka_;
                }

                if (Object.main_name.Length >= Object2.main_name.Length)
                {
                    main_name = Object.main_name;
                }
                else
                {
                    main_name = Object2.main_name;
                }

                if (Object.sborName.Length >= Object2.sborName.Length)
                {
                    sborName = Object.sborName;
                }
                else
                {
                    sborName = Object2.sborName;
                }
                if (Object.iof.stroka_.Length >= Object2.iof.stroka_.Length)
                {
                    iof = Object.iof.stroka_;
                }
                else
                {
                    iof = Object2.iof.stroka_;
                }

                if (Object.year >= Object2.year)
                {
                    year = Object.year;
                }
                else
                {
                    year = Object2.year;
                }
                if (Object.city.Length >= Object2.city.Length)
                {
                    city = Object.city;
                }
                else
                {
                    city = Object2.city;
                }
                if (Object.straniciN >= Object2.straniciN)
                {
                    straniciN = Object.straniciN;
                }
                else
                {
                    straniciN = Object2.straniciN;
                }
                if (Object.straniciE >= Object2.straniciE)
                {
                    straniciE = Object.straniciE;
                }
                else
                {
                    straniciE = Object2.straniciE;
                }
                if (Object.izdatelstvo.Length >= Object2.izdatelstvo.Length)
                {
                    izdatelstvo = Object.izdatelstvo;
                }
                else
                {
                    izdatelstvo = Object2.izdatelstvo;
                }

                StatSborConfPech b = new StatSborConfPech( fio,  main_name,  sborName,  iof,  city,  izdatelstvo,  year,  straniciN,  straniciE);


                return b;

            }
            public static bool operator <(StatSborConfPech Object, StatSborConfPech Object2)
            {
                if ((Object.straniciE - Object.straniciN + 1) < (Object2.straniciE - Object2.straniciN + 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator >(StatSborConfPech Object, StatSborConfPech Object2)
            {
                if ((Object.straniciE - Object.straniciN + 1) > (Object2.straniciE - Object2.straniciN + 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        class Dissertatsiya : Book
        {
            protected string specialnost;
            protected string candidatOf;



            public Dissertatsiya() : base()
            {
                specialnost = "неизвестная специальность";
                candidatOf = "неизвестная кандидатская";

            }
            public Dissertatsiya(string fio, string main_name, string candidatOf, string specialnost, string city, ushort year, ushort pages)
            {
                this.fio = new Avtor(fio);
                this.main_name_ = main_name;
                this.candidatOf_ = candidatOf;
                this.specialnost_ = specialnost;
                this.city_ = city;
                this.year_ = year;
                this.pages_ = pages;
            }


            public string specialnost_
            {
                get
                {
                    return specialnost;
                }
                set
                {

                    if (value != "")
                    {
                        var n_string = new StringBuilder();
                        foreach (char c in value)
                        {
                            if (c == '.' || (Char.IsNumber(c) == true) && (c >= 0))
                            {
                                n_string.Append(c);
                            }
                        }

                        specialnost = (n_string.ToString());
                    }
                    else
                    {
                        specialnost = "00.00.00";
                    }


                }
            }

            public string candidatOf_
            {
                get
                {
                    return candidatOf;
                }
                set
                {

                    if (value != "")
                    {
                        candidatOf = CorrectingName(value).ToLower();

                    }else 
                    {
                        candidatOf = "кандидат uknown unknown";
                    }
                }
            }
            protected override string ResultStr()
            {

                return $"{fio.fio} {main_name} : дис. {candidatOf} : {specialnost}. – {city}, {year}г. – {pages} с.";
            }

            ~Dissertatsiya()
            {
                Console.WriteLine("Объекты уничтожен");
            }
            public static string operator %(Dissertatsiya Object, Dissertatsiya Object2)
            {


                float percent = 0;
                if (Object.fio.fio == Object2.fio.fio)
                {
                    percent += 20;
                }
                if (Object.main_name == Object2.main_name)
                {
                    percent += 16;
                }
                if (Object.candidatOf == Object2.candidatOf)
                {
                    percent += 8;
                }
                if (Object.specialnost == Object2.specialnost)
                {
                    percent += 8;
                }
                if (Object.city == Object2.city)
                {
                    percent += 16;
                }

                if (Object.year == Object2.year)
                {
                    percent += 16;
                }

                if (Object.pages == Object2.pages)
                {
                    percent += 16;
                }
                if (percent > 100)
                {
                    percent = 100;
                }
                return "Процент схожести двух книг - " + percent.ToString() + '%'; ;

            }

            public static Dissertatsiya operator +(Dissertatsiya Object, Dissertatsiya Object2)
            {

                string fio; string main_name; string candidatOf; string specialnost; string city; ushort year; ushort pages;

                if (Object.fio.stroka_.Length >= Object2.fio.stroka_.Length)
                {
                    fio = Object.fio.stroka_;
                }
                else
                {
                    fio = Object2.fio.stroka_;
                }

                if (Object.main_name.Length >= Object2.main_name.Length)
                {
                    main_name = Object.main_name;
                }
                else
                {
                    main_name = Object2.main_name;
                }

                if (Object.city.Length >= Object2.city.Length)
                {
                    city = Object.city;
                }
                else
                {
                    city = Object2.city;
                }
                if (Object.candidatOf.Length >= Object2.candidatOf.Length)
                {
                    candidatOf = Object.candidatOf;
                }
                else
                {
                    candidatOf = Object2.candidatOf;
                }
                if (Object.specialnost.Length >= Object2.specialnost.Length)
                {
                    specialnost = Object.specialnost;
                }
                else
                {
                    specialnost = Object2.specialnost;
                }

                if (Object.year >= Object2.year)
                {
                    year = Object.year;
                }
                else
                {
                    year = Object2.year;
                }
                if (Object.pages >= Object2.pages)
                {
                    pages = Object.pages;
                }
                else
                {
                    pages = Object2.pages;
                }

                Dissertatsiya b = new Dissertatsiya( fio,  main_name,  candidatOf,  specialnost,  city,  year,  pages);


                return b;

            }

            public static bool operator <(Dissertatsiya Object, Dissertatsiya Object2)
            {
                if (Object.pages < Object2.pages)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            public static bool operator >(Dissertatsiya Object, Dissertatsiya Object2)
            {
                if (Object.pages > Object2.pages)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }




        static void Main(string[] args)
        {

            //      К   Н   И   Г   А
            Console.WriteLine("Работа с объектом КНИГА(родитель для всех)");
            Console.WriteLine("Пустой объект");
            Book b0 = new Book();
            b0.Show();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Объект 1");
            Book b = new Book("И@шлИНский Алек@са@ндр + Юл@ев!ич AKKAKAKAKAK", "Прикладные задачи механики: в двух книгах", "Мо.!@сква", "Нау!!ка", 2040, 420);
            b.Show();
            Console.WriteLine();
            Console.WriteLine("Объект 2");
            Book b1 = new Book("И@шлИНский Алек@са@ндр + Юл@ев!ич AKKAKAKAKAK", "Пр@#икdfdfладные задачи механики: в двух книгах", "Мо.!@сква", "Нау!!ка", 2040, 416);
            b1.Show();
            Console.WriteLine();
            Console.WriteLine("Была произведена запись в файл результата");
            b.WriteInToFileTXT();
            Console.WriteLine();
            Console.WriteLine("Результат сравнения в %");
            Console.WriteLine(b % b1);
            Console.ReadKey();
            Console.WriteLine();
            Book b3;
            b3 = b + b1;
            Console.WriteLine();
            Console.WriteLine("Объект 3. Сложены наибольшие составляющие 2 объектов");
            b3.Show();
            Console.WriteLine();
            if (b > b1)
            {
                Console.WriteLine("У объекта1 больше страниц. - Утверждение истино (Проверка на true)");
            };
            Console.WriteLine();
            if (b1 > b)
            {
                Console.WriteLine("У объекта1 больше страниц. ");
            }
            else
            {
                Console.WriteLine("У объекта2 больше страниц. - Утверждение ложно (Проверка на false)");
            }

            //-------------------------------ДЕСТРУКТОР---------------------------\
            //while (true)
            //{

            //    Book Book = new Book();


            //}
            //-------------------------------ДЕСТРУКТОР---------------------------\

            //      К   Н   И   Г   А

            //      С   Т   А   Т   Ь   Я

            //Statement st0 = new Statement();
            //st0.Show();
            //Console.WriteLine();
            //Console.WriteLine();
            //Statement st = new Statement("МУзей!мнеК! Ольга Юрьевна", "Гибридное автоматизированное проектирование молотовых поковок ступенчатых валов ", "Ку!знечно-штамповочное производство. Обработка материалов давлением", 2013, 6, 36, 32);
            //st.Show();
            //st.WriteInToFileTXT();

            //      С   Т   А   Т   Ь   Я

            //      С   Т   А   Т   Ь   Я   СБОРКОНФ

            //StatSborConference st0 = new StatSborConference();
            //st0.Show();
            //Console.WriteLine();
            //Console.WriteLine();
            //StatSborConference st = new StatSborConference("бараЗ!!  Владислав Рувимович", "Фрикционное деформирование аустенитных сталей: особенности структуры и формирования механических свойств ", "XX Уральская    школа металловедов-термистов \"актуальные проблемы физического металловедения сталей и сплавов\", посвященная 100-летию со дня рождения Н. Н. Липчина, Пермь, 1–5 февраля 2010 г.", "        Екатери!!нбург       ", "УГТУ-УПИ", 2013, 9, 8);
            //st.Show();
            //st.WriteInToFileTXT();

            //      С   Т   А   Т   Ь   Я   СБОРКОНФ


            //      С   Т   А   Т   Ь   Я   СБОРНАУЧПЕЧ

            //Console.WriteLine("Работа с объектом Сборник научных трудов(наследник)");
            //Console.WriteLine("Пустой объект");
            //StatSborConfPech sbnp0 = new StatSborConfPech();
            //sbnp0.Show();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("Объект 1");
            //StatSborConfPech sbnp = new StatSborConfPech("не@федова Ольга алексеевна!", "Вариацио!!!!нный          принцип виртуальных скоростей и напряжений для модели анизотропного упругого идеально пластичного материала", "Механика деформирования и разруш!!!!!ения", "Жужгова Юлия Евгеньевна", "!!Екатеринбург", "УрО РАН", 2001, 9, 50);
            //sbnp.Show();
            //Console.WriteLine();
            //Console.WriteLine("Объект 2");
            //StatSborConfPech sbnp1 = new StatSborConfPech("не@федова Ольга алексеевна!", "Вариацио!!!!нный          принцип виртуальных скоростей и напряжений для модели анизотропного упругого идеально пластичного материала", "Механика деформирования и разруш!!!!!ения", "Жужгова Юлия Евгеньевна", "!!Екатеринбург", "УрО РАН", 2001, 9, 19);
            //sbnp1.Show();
            //sbnp1.WriteInToFileTXT();
            //Console.WriteLine();
            //Console.WriteLine("Результат сравнения в %");
            //Console.WriteLine(sbnp % sbnp1);
            //Console.ReadKey();
            //Console.WriteLine();
            //StatSborConfPech sbnp3;
            //sbnp3 = sbnp + sbnp1;
            //Console.WriteLine("Объект 3. Сложены наибольшие составляющие 2 объектов");
            //sbnp3.Show();
            //Console.WriteLine();
            //if (sbnp > sbnp1)
            //{
            //    Console.WriteLine("У объекта1 больше страниц. - Утверждение истино (Проверка на true)");
            //};
            //if (sbnp1 > sbnp)
            //{
            //    Console.WriteLine("У объекта1 больше страниц ");
            //}
            //else
            //{
            //    Console.WriteLine("У объекта2 больше страниц. - Утверждение ложно (Проверка на false)");
            //}

            //while (true)
            //{

            //    StatSborConfPech StatSborConfPech = new StatSborConfPech();


            //}


            //      С   Т   А   Т   Ь   Я   СБОРНАУЧПЕЧ

            //      Д   И   С   С   Е   Р   Т   А   Ц   И   Я

            //Dissertatsiya st0 = new Dissertatsiya();
            //st0.Show();
            //Console.WriteLine();
            //Console.WriteLine();
            //Dissertatsiya st = new Dissertatsiya("Путилова Евгения Оскарова", "Магнитный контроль структуры, фазового состава и прочностных характеристик многокомпонентных материалов", "технических наук", " 05.1а1.1!3", "ЕкА!теринбург", 2013, 143);

            //st.Show();
            //st.WriteInToFileTXT();

            //-------------------------------ДЕСТРУКТОР---------------------------\

            //while (true)
            //{

            //    Dissertatsiya Dissertatsiya = new Dissertatsiya();
            //}

            //-------------------------------ДЕСТРУКТОР---------------------------\

            //Dissertatsiya st0 = new Dissertatsiya();
            //st0.Show();
            //Console.WriteLine();
            //Console.WriteLine();
            //Dissertatsiya st = new Dissertatsiya("Путилова Евгения Оскарова", "Магнитный контроль структуры, фазового состава и прочностных характеристик многокомпонентных материалов", "кандидат технич!еских наук", " 05.1а1.1!3", "ЕкА!теринбург", 2013, 143);
            //st.Show();
            //Console.ReadKey();
            //      Д   И   С   С   Е   Р   Т   А   Ц   И   Я
        }
    }
}
