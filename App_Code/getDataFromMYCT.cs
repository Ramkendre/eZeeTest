﻿using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;

/// <summary>
/// Summary description for getDataFromMYCT
/// </summary>
public class getDataFromMYCT
{
    public getDataFromMYCT()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    CommonCode cc = new CommonCode();

    string language = string.Empty;
    RegisterToMyct reg = new RegisterToMyct();
    string SqlQuery = "", UserName = "", UserID = "", R1 = "", R2 = "", R3 = "", R4 = "", R5 = "", R6 = "", initial = "", usrRole = "", RoleId = "", userid;
    int flag;

    //Below function insert data to EzeeTest Database
    public void insertDatatoLogin(string LoginId, string Password, string UserName, string Address)
    {
        try
        {
            string sql12 = "Select *from Login Where LoginId='" + LoginId + "'";
            DataSet dset = cc.ExecuteDataset(sql12); //ExecuteDatasetEzeeTest
            if (dset.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                SqlQuery = "Insert INTO Login(LoginId,UserName,Password,Address,DOJ,Role,CompanyId,Active,admintype,UserType,Category,DataFromApp) Values " +
                    " '" + LoginId + "',N'" + UserName + "',N'" + Password + "',N'" + Address + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','10','5164','1','1','1','--Select--','0' ";

                flag = cc.ExecuteNonQuery(SqlQuery); //ExecuteNonQueryEzeeTest

                //if (flag == 1)
                //{
                    string sql = "SELECT MAX(Uid) AS LastID FROM Login";
                    string Id1 = cc.ExecuteScalar(sql); //ExecuteScalarEzeeTest

                    if (!(Id1 == null))
                    {
                        string Sql = "insert Admin_SubUser(loginid,loginname,uid,UnderUsername,roleid,rolename,DT,R1,R2,companyid)" +
                           "values('6182','9999999999'," + Id1 + ",'" + LoginId + "','10','Students','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','Admin','9999999999','5164')";
                        flag = cc.ExecuteNonQuery(Sql); //ExecuteNonQueryEzeeTest
                    }
                //}
           }
        }
        catch (Exception)
        {

        }
    }
}