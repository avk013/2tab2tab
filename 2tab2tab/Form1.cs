using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2tab2tab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[][] tab_array_in_double1 = null;
            string[][] tab_array_in_double2 = null;
            string[][] tab_array_in_double_out = null;
            int nom_begin = 0, column_tab=0;
            string[] tab1 = File.ReadAllLines(@"c:\!!\1.csv", Encoding.Default);
            string[] tab2 = File.ReadAllLines(@"c:\!!\2.csv", Encoding.Default);
            string[] tab_array_in;
            tab_array_in_double1 = new string[tab1.Length][];
            tab_array_in_double2 = new string[tab2.Length][];
            int maxim=0;
            //if (tab2.Length > tab1.Length)
                maxim =(tab2.Length+ tab1.Length);
            tab_array_in_double_out = new string[maxim][];

            for (int i = 0; i < tab1.Length; i++)
            {
                tab_array_in_double1[i] = new string[16];
                if (!String.IsNullOrEmpty(tab1[i]))
                {
                    tab_array_in = tab1[i].Split(',');
                    column_tab=tab_array_in.Length;
                    for (int j = 0; j < column_tab; j++)
                    { tab_array_in_double1[i][j] = tab_array_in[j]; }
                }
            }
            ////////////////
            for (int i = 0; i < tab2.Length; i++)
            {
                tab_array_in_double2[i] = new string[14];
                if (!String.IsNullOrEmpty(tab2[i]))
                {
                    tab_array_in = tab2[i].Split(',');
                    column_tab = tab_array_in.Length;
                    for (int j = 0; j < column_tab; j++)
                    { tab_array_in_double2[i][j] = tab_array_in[j]; }
                }
            }
            label4.Text = tab_array_in_double1.Length.ToString();
            label5.Text = tab_array_in_double2.Length.ToString();
            // format tab1
            //идентификатор,Файл,Операционная система, Пакет обновления ОС, Имя компьютера,Имя пользователя, SMTP -адрес e - mail,Вход в домен,Тип ЦП,Системная плата,Системная память, Монитор, Дисковый накопитель,Первичный адрес IP,Первичный адрес MAC
            // format tab2
            //кабинет,компьютер,email,антивирус,ethernal-Bluechecker,лицензия,ХР,ELT,принтер/сканер,scaner,корпус,ИПБ,свитч/роутер
            // идея компььютер должен совпадать с частью идентификатора, или имени компьютера, или имени пользователя
            // 2.1 сравниваем с 1.0, 1.4, 1.5
            int k = 0;
            for(int i=0;i<tab_array_in_double2.Length;i++)
            {
                
                //tab_array_in_double_out[i][1]= i.ToString();
                for (int ii = 0; ii < tab_array_in_double1.Length; ii++)
                {
                if (
                        //(tab_array_in_double1[ii][0].IndexOf(tab_array_in_double2[i][0]) >= 0) ||
                // имя учетки в имени файла                
            (tab_array_in_double1[ii][0].ToUpper().IndexOf(tab_array_in_double2[i][1].ToUpper()) >= 0)
              && // номер кабинета в имени файла
              (tab_array_in_double1[ii][0].ToUpper().IndexOf(tab_array_in_double2[i][0].ToUpper()) >= 0)
                // 
                //|| (tab_array_in_double1[ii][4].IndexOf(tab_array_in_double2[i][1]) > 0)
                //|| (tab_array_in_double1[ii][5].IndexOf(tab_array_in_double2[i][1]) > 0)))
                )//)
                    {
                        tab_array_in_double_out[k] = new string[30];
                        tab_array_in_double_out[k][1] = tab_array_in_double2[i][0];
                        tab_array_in_double_out[k++][2] = tab_array_in_double2[i][1];
                    }
                    

                }
                // tab_array_in_double_out[i][i] = i.ToString();
            }




            //массив в csv
            SaveArrayAsCSV(tab_array_in_double_out, @"c:\!!\out.csv");
        }




        public static void SaveArrayAsCSV(Array arrayToSave, string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                WriteItemsToFile(arrayToSave, file);
            }
        }

        private static void WriteItemsToFile(Array items, TextWriter file)
        {
            foreach (object item in items)
            {
                if (item is Array)
                {
                    WriteItemsToFile(item as Array, file);
                    file.Write(Environment.NewLine);
                }
                else file.Write(item + ",");
            }
        }
    }

}
