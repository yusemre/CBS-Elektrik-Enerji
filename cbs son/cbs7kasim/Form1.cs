using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MapInfo;

namespace cbs7kasim
{
    public partial class Form1 : Form
    {
        public static string win_id;
        public static MapInfo.MapInfoApplication mi;
        Callback callb;
        public Form3 f3 = new Form3();
        public Form5 f5 = new Form5();
        string file_path;
        
        
        public Form1()
        {
            InitializeComponent();
            callb = new Callback(this);
        }
        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private void Form1_Load(object sender, EventArgs e)
        {
            mi = new MapInfo.MapInfoApplication();
            //mi = Activator.CreateInstance(Type.GetTypeFromProgID("Mapinfo.Application")) as MapInfoApplication;
            int p = panel1.Handle.ToInt32();
            mi.Do("set next document parent " + p.ToString() + "style 1");
            mi.Do("set application window " + p.ToString());
            mi.Do("run application \"" + "d:/OLE7.wor" + "\"");
            mi.Do("Add Column \"Iller\" (tuketim Decimal (20, 3))From Elektrik_Uretim_Tuketim Set To Elektrik_Uretim Where COL2 = COL1  Dynamic");
            mi.Do("Add Column \"Iller\" (uretim Decimal (20, 3))From Elektrik_Uretim_Tuketim Set To Elektrik_Tuketim Where COL2 = COL1  Dynamic");
            mi.Do("Add Column \"Iller\" (kayip_kacak Decimal (20, 1))From Kayip_Kacak Set To Il_KK_Oran Where COL2 = COL1  Dynamic");
            mi.Do("Add Column \"Iller\" (gunes Decimal (20, 1))From Ortalama_Gunes_Suresi Set To Ortalama_Gunes_Suresi Where COL2 = COL1  Dynamic");
            mi.Do("Add Column \"Iller\" (uretim_tuketim_oran Float)From Elektrik_Uretim_Tuketim Set To Elektrik_Tuketim/Elektrik_Uretim Where COL2 = COL1  Dynamic");
            mi.Do("Add Column \"Iller\" (tuketim_uretim_oran Float)From Elektrik_Uretim_Tuketim Set To Elektrik_Uretim/Elektrik_Tuketim Where COL2 = COL1  Dynamic");
            mi.Do("Add Column \"Iller\" (bolge_kayip_kacak Decimal (20, 1))From Kayip_Kacak Set To Bolge_KK_Oran Where COL2 = COL1  Dynamic");
            mi.Do("Add Column \"Iller\" (kayip_kacak_enerji Decimal (20, 1))From Kayip_Kacak Set To Kayip_Kacak_Enerji Where COL2 = COL1  Dynamic");
            mi.Do("Add Column \"Iller\" (bolge_no Float)From Kayip_Kacak Set To Bolge_No Where COL2 = COL1  Dynamic");
            win_id = mi.Eval("frontwindow()");

            mi.SetCallback(callb);
            mi.Do("create buttonpad \"a\" as toolbutton calling OLE \"info\" id 2001");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (mi != null)
            {
                // The form has been resized. 
                if (mi.Eval("WindowID(0)") != "")
                {
                    // Update the map to match the current size of the panel. 
                    MoveWindow((System.IntPtr)long.Parse(mi.Eval("WindowInfo(FrontWindow(),12)")), 0, 0, this.panel1.Width, this.panel1.Height, false);
                }
            }

        }




        private void button5_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command 1706");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command 1705");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command id 2001");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command 1702");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            file_path = ("d:/" + DateTime.Now.Second);
            mi.Do("Save Window " + win_id + " As \"" + file_path + ".bmp\" Type \"BMP\" Copyright \"    \"");
            MessageBox.Show("Dosya, " + file_path + " konumunda kaydedilmiştir.", "Uyarı");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }


    }

    [ComVisible(true)]
    public class Callback
    {
        Form1 f1;

        public Callback(Form1 _f1)
        {
            f1 = _f1;
        }
        public void info(string a)
        {
            int k = Convert.ToInt32(Form1.mi.Eval("searchpoint(frontwindow(),commandinfo(1),commandinfo(2))"));
            string tabloadi = "";
            for (int i = 1; i <= k; i++)
            {
                tabloadi = Form1.mi.Eval("SearchInfo(" + i.ToString() + ",1)");
                String row_id = Form1.mi.Eval("SearchInfo(" + i.ToString() + ",2)");
                Form1.mi.Do("Fetch rec " + row_id + " From " + tabloadi);
                if ((tabloadi == "Iller"))
                {
                    f1.Invoke(new mapinfo(f1.f3.fill_form));

                }
            }
        }
        delegate void mapinfo();
    }
}
