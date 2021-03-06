﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Vlix;

namespace VlixOPC
{
    class Program
    {
        static void Main(string[] args)
        {
            Global.Product = new ProductDetails("VlixOPC", typeof(OPCBackEndConfig), "Vlix\\VlixOPC");
            bool SendResult = (new EmbeddedResourceFileSender()).SendFiles("VlixOPC", "SendToProgramDataDirectory", Global.Product.ProgramDataDirectory, "*", false, Assembly.GetExecutingAssembly());
            if (!SendResult) throw new CustomException("FATAL ERROR: Unable to access Directory '" + Global.Product.ProgramDataDirectory);            
            OPCBackEnd oPCBackEnd = new OPCBackEnd();
            Console.ReadKey();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
