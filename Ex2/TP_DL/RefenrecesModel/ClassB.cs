using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TP_DL.RefenrecesModel
{
    [Serializable]
    public class ClassB : ISerializable
    {
        public DateTime DateTimeProperty { get; set; }
        public decimal DecimalProperty { get; set; }
        public string StringProperty { get; set; }
        public ClassC ClassCProperty { get; set; }

        public ClassB(DateTime dateTimeProperty, decimal decimalProperty, string stringProperty, ClassC classCProperty)
        {
            DateTimeProperty = dateTimeProperty;
            DecimalProperty = decimalProperty;
            StringProperty = stringProperty;
            ClassCProperty = classCProperty;
        }

        public ClassB(SerializationInfo info, StreamingContext context)
        {
            DateTimeProperty = info.GetDateTime("DateTimeProperty");
            DecimalProperty = info.GetDecimal("DecimalProperty");
            StringProperty = info.GetString("StringProperty");
            ClassCProperty = (ClassC)info.GetValue("ClassCProperty", typeof(ClassC));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DateTimeProperty", DateTimeProperty);
            info.AddValue("DecimalProperty", DecimalProperty);
            info.AddValue("StringProperty", StringProperty);
            info.AddValue("ClassCProperty", ClassCProperty, typeof(ClassC));
        }

        public override string ToString()
        {
            return "DateTime property: " + DateTimeProperty + " DecimalProperty: " + DecimalProperty + " String property: " + StringProperty;
        }
    }
}
