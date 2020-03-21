using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheBitBrine;

namespace AutoIndexCrawler
{
    public partial class Form1 : Form
    {
        public bool StartBool = false;
        public bool PauseBool = false;
        public string[] StartingPointString = { };
        public string CrawlMode = "Full Index";
        public string ExportLocationString = "";
        public List<string> TheWholeList = new List<string>();
        //UI Controls
        public bool AutoScrollBool = false;
        public bool AutoRefreshBool = true;
        public bool isLinkValid = false;
        //Stats
        public int LinkCount = 0;
        public int FileCount = 0;
        public int ProgressRate = 0;
        //Stuff
        public Stopwatch RuntimeStat = new Stopwatch();
        UsefulMethods UsefulMethods = new UsefulMethods();
        //Threads
        Thread Crawler;
        Thread NewDiscoveriesToFile;

        #region UIStuff


        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            ThreadStart THS = new ThreadStart(FinishCheckThreaded);
            Thread TH = new Thread(THS);
            TH.IsBackground = true;
            TH.Start();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (isLinkValid)
            {
                if (StartButton.Text == "Start")
                {
                    StartButton.Text = "Stop";

                    if (FileOnly.Checked) CrawlMode = "File Only";
                    if (FullIndex.Checked) CrawlMode = "Full Index";
                    if (DirectoryOnly.Checked) CrawlMode = "Directory Only";

                    StartBool = true;
                    StartingPointLabel.Enabled = false;
                    InputTextBox.Enabled = false;
                    FullIndex.Enabled = false;
                    DirectoryOnly.Enabled = false;
                    FileOnly.Enabled = false;
                    ExportLocationButton.Enabled = false;
                    DataSourceRefresher.Enabled = true;
                    BeginTheIndexingShit();
                    RuntimeStat.Start();
                }
                else
                {
                    StartBool = false;
                    StartButton.Text = "Start";
                    StartingPointLabel.Enabled = true;
                    InputTextBox.Enabled = true;
                    FullIndex.Enabled = true;
                    DirectoryOnly.Enabled = true;
                    FileOnly.Enabled = true;
                    ExportLocationButton.Enabled = true;
                    if (Crawler != null)
                        Crawler.Abort();
                    DataSourceRefresher.Enabled = false;
                    RuntimeStat.Stop();
                }
            }
            else
            {
                MessageBox.Show("Invaild or unreachable host.\r\nCheck the link to make sure it's up and valid.", "Invaild URL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void StartingPoint_TextChanged(object sender, EventArgs e)
        {
            string[] AutoIndexListBox = InputTextBox.Text.Split('\n');
            for (int i = 0; i < AutoIndexListBox.Length; i++)
            {
                if (AutoIndexListBox[i].Contains("\n"))
                    AutoIndexListBox[i] = AutoIndexListBox[i].Replace("\n", "");
                if (AutoIndexListBox[i].Contains("\r"))
                    AutoIndexListBox[i] = AutoIndexListBox[i].Replace("\r", "");
                if (!AutoIndexListBox[i].StartsWith("http"))
                    AutoIndexListBox[i] = "http://" + AutoIndexListBox[i];
            }
            StartingPointString = AutoIndexListBox;

        }

        private void ExportLocationButton_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            ExportLocationDialog.Filter = "Comma-separated values (*.csv) | *.csv";
            ExportLocationDialog.FileName = "Crawl-" + r.Next(1000, 10000);
            DialogResult DR = ExportLocationDialog.ShowDialog();
            if (DR.ToString() == "OK" && ExportLocationDialog.FileName != "")
                ExportLocationString = ExportLocationDialog.FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ValidateGivenLink(StartingPointString);
        }

        private void DataSourceRefresher_Tick(object sender, EventArgs e)
        {
            if (AutoRefreshBool)
            {
                if(ResultsList.Items.Count >= 250)
                ResultsList.Items.Clear();

                for (int i = 0; i < TheWholeList.Count; i++)
                {
                    if (ResultsList.Items.Contains(TheWholeList[i]) == false && TheWholeList[i].StartsWith("www.") == false)
                    {
                        ResultsList.Items.Add(TheWholeList[i]);
                    }
                }
            }
            if (AutoScrollBool && AutoRefreshBool)
            {
                ResultsList.TopIndex = ResultsList.Items.Count - 1;
            }
        }


        private void AutoRefresh_Click(object sender, EventArgs e)
        {
            if (AutoRefresh.Text.Contains("On") == true)
            {
                AutoRefreshBool = false;
                AutoRefresh.Text = AutoRefresh.Text.Replace("On", "Off");
            }
            else
            {
                AutoRefreshBool = true;
                AutoRefresh.Text = AutoRefresh.Text.Replace("Off", "On");

            }
        }

        private void AutoScroll_Click(object sender, EventArgs e)
        {
            if (AutoScroll.Text.Contains("On") == true)
            {
                AutoScrollBool = false;
                AutoScroll.Text = AutoScroll.Text.Replace("On", "Off");
            }
            else
            {
                AutoScrollBool = true;
                AutoScroll.Text = AutoScroll.Text.Replace("Off", "On");

            }
        }

        private void ClearResults_Click(object sender, EventArgs e)
        {
            ResultsList.Items.Clear();
        }

        private void StatsRefresher_Tick(object sender, EventArgs e)
        {
            Runtime.Text = "[Runtime: " + string.Format("{0:hh\\:mm\\:ss}", RuntimeStat.Elapsed) + "]";
            Stats.Text = "[Total vDirs: " + LinkCount + "] [Total Files: " + FileCount + "]";
            try
            {
                Form1.ActiveForm.Text = "AutoIndex Crawler - Threads: " + Process.GetCurrentProcess().Threads.Count;
            }
            catch { /*SUCK IT UP DUDE!*/ }
        }

        private void LinkValidator_Tick(object sender, EventArgs e)
        {
            if (ExportLocationString != "" && InputTextBox.Text != "" && isLinkValid == true) StartButton.Enabled = true;
            else StartButton.Enabled = false;
        }

        private void InputTextBox_DoubleClick(object sender, EventArgs e)
        {
            InputTextBox.SelectAll();
        }

        private void InputTextBox_GotFocus(object sender, EventArgs e)
        {
            InputTextBox.SelectAll();
        }

        private void InputTextBox_LostFocus(object sender, EventArgs e)
        {
            InputTextBox.SelectedText = "";
        }



        private void ResultsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(ResultsList.SelectedItem.ToString());
        }

