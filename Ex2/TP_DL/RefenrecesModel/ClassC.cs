using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TP_DL.RefenrecesModel
{
    [Serializable]
    public class ClassC : ISerializable
    {
        public DateTime DateTimeProperty { get; set; }
        public decimal DecimalProperty { get; set; }
        public string StringProperty { get; set; }
        public ClassA ClassAProperty { get; set; }

        public ClassC(DateTime dateTimeProperty, decimal decimalProperty, string stringProperty, ClassA classAProperty)
        {
            DateTimeProperty = dateTimeProperty;
            DecimalProperty = decimalProperty;
            StringProperty = stringProperty;
            ClassAProperty = classAProperty;
        }

        public ClassC(SerializationInfo info, StreamingContext context)
        {
            DateTimeProperty = info.GetDateTime("DateTimeProperty");
            DecimalProperty = info.GetDecimal("DecimalProperty");
            StringProperty = info.GetString("StringProperty");
            ClassAProperty = (ClassA)info.GetValue("ClassAProperty", typeof(ClassA));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DateTimeProperty", DateTimeProperty);
            info.AddValue("DecimalProperty", DecimalProperty);
            info.AddValue("StringProperty", StringProperty);
            info.AddValue("ClassAProperty", ClassAProperty, typeof(ClassA));
        }

        public override string ToString()
        {
            return "DateTime property: " + DateTimeProperty + " DecimalProperty: " + DecimalProperty + " String property: " + StringProperty;
        }
    }
}
