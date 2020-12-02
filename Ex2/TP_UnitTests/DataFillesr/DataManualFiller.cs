using System;
using TP_DL;
using TP_DL.Objects;


namespace TP_UnitTests
{
    public class DataManualFiller : IDataFiller
    {

        public DataManualFiller(){}

        public void InsertData(DataContext dataContext)
        {
            dataContext.Clients.Add(new Client("John", "Doe", 000000000, new Guid()));
        }
    }
}
