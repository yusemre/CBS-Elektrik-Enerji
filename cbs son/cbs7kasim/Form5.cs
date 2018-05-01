using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cbs7kasim
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ARAS")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =10 into sel");
                
            }
            else if (comboBox1.Text == "TRAKYA")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =1 into sel");
            }
            else if (comboBox1.Text == "İSTANBUL")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =3 into sel");
            }
            else if (comboBox1.Text == "DİCLE")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =8 into sel");
            }
            else if (comboBox1.Text == "VANGÖLÜ")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =9 into sel");
            }
            else if (comboBox1.Text == "AKDENİZ")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =6 into sel");
            }
            else if (comboBox1.Text == "ADM")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =5 into sel");
            }
            else if (comboBox1.Text == "OSMANGAZİ")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =15 into sel");
            }
            else if (comboBox1.Text == "ULUDAĞ")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =2 into sel");
            }
            else if (comboBox1.Text == "ÇAMLIBEL")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =20 into sel");
            }
            else if (comboBox1.Text == "MERAM")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =16 into sel");
            }
            else if (comboBox1.Text == "TOROSLAR")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =7 into sel");
            }
            else if (comboBox1.Text == "KAYSERİ")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =17 into sel");
            }
            else if (comboBox1.Text == "GEDİZ")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =4 into sel");
            }
            else if (comboBox1.Text == "BAŞKENT")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =13 into sel");
            }
            else if (comboBox1.Text == "SAKARYA")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =14 into sel");
            }
            else if (comboBox1.Text == "ÇORUH")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =11 into sel");
            }
            else if (comboBox1.Text == "YEŞİLIRMAK")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =12 into sel");
            }
            else if (comboBox1.Text == "AKEDAŞ")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =19 into sel");
            }
            else if (comboBox1.Text == "FIRAT")
            {
                Form1.mi.Do("select * from \"Iller\" where bolge_no =18 into sel");
            }

        }
    }
}
