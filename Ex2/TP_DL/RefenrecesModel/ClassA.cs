using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TP_DL.RefenrecesModel
{
    [Serializable]
    public class ClassA : ISerializable
    {
        public DateTime DateTimeProperty { get; set; }
        public decimal DecimalProperty { get; set; }
        public string StringProperty { get; set; }
        public ClassB ClassBProperty { get; set; }

        public ClassA(DateTime dateTimeProperty, decimal decimalProperty, string stringProperty, ClassB classBProperty)
        {
            DateTimeProperty = dateTimeProperty;
            DecimalProperty = decimalProperty;
            StringProperty = stringProperty;
            ClassBProperty = classBProperty;
        }

        public ClassA(SerializationInfo info, StreamingContext context)
        {
            DateTimeProperty = info.GetDateTime("DateTimeProperty");
            DecimalProperty = info.GetDecimal("DecimalProperty");
            StringProperty = info.GetString("StringProperty");
            ClassBProperty = (ClassB)info.GetValue("ClassBProperty", typeof(ClassB));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DateTimeProperty", DateTimeProperty);
            info.AddValue("DecimalProperty", DecimalProperty);
            info.AddValue("StringProperty", StringProperty);
            info.AddValue("ClassBProperty", ClassBProperty, typeof(ClassB));
        }

        public override string ToString()
        {
            return "DateTime property: " + DateTimeProperty + " DecimalProperty: " + DecimalProperty + " String property: " + StringProperty;
        }
    }
}
