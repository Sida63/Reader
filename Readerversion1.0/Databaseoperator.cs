using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Readerversion1._0
{
    public class Databaseoperator
    {
        private MySqlConnection connection;
        MySqlCommand cmd;
        public void connectdatabase(string server="127.0.0.1",string database="ReaderPlatform",string uid="root",string pwd="btnx1234")
        {
            string temp="Server="+server+";Database="+database+";Uid="+uid+";Pwd="+pwd;
            connection = new MySqlConnection(temp);
        }
        public bool testconnectdatabase(string server = "127.0.0.1", string database = "ReaderPlatform", string uid = "root", string pwd = "btnx1234")
        {
            string temp = "Server=" + server + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + pwd;
            try
            {
                connection = new MySqlConnection(temp);
                opendatabase();
                closedatabase();
                return true;
            }
            catch (Exception)
            {
                connection = null;
                return false;
            }
            
        }
        public void opendatabase()
        {
            connection.Open();
            cmd = connection.CreateCommand();
        }
        public void closedatabase()
        {
            connection.Close();
        }
        public void insertdata(string tablename,string paramaters,string values)
        {
            connectdatabase();
            opendatabase();
            string temp = "INSERT INTO "+tablename+"("+paramaters+")VALUES("+values+")";
            cmd.CommandText = temp;
            cmd.ExecuteNonQuery();
            closedatabase();
        }
        public void inserttestdata(string tablename, string paramaters, string values)
        {
            connectdatabase("127.0.0.1", "Testplatform", "root", "btnx1234");//need to reset the passwd
            opendatabase();
            string temp = "INSERT INTO " + tablename + "(" + paramaters + ")VALUES(" + values + ")";
            cmd.CommandText = temp;
            cmd.ExecuteNonQuery();
            closedatabase();
        }
        public void deletedata(string table,string paramaters, string value)
        {
            string temp = "Delete from " + table + " where " + paramaters + "=" + "'"+value+"'";
            cmd.CommandText = temp;
            cmd.ExecuteNonQuery();
        }
        public void deleteall(string table)
        {
            cmd.CommandText = "truncate " + table;
            cmd.ExecuteNonQuery();
        }
        public MySqlDataReader select(string table, string paramater, string value)
        {
            connectdatabase();
            opendatabase();
            string temp = "select * from " + table + " where " + paramater + "= " + "'"+value+"'";
            cmd.CommandText =temp;
            MySqlDataReader mySQLReader = (MySqlDataReader)cmd.ExecuteReader();
            return mySQLReader;
        }
        public MySqlDataReader select(string table, string paramater)
        {
            connectdatabase();
            opendatabase();
            string temp = "select " + paramater + " from " + table;
            cmd.CommandText = temp;
            MySqlDataReader mySQLReader = (MySqlDataReader)cmd.ExecuteReader();
            return mySQLReader;
        }
        public MySqlDataReader selectall(string table)
        {
            connectdatabase();
            opendatabase();
            cmd.CommandText = "select * from "+table;
            MySqlDataReader mySQLReader = (MySqlDataReader)cmd.ExecuteReader();
            return mySQLReader;
        }
        public void update(string table, string paramaterchanged,string paramaterindex, string oldvalue,string newvalue)
        {
            string temp="UPDATE "+table+" SET "+paramaterchanged+" = "+newvalue+" WHERE "+paramaterindex+" = "+newvalue;
            cmd.CommandText = temp;
            cmd.ExecuteNonQuery();
        }
        public void createcatabase()
        {
            connection = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=btnx1234;");
            cmd = new MySqlCommand("CREATE DATABASE ReaderPlatform;", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void createtestdatabase()
        {
            connection = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=btnx1234;");
            cmd = new MySqlCommand("CREATE DATABASE TestPlatform;", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void createtestinfotable()
        {
            string testinfo = "CREATE TABLE testresultinfotable (ID int(11) NOT NULL auto_increment,Patientfile Varchar(255), Firstname Varchar(255),Middlename Varchar(255),Lastname Varchar(255), Diagnosis Varchar(255), Assaydate Date, Dateofbirth Date,Lot int(15),TestID int(15),Sentby Varchar(255),Gender Varchar(255),Operator Varchar(255),Testresultindex Varchar(255),Testname Varchar(255),Testcode Varchar(255),Imagepath Varchar(255),primary key (`ID`))";
            string testresult = "CREATE TABLE testresulttable (ID int(11) NOT NULL auto_increment, Testindex Varchar(255), Name Varchar(255), Result Varchar(255), Clinevalue int(11), Tlinevalue int(11), Background int(11), Valid Varchar(255),Date datetime, primary key(`ID`))";
            connection = new MySqlConnection("Server=127.0.0.1;Database=TestPlatform;Uid=root;Pwd=btnx1234;");
            connection.Open();
            cmd = new MySqlCommand(testinfo, connection);
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand(testresult, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void createtable()
        {
            string methodtablestatement = "CREATE TABLE Methodtable (ID int(11) NOT NULL auto_increment, Methodname Varchar(255),Paramaters Varchar(255),Paramaterindex Varchar(255), Brightness int(11), Contrast int(11), Saturation float(11,3), Cameraname Varchar(255), Resolution int(11),Sensitivevalue int(11),Adjustvalue int(11),primary key (`ID`))";
            string resulttablestatement = "CREATE TABLE Resulttable (ID int(11) NOT NULL auto_increment, Resultvalueindex Varchar(255) NOT NULL,Resultname Varchar(255),Resultstartvalue Varchar(255),Resultendvalue Varchar(255),Resultvalue Varchar(255),primary key (`ID`))";
            string rectangletablestatement = "CREATE TABLE RectangleTable (ID int(11) NOT NULL auto_increment,Rectangleindex Varchar(255) NOT NULL, X int(11),Y int(11),Width int(11), Height int(11),primary key (`ID`))";
            string settingentitystatement = "CREATE TABLE Settingentitytable (ID int(11) NOT NULL auto_increment,Paramatername Varchar(255),Cline Varchar(255),Shuttertime int(11),Readytime int(11), Methodname Varchar(255), Resultvalueindex Varchar(255), Rectangleindex Varchar(255),Paramaterindex Varchar(255),primary key (`ID`))";
            string setzonestatement = "CREATE TABLE SetZonetable (ID int(11) NOT NULL auto_increment,Paramater Varchar(255),Setzoneindex Varchar(255), ZonepositionX int(11),ZonepositionY int(11),ZonepositionWidth int(11), ZonepositionHeight int(11), Zonecategory Varchar(255), primary key(`ID`))";
            //string alterStatement = "ALTER TABLE Test ADD Field3 Boolean";
            connection = new MySqlConnection("Server=127.0.0.1;Database=ReaderPlatform;Uid=root;Pwd=btnx1234;");
            connection.Open();
            cmd = new MySqlCommand(methodtablestatement, connection);
            cmd.ExecuteNonQuery();
            cmd.CommandText = resulttablestatement;
            cmd.ExecuteNonQuery();
            cmd.CommandText = rectangletablestatement;
            cmd.ExecuteNonQuery();
            cmd.CommandText = settingentitystatement;
            cmd.ExecuteNonQuery();
            cmd.CommandText = setzonestatement;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void createmultilanguagedatabase()
        {
            connection = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=btnx1234;");
            cmd = new MySqlCommand("CREATE DATABASE Multilanguage;", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void createmultilanguagetable()
        {
            string multilanguage = "CREATE TABLE multilanguagetable (ID int(11) NOT NULL auto_increment,Language Varchar(255),primary key (`ID`))";
            connection = new MySqlConnection("Server=127.0.0.1;Database=Multilanguage;Uid=root;Pwd=btnx1234;");
            connection.Open();
            cmd = new MySqlCommand(multilanguage, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void createlanguageentitytable(string languagename)
        {
            string languageentity = "CREATE TABLE " + languagename + " (ID int(11) NOT NULL auto_increment, VocabularyID Varchar(255), Meaning Varchar(255), primary key(`ID`))";
            string temp = "INSERT INTO multilanguagetable (Language)VALUES(" + "'"+languagename +"'"+ ")";
            connection = new MySqlConnection("Server=127.0.0.1;Database=Multilanguage;Uid=root;Pwd=btnx1234;");
            connection.Open();
            cmd = new MySqlCommand(languageentity, connection);
            cmd.ExecuteNonQuery();
            cmd.CommandText = temp;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
