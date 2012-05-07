
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace DotNetNuke.Social.Controllers
{
    public static class Serialize
    {

        public enum SerializationMethods { Binary, XML };
        public static bool SerializeToDisk(this object request, SerializationMethods Method, string Filename)
        {
            if (Method == SerializationMethods.XML) return request.SerializeXMLToDisk(Filename);
            return request.SerializeBinaryToDisk(Filename);

        }
        public static bool SerializeBinaryToDisk(this object request, string Filename)
        {
            System.IO.File.WriteAllBytes(Filename, SerializeBinaryAsBytes(request));
            return System.IO.File.Exists(Filename);
        }

        public static MemoryStream SerializeBinary(this object request)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream1 = new MemoryStream();
            binaryFormatter.Serialize(memoryStream1, request);
            return memoryStream1;
        }
        public static byte[] SerializeBinaryAsBytes(this object request)
        {
            using (MemoryStream stm = SerializeBinary(request))
            {
                return stm.ConvertStreamToBytes();
            }
            return null;
        }
        public static object DeSerializeBinary(this MemoryStream memStream)
        {
            memStream.Position = (long)0;
            object local1 = new BinaryFormatter().Deserialize(memStream);
            memStream.Close();
            return local1;
        }

        public static object DeSerializeXML(this MemoryStream memStream, Type type, bool ThrowException)
        {
            object local2;

            if (memStream.Position > (long)0 && memStream.CanSeek)
            {
                memStream.Position = (long)0;
            }
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                local2 = xmlSerializer.Deserialize(memStream);
            }
            catch (Exception exc)
            {
                local2 = null;
                if (ThrowException) throw exc;
            }
            return local2;
        }

        public static object DeSerializeXML(this MemoryStream memStream, Type type)
        {
            object local2;

            if (memStream.Position > (long)0 && memStream.CanSeek)
            {
                memStream.Position = (long)0;
            }
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                local2 = xmlSerializer.Deserialize(memStream);
            }
            catch (Exception)
            {
                local2 = null;
            }
            return local2;
        }

        public static byte[] SerializeXMLAsBytes(this object request)
        {
            using (MemoryStream stm = SerializeXML(request))
            {
                return stm.ConvertStreamToBytes();
            }
            return null;
        }
        public static bool SerializeXMLToDisk(this object request, string Filename)
        {
            if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            System.IO.File.WriteAllText(Filename, SerializeXMLAsString(request));
            return System.IO.File.Exists(Filename);
        }
        public static string SerializeXMLAsString(object request)
        {
            using (MemoryStream stm = SerializeXML(request))
            {
                return stm.ConvertStreamToString();
            }
            return null;
        }

        public static MemoryStream SerializeXML(this object request)
        {
            return SerializeXML(request, request.GetType());
        }

        public static MemoryStream SerializeXML(this object request, Type type, bool ThrowException)
        {
            MemoryStream memoryStream2;

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                MemoryStream memoryStream1 = new MemoryStream();
                xmlSerializer.Serialize(memoryStream1, request);
                memoryStream2 = memoryStream1;
            }
            catch (Exception exc)
            {
                memoryStream2 = null;
                if (ThrowException) throw exc;
            }
            return memoryStream2;
        }
        public static MemoryStream SerializeXML(this object request, Type type)
        {
            MemoryStream memoryStream2;

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                MemoryStream memoryStream1 = new MemoryStream();
                xmlSerializer.Serialize(memoryStream1, request);
                memoryStream2 = memoryStream1;
            }
            catch (Exception exc)
            {
                memoryStream2 = null;
            }
            return memoryStream2;
        }

        public static T DeserializeXMLFromDisk<T>(this string Filename)
        {
            string contents = System.IO.File.ReadAllText(Filename);
            return DeSerializeXML<T>(contents);
        }

        public static T DeSerializeXML<T>(this string envelope,  bool ThrowException)
        {
            T local2;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(envelope));
                T local1 = (T)xmlSerializer.Deserialize(memoryStream);
                memoryStream.Close();
                local2 = local1;
            }
            catch (Exception exc)
            {
                local2 = default(T);
                if (ThrowException) throw exc;
            }
            return local2;
        }

        public static T DeSerializeXML<T>(this string envelope)
        {
            T local2;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(envelope));
            T local1 = (T)xmlSerializer.Deserialize(memoryStream);
            memoryStream.Close();
            local2 = local1;

            return local2;
        }


        public static string ConvertStreamToString(this System.IO.Stream Stream)
        {
            if (Stream != null && Stream.Length > 0)
            {
                if (Stream.Position > 0) Stream.Seek(0, SeekOrigin.Begin);
                byte[] data = new byte[Stream.Length];
                Stream.Read(data, 0, data.Length);
                return System.Text.Encoding.UTF8.GetString(data);
            }
            return null;
        }

        public static string ConvertStreamToString(this System.IO.MemoryStream Stream)
        {
            byte[] d = ConvertStreamToBytes(Stream);
            if (d == null) return "";
            return System.Text.ASCIIEncoding.ASCII.GetString(d);
        }
        public static byte[] ConvertStreamToBytes(this System.IO.MemoryStream Stream)
        {
            if (Stream == null) return null;
            if (Stream != null && Stream.CanSeek && Stream.Position > 0) Stream.Position = 0;
            byte[] d = new byte[(int)Stream.Length];
            Stream.Read(d, 0, d.Length);
            Stream.Close();
            return d;
        }
        public static System.IO.MemoryStream ConvertStringToStream(this string Data)
        {
            return ConvertBytesToStream(System.Text.ASCIIEncoding.ASCII.GetBytes(Data));
        }
        public static System.IO.MemoryStream ConvertBytesToStream(this byte[] Data)
        {
            return new System.IO.MemoryStream(Data);
        }

        public static T FromJson<T>(string JSON) where T : class
        {
            if (string.IsNullOrEmpty(JSON)) return default(T);

            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(T));
            using (System.IO.MemoryStream stm = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(JSON)))
            {
                if (stm.CanSeek && stm.Position > 0) stm.Seek(0, SeekOrigin.Begin);
                return (s.ReadObject(stm) as T);
            }
        }
        public static string ToJson(object O)
        {
            if (O == null) return null;

            DataContractJsonSerializer s = new DataContractJsonSerializer(O.GetType());
            using (System.IO.MemoryStream stm = new MemoryStream())
            {
                s.WriteObject(stm, O);
                return Encoding.UTF8.GetString(stm.ToArray());
            }            

        }

    }

}
