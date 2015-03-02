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

using YAF.Types.SitecoreHelpers;

namespace YAF.Types.Interfaces
{
    using System;
    using System.Data;
    using System.Security;
    using System.Web.Security;
    using YAF.Types.Constants;

    /// <summary>
    /// The UserData Interface
    /// </summary>
   [SecurityCriticalAttribute]
    public interface IUserData
    {
        /// <summary>
        ///   Gets a value indicating whether AutoWatchTopics.
        /// </summary>
        bool AutoWatchTopics {
            [SecurityCriticalAttribute]
            get; }

        /// <summary>
        ///   Gets Avatar.
        /// </summary>
        string Avatar {
            [SecurityCriticalAttribute]
            get; }

        /// <summary>
        ///   Gets Culture.
        /// </summary>
        string CultureUser {
            [SecurityCriticalAttribute]
            get; }

        /// <summary>
        ///   Gets DBRow.
        /// </summary>
        DataRow DBRow {
            [SecurityCriticalAttribute]
            get; }

        /// <summary>
        ///   Gets a value indicating whether  DST is Enabled.
        /// </summary>
        bool DSTUser {
            [SecurityCriticalAttribute]
            get; }

        /// <summary>
        /// Gets a value indicating whether DailyDigest.
        /// </summary>
        bool DailyDigest {
            [SecurityCriticalAttribute]
            get; }

        /// <summary>
        ///   Gets DisplayName.
        /// </summary>
        string DisplayName {
            [SecurityCriticalAttribute]
            get; }

        /// <summary>
        ///   Gets Email.
        /// </summary>
        string Email {
            [SecurityCriticalAttribute]
            get; }

        /// <summary>
        ///   Gets a value indicating whether HasAvatarImage.
        /// </summary>
        bool HasAvatarImage {
            [SecurityCriticalAttribute]
            get; }

        /// <summary>
        ///   Gets a value indicating whether IsActiveExcluded.
        /// </summary>
        bool IsActiveExcluded {
            [SecurityCriticalAttribute]
            get; }

        /// <summary>
        ///   Gets a value indicating whether IsGuest.
        /// </summary>
        bool IsGuest {
            [SecurityCriticalAttribute]
            get; }

        /// <summary>
        ///   Gets Joined.
        /// </summary>
        DateTime? Joined {

            [SecurityCriticalAttribute]
            get;
        }

        /// <summary>
        ///   Gets LanguageFile.
        /// </summary>
        string LanguageFile { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets LastVisit.
        /// </summary>
        DateTime? LastVisit { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets Membership.
        /// </summary>
        SitecoreMembershipUser Membership { [SecurityCriticalAttribute] get; }

        /// <summary>
        /// Gets NotificationSetting.
        /// </summary>
        UserNotificationSetting NotificationSetting { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets Number of Posts.
        /// </summary>
        int? NumPosts { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets a value indicating whether UseMobileTheme.
        /// </summary>
        bool UseMobileTheme { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets a value indicating whether PMNotification.
        /// </summary>
        bool PMNotification { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets Points.
        /// </summary>
        int? Points { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets Profile.
        /// </summary>
        IYafUserProfile Profile { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets RankName.
        /// </summary>
        string RankName { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets Signature.
        /// </summary>
        string Signature { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets ThemeFile.
        /// </summary>
        string ThemeFile { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets TimeZone.
        /// </summary>
        int? TimeZone { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets UserID.
        /// </summary>
        int UserID { [SecurityCriticalAttribute] get; }

        /// <summary>
        ///   Gets UserName.
        /// </summary>
        string UserName { [SecurityCriticalAttribute] get; }

        /// <summary>
        /// Gets the text editor.
        /// </summary>
        /// <value>
        /// The text editor.
        /// </value>
        string TextEditor { [SecurityCriticalAttribute] get; }
    }
}