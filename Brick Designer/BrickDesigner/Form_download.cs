﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Data.OleDb;
using System.Threading;
using System.Xml;

/*
 * 
 * 전체적인 변수, 함수 재 정렬 및 재 작성
 * 
 */

/*
 * TreeView     )) 전체삭제 버튼
 *              )) 트리뷰로 추가할때 시간이 지체되는 현상이 있음 // 알고리즘을 바꿔서 빠르게 해야할듯
 *              
 * DB           )) 특수문자 이상한것
 * INIT         )) 디비 다운로드 완료시 DB를 새로하는 작업을 해야함 // Combobox 도 새롭게 하고, 리스트뷰, 트리뷰도 새롭게 한다.
 * 
 * Download     )) 다운로드 실패한 리스트 사용자에게 보여주기
 * 
 * 
 * 그리고 지금까지 다운로드 받은 애들을 따로 저장해서 그 애들은 어떻게 해야할지?????
 * 
 * 다운로드 창을 켰을때 디비 만들어주고 걍 끄면 에러남 // 테이블 생성 확인해야함ㄴ
 */


/*
 * FASTA다운받으면
 *              1. DB입력을 시켜야함
 *              2. COMBO박스 init
 * 
 * 
 * 
 */


namespace BrickDesigner
{
    public partial class Form_Download : Form
    {

        public AutoResetEvent areStep1 = new AutoResetEvent(false);

