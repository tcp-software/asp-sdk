using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Web.Script.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Serialization.Json;


/// <summary>
/// This class is used to use shiftplanning API
/// Created Date : 22/11/2010
/// Modified Date : 25/11/2010
/// </summary>
public class shiftPlaning
{
    /// <Private Values>
    private string _Key;
    private bool _Debug;
    private string _module;
    private string _username;
    private string _password;
    private string _method;
    public string OutPut = "XML";
    private string _outPut;
    private string _token;
    private string _callback;
    private NameValueCollection requests;
    private DataSet currentResponse;
    // constants
    private string session_identifier = "SP";
    const string api_endpoint = "http://www.shiftplanning.com/api/";
    const string output_type = "xml";
    private int _init;
    private bool _debug;
    private NameValueCollection request;
    /// </Private Values>


    ///<Public Properties>
    public string Key
    {
        set { _Key = value; }
        get { return _Key; }
    }

    public bool Debug
    {
        set { _Debug = value; }
        get { return _Debug; }
    }

    public string module
    {
        set { _module = value; }
        get { return _module; }
    }

    public string Username
    {
        set { _username = value; }
        get { return _username; }
    }

    public string Password
    {
        set { _password = value; }
        get { return _password; }
    }

    public string Method
    {
        set { _method = value; }
        get { return _method; }
    }


    public string Token
    {
        get { return _token; }
        set { _token = value; }
    }
    ///<Public Properties>
   



   

    public shiftPlaning(string devKey)
    {
        this._debug = false;
        this.startSession();
        this.setAppKey(devKey);
    }

    protected void startSession()
    {// start the session
        try
        {
            System.Web.HttpContext.Current.Session[this.session_identifier] = this.session_identifier;
        }
        catch (Exception ex) { }
    }
    public void setAppKey(string key)
    {// set the developer key to use
        this.Key = key;
    }
    public string getAppKey()
    {
        // return the developer key
        return Key;
    }
    /*
	 * User Authentication Methods
	 *
	 */
    public string doLogin(string Username, string Password)
    {// perform a login api call1
        JavaScriptSerializer js = new JavaScriptSerializer();
        login bData = new login();
        bData.key = Key;
        bData.output = OutPut;
        Request objrequest = new Request();
        objrequest.method = "GET";
        objrequest.module = "staff.login";
        objrequest.password = Password;
        objrequest.username = Username;
        bData.request = objrequest;
        NameValueCollection myNewDataTest = new NameValueCollection();
        myNewDataTest.Add("data", js.Serialize(bData));

        return perform_request(myNewDataTest);
    }

