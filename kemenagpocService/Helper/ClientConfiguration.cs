﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kemenagpocService.Helper
{
    public class ClientConfiguration
    {
        public static ClientConfiguration Default { get { return ClientConfiguration.OneBox; } }

        public static ClientConfiguration OneBox = new ClientConfiguration()
        {
            UriString = "https://trialkemenag.crm5.dynamics.com/",
            UserName = "admin@trialkemenag.onmicrosoft.com",
            // Insert the correct password here for the actual test.
            Password = "pass@word1",

            ActiveDirectoryResource = "https://trialkemenag.crm5.dynamics.com",
            ActiveDirectoryTenant = "https://login.windows.net/trialkemenag.onmicrosoft.com",
            ActiveDirectoryClientAppId = "4e83eeff-9dfb-4361-b119-479357382267",
            // Insert here the application secret when authenticate with AAD by the application
            ActiveDirectoryClientAppSecret = "",

            // Change TLS version of HTTP request from the client here
            // Ex: TLSVersion = "1.2"
            // Leave it empty if want to use the default version
            TLSVersion = "1.1",
        };

        public string TLSVersion { get; set; }
        public string UriString { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ActiveDirectoryResource { get; set; }
        public String ActiveDirectoryTenant { get; set; }
        public String ActiveDirectoryClientAppId { get; set; }
        public string ActiveDirectoryClientAppSecret { get; set; }
    }
}