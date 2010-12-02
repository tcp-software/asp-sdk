using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Specialized;
using System.Xml;

public partial class _Default : System.Web.UI.Page 
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["logoff"] != null)
            {
                
               
            }
        }
    }
    protected void btnCheckDevelioperKey_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        objshiftPlaning.Method = "GET";
        objshiftPlaning.Key = txtKey.Text;
        objshiftPlaning.Username = txtUsername.Text;
        objshiftPlaning.Password = txtPassword.Text;
        objshiftPlaning.OutPut = "xml";
        objshiftPlaning.module = "staff.login";
        string responseXml = objshiftPlaning.doLogin(txtUsername.Text, txtPassword.Text);
       
        txtResponse.Text = responseXml;
        TextReader txtReader = new StringReader(responseXml);
        XmlReader reader = new XmlTextReader(txtReader);
        DataSet ds = new DataSet();
        ds.ReadXml(reader);
        
        string myToken = objshiftPlaning.getAppToken();
        Session["myToken"] = myToken;
        if (myToken == null)
        {
            string LoginResponse = objshiftPlaning.doLogin(txtUsername.Text, txtPassword.Text);
            TextReader Reader = new StringReader(LoginResponse);
            DataSet dsResp = new DataSet();
            dsResp.ReadXml(Reader);
            //if (dsResp != null)
            //{
            //    if (dsResp.Tables["response"] != null)
            //    {
            //        if (dsResp.Tables["response"].Rows.Count > 0)
            //        {
            //            if (dsResp.Tables["response"].Rows[0]["status"] == "1")
            //            {
            //                if (dsResp.Tables["employee"] != null)
            //                {
            //                   // Response.Write("Hi, " + dsResp.Tables["employee"].Rows[0]["name"].ToString() + Environment.NewLine);
            //                }
            //            }
            //            else
            //            {

            //            }
            //        }
            //        else
            //        {
            //        }
            //    }
            //}
        }
        else
        {
            DataTable objEmployee = ds.Tables["employee"];
            DataTable objbusiness = ds.Tables["business"];
            if (ds.Tables["employee"] != null)
            {
               // Response.Write("Hi, " + ds.Tables["employee"].Rows[0]["name"].ToString() + Environment.NewLine);
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        objshiftPlaning.Method = "GET";
        objshiftPlaning.Key = txtKey.Text;
        objshiftPlaning.Username = txtUsername.Text;
        objshiftPlaning.Password = txtPassword.Text;
        objshiftPlaning.OutPut = "xml";
        objshiftPlaning.module = "staff.login";
       
        string responseXml = objshiftPlaning.doLogin(txtUsername.Text, txtPassword.Text);
        txtResponse.Text = responseXml;
        string myToken = objshiftPlaning.getAppToken();
    }
    protected void btmGetMessages_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.Method = "GET";
        objshiftPlaning.Key = txtKey.Text;
        objshiftPlaning.Username = txtUsername.Text;
        objshiftPlaning.Password = txtPassword.Text;
        objshiftPlaning.OutPut = "xml";
        objshiftPlaning.module = "staff.login";
        string responseXml = objshiftPlaning.getMessages();
        txtResponse.Text = responseXml;
    }
    protected void btnDetailMessage_Click(object sender, EventArgs e)
    {
    }
    protected void btnDelMsg_Click(object sender, EventArgs e)
    {
    }
    protected void btnWallMsg_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.Method = "GET";
        objshiftPlaning.Key = txtKey.Text;
        objshiftPlaning.Username = txtUsername.Text;
        objshiftPlaning.Password = txtPassword.Text;
        objshiftPlaning.OutPut = "xml";
        objshiftPlaning.module = "staff.login";
        string responseXml = objshiftPlaning.getWallMessages();
        txtResponse.Text = responseXml;
    }
    protected void btnGetEmp_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.OutPut = "xml";
        string response = objshiftPlaning.getEmployees();
        txtResponse.Text = response;
    }
    protected void btnEmpDetails_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.OutPut = "xml";
        string response = objshiftPlaning.getEmployeeDetails(12316);
        txtResponse.Text = response;
    }
    protected void updateEmployee_Click(object sender, EventArgs e)
    {
        // This click is not working as we are not sure which array format is PHP function is using.
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.OutPut = "xml";
        DataTable dt = new DataTable("request");
        dt.Columns.Add("id");
        dt.Columns.Add("token");
        dt.Columns.Add("module");
        dt.Columns.Add("method");
        dt.Columns.Add("nick_name");
        dt.Columns.Add("wage");
        DataRow dr;// = new DataRow();
        dr = dt.NewRow();
        dr["id"] = 12316;
        dr["nick_name"] = "sherwood";
        dr["wage"] = 99;
        dr["method"] = "staff.employees";
        dr["module"] = "UPDATE";
        dt.Rows.Add(dr);

        NameValueCollection test = new NameValueCollection();

        string response = objshiftPlaning.updateEmployee(12316, test);
        txtResponse.Text = response;
    }
    protected void createEmp_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.OutPut = "xml";
        string response = objshiftPlaning.getEmployeeDetails(12316);
        txtResponse.Text = response;
    }
     protected void btnGetStafSkill_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.OutPut = "xml";
        string response = objshiftPlaning.getStaffSkills();
        txtResponse.Text = response;
    }
    protected void btnStaffSkillById_Click(object sender, EventArgs e)
    {
    }
    protected void btnDelSkillById_Click(object sender, EventArgs e)
    {
    }
    protected void btnSchedules_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.Method = "GET";
        objshiftPlaning.Key = txtKey.Text;
        objshiftPlaning.Username = txtUsername.Text;
        objshiftPlaning.Password = txtPassword.Text;
        objshiftPlaning.OutPut = "xml";
        objshiftPlaning.module = "staff.login";
        string responseXml = objshiftPlaning.getSchedules();//.getWallMessages();
        txtResponse.Text = responseXml;
    }
    protected void btnSchedulesDetail_Click(object sender, EventArgs e)
    {
    }
    protected void btnDelSchedules_Click(object sender, EventArgs e)
    {
    }
    protected void btnShifts_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.OutPut = "xml";
        string response = objshiftPlaning.getShifts();
        txtResponse.Text = response;
    }
    protected void btnShifById_Click(object sender, EventArgs e)
    {
    }
    protected void btnDelShift_Click(object sender, EventArgs e)
    {
    }
    protected void getVacationScheduleDetails_Click(object sender, EventArgs e)
    {
    }
    protected void deleteVacationSchedule_Click(object sender, EventArgs e)
    {
    }
    protected void getScheduleConflicts_Click(object sender, EventArgs e)
    {
        // This click is not working as we are not sure which arrray foirmat we need to send to the function.
    }
    protected void getAdminSettings_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
         objshiftPlaning.OutPut = "xml";
        string response = objshiftPlaning.getAdminSettings();
        txtResponse.Text = response;
    }
    protected void getAdminFiles_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.OutPut = "xml";
        string response = objshiftPlaning.getAdminFiles();
        txtResponse.Text = response;
    }
    protected void getAdminFileDetails_Click(object sender, EventArgs e)
    {
    }
    protected void deleteAdminFile_Click(object sender, EventArgs e)
    {
    }
    protected void getAdminBackups_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.OutPut = "xml";
        string response = objshiftPlaning.getAdminBackups();
        txtResponse.Text = response;
    }
    protected void getAdminBackupDetails_Click(object sender, EventArgs e)
    {
    }
    protected void deleteAdminBackup_Click(object sender, EventArgs e)
    {
    }
    protected void getAPIConfig_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.Method = "GET";
        objshiftPlaning.Key = txtKey.Text;
        objshiftPlaning.Username = txtUsername.Text;
        objshiftPlaning.Password = txtPassword.Text;
        objshiftPlaning.OutPut = "xml";
        objshiftPlaning.module = "staff.login";
        string responseXml = objshiftPlaning.getAPIConfig();
        txtResponse.Text = responseXml;
    }
    protected void getAPIMethods_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.Method = "GET";
        objshiftPlaning.Key = txtKey.Text;
        objshiftPlaning.Username = txtUsername.Text;
        objshiftPlaning.Password = txtPassword.Text;
        objshiftPlaning.OutPut = "xml";
        objshiftPlaning.module = "staff.login";
        string response = objshiftPlaning.getAPIMethods();
        txtResponse.Text = response;
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        shiftPlaning objshiftPlaning = new shiftPlaning(txtKey.Text);
        try
        {
            objshiftPlaning.Token = Session["myToken"].ToString();
        }
        catch (Exception ex) { }
        objshiftPlaning.Method = "GET";
        objshiftPlaning.Key = txtKey.Text;
        objshiftPlaning.Username = txtUsername.Text;
        objshiftPlaning.Password = txtPassword.Text;
        objshiftPlaning.OutPut = "xml";
        objshiftPlaning.module = "staff.login";
        string response = objshiftPlaning.doLogout();
        txtResponse.Text = response;
    }
}