    /*
	 * Message Methods
	 *
	 */
    public string getMessages()
    {// get messages for the currently logged in user
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "GET";
        objrequest.module = "messaging.messages";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getMessageDetails(int id)
    {//
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        //bData.id = id.ToString();

        objrequest.method = "GET";
        objrequest.module = "messaging.messages";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string createMessage(string message)
    {// create a new message
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "CREATE";
        objrequest.module = "messaging.messages";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);

    }

    public string deleteMessage(int id)
    {// delete a message
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        //bData.id = id.ToString();

        objrequest.method = "DELETE";
        objrequest.module = "messaging.messages";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getWallMessages()
    {// get message wall
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "GET";
        objrequest.module = "messaging.wall";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);

    }

    /*
	 * Staff Methods
	 *
	 */
    public string getEmployees()
    {// get a list of employees
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "GET";
        objrequest.module = "staff.employees";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getEmployeeDetails(int id)
    {// get details for a specific employee
        DataRequestByID bData = new DataRequestByID();
        bData.token = Token;
        bData.output = OutPut;

        DataRequestId objrequest = new DataRequestId();
        objrequest.method = "GET";
        objrequest.id = id.ToString();
        objrequest.module = "staff.employees";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string updateEmployee(int id, NameValueCollection new_data)
    {// update an employee record
        RequestById bData = new RequestById();
        bData.token = Token;
        bData.output = OutPut;
        employee objrequest = new employee();
        objrequest.method = "UPDATE";
        objrequest.module = "staff.employees";
        objrequest.nick_name = "sherwood";
        objrequest.id = id.ToString();
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);

    }

    public string createEmployee(string[] data)
    {// create a new employee record
        BasicData bData = new BasicData();
        bData.token = Token;
        bData.output = OutPut;
        Request objrequest = new Request();
        objrequest.method = "CREATE";
        objrequest.module = "staff.employees";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);

    }

    public string deleteEmployee(int id)
    {// delete an employee
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "DELETE";
        objrequest.module = "staff.employees";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getStaffSkills()
    {// get staff skills
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "GET";
        objrequest.module = "staff.skills";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getStaffSkillDetails(int id)
    {// get staff skill details
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "GET";
        objrequest.module = "staff.skills";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);

    }

    public string createStaffSkill(string[] skill_details)
    {// create staff skill
        BasicData bData = new BasicData();
        bData.token = Token;
        bData.output = OutPut;
        Request objrequest = new Request();
        objrequest.method = "CREATE";
        objrequest.module = "staff.skills";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string updateStaffSkill(int id, string[] skill_details)
    {// update staff skill
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "UPDATE";
        objrequest.module = "staff.skills";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string deleteStaffSkill(int id)
    {// delete staff skill
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "DELETE";
        objrequest.module = "staff.skills";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string createPing(string[] ping_data)
    {// create a ping
        //return $this->setRequest(
        //    array_merge(
        //        array(
        //            'module' => 'staff.ping',
        //            'method' => 'CREATE'
        //        ),
        //        $ping_data
        //    )
        //);
        return "";
    }


    /*
	 * Schedule Methods
	 *
	 */
    public string getSchedules()
    {// get schedules
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "GET";
        objrequest.module = "schedule.schedules";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getScheduleDetails(int id)
    {// get schedule details
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "GET";
        objrequest.module = "schedule.schedules";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string createSchedule(string[] schedule_details)
    {// create a new schedule
        BasicData bData = new BasicData();
        bData.token = Token;
        bData.output = OutPut;
        Request objrequest = new Request();
        objrequest.method = "CREATE";
        objrequest.module = "schedule.schedules";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string updateSchedule(int id, string[] schedule_details)
    {// update an existing schedule
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "UPDATE";
        objrequest.module = "schedule.schedules";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string deleteSchedule(int id)
    {// delete an existing schedule
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "DELETE";
        objrequest.module = "schedule.schedules";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getShifts()
    {// get shifts
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "GET";
        objrequest.module = "schedule.shifts";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getShiftDetails(int id)
    {// get shift details
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "GET";
        objrequest.module = "schedule.shifts";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string updateShift(int id, string[] shift_details)
    {// update shift details
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "UPDATE";
        objrequest.module = "schedule.shifts";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string createShift(string[] shift_details)
    {// create a new shift
        BasicData bData = new BasicData();
        bData.token = Token;
        bData.output = OutPut;
        Request objrequest = new Request();
        objrequest.method = "CREATE";
        objrequest.module = "schedule.shifts";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string deleteShift(int id)
    {// delete a shift
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "DELETE";
        objrequest.module = "schedule.shifts";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getVacationSchedules(string[] time_period)
    {// get schedule vacations, pass start and end params to get vacations within a certian time-period
        BasicData bData = new BasicData();
        bData.token = Token;
        bData.output = OutPut;
        Request objrequest = new Request();
        objrequest.method = "GET";
        objrequest.module = "schedule.vacations";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getVacationScheduleDetails(int id)
    {// get vacation schedule details
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "GET";
        objrequest.module = "schedule.vacations";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string createVacationSchedule(string[] vacation_details)
    {// create a vacation schedule
        BasicData bData = new BasicData();
        bData.token = Token;
        bData.output = OutPut;
        Request objrequest = new Request();
        objrequest.method = "CREATE";
        objrequest.module = "schedule.vacations";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);

    }

    public string updateVacationSchedule(int id, string[] vacation_details)
    {// update a vacation schedule
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "UPDATE";
        objrequest.module = "schedule.vacations";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string deleteVacationSchedule(int id)
    {// delete a vacation schedule
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "DELETE";
        objrequest.module = "schedule.vacations";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getScheduleConflicts(string[] time_period)
    {// get schedule conflicts
        BasicData bData = new BasicData();
        bData.token = Token;
        bData.output = OutPut;

        Request objrequest = new Request();
        objrequest.method = "GET";
        objrequest.module = "schedule.conflicts";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }


    /*
	 * Administration Methods
	 *
	 */
    public string getAdminSettings()
    {// get admin settings
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "GET";
        objrequest.module = "admin.settings";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);

    }

    public string updateAdminSettings(string[] settings)
    {// update admin settings
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "UPDATE";
        objrequest.module = "admin.settings";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getAdminFiles()
    {// get administrator file listing
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "GET";
        objrequest.module = "admin.files";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getAdminFileDetails(int id)
    {// get admin file details
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "GET";
        objrequest.module = "admin.files";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string updateAdminFile(int id, string[] details)
    {// update admin file details
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "UPDATE";
        objrequest.module = "admin.files";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string createAdminFile(string[] file_details)
    {// create new admin file
        BasicData bData = new BasicData();
        bData.token = Token;
        bData.output = OutPut;
        Request objrequest = new Request();
        objrequest.method = "CREATE";
        objrequest.module = "admin.files";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
        //$file_details = array_merge( $file_details, $this->getFileData( $file_details['filename'] ) );
        //return $this->setRequest(
        //    array_merge(
        //        array(
        //            'module' => 'admin.file',
        //            'method' => 'CREATE'
        //        ),
        //        $file_details
        //    )
        //);
    }

    public string deleteAdminFile(int id)
    {// delete admin file
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "DELETE";
        objrequest.module = "admin.files";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
        //return $this->setRequest(
        //    array(
        //        'module' => 'admin.file',
        //        'method' => 'DELETE',
        //        'id' => $id
        //    )
        //);
    }

    public string getAdminBackups()
    {// get admin backups
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "GET";
        objrequest.module = "admin.backups";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
        //return $this->setRequest(
        //    array(
        //        'module' => 'admin.backups',
        //        'method' => 'GET'
        //    )
        //);
    }

    public string getAdminBackupDetails(int id)
    {// get admin backup details
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "GET";
        objrequest.module = "admin.backup";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string createAdminBackup(string[] backup_details)
    {// create an admin backup
        //$backup_details = array_merge( $backup_details, $this->getFileData( $backup_details['filename'] ) );
        //return $this->setRequest(
        //    array_merge(
        //        array(
        //            'module' => 'admin.backup',
        //            'method' => 'CREATE'
        //        ),
        //        $backup_details
        //    )
        //);
        return "";
    }

    public string deleteAdminBackup(int id)
    {// delete an admin backup
        BasicRequestData bData = new BasicRequestData();
        bData.token = Token;
        bData.output = OutPut;
        bData.id = id.ToString();
        Request objrequest = new Request();
        objrequest.method = "DELETE";
        objrequest.module = "admin.backup";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    /*
     * API Methods
     *
     */
    public string getAPIConfig()
    {// get api config
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "GET";
        objrequest.module = "api.config";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);
    }

    public string getAPIMethods()
    {// get all available api methods
        DataEtcRequest bData = new DataEtcRequest();
        bData.token = Token;
        bData.output = OutPut;
        DataRequest objrequest = new DataRequest();
        objrequest.method = "GET";
        objrequest.module = "api.methods";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        return perform_request(RequestApi);


    }

    public string getAppToken()
    {// return the token that's currently being used
        try
        {//
            if (currentResponse != null)
            {
                if (currentResponse.Tables["response"] != null)
                {// user authenticated, return the token
                    this._token = currentResponse.Tables["response"].Rows[0]["token"].ToString();
                    Token = currentResponse.Tables["response"].Rows[0]["token"].ToString();
                    return currentResponse.Tables["response"].Rows[0]["token"].ToString();
                }
                else
                {// user not authenticated, return an error
                    if (Token != null)
                    {
                        return Token;
                    }
                    else
                    {
                        return internal_errors(4);
                    }
                }
            }
            else
            {
                // user not authenticated, return an error
                if (Token != null)
                {
                    return Token;
                }
                else
                {
                    return internal_errors(4);
                }
            }
        }
        catch (Exception e)
        {//
            return e.ToString();
        }
    }
    private string getFileMimeType(string extension)
    {//
        NameValueCollection mimes = new NameValueCollection();
        mimes.Add("ez", "application/andrew-inset");
        mimes.Add("hqx", "application/mac-binhex40");
        mimes.Add("cpt", "application/mac-compactpro");
        mimes.Add("doc", "application/msword");
        mimes.Add("bin", "application/octet-stream");
        mimes.Add("dms", "application/octet-stream");
        mimes.Add("lha", "application/octet-stream");
        mimes.Add("lzh", "application/octet-stream");
        mimes.Add("exe", "application/octet-stream");
        mimes.Add("class", "application/octet-stream");
        mimes.Add("so", "application/octet-stream");
        mimes.Add("dll", "application/octet-stream");
        mimes.Add("oda", "application/oda");
        mimes.Add("pdf", "application/pdf");
        mimes.Add("ai", "application/postscript");
        mimes.Add("eps", "application/postscript");
        mimes.Add("smi", "application/smil");
        mimes.Add("smil", "application/smil");
        mimes.Add("wbxml", "application/vnd.wap.wbxml");
        mimes.Add("wmlc", "application/vnd.wap.wmlc");
        mimes.Add("wmlsc", "application/octet-stream");
        mimes.Add("bcpio", "application/x-bcpio");
        mimes.Add("vcd", "application/x-cdlink");
        mimes.Add("pgn", "application/x-chess-pgn");
        mimes.Add("cpio", "application/x-cpio");
        mimes.Add("csh", "application/x-csh");
        mimes.Add("dcr", "application/x-director");
        mimes.Add("dir", "application/x-director");
        mimes.Add("dxr", "application/x-director");
        mimes.Add("dvi", "application/x-dvi");
        mimes.Add("spl", "application/x-futuresplash");
        mimes.Add("gtar", "application/x-gtar");
        mimes.Add("hdf", "application/x-hdf");
        mimes.Add("js", "aapplication/x-javascript");
        mimes.Add("skp", "application/x-koa");
        mimes.Add("pdf", "application/pdf");
        mimes.Add("ai", "application/postscript");
        mimes.Add("eps", "application/postscript");
        mimes.Add("smi", "application/smil");
        mimes.Add("smil", "application/smil");
        mimes.Add("wbxml", "application/vnd.wap.wbxml");
        mimes.Add("wmlc", "application/vnd.wap.wmlc");
        mimes.Add("wmlsc", "application/octet-stream");
        mimes.Add("bcpio", "application/x-bcpio");
        mimes.Add("skd", "application/x-koan");
        mimes.Add("skt", "application/x-koan");
        mimes.Add("skm", "application/x-koan");
        mimes.Add("latex", "application/x-latex");
        mimes.Add("nc", "application/x-netcdf");
        mimes.Add("cdf", "application/x-netcdf");
        mimes.Add("sh", "application/x-sh");
        mimes.Add("shar", "application/x-shar");
        mimes.Add("swf", "application/x-shockwave-flash");
        mimes.Add("sit", "aapplication/x-stuffit");
        mimes.Add("sv4cpio", "application/x-sv4cpio");
        mimes.Add("sv4crc", "application/x-sv4crc");
        mimes.Add("tar", "application/x-tar");
        mimes.Add("tcl", "application/x-tcl");
        mimes.Add("tex", "application/x-tex");
        mimes.Add("texinfo", "application/x-texinfo");
        mimes.Add("texi", "application/x-texinfo");
        mimes.Add("t", "application/x-troff");
        mimes.Add("tr", "application/x-troff");
        mimes.Add("roff", "application/x-troff");
        mimes.Add("man", "application/x-troff-man");
        mimes.Add("me", "application/x-troff-me");
        mimes.Add("ms", "application/x-troff-ms");
        mimes.Add("ustar", "application/x-ustar");
        mimes.Add("src", "application/x-wais-source");
        mimes.Add("xhtml", "application/xhtml+xml");
        mimes.Add("xht", "application/xhtml+xml");
        mimes.Add("zip", "application/zip");
        mimes.Add("au", "audio/basic");
        mimes.Add("snd", "audio/basic");
        mimes.Add("mid", "audio/midi");
        mimes.Add("midi", "audio/midi");
        mimes.Add("kar", "audio/midi");
        mimes.Add("mpga", "audio/mpeg");
        mimes.Add("mp2", "audio/mpeg");
        mimes.Add("mp3", "audio/mpeg");
        mimes.Add("aif", "audio/x-aiff");
        mimes.Add("aiff", "audio/x-aiff");
        mimes.Add("aifc", "audio/x-aiff");
        mimes.Add("m3u", "audio/x-mpegurl");
        mimes.Add("ram", "audio/x-pn-realaudio");
        mimes.Add("rm", "audio/x-pn-realaudio");
        mimes.Add("rpm", "audio/x-pn-realaudio-plugin");
        mimes.Add("ra", "audio/x-realaudio");
        mimes.Add("wav", "audio/x-wav");
        mimes.Add("pdb", "chemical/x-pdb");
        mimes.Add("xyz", "chemical/x-xyz");
        mimes.Add("bmp", "image/bmp");
        mimes.Add("gif", "image/gif");
        mimes.Add("ief", "image/ief");
        mimes.Add("jpeg", "image/jpeg");
        mimes.Add("jpg", "image/jpgg");
        mimes.Add("jpe", "image/jpeg");
        mimes.Add("png", "image/png");
        mimes.Add("tiff", "image/tiff");
        mimes.Add("tif", "image/tif");
        mimes.Add("djvu", "image/vnd.djvu");
        mimes.Add("djv", "image/vnd.djvu");
        mimes.Add("wbmp", "image/vnd.wap.wbmp");
        mimes.Add("ras", "image/x-cmu-raster");
        mimes.Add("pnm", "image/x-portable-anymap");
        mimes.Add("pbm", "image/x-portable-bitmap");
        mimes.Add("pgm", "image/x-portable-graymap");
        mimes.Add("ppm", "image/x-portable-pixmap");
        mimes.Add("rgb", "image/x-rgb");
        mimes.Add("xbm", "image/x-xbitmap");
        mimes.Add("xpm", "image/x-xpixmap");
        mimes.Add("xwd", "mage/x-windowdump");
        mimes.Add("iges", "model/iges");
        mimes.Add("msh", "model/mesh");
        mimes.Add("mesh", "model/mesh");
        mimes.Add("silo", "model/mesh");
        mimes.Add("wrl", "model/vrml");
        mimes.Add("vrml", "model/vrml");
        mimes.Add("css", "text/css");
        mimes.Add("html", "text/html");
        mimes.Add("htm", "text/html");
        mimes.Add("asc", "text/plain");
        mimes.Add("txt", "text/plain");
        mimes.Add("rtx", "text/richtext");
        mimes.Add("rtf", "text/rtf");
        mimes.Add("sgml", "text/sgml");
        mimes.Add("sgm", "text/sgml");
        mimes.Add("tsv", "text/tab-seperated-values");
        mimes.Add("wml", "text/vnd.wap.wml");
        mimes.Add("wmls", "text/vnd.wap.wmlscript");
        mimes.Add("etx", "text/x-setext");
        mimes.Add("xml", "text/xml");
        mimes.Add("xsl", "text/xml");
        mimes.Add("mpeg", "video/mpeg");
        mimes.Add("mpg", "video/mpeg");
        mimes.Add("mpe", "video/mpeg");
        mimes.Add("qt", "video/quicktime");
        mimes.Add("mov", "video/quicktime");
        mimes.Add("mxu", "video/vnd.mpegurl");
        mimes.Add("avi", "video/x-msvideo");
        mimes.Add("movie", "video/x-sgi-movie");
        mimes.Add("ice", "x-conference-xcooltalk");
        string item = string.Empty;
        try
        {//
            if (mimes.GetValues(extension) != null)
            {
                foreach (string item_loopVariable in new NameValueCollection(mimes))
                {
                    item = item_loopVariable;
                    // mime found
                    if (requests[item] == extension)
                    {
                        return requests[item];
                    }
                }


            }
            else
            {
                // mime not found
                throw new Exception("Mime for ." + extension + " not found");
            }
        }
        catch (Exception e)
        {//
            e.ToString();
        }
        return "";
    }


    private string internal_errors(Int32 errno)
    {// errors internal to the ShiftPlanning SDK
        string message = string.Empty;
        switch (errno)
        {// internal error messages
            case 1:
                message = "The requested API method was not found in this SDK.";
                break;
            case 2:
                message = "The ShiftPlanning API is not responding.";
                break;
            case 3:
                message = "You must use the login method before accessing other modules of this API.";
                break;
            case 4:
                message = "A session has not yet been established.";
                break;
            case 5:
                message = "You must specify your Developer Key when using this SDK.";
                break;
            case 6:
                message = "The ShiftPlanning SDK needs the CURL PHP extension.";
                break;
            case 7:
                message = "The ShiftPlanning SDK needs the JSON PHP extension.";
                break;
            case 8:
                message = "File doesn\'t exist.";
                break;
            case 9:
                message = "Could not find the correct mime for the file supplied.";
                break;
            default:
                message = "Could not find the requested error message.";
                break;
        }
        return message;
    }
    private void setSession()
    {// store the user data to this session
        if (currentResponse.Tables.Count > 0)
        {

        }
        //if (System.Web.HttpContext.Current.Session["token"] != null)
        //{
        //    System.Web.HttpContext.Current.Session["token"]
        //}
        //System.Web.HttpContext.Current.Session["token"] = this.response[0]["token"].tos();
        //System.Web.HttpContext.Current.Session["data"] = this.response[0]["data"];
        //print_r($this->response['data'][0]); 
        //print_r($this->response['token'][0]); die;
    }
    public string doLogout()
    {
        return this.destroySession();
    }
    private string destroySession()
    {// destroy the currently active session
        BasicData bData = new BasicData();
        bData.token = Token;
        bData.output = OutPut;
        Request objrequest = new Request();
        objrequest.method = "GET";
        objrequest.module = "staff.logout";
        bData.request = objrequest;
        NameValueCollection RequestApi = new NameValueCollection();
        JavaScriptSerializer js = new JavaScriptSerializer();
        RequestApi.Add("data", js.Serialize(bData));
        string responseXml = perform_request(RequestApi);
        TextReader txtReader = new StringReader(responseXml);
        XmlReader reader = new XmlTextReader(txtReader);
        currentResponse = new DataSet();
        currentResponse.ReadXml(reader);
        reader.Close();
        txtReader.Close();

        if (currentResponse.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < currentResponse.Tables[0].Rows.Count; i++)
            {
                if (currentResponse.Tables[0].Rows[i]["status"] != null)
                {
                    if (currentResponse.Tables[0].Rows[i]["status"].ToString() == "1")
                    {
                        System.Web.HttpContext.Current.Session["token"] = null;
                        System.Web.HttpContext.Current.Session["data"] = null;
                        break;
                    }

                }
            }
        }
        return responseXml;
    }
    public DataSet getResponse(int call_num)
    {// return the API response data to the calling method
        DataSet ds = new DataSet();
        if (currentResponse != null)
        {
            return currentResponse;
        }
        else
        {
            return ds;
        }

    }
    public string setRequest(NameValueCollection requests)
    {// set the request parameters
        // clear out previous request data
        this.requests = new NameValueCollection();

        // set the default response type of JSON
        this.request["output"] = this._outPut;

        this._init = 0;
        string item = null;
        if (currentResponse != null)
        {
            if (Token != null)
            {
                foreach (string item_loopVariable in new NameValueCollection(requests))
                {
                    item = item_loopVariable;
                    if (requests[item] == "key")
                    {
                        requests.Remove(item);
                        break;
                    }
                }
                return perform_request(requests);
            }
            else
            {
                BasicData bData = new BasicData();
                bData.key = Key;
                bData.output = OutPut;
                Request objrequest = new Request();
                objrequest.method = Method;
                objrequest.module = module;
                objrequest.password = Password;
                objrequest.username = Username;
                bData.request = objrequest;
                NameValueCollection RequestApi = new NameValueCollection();
                JavaScriptSerializer js = new JavaScriptSerializer();
                RequestApi.Add("data", js.Serialize(bData));

                return perform_request(RequestApi);
            }
        }
        else
        {
            BasicData bData = new BasicData();
            bData.key = Key;
            bData.output = OutPut;
            Request objrequest = new Request();
            objrequest.method = Method;
            objrequest.module = module;
            objrequest.password = Password;
            objrequest.username = Username;
            bData.request = objrequest;
            NameValueCollection RequestApi = new NameValueCollection();
            JavaScriptSerializer js = new JavaScriptSerializer();
            RequestApi.Add("data", js.Serialize(bData));

            return perform_request(RequestApi);
        }

    }
    private string setCallback(string callback)
    {// set the method to call after successful api call
        this._callback = callback;
        return this._callback;
    }

    public object getSession()
    {// check whether a valid session has been established
        if (System.Web.HttpContext.Current.Session["token"] != null)
        {// user is already authenticated
            if (currentResponse.Tables["data"] != null)
            {
                return currentResponse.Tables["data"];
            }
            else
            {
                return false;
            }

        }
        else
        {// user has not authenticated
            return false;
        }
    }
    public void setDebug()
    {
        // turn debug on
        if (File.Exists("log.txt"))
        {
            File.Delete("log.txt");
        }
        else
        {
            Debug = true;
        }
    }

    public static string ToJsonString(object value)
    {
        JavaScriptSerializer ser = new JavaScriptSerializer();
        string json = ser.Serialize(value);
        return json;
    }

    public class Request
    {
        public string module, method, username, password;
    }
    public class DataRequest
    {
        public string module, method;
    }
    public class DataRequestId
    {
        public string module, method, id;
    }
    public class DataEtcRequest
    {
        public string output, key, token;
        public DataRequest request = new DataRequest();
    }
    public class DataRequestByID
    {
        public string output, token;
        public DataRequestId request = new DataRequestId();
    }
    public class BasicData
    {
        public string output, key, token;
        public Request request = new Request();
    }
    public class BasicRequestData
    {
        public string output, key, token, id;
        public Request request = new Request();
    }
    public class employee
    {
        public string module, method, id, name, email, username, group, wage, nick_name, birth_day, birth_month, cell_phone, home_phone, avatar, address, city, state, notes, ical, group_name, status_name;

    }
    private class business
    {
        public string name, address, phone, fax;

    }
    private class data
    {
        public employee Employee = new employee();
        public business Business = new business();
    }

    private class LoginResponse
    {
        public string status, token, error;
        public data Data = new data();
    }
    private class ErrorResponse
    {
        public string status, token, error, data;

    }
    public class RequestById
    {
        public string output, key, token;
        public employee request = new employee();
    }

    public class login
    {
        public string output, key, token;
        public Request request = new Request();
    }
    private DataSet XmlString2DataSet(string xmlString)
    {
        //create a new DataSet that will hold our values
        DataSet quoteDataSet = null;

        //check if the xmlString is not blank
        if (String.IsNullOrEmpty(xmlString))
        {
            //stop the processing
            return quoteDataSet;
        }

        try
        {
            //create a StringReader object to read our xml string
            using (StringReader stringReader = new StringReader(xmlString))
            {
                //initialize our DataSet
                quoteDataSet = new DataSet();

                //load the StringReader to our DataSet
                quoteDataSet.ReadXml(stringReader);
            }
        }
        catch
        {
            //return null
            quoteDataSet = null;
        }

        //return the DataSet containing the stock information
        return quoteDataSet;
    }
    public string perform_request(NameValueCollection RequestApi)
    {
        string Result = string.Empty;
        using (WebClient client = new WebClient())
        {
            client.Headers.Add("KeepsAlive", "true");
            Byte[] responseData = client.UploadValues("http://www.shiftplanning.com/api/", RequestApi);
            Result = System.Text.Encoding.ASCII.GetString(responseData);
            currentResponse = new DataSet();
            currentResponse = XmlString2DataSet(Result);
        }
        return Result;
    }



}
