using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyClaimsService.Models
{
    /// <summary>
    /// Class XMLFilesInfo.
    /// </summary>
    public class XMLFilesInfo
    {
        /// <summary>
        /// Gets or sets the name of the claims file.
        /// </summary>
        /// <value>The name of the claims file.</value>
        public string ClaimsFileName { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }
    }
}