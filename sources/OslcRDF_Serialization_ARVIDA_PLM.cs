using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Json;

using OSLC4Net.Core.Model;
using OSLC4Net.Core.DotNetRdfProvider;

using VDS.RDF;

using log4net;

namespace OSLC_ARVIDA
{
    public class RDFSerialize
    {
        private MediaTypeHeaderValue theHeaderValue(string mediaType)
        {
            MediaTypeHeaderValue thisMediaType = null;
            if (mediaType == OSLC4Net.Core.Model.OslcMediaType.APPLICATION_JSON)
                thisMediaType = OslcMediaType.APPLICATION_JSON_TYPE;
            else if (mediaType == OSLC4Net.Core.Model.OslcMediaType.APPLICATION_RDF_XML)
                thisMediaType = OslcMediaType.APPLICATION_RDF_XML_TYPE;
            return thisMediaType;
        }

        private System.Net.Http.Formatting.MediaTypeFormatter theFormatter<T>(T value, string mediaType)
        {
            System.Net.Http.Formatting.MediaTypeFormatter formatter = null;
            if (mediaType == OSLC4Net.Core.Model.OslcMediaType.APPLICATION_JSON)
            {
                formatter = new OSLC4Net.Core.JsonProvider.JsonMediaTypeFormatter();
            }
            else if (mediaType == OSLC4Net.Core.Model.OslcMediaType.APPLICATION_RDF_XML)
            {
                ISet<System.Net.Http.Formatting.MediaTypeFormatter> formatters = 
                    new HashSet<System.Net.Http.Formatting.MediaTypeFormatter>();
                formatters.Add(new RdfXmlMediaTypeFormatter());
                formatter = new System.Net.Http.Formatting.MediaTypeFormatterCollection(formatters).FindWriter(value.GetType(),
                    new System.Net.Http.Headers.MediaTypeHeaderValue(mediaType));
            }
            return formatter;
        }

        public Stream getRDF<T>(T value, string mediaType) where T :class 
        {
            System.Net.Http.Formatting.MediaTypeFormatter formatter = theFormatter(value, mediaType);
            MediaTypeHeaderValue thisMediaType = theHeaderValue(mediaType);          
            return Serialize(formatter, value, thisMediaType);
        }

        public string getRDFStr<T>(T value, string mediaType) where T :class 
        {
            System.Net.Http.Formatting.MediaTypeFormatter formatter = theFormatter(value, mediaType);
            MediaTypeHeaderValue thisMediaType = theHeaderValue(mediaType);          
            Stream tmpStream = Serialize(formatter, value, thisMediaType);
            return (Encoding.UTF8.GetString((tmpStream as MemoryStream).ToArray()));
        }

        public T getObjFromRDF<T>(T value, string mediaType, string rdfStr) where T : class
        { 
            System.Net.Http.Formatting.MediaTypeFormatter formatter = theFormatter(value, mediaType);
            MediaTypeHeaderValue thisMediaType = theHeaderValue(mediaType);
            return Deserialize(formatter, value, rdfStr, thisMediaType);
        }

        public void coutRDF(Stream thisStream)
        {
            Console.Write(Encoding.UTF8.GetString((thisStream as MemoryStream).ToArray()));
        }

        public string strRDF(Stream thisStream)
        {
            return (Encoding.UTF8.GetString((thisStream as MemoryStream).ToArray()));
        }

        private Stream Serialize<T>(System.Net.Http.Formatting.MediaTypeFormatter formatter, 
                                    T value, System.Net.Http.Headers.MediaTypeHeaderValue mediaType)
        {
            Stream stream = new MemoryStream();
            try
            {
                HttpContent content = new StreamContent(stream);
                content.Headers.ContentType = mediaType;
                formatter.WriteToStreamAsync(typeof(T), value, stream, content, null).Wait();
                stream.Position = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Serialization error: " + ex.ToString());
            }
            return stream;
        }

