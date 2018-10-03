using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Point
    {
        public Point(int r, int c)
        {
            Row = r;
            Col = c;
        }


        public int Row { get; set; }
        public int Col { get; set; }

        public static bool operator ==(Point x, Point y)
        {
            return x.Row == y.Row && x.Col == y.Col;
        }

        public static bool operator !=(Point x, Point y)
        {
            return !(x == y);
        }
    }


    class Program
    {
        private static int[,] a2D;
        private const int maxr = 20;
        private const int maxc = 20;
        private const int maxdeep = 4;
        private static List<Point[]> ways;
        private static Point[] temp;
        private static Point[] MAX;
        private static int max = 1;

        static void Main(string[] args)
        {

            var RR = new RemoveRecursion();

            // задание 4. 
            RR.doSomeWorkWithSomeData();

            

            DecodeTest(); // Тест на дкедирование
            OptimizeThis(); // Тест на знание .NET

            // Тест на неправильную ф-цию
            var lst = new List<int>();
            lst.Add(1);
            Method1(ref lst);
            foreach (var VARIABLE in lst)
                Console.Write($"     >>>{VARIABLE}<<<     ");


            // первое задане
            ways = new List<Point[]>();
            MAX = new Point[4];
            init();

            Console.WriteLine("start");
            for (int x = 0; x < maxc; x++)
            {
                for (int y = 0; y < maxr; y++)
                {
                    var p = new Point(x, y);
                    funk(p, 0, p);
                    Console.WriteLine($"x={x}y={y}");
                    Pow();
                }
            }
            Console.WriteLine("done");


             for (int i = 0; i < maxdeep; i++)
                Console.WriteLine($"r-{MAX[i].Row}  c-{MAX[i].Col} v={a2D[MAX[i].Row, MAX[i].Col]}");

            Console.WriteLine($"MAX = {max}");
            
            Console.ReadLine();
            
        }


        private static void DecodeTest()
        {
            Console.WriteLine(
                String.Intern(
                    X111.GetDecodedMessage(
                        "eflohgcpkgjpegaapahapboajbfbdbmbhedcbekcgfbdkphdlepdgegekdnepcefhdlfiobggcjgadahd" +
                        "chhmnnhncfiobmiibdjanjjcoakkmhklapkfaglkbnloldmcalmkacngpinfppnepgomknojpeplolpf" +
                        "pcajojamoabonhbhjobmnfccnmcboddlikdnmbedniegmpeemgfamnfhiegghlghkchiljhglainlhih" +
                        "goififjdkmjnkdkalkkmkblffilehplojgmeknmjeennjlnmicomijojiapkdhpihopaifaiimapgdbe" +
                        "ikblhbcfcicegpceggdmbndmgeeoflecgcfhgjflfagkahgicogcdfhfcmhopcipekiaebjkdijeepje" +
                        "dgkmomkaeelpcllpccmmcjmnnpmmbhnmboneneocbmoomcppakpnababbiadapaibgbmlmbiaecmpkcd" +
                        "lbddmidnkpdnpgemonehoefaplfmocgpnjgloahfjhhdnohdofimimimndjknkjembkcnikbnpkpmglh" +
                        "mnlciemlflmifcnekjnhlaoklhocgoomkfpblmpmkdakkkadfbbakibckpbmjgckincmiedcildbjcea" +
                        "ijeidafbihflhofchfgbhmghhdhjhkhigbidhiinbpioggjggnjebekfflkhfclofjljeamhehmoeome" +
                        "efnmplnnedoodkoidbpaphpbeppmdgaadnafcebnclbonbcacjcgcadmbhdlbodnbfebbmejmcfhakfb" +
                        "bbgeaignlognpfhganhcaeifalihpbjjpijnppjkogkcknkepelpollcocmeojmknanajhnbooncnfom" +
                        "mmoeidpemkpnmbajmiammpahmgbbmnbllecpllcjgcdpkjdblaeaghegloejkffmkmfgkdgbfkgcjbha" +
                        "jihojphkigioinioiejmiljgicklhjkbialeihlncolkhfmjhmmdhdnlgkndgboofiomgpoiggpacnpp" +
                        "aeabelamfcblejbdaacefhcfeocpdfdhpldaedekdkemdbfgdifldpffofgecngecehiclhiccincjid" +
                        "npiechjmbojkmekoamkjadlfbklolamhaimbapmipfnhpmnnpdoppkooobpgkipdpppcpgagonanneba" +
                        "olbcoccinjcoiadmmhdgnodjmfecimeomdfomkfnlbglligfmpgjlghllnhbleihglinkcjpkjjekakk" +
                        "khkkkokckfldjmldkdmfjkmijbnejinbfpnaegoggnoaiephdlpnicaaijadiablchbphobggfcahmcd" +
                        "hddmbkdkfbeegiedbpeffgffgnfofegmelgcfchefjhheaikehigeoifpejidmjoddkodkkjoallcilj" +
                        "dplbcgmjcnmpceniblniccokbjonbapjbhpennpfmeacbmaladbbakbkpacjaicipocalfdapmdjpdef" +
                        "pkeipbfcoifbopfpoggijngkoehfolhpicibojimnajpmhjbnojhmfknhmkomdlplkljlbmbhimklpme" +
                        "lgnglnnaleofllopfcpojjpojaackhackoahkfblfmb", 7400187)));
        }

        //Каким способом можно оптимизировать следующий код:
        private static void OptimizeThis()
        {
            
            string a = "a";

            /* Пример кода из задания
                        for (int i = 0; i < 1000000; i++)
                            a += "a";
            */
            // Пример оптимизация  
            a = a.PadRight(1000000, a[0]);

            //вывод результата на экран
            //Console.WriteLine(a);
        }

        /// <summary>
        /// Неверный метод. List передается по ссылке. Передавать ссылку по ссылке как то не прилчно
        /// </summary>
        /// <param name="listDigits"></param>
        private static void Method1(ref List<int> listDigits)
        {
            listDigits.Add(55);
            listDigits[0] = 2;
            var q = new List<int>();
            q.Add(66);

            listDigits = q; // если ссылка по ссылке то ориганильный лит во внешней процедуре затирается
        }

        // И все остальное 
        private static void init()
        {
            a2D = new int[20, 20]
            {
                {08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
                {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00},
                {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
                {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
                {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
                {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
                {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
                {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
                {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
                {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
                {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
                {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
                {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
                {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
                {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
                {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
                {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
                {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
                {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
                {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48}
            };
        }

        private static void funk(Point p, int step, Point prevPoint)
        {
            if (step == 0)
            {
                temp = new Point[maxdeep];
            }
            if (step > maxdeep - 1)
            {
                bool exist = false;

                    foreach (var way in ways)
                    {
                        int i;
                        for (i = 0; i < maxdeep; i++)
                            if (way[i] != temp[i]) break;
                        if (i == maxdeep) exist = true;
                    }
                if (!exist)
                {
                    var t = new Point[maxdeep];
                    t[0] = temp[0];
                    t[1] = temp[1];
                    t[2] = temp[2];
                    t[3] = temp[3];
                    ways.Add(t);


                   // for (int i = 0; i < maxdeep; i++)
                    //    Console.WriteLine($"r-{temp[i].Row}  c-{temp[i].Col} v={a2D[temp[i].Row, temp[i].Col]}");

                }
                //temp = new Point[4];
                // Console.ReadLine();
                return;

            }



            temp[step] = p;
            step++;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    var newP = new Point(p.Row + x, p.Col + y);
                    if (p == newP) continue;
                    if (newP.Col < 0 || newP.Row < 0 || newP.Col >= maxc || newP.Row >= maxr) continue;
                    bool exist = false;
                    for (int i = 0; i < step; i++)
                        if (temp[i] == newP) exist = true;
                    if (exist) continue;

                    funk(newP, step, p);
                }
            }
        }

        private static void Pow()
        {
            
            foreach (var way in ways)
            {

                int t = 1;
                for (int i = 0; i < maxdeep; i++)
                    t = t * getvalue(way[i]);
                if (t > max)
                {
                    MAX[0] = way[0];
                    MAX[1] = way[1];
                    MAX[2] = way[2];
                    MAX[3] = way[3];
                    max = t;
                }
            }

            ways.Clear();
            //for (int i = 0; i < maxdeep; i++)
            //    Console.WriteLine($"r-{MAX[i].Row}  c-{MAX[i].Col} v={a2D[MAX[i].Row, MAX[i].Col]}");

        }

        private static int getvalue(Point p)
        {
            return a2D[p.Row, p.Col];
        }
    }
}

/*

тест по sql

1) структура данных
---------------------------------------------
TABLE SELLERS
id 					: int : key
fio                 : varchar : uniq
qualificationof     : int
experience          : int
havecar             : bool
---------------------------------------------
TABLE HHANTERS
id                  : int : key
fio                 : varchar : uniq
experience          : int
phoneNumber         : varchar
---------------------------------------------
TABLE QUALIFICATION
id                  : int : key
value               : varchar
---------------------------------------------
4) Необходимо добавить новую колонку «Дата рождения», таким образом, чтобы не изменять структуру таблиц базы данных (т.е добавлять только записи с помощью Insert)
// Если я правильно понял задание, то решением является добавление таблицы EXTENSIONS которая должна ссылаться на таблицы SELLERS и HHANTERS.
// В предоставленном решинии связ создается на основе уникального поля fio существующего в таблицах SELLERS и HHANTERS
// Вторым решением является создание ключей для таблиц со сквозной нумерацией для всей базы т.е. значение полей id никогда не повтаряются.
TABLE EXTENSIONS
id                  : int : key
extensionsFor       : varchar : uniq
BirthDate           : DateTime:
---------------------------------------------


2) Сформировать SQL запросы, с помощью которых можно получить данные для формирования каждой таблицы.

SELLERS
select fio, value, experience, havecar, BirthDate from SELLERS
   join QUALIFICATION on QUALIFICATION.id = SELLERS.qualificationof
   join EXTENSIONS on EXTENSIONS.extensionsFor = SELLERS.fio 

HHANTERS
select fio, experience, phoneNumber, BirthDate from HHANTERS
join EXTENSIONS on EXTENSIONS.extensionsFor = HHANTERS.fio 


3) Какие SQL запросы нужно сформировать чтобы перенести сотрудника

    insert into HHANTERS values (
        select fio from SELLERS where id = @aid, 
        select experience from SELLERS where id = @aid,
        aphoneNumber);
    delete from SELLERS where id = @aid;
    
 */
 



    
