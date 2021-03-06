﻿// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See full license at the bottom of this file.

using ChainStoreWeb.Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ChainStoreWeb.Pages
{
    public partial class EmployeeAdder : System.Web.UI.Page
    {
        private SharePointContext spContext;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void AddLocalEmployeeToCorpDB(string employeeName)
        {
            using (SqlConnection conn = SQLAzureUtilities.GetActiveSqlConnection())
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "AddEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter tenant = cmd.Parameters.Add("@Tenant", SqlDbType.NVarChar);
                tenant.Value = spContext.SPHostUrl.ToString();
                SqlParameter name = cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
                name.Value = employeeName;
                cmd.ExecuteNonQuery();
            }
        }
    }
}

/*

OfficeDev/SharePoint_Provider-hosted_Add-ins_Tutorials, https://github.com/OfficeDev/SharePoint_Provider-hosted_Add-ins_Tutorials
 
Copyright (c) Microsoft Corporation
All rights reserved. 
 
MIT License:
Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:
 
The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.
 
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.    
  
*/