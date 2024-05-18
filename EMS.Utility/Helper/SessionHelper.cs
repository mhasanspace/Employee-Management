using EMS.Domain.OtherModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Utility.Helper
{
    public static class SessionHelper
    {
        public static AppUserLoginInfo GetAppUserLogin(ISession session)
        {
            var sessionData = session.GetString("AppUserLoginInfo");
            if (string.IsNullOrEmpty(sessionData))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<AppUserLoginInfo>(sessionData);
        }
    }
}
