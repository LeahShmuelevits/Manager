﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "data source = srv2\\pupils; initial catalog = ManagerDB; Integrated Security = SSPI; Persist Security Info = False; TrustServerCertificate = true";
        
                DataAccess da = new DataAccess();
         //   da.insertDataCategory(connectionString);
            
         //   da.insertDataProduct(connectionString);

           // da.readDataCategory(connectionString);
            da.readDataProduct(connectionString);
        }
        }
    }
