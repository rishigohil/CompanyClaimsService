using CompanyClaimsService.Models;
using CompanyClaimsService.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CompanyClaimsService.Repository
{
    public class ClaimsRepository
    {
        /// <summary>
        /// Gets the files names.
        /// </summary>
        /// <returns></returns>
        public List<XMLFilesInfo> GetFiles()
        {
            var path = CoreHelper.GetFullPath("~/ClaimFiles/");
            string[] XMLfiles = Directory.GetFiles(path, "*.XML");
            var xmlFilesInfo = new List<XMLFilesInfo>();

            foreach (string file in XMLfiles)
            {
                var fileName = Path.GetFileName(file);
                string[] names = fileName.Split('-');
                if (names.Length > 1)
                {
                    xmlFilesInfo.Add(new XMLFilesInfo
                    {
                        //May change later.
                        ClaimsFileName = fileName.Split('.')[0],
                        FileName = fileName.Split('.')[0]
                    });
                }

            }

            return xmlFilesInfo;
        }

        /// <summary>
        /// Gets the XML data.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>XML Data Parsed in Json Format</returns>
        public string GetXmlData(string fileName)
        {
            string path = CoreHelper.GetFullPath("~/ClaimFiles/") + fileName + ".xml";
            var processedXml = string.Empty;
            if (File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                
                processedXml = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, true);
            }

            return processedXml;
        }
    }
}