        #endregion

        public void BeginTheIndexingShit()
        {
            ThreadStart TS = new ThreadStart(ThreadStarter);
            Crawler = new Thread(TS);
            Crawler.IsBackground = true;
            Crawler.Start();

            ThreadStart TS2 = new ThreadStart(WriteToFile);
            NewDiscoveriesToFile = new Thread(TS2);
            NewDiscoveriesToFile.IsBackground = true;
            NewDiscoveriesToFile.Start();

        }

        public void ThreadStarter()
        {
            string StartingList = "";
            for (int i = 0; i < StartingPointString.Length; i++)
            {
                if (i != StartingPointString.Length - 1)
                    StartingList += StartingPointString[i] + "\n";
                else
                    StartingList += StartingPointString[i];
            }
            MainCrawlerEngine(StartingList);
        }

        public void WriteToFile()
        {
            if (File.Exists(ExportLocationString) == true)
                File.Delete(ExportLocationString);
            do
            {
                try
                {
                    StreamWriter SW = new StreamWriter(ExportLocationString + ".temp", true);

                    List<string> TempList = new List<string>();
                    TempList.AddRange(TheWholeList);

                    ClearOut<string>(TheWholeList);
                    PauseBool = true;
                    TempList.Sort();
                    for (int i = 0; i < TempList.Count; i++)
                    {
                        if(TempList[i].StartsWith("www.") == false)
                        SW.WriteLine(TempList[i].Replace("&amp;","&"));
                    }
                    SW.Close();
                    SW.Dispose();
                    PauseBool = false;
                    SortExportFile(ExportLocationString);
                    Thread.Sleep(5000);
                }
                catch { }
            } while (StartBool == true);
        }

        public void SortExportFile(string Location)
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = Location + ".temp /O " + Location; 
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "sort";
            Process.Start(Info);
        }

        public void ClearOut<T>(List<T> List)
        {
            List.Clear();
            int identificador = GC.GetGeneration(List);
            GC.Collect(identificador, GCCollectionMode.Forced);
        }


        public void MainCrawlerEngine(object StartingPoint)
        {
            if(StartBool == false) { Thread.CurrentThread.Abort(); }
            while (PauseBool == true) { Thread.Sleep(100); }

            string[] AutoIndexList = StartingPoint.ToString().Split('\n');
            for (int y = 0; y < AutoIndexList.Length; y++)
            {
                string CurrentHTMLString = UsefulMethods.LinkToHTML(AutoIndexList[y]);
                List<string> AllExtractedLinks = UsefulMethods.GetLinksRegex(UsefulMethods.HrefToFullLink(AutoIndexList[y], CurrentHTMLString));

                for (int i = 0; i < AllExtractedLinks.Count; i++)
                {
                    if (UsefulMethods.HTMLOrNot(AllExtractedLinks[i]))
                    {
                        if (CrawlMode != "File Only")
                            TheWholeList.Add(/*"Link: " + */AllExtractedLinks[i]);
                        //MainCrawlerEngine(AllExtractedLinks[i]);
                        ParameterizedThreadStart DiscoveryLoopPTS = new ParameterizedThreadStart(MainCrawlerEngine);
                        Thread DiscoveryLoopTH = new Thread(DiscoveryLoopPTS);
                        DiscoveryLoopTH.IsBackground = true;
                        DiscoveryLoopTH.Start(AllExtractedLinks[i]);
                        LinkCount++;
                    }
                    else
                    {
                        if (CrawlMode != "Directory Only" && TheWholeList.Contains(AllExtractedLinks[i]) == false)
                            TheWholeList.Add(/*"File: " + */AllExtractedLinks[i]);
                        FileCount++;
                    }
                }
            }
        }

        public void ValidateGivenLink(string[] Links)
        {
            Thread VaildationThread = new Thread(() => VaildateLink());
            VaildationThread.IsBackground = true;
            VaildationThread.Start();
        }

        public void VaildateLink()
        {
            while (true)
            {
                string[] AutoIndexList = StartingPointString;
                for (int y = 0; y < AutoIndexList.Length; y++)
                {
                    using (WebClient webClient = new WebClient())
                    {
                        try
                        {
                            webClient.DownloadData(AutoIndexList[y]);
                            isLinkValid = true;
                        }
                        catch (Exception ex)
                        {
                            isLinkValid = false;
                        }
                    }
                }
                Thread.Sleep(50);
            }
        }

        public void STAHP()
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C echo 1 && \"" + Application.ExecutablePath + "\"";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
            Application.Exit();
        }

        public void FinishCheckThreaded()
        {
            //while (true)
            //{
            //    int TempLink = LinkCount;
            //    int TempFile = FileCount;

            //    Thread.Sleep(1000);
            //    if (TempFile == FileCount && TempLink == LinkCount)
            //    {
            //        Thread.Sleep(3500);
            //        if (TempFile == FileCount && TempLink == LinkCount)
            //        {
            //            WriteToFile();
            //            Finished = true;
            //        }
            //        else
            //            Finished = false;
            //    }
            //}
        }

    }
}
