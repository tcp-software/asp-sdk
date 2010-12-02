<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableViewState="false" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>This is demo page to test API</title>
    <link href="App_Themes/Default/Style.css" rel="Stylesheet" />
</head>



<body>
    <form id="form1" runat="server">
        <div>
        <h1>This is demo page to test API</h1>
            <table width="100%" cellpadding="0" cellspacing="2" align="center">
                <tr>
                    <td valign="top">
                        <fieldset id="fLogin">
                            <legend>Check API Key</legend>
                            <table width="654" align="center" cellpadding="4" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        Developer Key</td>
                                    <td>
                                        <asp:TextBox ValidationGroup="devKey" CssClass="form_txtfield_box2" ID="txtKey" runat="server"></asp:TextBox>
                                        <%
                                            if (Session["myToken"] != null)
                                            {
                                                %>
                                                <%--<asp:Button ValidationGroup="devKey" ID="Button1" runat="server" Text="LogOut" OnClick="Button1_Click" />--%>
                                                <%
                                            }
                                             %>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        Username</td>
                                    <td>
                                        <asp:TextBox ValidationGroup="devKey" CssClass="form_txtfield_box2" ID="txtUsername" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Password</td>
                                    <td>
                                        <asp:TextBox ValidationGroup="devKey" CssClass="form_txtfield_box2" ID="txtPassword" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                <td></td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnCheckDevelioperKey" runat="server" Text="Check Key & Get Data" OnClick="btnCheckDevelioperKey_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        getMessages</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btmGetMessages" runat="server" Text="Submit" OnClick="btmGetMessages_Click" />
                                    </td>
                                </tr>
                             <%--   <tr>
                                    <td>
                                        getMessageDetails by message Id</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnDetailMessage" runat="server" Text="Submit" OnClick="btnDetailMessage_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Delete Message By Id</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnDelMsg" runat="server" Text="Submit" OnClick="btnDelMsg_Click" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        getWallMessages( )</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnWallMsg" runat="server" Text="Submit" OnClick="btnWallMsg_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        getEmployees( )</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnGetEmp" runat="server" Text="Submit" OnClick="btnGetEmp_Click" />
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td>
                                        getEmployeeDetails( $employee_id_number )</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnEmpDetails" runat="server" Text="Submit" OnClick="btnEmpDetails_Click" />
                                    </td>
                                </tr>--%>
                                 <tr>
                                    <td>
                                        updateEmployee( id,datararray )</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="updateEmployee" runat="server" Text="Submit" OnClick="updateEmployee_Click" />
                                    </td>
                                </tr>
                                 <%--<tr>
                                    <td>
                                        create employee( datararray )</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="createEmp" runat="server" Text="Submit" OnClick="createEmp_Click" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                       getStaffSkills( )
</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnGetStafSkill" runat="server" Text="Submit" OnClick="btnGetStafSkill_Click" />
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td>
                                        getStaffSkillDetails( $skill_id )
</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnStaffSkillById" runat="server" Text="Submit" OnClick="btnStaffSkillById_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        deleteStaffSkill( $skill_id )
</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnDelSkillById" runat="server" Text="Submit" OnClick="btnDelSkillById_Click" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        getSchedules( )

</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnSchedules" runat="server" Text="Submit" OnClick="btnSchedules_Click" />
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td>
                                        getScheduleDetails( $schedule_id )


</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnSchedulesDetail" runat="server" Text="Submit" OnClick="btnSchedulesDetail_Click" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        deleteSchedule( $schedule_id )</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnDelSchedules" runat="server" Text="Submit" OnClick="btnDelSchedules_Click" />
                                    </td>
                                </tr>--%>
                                 <tr>
                                    <td>
                                        getShifts( )</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnShifts" runat="server" Text="Submit" OnClick="btnShifts_Click" />
                                    </td>
                                </tr>
                                 <%--<tr>
                                    <td>
                                        getShiftDetails( $shift_id )
</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnShifById" runat="server" Text="Submit" OnClick="btnShifById_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        deleteShift( $shift_id )
</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="btnDelShift" runat="server" Text="Submit" OnClick="btnDelShift_Click" />
                                    </td>
                                </tr>--%>
                                <%-- <tr>
                                    <td>
                                        getVacationScheduleDetails( $schedule_id )

</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="getVacationScheduleDetails" runat="server" Text="Submit" OnClick="getVacationScheduleDetails_Click" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        deleteVacationSchedule( $schedule_id )</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="deleteVacationSchedule" runat="server" Text="Submit" OnClick="deleteVacationSchedule_Click" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        getScheduleConflicts</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="getScheduleConflicts" runat="server" Text="Submit" OnClick="getScheduleConflicts_Click" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        getAdminSettings</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="getAdminSettings" runat="server" Text="Submit" OnClick="getAdminSettings_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        getAdminFiles</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="getAdminFiles" runat="server" Text="Submit" OnClick="getAdminFiles_Click" />
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td>
                               getAdminFileDetails( $file_id )
</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="getAdminFileDetails" runat="server" Text="Submit" OnClick="getAdminFileDetails_Click" />
                                    </td>
                                </tr>
                                  <tr>
                                    <td>
                          deleteAdminFile( $file_id )

</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="deleteAdminFile" runat="server" Text="Submit" OnClick="deleteAdminFile_Click" />
                                    </td>
                                </tr>--%>
                                 <tr>
                                    <td>
                  getAdminBackups

</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="getAdminBackups" runat="server" Text="Submit" OnClick="getAdminBackups_Click" />
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td>
                  getAdminBackupDetails( $backup_id )


</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="getAdminBackupDetails" runat="server" Text="Submit" OnClick="getAdminBackupDetails_Click" />
                                    </td>
                                </tr>
                                   <tr>
                                    <td>
                  deleteAdminBackup( $backup_id )



</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="deleteAdminBackup" runat="server" Text="Submit" OnClick="deleteAdminBackup_Click" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                  getAPIConfig



</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="getAPIConfig" runat="server" Text="Submit" OnClick="getAPIConfig_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                  getAPIMethods



</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="getAPIMethods" runat="server" Text="Submit" OnClick="getAPIMethods_Click" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                  LogOut



</td>
                                    <td>
                                        <asp:Button ValidationGroup="devKey" ID="LogOut" runat="server" Text="Submit" OnClick="LogOut_Click" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td><td valign="top">
                        <fieldset id="Fieldset1">
                            <legend>Response Area</legend>
                            <table width="100%" align="center" cellpadding="4" cellspacing="0" border="0">
                            <tr><td valign="top">
                                        Response from Server</td></tr>
                                <tr>
                                    
                                    <td>
                                        <asp:TextBox TextMode="MultiLine" Rows="30" Columns="10" ReadOnly="true"  CssClass="form_txtfield_box2" Width="450" ID="txtResponse" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                
            </table>
        </div>
    </form>
</body>
</html>
