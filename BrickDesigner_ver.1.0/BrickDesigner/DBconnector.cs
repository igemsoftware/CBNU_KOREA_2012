using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Windows.Forms;

/*
 * 디비 관리기.
 * 이 디비관리기는 다운로드창과
 * 디비를 사용해서 데이터를 가져오는 모든 곳에서 사용가능하다.
 * 
 * dis_con()        )) 에러 발생. 소멸자 함수 해결해야함
 *  
 */

namespace BrickDesigner
{
    class DBconnector
    {
        OleDbConnection conn;
        OleDbCommand conm;

        string strDB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Part_db.accdb;Jet OLEDB:Database Password=1234";
        FileInfo dbfile = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "Part_db.accdb"));
        //FileInfo downfile = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "temp.cbu"));

        public DBconnector()
        {

            if (dbfile.Exists)
            {
                con_DB();
            }
            else
            {
                make_DBFILE();
                con_DB();
                make_TABLE();
            }
        }

        private void con_DB()
        {
            try
            {
                conn = new OleDbConnection();
                conn.ConnectionString = strDB;
                conn.Open();
                
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void discon_DB()
        {
            try
            {
                conn.Close();

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void make_TABLE()
        {
            // 사용자 테이블 추가 예정

            try
            {
                dbfile.Refresh();

                if (dbfile.Exists)
                {

                    string c_qu = "CREATE TABLE part( part_id LONG PRIMARY KEY,part_name LONGTEXT default null,part_short_name LONGTEXT default null,part_short_desc LONGTEXT default null,part_type LONGTEXT default null,part_status LONGTEXT default null,part_result LONGTEXT default null,part_nickname LONGTEXT default null,part_rating INT,part_url LONGTEXT default null,part_entered LONGTEXT default null,part_author LONGTEXT default null,best_quality LONGTEXT default null )";
                    conm = new OleDbCommand(c_qu, conn);
                    conm.ExecuteNonQuery();

                    c_qu = "create table deep_subparts ( part_id LONG not null, subpart_id LONG not null, part_sub_num LONG not null,  PRIMARY KEY(part_id, subpart_id, part_sub_num ), FOREIGN KEY (part_id) REFERENCES part (part_id) ON DELETE CASCADE ON UPDATE CASCADE, FOREIGN KEY (subpart_id) REFERENCES part (part_id) ON DELETE CASCADE ON UPDATE CASCADE )";
                    conm = new OleDbCommand(c_qu, conn);
                    conm.ExecuteNonQuery();

                    c_qu = "CREATE TABLE sequences ( part_id LONG NOT NULL, seq_data LONGTEXT default null, PRIMARY KEY( part_id ), FOREIGN KEY (part_id) REFERENCES part (part_id) ON DELETE CASCADE ON UPDATE CASCADE )";
                    conm = new OleDbCommand(c_qu, conn);
                    conm.ExecuteNonQuery();

                    c_qu = "CREATE TABLE specified_subparts ( part_id LONG not null, subpart_id LONG not null, part_sub_num LONG not null, PRIMARY KEY( part_id, subpart_id, part_sub_num ), FOREIGN KEY (part_id) REFERENCES part (part_id) ON DELETE CASCADE ON UPDATE CASCADE, FOREIGN KEY (subpart_id) REFERENCES part (part_id) ON DELETE CASCADE ON UPDATE CASCADE )";
                    conm = new OleDbCommand(c_qu, conn);
                    conm.ExecuteNonQuery();

                    c_qu = "CREATE TABLE specified_subscars ( part_id LONG not null, part_scar_num LONG not null , scar_id LONG not null, scar_type LONGTEXT default null, scar_name LONGTEXT default null, scar_nickname LONGTEXT default null, scar_comments LONGTEXT default null, scar_seq LONGTEXT default null, PRIMARY KEY( part_id, part_scar_num ), FOREIGN KEY (part_id) REFERENCES part (part_id) ON DELETE CASCADE ON UPDATE CASCADE )";
                    conm = new OleDbCommand(c_qu, conn);
                    conm.ExecuteNonQuery();

                    c_qu = "CREATE TABLE categories ( part_id LONG not null, category LONGTEXT NOT NULL, PRIMARY KEY( part_id, category ), FOREIGN KEY (part_id) REFERENCES part (part_id) ON DELETE CASCADE ON UPDATE CASCADE )";
                    conm = new OleDbCommand(c_qu, conn);
                    conm.ExecuteNonQuery();

                    c_qu = "CREATE TABLE features ( part_id LONG not null, feature_id LONG not null, feature_title LONGTEXT default null, feature_type LONGTEXT default null, feature_direction LONGTEXT default null, feature_startpos LONG default null, feature_endpos LONG default null, PRIMARY KEY( part_id, feature_id ), FOREIGN KEY (part_id) REFERENCES part (part_id) ON DELETE CASCADE ON UPDATE CASCADE )";
                    conm = new OleDbCommand(c_qu, conn);
                    conm.ExecuteNonQuery();

                    c_qu = "CREATE TABLE parameterz ( part_id LONG not null, par_name LONGTEXT default null, par_value LONGTEXT default null, par_units LONGTEXT default null, par_url LONGTEXT default null, par_id 	LONG not null, par_m_data LONGTEXT default null, par_user_id LONG default null, par_user_name LONGTEXT default null, PRIMARY KEY( part_id, par_id ), FOREIGN KEY (part_id) REFERENCES part (part_id) ON DELETE CASCADE ON UPDATE CASCADE )";
                    conm = new OleDbCommand(c_qu, conn);
                    conm.ExecuteNonQuery();

                    c_qu = "CREATE TABLE userbricks ( part_name LONGTEXT not null, part_type LONGTEXT default null, part_desc LONGTEXT default null, part_seq LONGTEXT default null, PRIMARY KEY(part_name) )";
                    conm = new OleDbCommand(c_qu, conn);
                    conm.ExecuteNonQuery();
                    
                }



            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


            
        }

        public void make_DBFILE()
        {
            try
            {

                dbfile.Refresh();
                if (!dbfile.Exists)
                {
                    Type objClassType = Type.GetTypeFromProgID("ADOX.Catalog");

                    if (objClassType != null)
                    {
                        object obj = Activator.CreateInstance(objClassType);

                        // Create MDB file
                        obj.GetType().InvokeMember(
                            "Create", System.Reflection.BindingFlags.InvokeMethod, null, obj, new object[]{
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+strDB+";"});

                        // Clean up
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                        obj = null;
                    }
                }

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public OleDbDataReader select_Data(string _query)
        {
            try
            {
                dbfile.Refresh();

                if (dbfile.Exists)
                {
                    conm = new OleDbCommand(_query, conn);

                    return conm.ExecuteReader();
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public void insert_Data(string _query)
        {
            try
            {
                dbfile.Refresh();

                if (dbfile.Exists)
                {
                    conm = new OleDbCommand(_query, conn);

                    conm.ExecuteNonQuery();
                }
                else
                {

                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public bool insert_Data(OleDbCommand _oldc)
        {
            try
            {
                dbfile.Refresh();

                if (dbfile.Exists)
                {
                    _oldc.Connection = conn;

                    _oldc.ExecuteNonQuery();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool update_Data(string _query)
        {
            try
            {
                dbfile.Refresh();

                if (dbfile.Exists)
                {
                    conm = new OleDbCommand(_query, conn);

                    conm.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool update_Data(OleDbCommand _oldc)
        {
            try
            {
                dbfile.Refresh();

                if (dbfile.Exists)
                {
                    _oldc.Connection = conn;

                    _oldc.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
