﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Synb_Project_TeamB
{
    class ViewerData
    {
        private static string Cnnection_Str;
        private static MySqlConnection oCnn = null;
        //private static MySqlDataAdapter oAdt= null;
        //private static MySqlCommand oCmd = null;
        private static DataSet DataSet_TreeView = null;
        private static DataRow DataRow_TreeView = null;

        private static DataSet DS_tree = null;
        private static DataRow DR_tree = null;

        private static DataSet DS_notice = null;
        private static DataRow DR_notice = null;

        private static DataSet DSlistOfEG = null;
        private static DataRow DRlistOfEG = null;

        private static DataSet DSlistOfCOG = null;
        private static DataRow DRlistOfCOG = null;

        public static int cnt;
        public static int totalCnt;

        public static int InitMySql(string database, string userid, string pwd)
        {
            Cnnection_Str = string.Format("data source = 210.115.163.125; database = {0}; user id={1}; password = {2}"
                , database, userid, pwd);
            try
            {
                //접속 부분
                oCnn = new MySqlConnection(Cnnection_Str);
                oCnn.Open();
                return 0;
            }
            catch (MySqlException _e)
            {
                return 1;
            }
        }
        public static void treeList_reader(String query)
        {
            try
            {
                DS_tree = MySqlHelper.ExecuteDataset(oCnn, query);
                if(DS_tree.Tables[0].Rows.Count != 0)
                    DR_tree = DS_tree.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
                // MessageBox.Show("DB Connection Error. Try again.");
            }
        }

        public static int getNodeCount()
        {
            return DS_tree.Tables[0].Rows.Count;
        }
        public static string getNodeName(int i)
        {
            DR_tree = DS_tree.Tables[0].Rows[i];

            return DR_tree["name"].ToString();
        }

        public static void notice_reader(String query)
        {
            try
            {
                DS_notice = MySqlHelper.ExecuteDataset(oCnn, query);
                DR_notice = DS_notice.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
                // MessageBox.Show("DB Connection Error. Try again.");
            }
        }

        public static string getLastNotice()
        {
            DR_notice = DS_notice.Tables[0].Rows[DS_notice.Tables[0].Rows.Count - 1];

            return DR_notice["content"].ToString();
        }
        //나중에 트리뷰가 추가되면 해당 트리뷰의 이름을 받아서 selct문을 실행 할 수 있도록 한다.
        public static void Synb_reader(String query)
        {
            try
            {
                DataSet_TreeView = MySqlHelper.ExecuteDataset(oCnn, query);
                DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
               // MessageBox.Show("DB Connection Error. Try again.");
            }
        }

        public static int Synb_View_getCount()
        {
            return DataSet_TreeView.Tables[0].Rows.Count;
        }
        public static string Synb_View_getStart(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            
            return DataRow_TreeView["START"].ToString();
        }
        public static string Synb_View_getEnd(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            
            return DataRow_TreeView["END"].ToString();
        }
        public static string Synb_View_getLocus(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["LOCUS_TAG"].ToString();
        }
        public static string Synb_View_getID(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["IS_Synb"].ToString();
        }
        public static string Synb_View_getAccession(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["ACCESSION"].ToString();
        }
        public static string Synb_View_getDeg(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["IS_DEG"].ToString();
        }
        public static string Synb_View_getProduct(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["PRODUCT"].ToString();
        }
        public static string Synb_View_getType(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["FEATURE_TYPE"].ToString();
        }
        public static string Synb_View_getNA(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["NA_LENGTH"].ToString();
        }
        public static string Synb_View_getSTRAND(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["STRAND"].ToString();
        }
        public static string Synb_View_getTERM(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["GENE_TERM"].ToString();
        }
        public static string Synb_View_getDEG(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["IS_DEG"].ToString();
        }
        public static string Synb_View_getEG(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["IS_EG"].ToString();
        }
        public static string Synb_View_getCog(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["COG"].ToString();
        }
        public static string Synb_View_getSec(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["Sequence"].ToString();
        }
        public static string Synb_View_getStrand(int i)
        {
            DataRow_TreeView = DataSet_TreeView.Tables[0].Rows[i];
            return DataRow_TreeView["STRAND"].ToString();
        }


        //////////////////////Designer Viewer

        public static void Designer_SelectGene(String GeneName)
        {

            String query = "SELECT * FROM EGDesignTable Where synb_uid = '" + GeneName + "'";


            try
            {
                DSlistOfEG = MySqlHelper.ExecuteDataset(oCnn, query);
                if (cnt == 0)
                {
                    return;
                }
                DRlistOfEG = DSlistOfEG.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
            }
        }

        public static string Designer_getLength()
        {
            DRlistOfEG = DSlistOfEG.Tables[0].Rows[0];
            return DRlistOfEG["Length"].ToString();
        }
        public static string Designer_getTerm()
        {
            DRlistOfEG = DSlistOfEG.Tables[0].Rows[0];
            return DRlistOfEG["Go_Term"].ToString();
        }

        public static string Designer_getProduct()
        {
            DRlistOfEG = DSlistOfEG.Tables[0].Rows[0];
            return DRlistOfEG["Product"].ToString();
        }



        //////////////////////Designer Data
        public static void selectEGList()
        {

            String query = "SELECT * FROM EGDesignTable";


            try
            {
                DSlistOfEG = MySqlHelper.ExecuteDataset(oCnn, query);
                getEG_Count();
                totalCnt = cnt;
                if (cnt == 0)
                {
                    return;
                }
                DRlistOfEG = DSlistOfEG.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
            }

            getEG_Count();
        }

        public static void selectEGList(int indexOfCircle)
        {
            char index = (char)('A' + indexOfCircle);

            String query = "SELECT * FROM EGDesignTable WHERE " + index + "<>'0' Order by Count";

            try
            {
                DSlistOfEG = MySqlHelper.ExecuteDataset(oCnn, query);
                getEG_Count();
                if (cnt == 0)
                {
                    return;
                }
                DRlistOfEG = DSlistOfEG.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
                // MessageBox.Show("DB Connection Error. Try again.");
            }

            getEG_Count();
        }

        public static void selectCOGFreq(int indexOfCircle)
        {
            char index = (char)('A' + indexOfCircle);

            String query = "SELECT COG, " + index + " FROM EGCOGTable";


            try
            {
                DSlistOfCOG = MySqlHelper.ExecuteDataset(oCnn, query);
                
                DRlistOfCOG = DSlistOfCOG.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
            }
        }

        public static void selectEGList_synb_uid(int indexOfCircle, String synb_uid)
        {
            char index = (char)('A' + indexOfCircle);

            String query = "SELECT * FROM EGDesignTable WHERE " + index + "<>'0' AND synb_uid like'%" + synb_uid + "%'";

            try
            {
                DSlistOfEG = MySqlHelper.ExecuteDataset(oCnn, query);
                getEG_Count();
                if (cnt == 0)
                {
                    return;
                }
                DRlistOfEG = DSlistOfEG.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
            }
        }

        public static void selectEGList_GOTerm(int indexOfCircle, String GOTerm)
        {
            char index = (char)('A' + indexOfCircle);

            String query = "SELECT * FROM EGDesignTable WHERE " + index + "<>'0' AND GO_Term like'%" + GOTerm + "%'";

            try
            {
                DSlistOfEG = MySqlHelper.ExecuteDataset(oCnn, query);
                getEG_Count();
                if (cnt == 0)
                {
                    return;
                }
                DRlistOfEG = DSlistOfEG.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
            }
        }

        public static void selectEGList_Product(int indexOfCircle, String Product)
        {
            char index = (char)('A' + indexOfCircle);

            String query = "SELECT * FROM EGDesignTable WHERE " + index + "<>'0' AND Product like'%" + Product + "%'";

            try
            {
                DSlistOfEG = MySqlHelper.ExecuteDataset(oCnn, query);
                getEG_Count();
                if (cnt == 0)
                {
                    return;
                }
                DRlistOfEG = DSlistOfEG.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
            }
        }

        public static void selectEGList_COG(int indexOfCircle, String COG)
        {
            char index = (char)('A' + indexOfCircle);

            String query = "SELECT * FROM EGDesignTable WHERE " + index + "<>'0' AND COG like'%" + COG + "%'";

            try
            {
                DSlistOfEG = MySqlHelper.ExecuteDataset(oCnn, query);
                getEG_Count();
                if (cnt == 0)
                {
                    return;
                }
                DRlistOfEG = DSlistOfEG.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
            }
        }

        public static void selectEGList_STRAND(int indexOfCircle, String STRAND)
        {
            char index = (char)('A' + indexOfCircle);

            String query = "SELECT * FROM EGDesignTable WHERE " + index + "<>'0' AND STRAND like'%" + STRAND + "%'";

            try
            {
                DSlistOfEG = MySqlHelper.ExecuteDataset(oCnn, query);
                getEG_Count();
                if (cnt == 0)
                {
                    return;
                }
                DRlistOfEG = DSlistOfEG.Tables[0].Rows[0];
            }
            catch (MySqlException e)
            {
            }
        }

        public static void getEG_Count()
        {
            cnt = DSlistOfEG.Tables[0].Rows.Count;
        }

        public static void getRoundEG_Count(int indexOfCircle)
        {
            char index = (char)('A' + indexOfCircle);
            String query = "SELECT * FROM EGDesignTable WHERE " + index + "<>'0' Order by Count";
            try
            {
                DSlistOfEG = MySqlHelper.ExecuteDataset(oCnn, query);
                getEG_Count();
            }
            catch (MySqlException e)
            {
                // MessageBox.Show("DB Connection Error. Try again.");
            }
        }

        public static string getEG_UID(int index)
        {
            DRlistOfEG = DSlistOfEG.Tables[0].Rows[index];
            return DRlistOfEG["synb_uid"].ToString();
        }
        public static int[] getEG_Freq(int index)
        {
            DRlistOfEG = DSlistOfEG.Tables[0].Rows[index];

            int[] getEG_Freq = new int[20];

            char column = 'A';

            for (int i = 0; i < 20; i++)
            {
                getEG_Freq[i] = int.Parse(DRlistOfEG[((char)(column + i)).ToString()].ToString());
            }

            return getEG_Freq;
        }
        public static string getEG_GOTerm(int index)
        {
            DRlistOfEG = DSlistOfEG.Tables[0].Rows[index];

            return DRlistOfEG["GO_Term"].ToString();
        }
        public static string getEG_Product(int index)
        {
            DRlistOfEG = DSlistOfEG.Tables[0].Rows[index];

            return DRlistOfEG["Product"].ToString();
        }
        public static string getEG_COG(int index)
        {
            DRlistOfEG = DSlistOfEG.Tables[0].Rows[index];

            return DRlistOfEG["COG"].ToString();
        }

        public static string getEG_STRAND(int index)
        {
            DRlistOfEG = DSlistOfEG.Tables[0].Rows[index];

            return DRlistOfEG["frequence"].ToString();
        }


        //COG 분석 자료 보여주는 부분
        public static string getEG_COG_FREQ_ANAL(int index)
        {
            DRlistOfCOG = DSlistOfCOG.Tables[0].Rows[index];

            return DRlistOfCOG[1].ToString();
        }
        public static string getEG_COG_ANAL(int index)
        {
            DRlistOfCOG = DSlistOfCOG.Tables[0].Rows[index];

            return DRlistOfCOG[0].ToString();
        }




    }
}
