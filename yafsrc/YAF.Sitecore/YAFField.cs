using System.Data;
using System.Web.UI;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.ContentEditor;
using YAF.Classes.Data;

namespace YAF
{
  // ----------------------------------------------------------------------------------
  /// <summary>
  /// This custom field displays all boards, categories and forums from YAF in a 
  /// drop down.
  /// </summary>
  /// <remarks>
  /// This is part of the optional Sitecore Package that enables you to select (inside Sitecore) 
  /// which board, category or forum to display on your page.
  /// </remarks>
  // ----------------------------------------------------------------------------------
  public class SitecoreYAFField : LookupEx
  {
    // ----------------------------------------------------------------------------------
    /// <summary>
    /// Renders the control.
    /// </summary>
    /// <param name="output">The output.</param>
    // ----------------------------------------------------------------------------------
    protected override void DoRender(HtmlTextWriter output)
    {
      Assert.ArgumentNotNull(output, "output");
      
      output.Write("<select" + GetControlAttributes() + ">");
      output.Write("<option value=\"\"></option>");

      DataTable boards = GetBoards();
      foreach (DataRow board in boards.Rows)
      {
        output.Write(GetOptionString(board["BoardID"], null, null, board["Name"] as string));
        DataTable categories = GetCategories(System.Convert.ToInt32(board["BoardID"]));
        foreach (DataRow category in categories.Rows)
        {
          output.Write(GetOptionString(board["BoardID"], category["CategoryID"], null, "&nbsp;&nbsp;&nbsp;&nbsp;" + category["Name"]));
          DataTable forums = GetForums(System.Convert.ToInt32(board["BoardID"]));
          foreach (DataRow forum in forums.Rows)
          {
            if (System.Convert.ToInt32(forum["CategoryID"]) == System.Convert.ToInt32(category["CategoryID"]))
              output.Write(GetOptionString(board["BoardID"], category["CategoryID"], forum["ForumID"], "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + forum["Name"] + " - " + forum["Description"]));
          }
        }
      }
    }

    // ----------------------------------------------------------------------------------
    /// <summary>
    /// Gets the boards.
    /// </summary>
    /// <returns></returns>
    // ----------------------------------------------------------------------------------
    private DataTable GetBoards()
    {
        DataTable boards = LegacyDb.board_list(null);
        return boards;
    }

    // ----------------------------------------------------------------------------------
    /// <summary>
    /// Gets the categories.
    /// </summary>
    /// <param name="boardID">The board ID.</param>
    /// <returns></returns>
    // ----------------------------------------------------------------------------------
    private DataTable GetCategories(int boardID)
    {
        DataTable categories = LegacyDb.category_list(boardID, null);
      return categories;
    }

    // ----------------------------------------------------------------------------------
    /// <summary>
    /// Gets the forums.
    /// </summary>
    /// <param name="boardID">The board ID.</param>
    /// <returns></returns>
    // ----------------------------------------------------------------------------------
    private DataTable GetForums(int boardID)
    {
      DataTable forums = LegacyDb.forum_list(boardID, null);
      return forums;
    }

    // ----------------------------------------------------------------------------------
    /// <summary>
    /// Creates a complete option string for the dropdown box
    /// </summary>
    /// <param name="boardID">The board ID.</param>
    /// <param name="categoryID">The category ID.</param>
    /// <param name="forumID">The forum ID.</param>
    /// <param name="title">The dropdown title</param>
    /// <returns></returns>
    // ----------------------------------------------------------------------------------
    private string GetOptionString(object boardID, object categoryID, object forumID, string title)
    {
      string value = GetValue(boardID, categoryID, forumID);
      bool selected = Value == value;
      return string.Format(@"<option value=""{0}"" {1}>{2}</option>", value, (selected ? @" selected=""selected""" : string.Empty), title);
    }

    // ----------------------------------------------------------------------------------
    /// <summary>
    /// Creates a value string for the dropdown values
    /// </summary>
    /// <param name="boardID">The board ID.</param>
    /// <param name="categoryID">The category ID.</param>
    /// <param name="forumID">The forum ID.</param>
    /// <returns></returns>
    // ----------------------------------------------------------------------------------
    private string GetValue(object boardID, object categoryID, object forumID)
    {
      return string.Format(@"<yaf board='{0}' category='{1}' forum='{2}'/>", boardID, categoryID, forumID);
    }



  }
  
  
  
}