        public string SerializeCollection<T>(
            IEnumerable<T> value, 
            string contentType,
            string descriptionAbout = null,
            string responseInfoAbout = null,
            string nextPageAbout = null) where T : class
        {

            if (String.IsNullOrEmpty(descriptionAbout))
                descriptionAbout = "http://com/undefined/descriptionAbout";

            if (String.IsNullOrEmpty(responseInfoAbout))
                responseInfoAbout = "http://com/undefined/responseInfoAbout";

            if (String.IsNullOrEmpty(responseInfoAbout))
                responseInfoAbout = "http://com/undefined/nextPageAbout";
            
            System.Net.Http.Formatting.MediaTypeFormatter formatter = null;
            Stream stream = new MemoryStream();
            HttpContent content = new StreamContent(stream);

            if (contentType == OslcMediaType.APPLICATION_JSON)
            {
                JsonValue json = OSLC4Net.Core.JsonProvider.JsonHelper.CreateJson(
                                                           descriptionAbout,
                                                           responseInfoAbout,
                                                           nextPageAbout,
                                                           null,
                                                           value,
                                                           null);

                formatter = new OSLC4Net.Core.JsonProvider.JsonMediaTypeFormatter(json, false);
                content.Headers.ContentType = OslcMediaType.APPLICATION_JSON_TYPE;
            }
            else if (contentType == OslcMediaType.APPLICATION_RDF_XML)
            {
                IGraph rdfGraph = DotNetRdfHelper.CreateDotNetRdfGraph(
                                                           descriptionAbout,
                                                           responseInfoAbout,
                                                           nextPageAbout,
                                                           null,
                                                           value,
                                                           null);

                formatter = new RdfXmlMediaTypeFormatter(rdfGraph);
                content.Headers.ContentType = OslcMediaType.APPLICATION_RDF_XML_TYPE;
            }

            if (formatter == null)
            {
                return "";
            }

            formatter.WriteToStreamAsync(typeof(T), value, stream, content, null).Wait();
            stream.Position = 0;
            return content.ReadAsStringAsync().Result;
        }

        private T Deserialize<T>(System.Net.Http.Formatting.MediaTypeFormatter formatter,
                                 T value, string str, MediaTypeHeaderValue mediaType) where T : class
        {
            Stream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            HttpContent content = new StreamContent(stream);
            content.Headers.ContentType = mediaType;
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return formatter.ReadFromStreamAsync(typeof(T), stream, content, logFormatter).Result as T;
        }

        public IEnumerable<T> DeserializeCollection<T>(
            string strRDF,
            IEnumerable<T> value,
            string contentType,
            string descriptionAbout = null,
            string responseInfoAbout = null,
            string nextPageAbout = null) where T : class
        {

            if (String.IsNullOrEmpty(descriptionAbout))
                descriptionAbout = "http://com/undefined/descriptionAbout";

            if (String.IsNullOrEmpty(responseInfoAbout))
                responseInfoAbout = "http://com/undefined/responseInfoAbout";

            if (String.IsNullOrEmpty(responseInfoAbout))
                responseInfoAbout = "http://com/undefined/nextPageAbout";

            Stream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            HttpContent content = new StreamContent(stream);
            System.Net.Http.Formatting.MediaTypeFormatter formatter = null;

            if (contentType == OslcMediaType.APPLICATION_JSON)
            {
                JsonValue json = OSLC4Net.Core.JsonProvider.JsonHelper.CreateJson(
                                                           descriptionAbout,
                                                           responseInfoAbout,
                                                           nextPageAbout,
                                                           null,
                                                           value,
                                                           null);

                formatter = new OSLC4Net.Core.JsonProvider.JsonMediaTypeFormatter(json, false);
                content.Headers.ContentType = OslcMediaType.APPLICATION_JSON_TYPE;
            }
            else if (contentType == OslcMediaType.APPLICATION_RDF_XML)
            {
                IGraph rdfGraph = DotNetRdfHelper.CreateDotNetRdfGraph(
                                                           descriptionAbout,
                                                           responseInfoAbout,
                                                           nextPageAbout,
                                                           null,
                                                           value,
                                                           null);

                formatter = new RdfXmlMediaTypeFormatter(rdfGraph);
                content.Headers.ContentType = OslcMediaType.APPLICATION_RDF_XML_TYPE;
            }

            if (formatter == null)
                return null;

            writer.Write(strRDF);
            writer.Flush();

            stream.Position = 0;

            return formatter.ReadFromStreamAsync(typeof(List<T>), stream, content, null).Result as IEnumerable<T>;
        }

        private class LogFormatter : System.Net.Http.Formatting.IFormatterLogger
        {
            public LogFormatter(ILog logger)
            {
                this.logger = logger;
            }

            public void LogError(string errorPath, Exception exception)
            {
                logger.Error(errorPath, exception);
            }

            public void LogError(string errorPath, string errorMessage)
            {
                logger.Error(errorPath + ": " + errorMessage);
            }

            private ILog logger;
        }

        private LogFormatter logFormatter = new LogFormatter(LogManager.GetLogger(typeof(RDFSerialize)));
    }
}