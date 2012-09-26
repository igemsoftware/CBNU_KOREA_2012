using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using MySql.Data;
//using MySql.Data.MySqlClient;

namespace Synb_Project_TeamB
{
    public partial class Home_View : Form
    {
        FileInfo _finfo = new FileInfo(@"./Synb_Tree.accdb");

        Uri Synb_ftp_server = new Uri("ftp://210.115.163.125/synb/Synb_Tree.accdb");

        Timer mainImageTimer;
        int timerCnt;

        public Home_View()
        {
            InitializeComponent();

            timerCnt = 1;

            TBnotice.Text = "DB접속 중입니다.......";
            ViewerData.InitMySql("Synb_View", "root", "1234");
            TBnotice.Text = "DB접속 완료........";
            TBnotice.Text = getNotice();

            if (isDBNew())
            {
                BTupdate.Hide();

                PBindivDownload.Value = 0;
                PBtotalDownload.Value = 0;
                LBtotalFileName.Text = "Local Database Version Is Already New!";
                LBtotalProg.Text = "";
                LBindivFileName.Text = "";
                LBindivProg.Text = "";
            }
            else
            {

            }

            mainImageTimer = new Timer();

            mainImageTimer.Tick += new EventHandler(onMainImagetimer);
            mainImageTimer.Interval = 5000;
            mainImageTimer.Start();

        }

        private void onMainImagetimer(object sender, System.EventArgs e)
        {
            timerCnt++;
            if(timerCnt == 4)
                timerCnt = 1;
            try
            {
                switch (timerCnt)
                {
                    case 1:
                        BTmainImage1_Click(null, null);
                        break;
                    case 2:
                        BTmainImage2_Click(null, null);
                        break;
                    case 3:
                        BTmainImage3_Click(null, null);
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }
        } 

        public String getNotice()
        {
            String query = "SELECT content FROM Synb_View.notice";

            ViewerData.notice_reader(query);

            return ViewerData.getLastNotice();
        
        }

        void synb_ftp_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            PBindivDownload.Value = e.ProgressPercentage;
        }

        private void file_Down()
        {
            WebClient synb_ftp = new WebClient();

                synb_ftp.Credentials = new NetworkCredential("UserId", "Password");

                synb_ftp.DownloadProgressChanged += new DownloadProgressChangedEventHandler(synb_ftp_DownloadProgressChanged);
                synb_ftp.DownloadFileAsync(Synb_ftp_server, @"./Synb_Tree.accdb");
                synb_ftp.Dispose();
        }

        private void ftp_server_Download()
        {
            //파일 여부 확인 후 없으면 파일 생성. 
            

            if (!_finfo.Exists)
            {
                file_Down();
            }
            else
            {


            }
        }

        bool isDBNew()
        {
            return true;
        }


        private void Viewer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Viewer view = new Viewer(this);
            view.Show();
        }

        private void Designer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Designer design = new Designer(this);
            design.Show();
        }

        private void BTmainImage1_Click(object sender, EventArgs e)
        {
            IVwindow.Image = Image.FromFile("../../Resources/1.PNG");
            BTmainImage1.Image = Image.FromFile("../../Resources/bullet_blue.PNG");
            BTmainImage2.Image = Image.FromFile("../../Resources/bullet_black.PNG");
            BTmainImage3.Image = Image.FromFile("../../Resources/bullet_black.PNG");

            mainImageTimer.Stop();
            mainImageTimer.Start();

            this.timerCnt = 1;
        }

        private void BTmainImage2_Click(object sender, EventArgs e)
        {
            IVwindow.Image = Image.FromFile("../../Resources/9.PNG");
            BTmainImage1.Image = Image.FromFile("../../Resources/bullet_black.PNG");
            BTmainImage2.Image = Image.FromFile("../../Resources/bullet_blue.PNG");
            BTmainImage3.Image = Image.FromFile("../../Resources/bullet_black.PNG");

            mainImageTimer.Stop();
            mainImageTimer.Start();

            this.timerCnt = 2;
        }

        private void BTmainImage3_Click(object sender, EventArgs e)
        {
            IVwindow.Image = Image.FromFile("../../Resources/8.PNG");
            BTmainImage1.Image = Image.FromFile("../../Resources/bullet_black.PNG");
            BTmainImage2.Image = Image.FromFile("../../Resources/bullet_black.PNG");
            BTmainImage3.Image = Image.FromFile("../../Resources/bullet_blue.PNG"); 

            mainImageTimer.Stop();
            mainImageTimer.Start();

            this.timerCnt = 3;
        }
    }
}
