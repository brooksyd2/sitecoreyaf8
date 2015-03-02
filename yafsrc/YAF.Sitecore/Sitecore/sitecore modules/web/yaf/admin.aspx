<%@ Page language="c#" %>
<%@ Register TagPrefix="YAF" Assembly="YAF" Namespace="YAF" %>
<script runat="server">
  
  /// <summary>
  /// This page is used from inside Sitecore and will use the first found Forum administrator
  /// as user so YAF can be configured from inside Sitecore.
  /// </summary>
  /// <remarks>
  /// Please observe the new "SitecoreAdminMode" attribute on the YAF:Forum component
  /// that will, when set to true, log every user in as a Forum administrator
  /// </remarks>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  void Page_Load(object sender, System.EventArgs e) 
  {
    // Check for correct domain
    if (Sitecore.Context.Domain.Name != "sitecore")
    {
      Response.Write("You must be logged into Sitecore to administer YAF");
      Response.End();
      return;
    }
    // Go to the admin page
    if (Request.QueryString.Count == 0)
      Server.Transfer("/sitecore modules/web/yaf/admin.aspx?g=admin_admin");
  }

</script>  


<html>
  <head id="YafHead" runat="server">
    <title>YetAnotherForum - Sitecore Administration</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </head>
  <body>
    <form id="form" runat="server">
      <YAF:Forum ID="forum" runat="server" SitecoreAdminMode="true" />
    </form>
  </body>
</html>
