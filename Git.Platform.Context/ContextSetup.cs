using Git.Platform.Context.Enums;
using Git.Platform.Context.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Git.Platform.Context
{
    public class ContextSetup
    {
        #region Constants

        #region XML
        private const string XML_ROOT = "Context";
        private const string XML_GLOBAL_LIST = "GlobalList";
        private const string XML_GLOBAL = "Global";
        private const string XML_INJECTION_CLASS_LIST = "InjectionClassList";
        private const string XML_INJECTION_CLASS = "InjectionClass";
        #endregion

        #region Class Properties
        private const string PROPERTY_CLASS_NAME = "ClassName";
        private const string PROPERTY_KEY = "Key";
        private const string PROPERTY_VALUE = "Value";
        private const string PROPERTY_NAMESPACE = "Namespace";
        private const string PROPERTY_PATH = "Path";
        #endregion

        #region Defaults
        private const string DEFAULT_PATH_CONTEXT = "ContextConfig.xml";
        #endregion

        #endregion

        #region Properties
        public string PathContext { get; set; }
        public ContextModel Context { get; set; }
        public ENUMContextFileType ContextFileType { get; set; }
        #endregion

        #region Constructor
        public ContextSetup(string path = DEFAULT_PATH_CONTEXT)
        {
            try
            {
                this.PathContext = path;
                this.ContextFileType = this.FileIdentifier();

                switch (this.ContextFileType)
                {
                    case ENUMContextFileType.XML:
                        this.ReadContextXML();
                        break;
                    case ENUMContextFileType.Json:
                        this.ReadContextJson();
                        break;
                    default:
                        throw new Exception(string.Format("Context File [{0}] is not configurated or is not allowed.", this.PathContext));
                }

                this.ReplaceContext();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }
        #endregion

        #region Private
        private ENUMContextFileType FileIdentifier()
        {
            ENUMContextFileType eContextFileType = ENUMContextFileType.None;
            string extension = string.Empty;

            try
            {
                extension = System.IO.Path.GetExtension(PathContext);
                switch (extension)
                {
                    case ".xml":
                        eContextFileType = ENUMContextFileType.XML;
                        break;
                    case ".json":
                        eContextFileType = ENUMContextFileType.Json;
                        break;
                    default:
                        break;
                }
                return eContextFileType;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }
        }

        private void ReadContextXML()
        {
            XDocument oXDocument = null;

            try
            {
                oXDocument = XDocument.Load(this.PathContext);

                this.Context = new ContextModel()
                {
                    GlobalList = oXDocument.Element(XML_ROOT).Element(XML_GLOBAL_LIST).Elements(XML_GLOBAL)
                    .Select(o => new GlobalModel
                    {
                        Key = o.Attribute(PROPERTY_KEY).Value,
                        Value = o.Attribute(PROPERTY_VALUE).Value
                    }).ToList(),
                    InjectionClassList = oXDocument.Element(XML_ROOT).Element(XML_INJECTION_CLASS_LIST).Elements(XML_INJECTION_CLASS)
                    .Select(o => new InjectionClassModel
                    {
                        Namespace = o.Attribute(PROPERTY_NAMESPACE).Value,
                        ClassName = o.Attribute(PROPERTY_CLASS_NAME).Value,
                        Path = o.Attribute(PROPERTY_PATH).Value,
                        Instance = null
                    }).ToList()
                };

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (oXDocument != null)
                {
                    oXDocument = null;
                }
            }
        }

        private void ReadContextJson()
        {
            StreamReader oStreamReader = null;
            string json = string.Empty;

            try
            {
                oStreamReader = new StreamReader(this.PathContext);
                json = oStreamReader.ReadToEnd();

                this.Context = JsonConvert.DeserializeObject<ContextModel>(json);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (oStreamReader != null)
                {
                    oStreamReader.Close();
                    oStreamReader.Dispose();
                }
            }
        }

        private void ReplaceContext()
        {
            Utils.ReplaceInstance<InjectionClassModel>(this.Context.GlobalList, this.Context.InjectionClassList);

            foreach (InjectionClassModel oInjectionClassModel in this.Context.InjectionClassList)
            {
                Assembly oAssembly = Assembly.LoadFrom(oInjectionClassModel.Path);
                string sName = string.Format("{0}.{1}", oInjectionClassModel.Namespace, oInjectionClassModel.ClassName);
                Type oType = oAssembly.GetType(sName);
                oInjectionClassModel.Instance = Activator.CreateInstance(oType);
            }
        }
        #endregion
    }
}
