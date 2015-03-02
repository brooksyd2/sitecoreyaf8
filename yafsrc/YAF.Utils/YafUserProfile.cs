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
namespace YAF.Utils
{
  #region Using
    using System;
    using System.Security;
    using System.Web.Profile;
    using YAF.Types.Extensions;
    using YAF.Types.Interfaces;

  #endregion

  /// <summary>
  /// The yaf user profile.
  /// </summary>
   [SecurityCriticalAttribute]
    public class YafUserProfile : Sitecore.Security.UserProfile, IYafUserProfile
  {
    #region Properties

    /// <summary>
    /// Gets or sets AIM.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("AIM;nvarchar;255")]
    public string AIM
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("AIM", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["AIM"] = value;
      }
    }

    /// <summary>
    /// Gets or sets Birthday.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Birthday;DateTime")]
    public DateTime Birthday
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("Birthday", DateTime.Now.ToString()).ToType<DateTime>();
      }
      [SecurityCriticalAttribute]
      set
      {
        base["Birthday"] = value.ToString();
      }
    }

    /// <summary>
    /// Gets or sets Blog.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Blog;nvarchar;255")]
    public string Blog
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("Blog", ""); ;
      }
      [SecurityCriticalAttribute]
      set
      {
        base["Blog"] = value;
      }
    }

    /// <summary>
    /// Gets or sets BlogServicePassword.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("BlogServicePassword;nvarchar;255")]
    public string BlogServicePassword
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("BlogServicePassword", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["BlogServicePassword"] = value;
      }
    }

    /// <summary>
    /// Gets or sets BlogServiceUrl.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("BlogServiceUrl;nvarchar;255")]
    public string BlogServiceUrl
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("BlogServiceUrl", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["BlogServiceUrl"] = value;
      }
    }

    /// <summary>
    /// Gets or sets BlogServiceUsername.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("BlogServiceUsername;nvarchar;255")]
    public string BlogServiceUsername
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("BlogServiceUsername", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["BlogServiceUsername"] = value;
      }
    }

    /// <summary>
    /// Gets or sets Gender.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Gender;int")]
    public int Gender
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("Gender", "0").ToType<int>();
      }
      [SecurityCriticalAttribute]
      set
      {
        base["Gender"] = value.ToString();
      }
    }

    /// <summary>
    /// Gets or sets Google+ URL
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Google;nvarchar;400")]
    public string Google
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("Google", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["Google"] = value;
      }
    }

    /// <summary>
    /// Gets or sets Google Id
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("GoogleId;nvarchar;255")]
    public string GoogleId
    {
        [SecurityCriticalAttribute]
        get
        {
            return GetBaseValue("GoogleId", "");
        }
        [SecurityCriticalAttribute]
        set
        {
            base["GoogleId"] = value;
        }
    }

    /// <summary>
    /// Gets or sets Homepage.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Homepage;nvarchar;255")]
    public string Homepage
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("Homepage", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["Homepage"] = value;
      }
    }

    /// <summary>
    /// Gets or sets ICQ.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("ICQ;nvarchar;255")]
    public string ICQ
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("ICQ", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["ICQ"] = value;
      }
    }

    /// <summary>
    /// Gets or sets Facebook.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Facebook;nvarchar;400")]
    public string Facebook
    {
        [SecurityCriticalAttribute]
        get
        {
            return GetBaseValue("Facebook", "");
        }
        [SecurityCriticalAttribute]
        set
        {
            base["Facebook"] = value;
        }
    }

    /// <summary>
    /// Gets or sets Facebook.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("FacebookId;nvarchar;400")]
    public string FacebookId
    {
        [SecurityCriticalAttribute]
        get
        {
            return GetBaseValue("FacebookId", "");
        }
        [SecurityCriticalAttribute]
        set
        {
            base["FacebookId"] = value;
        }
    }

    /// <summary>
    /// Gets or sets Twitter.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Twitter;nvarchar;400")]
    public string Twitter
    {
        [SecurityCriticalAttribute]
        get
        {
            return GetBaseValue("Twitter", "");
        }
        [SecurityCriticalAttribute]
        set
        {
            base["Twitter"] = value;
        }
    }

    /// <summary>
    /// Gets or sets Twitter.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("TwitterId;nvarchar;400")]
    public string TwitterId
    {
        [SecurityCriticalAttribute]
        get
        {
            return GetBaseValue("TwitterId", "");
        }
        [SecurityCriticalAttribute]
        set
        {
            base["TwitterId"] = value;
        }
    }

    /// <summary>
    /// Gets or sets Interests.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Interests;nvarchar;400")]
    public string Interests
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("Interests", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["Interests"] = value;
      }
    }

    /// <summary>
    /// Gets or sets Location.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Location;nvarchar;255")]
    public string Location
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("Location", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["Location"] = value;
      }
    }

    /// <summary>
    /// Gets or sets Country.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Country;nvarchar;2")]
    public string Country
    {
        [SecurityCriticalAttribute]
        get
        {
            return GetBaseValue("Country", "");
        }
        [SecurityCriticalAttribute]
        set
        {
            base["Country"] = value;
        }
    }

    /// <summary>
    /// Gets or sets Region or State(US).
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Region;nvarchar;255")]
    public string Region
    {
        [SecurityCriticalAttribute]
        get
        {
            return GetBaseValue("Region", "");
        }
        [SecurityCriticalAttribute]
        set
        {
            base["Region"] = value;
        }
    }

    /// <summary>
    /// Gets or sets a City.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("City;nvarchar;255")]
    public string City
    {
        [SecurityCriticalAttribute]
        get
        {
            return GetBaseValue("City", "");
        }
        [SecurityCriticalAttribute]
        set
        {
            base["City"] = value;
        }
    }

    /// <summary>
    /// Gets or sets MSN.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("MSN;nvarchar;255")]
    public string MSN
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("MSN", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["MSN"] = value;
      }
    }

    /// <summary>
    /// Gets or sets Occupation.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Occupation;nvarchar;400")]
    public string Occupation
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("Occupation", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["Occupation"] = value;
      }
    }

    /// <summary>
    /// Gets or sets RealName.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("RealName;nvarchar;255")]
    public string RealName
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("RealName", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["RealName"] = value;
      }
    }

    /// <summary>
    /// Gets or sets Skype.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("Skype;nvarchar;255")]
    public string Skype
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("Skype", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["Skype"] = value;
      }
    }

    /// <summary>
    /// Gets or sets XMPP.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("XMPP;nvarchar;255")]
    public string XMPP
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("XMPP", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["XMPP"] = value;
      }
    }

    /// <summary>
    /// Gets or sets YIM.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("YIM;nvarchar;255")]
    public string YIM
    {
      [SecurityCriticalAttribute]
      get
      {
          return GetBaseValue("YIM", "");
      }
      [SecurityCriticalAttribute]
      set
      {
        base["YIM"] = value;
      }
    }

    /// <summary>
    /// Gets or sets Last Synced With DNN.
    /// </summary>
    [SettingsAllowAnonymous(false)]
    [CustomProviderData("LastSyncedWithDNN;DateTime")]
    public DateTime LastSyncedWithDNN
    {
        [SecurityCriticalAttribute]
        get
        {
            return GetBaseValue("LastSyncedWithDNN", "01/01/1900").ToType<DateTime>();
        }
        [SecurityCriticalAttribute]
        set
        {
            base["LastSyncedWithDNN"] = value.ToString();
        }
    }

    #endregion

    /// <summary>
    /// Gets the value from the base class, but return a default value if base value is null
    /// </summary>
    /// <param name="field">The field to get values from.</param>
    /// <param name="defaultValue">The default value in case that the base value is null.</param>
    /// <returns></returns>
    private string GetBaseValue(string field, string defaultValue)
    {
        string value = base[field] as string;
        if (value == null)
            return defaultValue;
        return value;
    }

    #region Public Methods

    /// <summary>
    /// Helper function to get a profile from the system
    /// </summary>
    /// <param name="userName">
    /// Name of the user.
    /// </param>
    /// <returns>
    /// The get profile.
    /// </returns>
    public static YafUserProfile GetProfile(string userName)
    {
      return Create(userName) as YafUserProfile;
    }

    #endregion
  }
}