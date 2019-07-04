using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakSavar.Properties;

namespace UcakSavar
{
    public class Karakter
    {
       public PictureBox Resim { get; set; }

        public int Ust
        {
            get
            {
                return Resim.Top;
            }
            set
            {
                Resim.Top = value;
            }
        }

        public int Sol
        {
            get
            {
                return Resim.Left;
            }
            set
            {
                Resim.Left = value;
            }
        }

        public int Hiz { get; set; }

        public Karakter()
        {
            Resim = new PictureBox();
            Resim.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void SolaGit()
        {
            Sol-=Hiz;
        }

        public void SagaGit()
        {
            Sol+=Hiz;
        }

        public void Yukari()
        {
            Ust-=Hiz;
        }

        public void Asagi()
        {
            Ust+=Hiz;
        }
    }

    public class Mermi : Karakter
    {
        public Mermi() : base()
        {
            Hiz = 10;
            Resim.Image = Resources.mermi;
            Resim.Width = 25;
            Resim.Height = 25;
        }
    }

    public class UcakSavar : Karakter
    {
        public List<Mermi> Mermiler = new List<Mermi>();
        public UcakSavar() :base()
        {
            Hiz = 15;
            Resim.Width = 60;
            Resim.Height = 60;
            Resim.Image = Resources.ucaksavar;
            Ust = Ayarlar.OyunBoy - 60;
            Sol = (Ayarlar.OyunEn - 60) / 2;
        }

        public PictureBox AtesEt()
        {
            Mermi m = new Mermi();
            m.Ust = Ust;
            m.Sol = Sol + 10;
            Mermiler.Add(m);
            return m.Resim;
        }
    }

    public class DusmanUcak : Karakter
    {
        Random r = new Random();
        public DusmanUcak() : base()
        {
            Hiz = 8;
            Resim.Width = 30;
            Resim.Height = 30;
            Resim.Image = Resources.ucak;
            Sol = r.Next(0, Ayarlar.OyunEn - 30);
        }
    }
    
}
