using CompanyClaimsService.Repository;
using System;
using System.Web.Http;

namespace CompanyClaimsService.Controllers
{
    [RoutePrefix("api/claims")]
    public class ClaimsApiController : ApiController
    {
        ClaimsRepository claimsRepository;

        /// <summary>
        /// Gets the XML file list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        // GET api/<controller>
        public IHttpActionResult GetXmlFiles()
        {
            try
            {
                claimsRepository = new ClaimsRepository();
                var fileNames = claimsRepository.GetFiles();

                if (fileNames == null || fileNames.Count == 0)
                    return NotFound();

                return Ok(fileNames);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Gets the data for specific Claims file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Json claims data from the XML</returns>
        [HttpGet]
        [Route("{fileName}")]
        // GET api/<controller>/5
        public IHttpActionResult Get(string fileName)
        {
            try
            {

                claimsRepository = new ClaimsRepository();

                if (string.IsNullOrEmpty(fileName))
                    return BadRequest();

                var xmlData = claimsRepository.GetXmlData(fileName);

                if (string.IsNullOrEmpty(xmlData))
                    return NotFound();

                return Ok(xmlData);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}