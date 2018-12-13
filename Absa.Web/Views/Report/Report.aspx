<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Absa.Web.Views.Report.Report" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	     <script runat="server">
         void Page_Load(object sender, EventArgs e)
         {
             if (!IsPostBack)
             {
                 var model = new Absa.Web.Models.ReportModel();
                 Absa.DateAccess.AbsaDBEntities context = new  Absa.DateAccess.AbsaDBEntities();
                 var overRallReport = context.GetAppStatus(model.BusinessUnitId);
                 ReportDataSource rdc = new ReportDataSource("OverRall", overRallReport);
                 ReportViewer1.LocalReport.DataSources.Clear();
                 ReportViewer1.LocalReport.DataSources.Add(rdc);
                 ReportViewer1.LocalReport.Refresh();
             }
         }
    </script>
</head>
<body>
    <form id="form2" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1400px" AsyncRendering="False" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Views\Report\OverRall.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </form>
</body>
</html>