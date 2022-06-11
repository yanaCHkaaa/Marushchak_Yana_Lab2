using System;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
//Скласти опис класу для дати. Зберігає день, місяць і рік.
//Методи: різниця в днях двох дат, дата відстоїть від заданої на задану кількість днів (місяців), день тижня.
//Зробити властивості класу приватними, а для їх читання створити методи-геттери.

namespace lab2
{


    class Date
    {
        private int day;
        private int month;
        private int year;

        public int Day
        {
            get { return day; }
            set { day = value; }
        }
        public int Month
        {
            get { return month; }
            set { month = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public Date(int D, int M, int Y)
        {
            Day = D;
            Month = M;
            Year = Y;
        }
        public int Subtract1 = 60;
        public int Subtract2 = 19;

        public void dateDifferance(Date Date1, Date Date2)
        {
            double dayDate1 = ((1461 * (Date1.Year + 4800 + (Date1.Month - 14) / 12)) / 4 + (367 * (Date1.Month - 2 - 12 * ((Date1.Month - 14) / 12))) / 12 - (3 * ((Date1.Year + 4900 + (Date1.Month - 14) / 12) / 100)) / 4 + Date1.Day - 32075);
            double dayDate2 = ((1461 * (Date2.Year + 4800 + (Date2.Month - 14) / 12)) / 4 + (367 * (Date2.Month - 2 - 12 * ((Date2.Month - 14) / 12))) / 12 - (3 * ((Date2.Year + 4900 + (Date2.Month - 14) / 12) / 100)) / 4 + Date2.Day - 32075);
            if (dayDate1 > dayDate2)
            {
                int diff = Convert.ToInt32(dayDate1 - dayDate2);
                Console.WriteLine($"A differance between two days is {diff} days");
            }
            else
            {
                int diff = Convert.ToInt32(dayDate2 - dayDate1);
                Console.WriteLine($"A differance between two days is {diff} days");
            }



        }

        public void dayDifferance()
        {
            while (Day <= Subtract1)
            {
                Month -= 1;
                Day = Day + 30;
            }
            if (Day >= Subtract1)
            {
                Day -= Subtract1;
            }
            Console.WriteLine(CurrentDate());
        }

        public void monthDifferance()
        {
            while (Month <= Subtract2)
            {
                Year--;
                Month += 12;
            }
            if (Month >= Subtract2)
            {
                Month -= Subtract2;
            }
            Console.WriteLine(CurrentDate());
        }



        public void weekday()
        {
            string[] Days = new string[7];
            Days[0] = "Неділя";
            Days[1] = "Понеділок";
            Days[2] = "Вівторок";
            Days[3] = "Середа";
            Days[4] = "Четвер";
            Days[5] = "П'ятниця";
            Days[6] = "Субота";

            Day = Day % 7;
            string Answer = Days[Day];
            Console.WriteLine("Curent day of the week is " + Answer);
        }
        public string CurrentDate()
        {
            return "The current date is " + Day + "/" + Month + "/" + Year;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Date date1 = new Date(22, 08, 2022);
            Date date2 = new Date(28, 05, 2019);
            JSONser(date1);
            var Datework = Deserialize();
            Datework.dateDifferance(date1, date2);
            Datework.dayDifferance();
            Datework.monthDifferance();
            Datework.weekday();

            static void JSONser(Date date)
            {
                var json = JsonConvert.SerializeObject(date);

                File.WriteAllText(@"D:/EDUCATION/ОП/2 СЕМЕСТР/2/lab 2/json_file", json);
            }

            static Date Deserialize()
            {
                string filePath = @"D:/EDUCATION/ОП/2 СЕМЕСТР/2/lab 2/json_file";
                if (File.Exists(filePath))
                {
                    var DeserializationObj = JsonConvert.DeserializeObject<Date>(File.ReadAllText(filePath));
                    return DeserializationObj;
                }
                else
                {
                    return null;
                }
            }
            Console.ReadKey();
        }
    }
}