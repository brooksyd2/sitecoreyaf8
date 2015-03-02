/* Yet Another Forum.NET
 * Copyright (C) 2003-2005 Bjørnar Henden
 * Copyright (C) 2006-2013 Jaben Cargman
 * Copyright (C) 2014-2015 Ingo Herbote
 * http://www.yetanotherforum.net/
 * 
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at

 * http://www.apache.org/licenses/LICENSE-2.0

 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
namespace YAF.Pages.Admin
{
    #region Using

    using System;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    using YAF.Classes;
    using YAF.Controls;
    using YAF.Core;
    using YAF.Core.Model;
    using YAF.Types;
    using YAF.Types.Constants;
    using YAF.Types.Extensions;
    using YAF.Types.Interfaces;
    using YAF.Types.Models;
    using YAF.Utils;

    #endregion

    /// <summary>
    ///    The Admin Smilies Edit Page.
    /// </summary>
    public partial class smilies_edit : AdminPage
    {
        #region Methods

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender. 
        /// </param>
        /// <param name="e">
        /// The e. 
        /// </param>
        protected void Page_Load([NotNull] object sender, [NotNull] EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            this.PageLinks.AddLink(this.PageContext.BoardSettings.Name, YafBuildLink.GetLink(ForumPages.forum));
            this.PageLinks.AddLink(this.GetText("ADMIN_ADMIN", "Administration"), YafBuildLink.GetLink(ForumPages.admin_admin));
            this.PageLinks.AddLink(this.GetText("ADMIN_SMILIES", "TITLE"), YafBuildLink.GetLink(ForumPages.admin_smilies));
            this.PageLinks.AddLink(this.GetText("ADMIN_SMILIES_EDIT", "TITLE"), string.Empty);

            this.Page.Header.Title = "{0} - {1} - {2}".FormatWith(
                this.GetText("ADMIN_ADMIN", "Administration"), 
                this.GetText("ADMIN_SMILIES", "TITLE"), 
                this.GetText("ADMIN_SMILIES_EDIT", "TITLE"));

            this.cancel.Text = this.GetText("COMMON", "CANCEL");
            this.save.Text = this.GetText("COMMON", "SAVE");

            this.BindData();
        }

        /// <summary>
        ///     The bind data.
        /// </summary>
        private void BindData()
        {
            using (var dt = new DataTable("Files"))
            {
                dt.Columns.Add("FileID", typeof(long));
                dt.Columns.Add("FileName", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                DataRow dr = dt.NewRow();
                dr["FileID"] = 0;
                dr["FileName"] = "../spacer.gif"; // use blank.gif for Description Entry
                dr["Description"] = this.GetText("ADMIN_SMILIES_EDIT", "SELECT_SMILEY");
                dt.Rows.Add(dr);

                var dir =
                    new DirectoryInfo(this.Request.MapPath("{0}{1}".FormatWith(YafForumInfo.ForumServerFileRoot, YafBoardFolders.Current.Emoticons)));

                FileInfo[] files = dir.GetFiles("*.*");

                long fileId = 1;

                foreach (FileInfo file in from file in files
                                          let sExt = file.Extension.ToLower()
                                          where sExt == ".png" || sExt == ".gif" || sExt == ".jpg"
                                          select file)
                {
                    dr = dt.NewRow();
                    dr["FileID"] = fileId++;
                    dr["FileName"] = file.Name;
                    dr["Description"] = file.Name;
                    dt.Rows.Add(dr);
                }

                this.Icon.DataSource = dt;
                this.Icon.DataValueField = "FileName";
                this.Icon.DataTextField = "Description";
            }

            this.DataBind();

            if (this.Request["s"] != null)
            {
                var smiley =
                    this.GetRepository<Smiley>().ListTyped(this.Request.QueryString.GetFirstOrDefaultAs<int>("s"), this.PageContext.PageBoardID).FirstOrDefault();

                if (smiley != null)
                {
                    this.Code.Text = smiley.Code;
                    this.Emotion.Text = smiley.Emoticon;

                    if (this.Icon.Items.FindByText(smiley.Icon) != null)
                    {
                        this.Icon.Items.FindByText(smiley.Icon).Selected = true;
                    }

                    this.Preview.Src = "{0}{1}/{2}".FormatWith(YafForumInfo.ForumClientFileRoot, YafBoardFolders.Current.Emoticons, smiley.Icon);
                    this.SortOrder.Text = smiley.SortOrder.ToString(); // Ederon : 9/4/2007
                }
            }
            else
            {
                var smilies =
                    this.GetRepository<Smiley>().ListTyped();

                this.SortOrder.Text = (smilies.Max(s => s.SortOrder) + 1).ToString();

                this.Preview.Src = "{0}images/spacer.gif".FormatWith(YafForumInfo.ForumClientFileRoot);
            }

            this.Icon.Attributes["onchange"] =
                "getElementById('{2}').src='{0}{1}/' + this.value".FormatWith(
                    YafForumInfo.ForumClientFileRoot, YafBoardFolders.Current.Emoticons, this.Preview.ClientID);
        }

        /// <summary>
        /// Handles the Click event of the cancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void cancel_Click([NotNull] object sender, [NotNull] EventArgs e)
        {
            YafBuildLink.Redirect(ForumPages.admin_smilies);
        }

        /// <summary>
        /// Handles the Click event of the save control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void save_Click([NotNull] object sender, [NotNull] EventArgs e)
        {
            string code = this.Code.Text.Trim();
            string emotion = this.Emotion.Text.Trim();
            string icon = this.Icon.SelectedItem.Text.Trim();
            byte sortOrder;

            if (emotion.Length > 50)
            {
                this.PageContext.AddLoadMessage(this.GetText("ADMIN_SMILIES_EDIT", "MSG_TOO_LONG"));
                return;
            }

            if (code.Length == 0)
            {
                this.PageContext.AddLoadMessage(this.GetText("ADMIN_SMILIES_EDIT", "MSG_CODE_MISSING"));
                return;
            }

            if (code.Length > 10)
            {
                this.PageContext.AddLoadMessage(this.GetText("ADMIN_SMILIES_EDIT", "MSG_CODE_LONG"));
                return;
            }

            if (!new Regex(@"\[.+\]").IsMatch(code))
            {
                this.PageContext.AddLoadMessage(this.GetText("ADMIN_SMILIES_EDIT", "MSG_CODE_BRACK"));
                return;
            }

            if (emotion.Length == 0)
            {
                this.PageContext.AddLoadMessage(this.GetText("ADMIN_SMILIES_EDIT", "MSG_NO_EMOTICON"));
                return;
            }

            if (this.Icon.SelectedIndex < 1)
            {
                this.PageContext.AddLoadMessage(this.GetText("ADMIN_SMILIES_EDIT", "MSG_NO_ICON"));
                return;
            }

            // Ederon 9/4/2007
            if (!byte.TryParse(this.SortOrder.Text, out sortOrder) || sortOrder > 255)
            {
                this.PageContext.AddLoadMessage(this.GetText("ADMIN_SMILIES_EDIT", "MSG_SORT_NMBR"));
                return;
            }

            if (this.Request["s"] != null)
            {
                this.GetRepository<Smiley>()
                    .Save(this.Request.QueryString.GetFirstOrDefaultAs<int>("s"), code, icon, emotion, sortOrder, 0);
            }
            else
            {
                this.GetRepository<Smiley>().Save(null, code, icon, emotion, sortOrder, 0);
            }

            YafBuildLink.Redirect(ForumPages.admin_smilies);
        }

        #endregion
    }
}