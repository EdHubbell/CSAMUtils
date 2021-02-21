using System;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using NLog;

namespace CSAM_Manual
{
    public class XMLBaseObject
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        protected static XmlWriterSettings GetXmlWriterSettings()
        {
            var oXMLWriterSettings = new XmlWriterSettings();
            var _with1 = oXMLWriterSettings;
            _with1.Indent = true;
            _with1.OmitXmlDeclaration = true;
            _with1.Encoding = System.Text.Encoding.UTF8;
            return oXMLWriterSettings;
        }

        protected static XmlSerializerNamespaces GetBlankXmlNamespaces()
        {
            var blankXmlNamespaces = new XmlSerializerNamespaces();
            blankXmlNamespaces.Add(string.Empty, string.Empty);
            return blankXmlNamespaces;
        }

        public string AsXMLString()
        {
            var xmlSerializer = new XmlSerializer(GetType());
            using (var stream = new StringWriter())
            {
                using (var writer = XmlWriter.Create(stream, GetXmlWriterSettings()))
                {
                    xmlSerializer.Serialize(writer, this, GetBlankXmlNamespaces());
                    return stream.ToString();
                }
            }
        }

        public virtual void Save(string fullFilePath)
        {
            Save("", fullFilePath);
        }

        public virtual void Save(string filePath, string fileName)
        {
            try
            {
                logger.Debug("entering {0}.{1}", MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name);
                // Directory.CreateDirectory(filePath)
                var writer = new XmlSerializer(GetType());
                var file = new StreamWriter(filePath + fileName);
                using (var oXmlWriter = XmlWriter.Create(file, GetXmlWriterSettings()))
                {
                    writer.Serialize(oXmlWriter, this, GetBlankXmlNamespaces());
                }

                file.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            finally
            {
                logger.Debug("exiting  {0}.{1}", MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name);
            }
        }

        public StringCollection GetSchemaValidationErrors(string schemaFileFullPath)
        {
            var schemas = new XmlSchemaSet();
            var collMessages = new StringCollection();
            try
            {
                var xdoc = new XmlDocument();
                xdoc.LoadXml(AsXMLString());
                schemas.Add("", schemaFileFullPath);
                xdoc.Schemas.Add(schemas);

                // Use a lambda sub here so that the collMessages is in scope as validation errors come in.  
                xdoc.Validate((sender, e) =>
                {
                    if (e.Severity == XmlSeverityType.Warning)
                    {
                        logger.Debug("WARNING: XML Validation {0}.{1} {2}", MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, e.Message);
                    }

                    if (e.Severity == XmlSeverityType.Error)
                    {
                        logger.Debug("ERROR: XML Validation {0}.{1} {2}", MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name, e.Message);
                        // xValidationErrors = True
                        // add error message to collection
                        collMessages.Add("XML: " + e.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                collMessages.Add(ex.Message);
            }

            return collMessages;
        }


        /// <summary>
        /// Generic load and deserialize of a specified type.
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="fileFullPath">full path to the XML file to deserialize. e.g. - C:\XferPrint\XferPrintConfig.xml</param>
        /// <returns></returns>
        public static t Load<t>(string fileFullPath)
        {
            t oDeserializedObject = default;
            try
            {
                var serializer = new XmlSerializer(typeof(t));
                var reader = new StreamReader(fileFullPath);
                oDeserializedObject = (t)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                return default;
            }

            return oDeserializedObject;
        }


        /// <summary>
        /// Makes a deep copy of this serializable object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object2Copy"></param>
        public static T GetDeepCopy<T>(ref T object2Copy)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, object2Copy);
                stream.Position = 0L;
                T objectCopy = (T)serializer.Deserialize(stream);
                return objectCopy;
            }
        }
    }
}