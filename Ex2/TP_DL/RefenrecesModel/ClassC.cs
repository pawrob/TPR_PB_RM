using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TP_DL.RefenrecesModel
{
    [Serializable]
    public class ClassC : ISerializable
    {
        public decimal DecimalProperty { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public string StringProperty { get; set; }
        public ClassA ClassAProperty { get; set; }

        public ClassC(decimal decimalProperty, DateTime dateTimeProperty, string stringProperty, ClassA classAProperty)
        {
            DecimalProperty = decimalProperty;
            DateTimeProperty = dateTimeProperty;
            StringProperty = stringProperty;
            ClassAProperty = classAProperty;
        }

        public ClassC(SerializationInfo info, StreamingContext context)
        {
            DecimalProperty = info.GetDecimal("DecimalProperty");
            DateTimeProperty = info.GetDateTime("DateTimeProperty");
            StringProperty = info.GetString("StringProperty");
            ClassAProperty = (ClassA)info.GetValue("ClassAProperty", typeof(ClassA));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DecimalProperty", DecimalProperty);
            info.AddValue("DateTimeProperty", DateTimeProperty);
            info.AddValue("StringProperty", StringProperty);
            info.AddValue("ClassAProperty", ClassAProperty, typeof(ClassA));
        }
        public override string ToString()
        {
            return "String property: " + StringProperty + " DateTime property: " + DateTimeProperty + " DecimalProperty: " + DecimalProperty;
        }
    }
}
