using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakSavar.Properties;

namespace UcakSavar
{
    public partial class Oyun : Form
    {
        public Oyun()
        {
            InitializeComponent();
        }

        UcakSavar ucakSavar = new UcakSavar();
        List<DusmanUcak> dusmanUcaklar = new List<DusmanUcak>();

        private void Oyun_Load(object sender, EventArgs e)
        {
            this.Width = Ayarlar.OyunEn;
            this.Height = Ayarlar.OyunBoy;

            this.Controls.Add(ucakSavar.Resim);
            timer1.Interval = Ayarlar.DusmanUcakSN * 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DusmanUcak dusman = new DusmanUcak();
            dusmanUcaklar.Add(dusman);
            this.Controls.Add(dusman.Resim);
        }

        List<Karakter> silinecekler = new List<Karakter>();

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (var ucak in dusmanUcaklar)
            {
                ucak.Asagi();
                foreach (var item in ucakSavar.Mermiler)
                    if (ucak.Resim.Bounds.IntersectsWith(item.Resim.Bounds))
                        Carpisma(ucak, item);
            }
            SilinecekleriSil();
        }

        private void SilinecekleriSil()
        {
            foreach (var item in silinecekler)
                if (item is DusmanUcak)
                    dusmanUcaklar.Remove((DusmanUcak)item);
                else if (item is Mermi)
                    ucakSavar.Mermiler.Remove((Mermi)item);
        }

        private void Carpisma(DusmanUcak ucak, Mermi mermi)
        {
            this.Controls.Remove(ucak.Resim);
            this.Controls.Remove(mermi.Resim);
            silinecekler.Add(ucak);
            silinecekler.Add(mermi);
        }

        private void Oyun_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    ucakSavar.SolaGit();
                    break;
                case Keys.Right:
                    ucakSavar.SagaGit();
                    break;
                case Keys.Space:
                    var mermiResim = ucakSavar.AtesEt();
                    this.Controls.Add(mermiResim);
                    break;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            foreach (var bizimMermi in ucakSavar.Mermiler)
                bizimMermi.Yukari();
        }

        private void Oyun_SizeChanged(object sender, EventArgs e)
        {
        
        }
    }
}
