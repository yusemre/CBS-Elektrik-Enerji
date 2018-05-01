using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cbs7kasim
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        public void fill_form()
        {
            
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalSeparator = ",";
            nfi.CurrencyGroupSeparator = ".";
            nfi.CurrencySymbol = "";

            //nfi.CurrencyGroupSeparator = ".";
            //nfi.CurrencySymbol = "";
            //label1.Text = Convert.ToDecimal(a).ToString("C3",nfi);
            string l6 =Form1.mi.Eval("iller.uretim*0.4120*1000");
            string l5 = Form1.mi.Eval("iller.uretim*0.0780*1000");
            string l7 = Form1.mi.Eval("iller.uretim-iller.tuketim");
            string l12 = Form1.mi.Eval("iller.uretim");
            string l14 = Form1.mi.Eval("iller.tuketim");
            string l15 = Form1.mi.Eval("iller.tuketim/(1-(iller.kayip_kacak/100))");
            string l20 = Form1.mi.Eval("(iller.tuketim/(1-(iller.kayip_kacak/100)))-iller.tuketim");
            string l21 = Form1.mi.Eval("((iller.tuketim/(1-(iller.kayip_kacak/100)))-iller.tuketim)*0.4120*1000");
            double l7d = Convert.ToDouble(l7);

            if (l7d < 0)
            {
                l7d = l7d * -1;
                label7.Text = "-" + Convert.ToDecimal(l7d).ToString("C0", nfi) + " MWh";
            }
            else
            {
                label7.Text = Convert.ToDecimal(l7).ToString("C0", nfi) + " MWh";
            }


            decimal l21f = Convert.ToDecimal(l21);
            l21f = l21f / 100;
            decimal l20f = Convert.ToDecimal(l20);
            l20f = l20f / 100;
            decimal l15f = Convert.ToDecimal(l15);
            l15f = l15f / 100;
            label3.Text = Form1.mi.Eval("iller.il_adi");
            label4.Text = Form1.mi.Eval("iller.plaka_no");
            label6.Text = Convert.ToDecimal(l6).ToString("C0");
            label5.Text = Convert.ToDecimal(l5).ToString("C0");

            label12.Text = Convert.ToDecimal(l12).ToString("C0", nfi) + " MWh";
            label14.Text = Convert.ToDecimal(l14).ToString("C0", nfi) + " MWh";
            label15.Text = l15f.ToString("C0", nfi) + " MWh"; //dağıtım şirketinden gelen elektrik miktarı
            label17.Text = "% " + Form1.mi.Eval("iller.kayip_kacak");
            label20.Text = l20f.ToString("C0", nfi) + " MWh"; //il kayıp kaçak oranı ve il tüketim miktarı kullanılarak kayıp kaçak miktarı hesaplama
            label21.Text = l21f.ToString("C0");

            //label3.Text = Form1.mi.Eval("iller.il_adi");
            //label4.Text =Form1.mi.Eval("iller.plaka_no");
            //label6.Text = Form1.mi.Eval("iller.uretim*0.4120*1000");
            //label5.Text =  Form1.mi.Eval("iller.uretim*0.0780*1000");
            //label7.Text =  Form1.mi.Eval("iller.uretim-iller.tuketim");
            //label12.Text = Form1.mi.Eval("iller.uretim");
            //label14.Text = Form1.mi.Eval("iller.tuketim");
            //label15.Text = Form1.mi.Eval("iller.tuketim/(1-(iller.kayip_kacak/100))");
            //label17.Text = "% " + Form1.mi.Eval("iller.kayip_kacak");
            //label20.Text = Form1.mi.Eval("(iller.tuketim/(1-(iller.kayip_kacak/100)))-iller.tuketim");
            //label21.Text =Form1.mi.Eval("((iller.tuketim/(1-(iller.kayip_kacak/100)))-iller.tuketim)*0.4120*1000");


            int pp = panel1.Handle.ToInt32();

            Form1.mi.Do("Select * from Iller where PLAKA_NO = \"" + Form1.mi.Eval("iller.plaka_no") + "\" into Selection");
            Form1.mi.Do("Set Next Document Parent " + panel1.Handle + " Style 1");

            Form1.mi.Do("Graph IL_ADI, tuketim ,uretim From Selection Using \"C:\\ProgramData\\MapInfo\\MapInfo\\Professional\\1150\\GraphSupport\\Templates\\Column\\Clustered.3tf\" Series In Columns");
            Form1.mi.Do("Set Graph Title \"Üretim ve Tüketim (MWh) \" SubTitle \"\" Footnote \"\" TitleGroup \"\" TitleAxisY1 ");


            this.ShowDialog();
        }

    }
}
