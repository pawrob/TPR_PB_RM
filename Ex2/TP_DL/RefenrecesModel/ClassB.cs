using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TP_DL.RefenrecesModel
{
    [Serializable]
    public class ClassB : ISerializable
    {
        public decimal DecimalProperty { get; set; }
        public DateTime DateTimeProperty { get; set; }
        public string StringProperty { get; set; }
        public ClassC ClassCProperty { get; set; }

        public ClassB(decimal decimalProperty, DateTime dateTimeProperty, string stringProperty, ClassC classCProperty)
        {
            DecimalProperty = decimalProperty;
            DateTimeProperty = dateTimeProperty;
            StringProperty = stringProperty;
            ClassCProperty = classCProperty;
        }

        public ClassB(SerializationInfo info, StreamingContext context)
        {
            DecimalProperty = info.GetDecimal("DecimalProperty");
            DateTimeProperty = info.GetDateTime("DateTimeProperty");
            StringProperty = info.GetString("StringProperty");
            ClassCProperty = (ClassC)info.GetValue("ClassCProperty", typeof(ClassC));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DecimalProperty", DecimalProperty);
            info.AddValue("DateTimeProperty", DateTimeProperty);
            info.AddValue("StringProperty", StringProperty);
            info.AddValue("ClassCProperty", ClassCProperty, typeof(ClassC));
        }
        public override string ToString()
        {
            return "String property: " + StringProperty + " DateTime property: " + DateTimeProperty + " DecimalProperty: " + DecimalProperty;
        }
    }
}
