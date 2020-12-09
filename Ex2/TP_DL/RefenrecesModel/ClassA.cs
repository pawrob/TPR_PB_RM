using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TP_DL.RefenrecesModel
{
    [Serializable]
    public class ClassA : ISerializable
    {
        public decimal DecimalProperty { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public string StringProperty { get; set; }
        public ClassB ClassBProperty { get; set; }

        public ClassA(decimal decimalProperty, DateTime dateTimeProperty, string stringProperty, ClassB classBProperty)
        {
            DecimalProperty = decimalProperty;
            DateTimeProperty = dateTimeProperty;
            StringProperty = stringProperty;
            ClassBProperty = classBProperty;
        }

        public ClassA(SerializationInfo info, StreamingContext context)
        {
            DecimalProperty = info.GetDecimal("DecimalProperty");
            DateTimeProperty = info.GetDateTime("DateTimeProperty");
            StringProperty = info.GetString("StringProperty");
            ClassBProperty = (ClassB)info.GetValue("ClassBProperty", typeof(ClassB));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DecimalProperty", DecimalProperty);
            info.AddValue("DateTimeProperty", DateTimeProperty);
            info.AddValue("StringProperty", StringProperty);
            info.AddValue("ClassBProperty", ClassBProperty, typeof(ClassB));
        }

        public override string ToString()
        {
            return "String property: " + StringProperty + " DateTime property: " + DateTimeProperty + " DecimalProperty: " + DecimalProperty;
        }
    }
}
