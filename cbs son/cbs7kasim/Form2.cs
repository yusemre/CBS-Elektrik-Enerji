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
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt16(textBox1.Text);
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            removetematik();
            
            if (comboBox1.Text == "Elektrik Üretim(MWh)")
            {
                Form1.mi.Do("select uretim from Iller order by uretim into sel noselect");
                thematic_column = "uretim";
            }
            else if (comboBox1.Text == "Elektrik Tüketim(MWh)")
            {
                thematic_column = "tuketim";
                Form1.mi.Do("select tuketim from Iller order by tuketim into sel noselect");
            }
            else if (comboBox1.Text == "İl Bazında Kayıp Kaçak(%)")
            {
                thematic_column = "kayip_kacak";
                Form1.mi.Do("select kayip_kacak from Iller order by kayip_kacak into sel noselect");
            }
            else if (comboBox1.Text == "Aylık Güneş Süresi Ortalamasının Yıllık Toplamı(saat)")
            {
                thematic_column = "gunes";
                Form1.mi.Do("select gunes from Iller order by gunes into sel noselect");
            }
            else if (comboBox1.Text == "Elektrik Üretim Tüketim Oranı")
            {
                thematic_column = "uretim_tuketim_oran";
                Form1.mi.Do("select uretim_tuketim_oran from Iller order by uretim_tuketim_oran into sel noselect");
            }
            else if (comboBox1.Text == "Elektrik Tüketim Üretim Oranı")
            {
                thematic_column = "tuketim_uretim_oran";
                Form1.mi.Do("select tuketim_uretim_oran from Iller order by tuketim_uretim_oran into sel noselect");
            }
            else if (comboBox1.Text == "Dağıtım Bölgesi Bazında Kayıp Kaçak(%)")
            {
                thematic_column = "bolge_kayip_kacak";
                Form1.mi.Do("select bolge_kayip_kacak from Iller order by bolge_kayip_kacak into sel noselect");
            }


            int range = Convert.ToInt16(Form1.mi.Eval("int(tableinfo(sel,8)/" + Convert.ToString(n) + ")"));
            int c_range = Convert.ToInt16(255 / n);
            //----------part 2 -----
            Form1.mi.Do("fetch first from sel");
            string r1 = Convert.ToString(Form1.mi.Eval("sel.col1"));
            string r2 = string.Empty;
            string cmstr = string.Empty;

            for (int i = 1; i < n; i++)
            {
                Form1.mi.Do("fetch rec " + Convert.ToString(i * range) + " from sel");
                r2 = Convert.ToString(Form1.mi.Eval("sel.col1"));
                string rgb = Convert.ToString(Form1.mi.Eval("RGB(255," + Convert.ToString((n - i) * c_range) + "," + Convert.ToString((n - i) * c_range) + ")"));
                cmstr = cmstr + r1 + ":" + r2 + " brush(2," + rgb + ",16777215), ";
                r1 = r2;
            }
            Form1.mi.Do("fetch last from sel");
            r2 = Convert.ToString(Form1.mi.Eval("sel.col1"));
            cmstr = cmstr + r1 + ":" + r2 + " brush(2,16711680,16777215)";
            // ----------part 3 -----
            Form1.mi.Do("shade window " + Form1.win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            Form1.mi.Do("Set Next Document Parent " + p + " Style 1");
            Form1.mi.Do("Create Cartographic Legend From Window " + Form1.win_id + " Behind Frame From Layer 1");


        }

        public void removetematik()
        {
            for (int k = Convert.ToInt16(Form1.mi.Eval("mapperinfo(" + Form1.win_id + ",9)")); k > 0; k = k - 1)
            {
                if (Convert.ToInt16(Form1.mi.Eval("layerinfo(" + Form1.win_id + "," + Convert.ToString(k) + ",24)")) == 3)
                {
                    Form1.mi.Do("remove map layer \"" + Form1.mi.Eval("layerinfo(" + Form1.win_id + "," + Convert.ToString(k) + ",1)") + "\"");
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }

}
   