        FileInfo downfile = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "Fasta.cbu"));
        
        BackgroundWorker bgw;
        BackgroundWorker bgw2;
        BackgroundWorker bgw3;
        DBconnector connector;


        List<string> list_brick;

        public Form_Download()
        {
            InitializeComponent();

            bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            bgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker_ProgressChanged);
            bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);

            bgw2 = new BackgroundWorker();
            bgw2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker2_DoWork);
            bgw2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker2_RunWorkerCompleted);

            bgw3 = new BackgroundWorker();
            bgw3.WorkerReportsProgress = true;
            bgw3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker3_DoWork);
            bgw3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker3_ProgressChanged);
            bgw3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker3_RunWorkerCompleted);

            connector = new DBconnector();

            this.combo_from_db();
        }





        // Fasta 파일 다운로드 클릭
        private void down_fasta_Click(object sender, EventArgs e)
        {
            // bgw가 다운로드 중이면 창을 끌때 확인창 필요함
            // 파일 유지여부는 생각해봐야할듯

            downfile.Refresh();

            if (!downfile.Exists)
            {
                if (MessageBox.Show("파일을 다운로드하시겠습니까?", "Download", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bgw.RunWorkerAsync();
                }
            }
            else
            {
                if (MessageBox.Show("파일을 다시 다운로드하시겠습니까?\n\nFile : "+downfile.LastWriteTime, "다운로드", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bgw.RunWorkerAsync();
                }
            }

        }


        // Fasta 파일 다운받기
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // 여기 url 외부텍스트파일에서 가져올것

            string url = "http://partsregistry.org/fasta/parts/All_Parts";

            WebRequest req = WebRequest.Create(url);
            req.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            Encoding enc;

            if (res.CharacterSet.ToLower() == "utf-8")
            {
                enc = Encoding.UTF8;
            }
            else
            {
                enc = Encoding.Default;
            }

            Stream dataStream = res.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, enc);

            Int64 iSize = res.ContentLength;
            Int64 iRun = 0;

            using (WebClient cli = new WebClient())
            {
                using (Stream streamRemote = cli.OpenRead(new Uri(url)))
                {
                    using (Stream streamLocal = new FileStream(Directory.GetCurrentDirectory() + "\\Fasta.cbu", FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        int iByteSize = 0;
                        byte[] byteBuffer = new byte[iSize];

                        while ((iByteSize = streamRemote.Read(byteBuffer, 0, byteBuffer.Length)) > 0)
                        {
                            streamLocal.Write(byteBuffer, 0, iByteSize);
                            iRun += iByteSize;

                            double dI = (double)(iRun);
                            double dT = (double)byteBuffer.Length;
                            double dP = (dI / dT);

                            int iP = (int)(dP * 100);

                            bgw.ReportProgress(iP);
                        }

                        streamLocal.Close();
                    }

                    streamRemote.Close();
                }

            }


        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("");
            progressBar1.Value = 0;
            downfile.Refresh();

            if (MessageBox.Show("DB에 적용하겠습니다. 예상시간: 3분", "Database", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bgw2.RunWorkerAsync();
            }
        }


        // 기본 데이터 베이스 작성하기
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                downfile.Refresh();

                try
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        progressBar1.Style = ProgressBarStyle.Marquee;
                    }));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                if (downfile.Exists)
                {
                    string str_q = "select part_id from part;";
                    OleDbDataReader oddr = connector.select_Data(str_q);

                    List<string> strl_Part_id = new List<string>();

                    while (oddr.Read())
                    {
                        strl_Part_id.Add(oddr.GetInt32(0).ToString());
                    }

                    FileStream fs = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), downfile.Name), FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs, Encoding.Default);

                    string line;
                    String[] str_Brickname;

                    System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("\"" + @"[\w\W]*" + "\"");

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith(">"))
                        {
                            str_Brickname = null;
                            str_Brickname = line.Split(' ');

                            // 만약 데이터베이스에 있다면 건너기

                            if (strl_Part_id.Contains(str_Brickname[2]))
                            {
                                // nothing;
                            } // end if
                            else
                            {
                                // 없다면 추가하기
                                
                                string str_qu_insert_brick = "insert into part (part_id,part_name,part_short_desc,part_type) values (@ID, @NAME, @SDESC, @TYPE);";

                                OleDbCommand conm = new OleDbCommand(str_qu_insert_brick);
                                
                                conm.Parameters.AddWithValue("@ID", str_Brickname[2]);
                                conm.Parameters.AddWithValue("@NAME", str_Brickname[0].Replace(">", ""));
                                conm.Parameters.AddWithValue("@SD", rx.Match(line).ToString().Replace("\"", ""));
                                conm.Parameters.AddWithValue("@TYPE", str_Brickname[3]);

                                connector.update_Data(conm);
                                

                            } // end else

                        } // end if

                    } // end while

                }

            }
            catch (System.Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }


        }

        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Complete");

            // 콤보상자 다시 업데이트

            combo_from_db();

            try
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    progressBar1.Style = ProgressBarStyle.Blocks;
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }






        // 콤보박스 가져와서 추가하기
        private void combo_from_db()
        {
            comboBox1.Items.Clear();

            string str_select_qu = "select distinct(part_type) from part";

            OleDbDataReader oddr = connector.select_Data(str_select_qu);

            while (oddr.Read())
            {
                comboBox1.Items.Add(oddr.GetString(0));
            }

            oddr.Close();

        }


        // 콤보박스 셀렉트가 체인지 되었을 경우
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            listView1.Items.Clear();

            string str_select_qu = "select part_name, part_short_desc, part_type from part where part_type = '" + comboBox1.SelectedItem.ToString() + "'";

            OleDbDataReader oddr = connector.select_Data(str_select_qu);

            int i = 0;

            ListViewItem item;

            while (oddr.Read())
            {
                item = new ListViewItem(oddr.GetString(0));
                item.SubItems.Add(oddr.GetString(1));
                item.SubItems.Add(oddr.GetString(2));

                try
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        listView1.Items.Add(item);
                    }));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                i++;
            }

            label3.Text = i.ToString();
        }




        // 서치브릭
        private void search_brick()
        {

            if (textBox1.Text.Length == 0)
            {
                return;
            }
            else
            {
                // 현재 어디에 라디오 버튼이 있는지 확인

                ListViewItem item;
                listView1.Items.Clear();
                OleDbDataReader oddr;

                if (radioButton1.Checked)
                {
                    string str_select_qu = "select part_name, part_short_desc, part_type from part where part_name like '%" + textBox1.Text + "%'";
                    oddr = connector.select_Data(str_select_qu);
                }
                else
                {
                    string str_select_qu = "select part_name, part_short_desc, part_type from part where part_short_desc like '%" + textBox1.Text + "%'";
                    oddr = connector.select_Data(str_select_qu);
                }

                int i = 0;

                while (oddr.Read())
                {
                    item = new ListViewItem(oddr.GetString(0));
                    item.SubItems.Add(oddr.GetString(1));
                    item.SubItems.Add(oddr.GetString(2));

                    try
                    {
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            listView1.Items.Add(item);
                        }));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                    i++;
                }

                label3.Text = i.ToString();
                oddr.Close();
            }
        }

        // 서치버튼
        private void button4_Click(object sender, EventArgs e)
        {
            this.search_brick();
        }

        // 서치 엔터시
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                this.search_brick();
            }
        }



        // 플러스 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            // 각 버튼 클릭 시 변수로 진행 중 체크

            for (int i = 0; i < listView1.CheckedItems.Count; i++)
            {
                string node_type = listView1.CheckedItems[i].SubItems[2].Text;
                if (node_type.Length == 0)
                {
                    node_type = "-";
                }
                string temp_node = listView1.CheckedItems[i].SubItems[0].Text;

                // 현재 타입의 노드가 있는지 ?

                if (treeView1.Nodes.ContainsKey(node_type))
                {
                    // 서브 노드로 가지고 있는지?

                    if (treeView1.Nodes[node_type].Nodes.ContainsKey(temp_node))
                    {
                    }
                    else
                    {
                        treeView1.Nodes[node_type].Nodes.Add(temp_node, temp_node);
                    }

                }
                else
                {
                    TreeNode tn = treeView1.Nodes.Add(node_type, node_type);
                    tn.Nodes.Add(temp_node, temp_node);

                }
            }

            treeView1.ExpandAll();
        }


        // 마이너스 버튼
        private void button3_Click(object sender, EventArgs e)
        {
            // 전체 삭제 버튼도 있어야 할듯


            // 선택한것이 없으면 리턴

            if (treeView1.SelectedNode == null)
            {
                return;
            }

            // 선택한 노드를 지우는데 현재 부모노드가 단지 하나의 노드만 가지고 있으면 그 부모노드를 지운다.

            // 현재노드가 부모노드이면 현재를 지운다.


            // 현재 노드가 서브노드인지 부모노드인지 판단

            if (treeView1.SelectedNode.Parent != null)
            {
                // 서브노드이면
                // 서브노드들이 몇개있는지 판단
                if (treeView1.SelectedNode.Parent.Nodes.Count == 1)
                {
                    // 한개있으면 지우기
                    treeView1.Nodes.Remove(treeView1.SelectedNode.Parent);
                }
                else
                {
                    //여러개있으면 걍 그놈 지우기
                    treeView1.SelectedNode.Remove();
                }

            }
            else
            {
                // 부모노드이면
                // 걍 지우기
                treeView1.SelectedNode.Remove();
            }

            treeView1.SelectedNode = null;
        }


        // 브릭 다운로드 버튼
        private void button5_Click(object sender, EventArgs e)
        {
            
            if (bgw3.IsBusy)
            {
                return;
            }
            
            
            // xml 다운로드

            list_brick = new List<string>();

            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                {
                    list_brick.Add(treeView1.Nodes[i].Nodes[j].Text);
                }
            }

            if (list_brick.Count == 0)
            {
                MessageBox.Show("선택한 브릭이 없습니다.", "다운로드", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(list_brick.Count + " 개의 브릭을 다운로드 하시겠습니까?", "다운로드", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // 모든 노드들을 거쳐가면서 서브노드를 출력해야함

                this.progressBar1.Maximum = list_brick.Count;

                bgw3.RunWorkerAsync();
                
            }
            

        }



        private void BackgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            // XML 에서 다운받기

            string str_current_id = null;
            try
            {
                for (int i = 0; i < list_brick.Count; i++)
                {
                    int j = 1, d = 1, ss = 1;

                    //string str_current_id = null;

                    try
                    {
                        XmlNodeList xnList;
                        XmlDocument xDoc = new XmlDocument();

                        xnList = null;

                        xDoc.Load("http://partsregistry.org/cgi/xml/part.cgi?part=" + list_brick[i]);


                        // 1
                        xnList = xDoc.SelectNodes("/rsbpml/part_list/part");

                        foreach (XmlNode xn in xnList)
                        {

                            str_current_id = xn["part_id"].InnerText;

                            string str_qu = "UPDATE part SET part_short_desc = @DESC, part_short_name = @SNAME, part_status = @STATUS, part_result = @RESULT , part_nickname = @NNAME, part_rating = @RATING, part_url = @URL, part_entered = @ENTERED, part_author = @AUTHOR, best_quality = @QUALITY WHERE part_name = '" + list_brick[i] + "'";

                            OleDbCommand conm = new OleDbCommand(str_qu);

                            conm.Parameters.AddWithValue("@DESC", xn["part_short_desc"].InnerText);
                            conm.Parameters.AddWithValue("@SNAME", xn["part_short_name"].InnerText);
                            conm.Parameters.AddWithValue("@STATUS", xn["part_status"].InnerText);
                            conm.Parameters.AddWithValue("@RESULT", xn["part_results"].InnerText);
                            conm.Parameters.AddWithValue("@NNAME", xn["part_nickname"].InnerText);

                            if (xn["part_rating"].InnerText.Length != 0)
                            {
                                conm.Parameters.AddWithValue("@RATING", xn["part_rating"].InnerText);
                            }
                            else
                            {
                                conm.Parameters.AddWithValue("@RATING", DBNull.Value);
                            }

                            conm.Parameters.AddWithValue("@URL", xn["part_url"].InnerText);
                            conm.Parameters.AddWithValue("@ENTERED", xn["part_entered"].InnerText);
                            conm.Parameters.AddWithValue("@AUTHOR", xn["part_author"].InnerText);
                            conm.Parameters.AddWithValue("@QUALITY", xn["best_quality"].InnerText);


                            connector.update_Data(conm);
                            conm.Dispose();
                        }



                        //2
                        xnList = xDoc.SelectNodes("/rsbpml/part_list/part/deep_subparts/subpart");

                        foreach (XmlNode xn in xnList)
                        {
                            string str_qu = "insert into deep_subparts (part_id, subpart_id, part_sub_num) values (@ID, @SID, @PSN)";

                            OleDbCommand conm = new OleDbCommand(str_qu);

                            conm.Parameters.AddWithValue("@ID", str_current_id);
                            conm.Parameters.AddWithValue("@SID", xn["part_id"].InnerText);
                            conm.Parameters.AddWithValue("@PSN", d);

                            connector.insert_Data(conm);
                            conm.Dispose();

                            d++;

                        }

                        xnList = xDoc.SelectNodes("/rsbpml/part_list/part/specified_subparts/subpart");

                        foreach (XmlNode xn in xnList)
                        {
                            string str_qu = "insert into specified_subparts (part_id, subpart_id, part_sub_num ) values (@ID, @SID, @PSN)";

                            OleDbCommand conm = new OleDbCommand(str_qu);

                            conm.Parameters.AddWithValue("@ID", str_current_id);
                            conm.Parameters.AddWithValue("@SID", xn["part_id"].InnerText);
                            conm.Parameters.AddWithValue("@PSN", ss);

                            connector.insert_Data(conm);
                            conm.Dispose();

                            ss++;
                        }

                        xnList = xDoc.SelectNodes("/rsbpml/part_list/part/specified_subscars/scar");

                        foreach (XmlNode xn in xnList)
                        {
                            string str_qu = "insert into specified_subscars (part_id, part_scar_num , scar_id, scar_type, scar_name, scar_nickname, scar_comments, scar_seq) values (@ID, @PSN, @SID, @STYPE, @SNAME, @SNNAME, @SCOM, @SSEQ)";

                            OleDbCommand conm = new OleDbCommand(str_qu);

                            conm.Parameters.AddWithValue("@ID", str_current_id);
                            conm.Parameters.AddWithValue("@PSN", j);
                            conm.Parameters.AddWithValue("@SID", xn["scar_id"].InnerText);
                            conm.Parameters.AddWithValue("@STYPE", xn["scar_type"].InnerText);
                            conm.Parameters.AddWithValue("@SNAME", xn["scar_name"].InnerText);
                            conm.Parameters.AddWithValue("@SNNAME", xn["scar_nickname"].InnerText);
                            conm.Parameters.AddWithValue("@SCOM", xn["scar_comments"].InnerText);
                            conm.Parameters.AddWithValue("@SSEQ", xn["scar_sequence"].InnerText);

                            connector.insert_Data(conm);
                            conm.Dispose();

                            j++;
                        }

                        xnList = xDoc.SelectNodes("/rsbpml/part_list/part/sequences");

                        foreach (XmlNode xn in xnList)
                        {
                            string str_qu = "insert into sequences (part_id, seq_data) values (@ID, @SEQ)";

                            OleDbCommand conm = new OleDbCommand(str_qu);

                            conm.Parameters.AddWithValue("@ID", str_current_id);
                            conm.Parameters.AddWithValue("@SEQ", xn["seq_data"].InnerText.Replace("\n", ""));

                            connector.insert_Data(conm);
                            conm.Dispose();
                        }

                        xnList = xDoc.SelectNodes("/rsbpml/part_list/part/features/feature");

                        foreach (XmlNode xn in xnList)
                        {
                            string str_qu = "insert into features (part_id, feature_id, feature_title, feature_type, feature_direction, feature_startpos, feature_endpos) values (@ID, @FID, @FTITLE, @FTYPE, @FDIRECTION, @FSTART, @FEND)";

                            OleDbCommand conm = new OleDbCommand(str_qu);

                            conm.Parameters.AddWithValue("@ID", str_current_id);
                            conm.Parameters.AddWithValue("@FID", xn["id"].InnerText);
                            conm.Parameters.AddWithValue("@FTITLE", xn["title"].InnerText);
                            conm.Parameters.AddWithValue("@FTYPE", xn["type"].InnerText);
                            conm.Parameters.AddWithValue("@FDIRECTION", xn["direction"].InnerText);
                            conm.Parameters.AddWithValue("@FSTART", xn["startpos"].InnerText);
                            conm.Parameters.AddWithValue("@FEND", xn["endpos"].InnerText);

                            connector.insert_Data(conm);
                            conm.Dispose();
                        }

                        xnList = xDoc.SelectNodes("/rsbpml/part_list/part/parameters/parameter");

                        foreach (XmlNode xn in xnList)
                        {
                            string str_qu = "insert into parameterz (part_id, par_name, par_value, par_units, par_url, par_id, par_m_data, par_user_id, par_user_name ) values (@ID, @PNAME, @PV, @PUNITS, @PURL, @PID, @PM, @PUI, @PUN)";

                            OleDbCommand conm = new OleDbCommand(str_qu);

                            conm.Parameters.AddWithValue("@ID", str_current_id);
                            conm.Parameters.AddWithValue("@PNAME", xn["name"].InnerText);
                            conm.Parameters.AddWithValue("@PV", xn["value"].InnerText);
                            conm.Parameters.AddWithValue("@PUNITS", xn["units"].InnerText);
                            conm.Parameters.AddWithValue("@PURL", xn["url"].InnerText);
                            conm.Parameters.AddWithValue("@PID", xn["id"].InnerText);
                            conm.Parameters.AddWithValue("@PM", xn["m_date"].InnerText);
                            conm.Parameters.AddWithValue("@PUI", xn["user_id"].InnerText);
                            conm.Parameters.AddWithValue("@PUN", xn["user_name"].InnerText);

                            connector.insert_Data(conm);
                            conm.Dispose();
                        }

                        xnList = xDoc.SelectNodes("/rsbpml/part_list/part/categories/category");

                        foreach (XmlNode xn in xnList)
                        {
                            string str_qu = "insert into categories (part_id, category) values (@ID, @CA)";

                            OleDbCommand conm = new OleDbCommand(str_qu);

                            conm.Parameters.AddWithValue("@ID", str_current_id);
                            conm.Parameters.AddWithValue("@CA", xn.InnerText);

                            connector.insert_Data(conm);
                            conm.Dispose();
                        }

                    } // e t
                    catch (System.Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                    bgw3.ReportProgress(i);

                } // end for

            } // end try
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void BackgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            MessageBox.Show("END");
        }

        // 폼 닫을 때 
        private void Form_download_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (bgw.IsBusy)
            {
                if (MessageBox.Show("파일을 다운로드 중입니다.", "종료", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    e.Cancel = false;
                }
            }
            else if (bgw2.IsBusy || bgw3.IsBusy)
            {
                MessageBox.Show("자료를 처리중입니다.", "종료", MessageBoxButtons.OK);
                e.Cancel = false;
            }

        }
    }
}
