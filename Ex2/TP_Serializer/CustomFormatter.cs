using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace TP_Serializer
{
    public class CustomFormatter : Formatter
    {
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }
        public override ISurrogateSelector SurrogateSelector { get; set; }
        public ObjectIDGenerator IdGenerator { get; set; }

        public CustomFormatter()
        {
            Binder = new CustomBinder();
            Context = new StreamingContext(StreamingContextStates.File);
            IdGenerator = new ObjectIDGenerator();
        }

        #region Serialize
        private string SerializedData = "";   //Data to serialize
        private List<string> FormattedSerializedData = new List<string>(); //List of serialized data

        public override void Serialize(Stream serializationStream, object graph)
        {
            if (graph is ISerializable data)
            {
                SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
                Binder.BindToName(graph.GetType(), out string assemblyName, out string typeName); //Bind graph type to assembly
                SerializedData += assemblyName + "|" + typeName + "|" + IdGenerator.GetId(graph, out bool firstTime); //Generating ID for specified object
                data.GetObjectData(info, Context);
                foreach (SerializationEntry item in info)
                {
                    WriteMember(item.Name, item.Value);
                }
                FormattedSerializedData.Add(SerializedData + "\n"); //Divide data by rows
                SerializedData = "";    //Empty the SerializedData String

                while (this.m_objectQueue.Count != 0)
                {
                    this.Serialize(null, this.m_objectQueue.Dequeue());
                }

                SaveToStream(serializationStream);
            }
            else
            {
                throw new ArgumentException("Object graph does not implement interface Iserializable");
            }
        }
        #endregion

        #region Serialize functions
        private void SaveToStream(Stream serializationStream)
        {
            if (serializationStream != null && m_objectQueue.Count == 0)
            {
                using (StreamWriter writer = new StreamWriter(serializationStream))
                {
                    foreach (string line in FormattedSerializedData)
                        writer.Write(line);
                }
            }
        }
        #endregion


        #region Deserialize
        private List<string> DeserializedData = new List<string>();
        private Dictionary<string, object> References = new Dictionary<string, object>();

        public override object Deserialize(Stream serializationStream)
        {
            if (serializationStream != null)
            {
                RecreateReferences(serializationStream);
            }
            foreach (string row in DeserializedData)
            {
                string[] splitRow = row.Split('|');
                Type objectDeserialize = GetBindedType(splitRow);   //Get splitRow type for deserialization

                SerializationInfo info = new SerializationInfo(objectDeserialize, new FormatterConverter());
                for (int i = 3; i < splitRow.Length; i++)
                {
                    string[] data = splitRow[i].Split('=');
                    Type dataRow = Binder.BindToType(splitRow[0], data[0]);
                    if (dataRow == null)
                    {
                        if (!data[0].Equals("null"))
                        {
                            SaveParsedValueToSerializationInfo(info, Type.GetType(data[0]), data[1], data[2]);
                        }
                        else
                        {
                            info.AddValue(data[1], null);
                        }
                    }
                    else
                    {
                        if (!data[2].Equals("-1"))
                        {
                            info.AddValue(data[1], References[data[2]], dataRow);
                        }
                    }
                }
                //Constructing References
                Type[] constructorTypes = { info.GetType(), Context.GetType() };
                object[] constuctorParameters = { info, Context };
                References[splitRow[2]].GetType().GetConstructor(constructorTypes).Invoke(References[splitRow[2]], constuctorParameters);
            }
            return References["1"];
        }
        #endregion

        #region Deserialize functions
        private void CreateReferences()
        {
            foreach (string item in DeserializedData)
            {
                String[] splits = item.Split('|'); //Splits every item in deserialized data
                References.Add(splits[2], FormatterServices.GetSafeUninitializedObject(Binder.BindToType(splits[0], splits[1])));
            }
        }

        private void RecreateReferences(Stream serializationStream)
        {
            using (StreamReader reader = new StreamReader(serializationStream))
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    DeserializedData.Add(line);
                }
            }
            CreateReferences();
        }

        private Type GetBindedType(string[] splitRow)
        {
            return Binder.BindToType(splitRow[0], splitRow[1]);
        }

        private void SaveParsedValueToSerializationInfo(SerializationInfo info, Type type, string name, string val)
        {
            switch (type.ToString())
            {
                case "System.DateTime":
                    info.AddValue(name, DateTime.Parse(val, null, System.Globalization.DateTimeStyles.AssumeLocal));
                    break;
                case "System.String":
                    info.AddValue(name, val);
                    break;
                case "System.Single":
                    info.AddValue(name, Single.Parse(val));
                    break;
                case "System.Int64":
                    info.AddValue(name, Int64.Parse(val));
                    break;
                case "System.Guid":
                    info.AddValue(name, Guid.Parse(val));
                    break;
                case "System.Decimal":
                    info.AddValue(name, Decimal.Parse(val));
                    break;
            }
        }
        #endregion


        #region Write
        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType.Equals(typeof(String)))
            {
                WriteString(obj, name);
            }
            else
            {
                WriteObject(obj, name, memberType);
            }
        }

        protected void WriteString(object obj, string name)
        {
            SerializedData += "|" + obj.GetType() + "=" + name + "=" + "\"" + (String)obj + "\"";
        }

        protected void WriteObject(object obj, string name, Type type)
        {
            if (obj != null)
            {
                SerializedData += "|" + obj.GetType() + "=" + name + "=" + IdGenerator.GetId(obj, out bool firstTime).ToString();
                if (firstTime)
                {
                    this.m_objectQueue.Enqueue(obj);
                }
            }
            else
            {
                SerializedData += "|" + "null" + "=" + name + "=-1";
            }
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            SerializedData += "|" + val.GetType() + "=" + name + "=" + val.ToUniversalTime();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            SerializedData += "|" + val.GetType() + "=" + name + "=" + val.ToString("0.00");
        }

        protected override void WriteInt32(int val, string name)
        {
            SerializedData += "|" + val.GetType() + "=" + name + "=" + val.ToString();
        }

        protected override void WriteInt64(long val, string name)
        {
            SerializedData += "|" + val.GetType() + "=" + name + "=" + val.ToString("000000000");
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            SerializedData += "|" + obj.GetType() + "=" + name + "=" + "\"" + obj.ToString() + "\"";
        }

        protected void WriteGuid(Guid val, string name)
        {
            SerializedData += "|" + val.GetType() + "=" + name + "=" + "\"" + val.ToString() + "\"";
        }
        #endregion
 
        
        #region notimplemented
        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }
        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

