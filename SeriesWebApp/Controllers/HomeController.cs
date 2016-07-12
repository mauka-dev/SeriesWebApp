using SeriesWebApp.BusinessLayer;
using System;
using System.Web.Http;

namespace SeriesWebApp.Controllers
{
    public class HomeController : ApiController
    {
        [Route("api/home/{maxSeriesTerm}")]
        public IHttpActionResult Get(int maxSeriesTerm)
        {
            try
            {
                if (maxSeriesTerm <= 0)
                {
                    return BadRequest("Incorrect parameters passed.");
                }

                ComplexSeries objComplexSeries = new ComplexSeries();
                return Ok(objComplexSeries.GenerateSeries(maxSeriesTerm));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/home/findElement/{maxSeriesTerm}/{divisor}/{nIndex}")]
        public IHttpActionResult FindElement(int maxSeriesTerm, int divisor, int nIndex)
        {
            try
            {
                if (maxSeriesTerm <= 0 || divisor <= 0 || nIndex <= 0)
                {
                    return BadRequest("Incorrect parameters passed.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ComplexSeries objComplexSeries = new ComplexSeries();
                int resultElement = objComplexSeries.FindSeriesElement(maxSeriesTerm, divisor, nIndex);

                return Ok(new int[] { resultElement });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
