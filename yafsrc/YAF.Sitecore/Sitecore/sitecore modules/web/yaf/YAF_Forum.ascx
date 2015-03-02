<%@ Control Language="c#" AutoEventWireup="true" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Import Namespace="System.Xml" %>
<%@ Register TagPrefix="YAF" Assembly="YAF" Namespace="YAF" %>
<script runat="server">
  
  /// <summary>
  /// This sublayout renders one board, group or forum from YAF
  /// </summary> 
  /// <remarks>
  /// This is part of the optional Sitecore Package that enables you to select (inside Sitecore) 
  /// which board, category or forum to display on your page.
  /// </remarks>
  void Page_Load(object sender, System.EventArgs e) 
  {
    string yafString = Sitecore.Context.Item["YAF"];
    if (string.IsNullOrEmpty(yafString))
      return;
      
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(yafString);
    XmlNode yafNode = doc.SelectSingleNode("/yaf");
    if (yafNode == null)
      return;
    
    int boardID = 0;
    int categoryID = 0;
    int forumID = 0;
    
    if (TryParse(yafNode, "board", out boardID))
      yafForum.BoardID = boardID;
    
    if (TryParse(yafNode, "category", out categoryID))
      yafForum.CategoryID = categoryID;
      
    if (TryParse(yafNode, "forum", out forumID))
      yafForum.LockedForum = forumID;  
  }
  
  private bool TryParse(XmlNode node, string attr, out int result)
  {
    XmlAttribute attribute = node.Attributes[attr];
    if (attribute == null)
    {
      result = 0;
      return false;
    }
    return int.TryParse(attribute.Value, out result);  
  }

</script> 

<YAF:Forum runat="server" ID="yafForum"></YAF:Forum>
