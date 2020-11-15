using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TP_DL;
using TP_DL.Objects;


namespace TP_UnitTests
{
    public class DataFiller : IDataFiller
    {

        public DataFiller(){}

        public void InsertData(DataContext dataContext)
        {
            dataContext.Clients.Add(new Client("John", "Doe", 000000000, new Guid()));
        }
    }
}
