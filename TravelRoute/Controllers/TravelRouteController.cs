using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelRouteService.Interfaces;
using TravelRoutePersistence.Model;

namespace TravelRoute.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TravelRouteController : ControllerBase
    {
        private readonly ITravelRouteService _travelRouteService;
        public TravelRouteController(ITravelRouteService travelRouteService)
        {
            _travelRouteService =  travelRouteService;
        }

        [HttpGet("TravelRoutes")]
        public IActionResult TravelRoutes()
        {
            try
            {
                var result = _travelRouteService.GetTravelRoutes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }
        [HttpGet("CheapestRoute")]
        public IActionResult CheapestRoute(string origin, string destination)
        {
            try
            {
               bool existingNodes = _travelRouteService.VerifyIfAirportNodesExistInRoutes(origin, destination);
                if (!existingNodes)
                {
                    return BadRequest("Origem ou Destino não estão cadastrados");
                }

                var result = _travelRouteService.GetCheapestRoute(origin, destination);

                var resultString = string.Empty;
                for (int i = 0; i < result.Routes.Count; i++)
                {
                    var currentRoute = result.Routes[i];
                    if(i == 0)
                        resultString += currentRoute.Origin + " - " + currentRoute.Destination;
                    else
                        resultString +=  " - " + currentRoute.Destination;
                }
                resultString += " ao custo de $" + result.TotalAmount;
                return Ok(resultString);
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }

        [HttpPost("AddTravelRoute")]
        public IActionResult TravelRoute(Route route)
        {
            try
            {
                Route existingRoute = _travelRouteService.GetTravelRouteByRoute(route);
                
                if(existingRoute!= null)
                {
                    return BadRequest("Essa rota já existe!");
                }
                bool result = _travelRouteService.AddTravelRoute(route);
                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch( Exception ex)
            {
                return Problem(ex.ToString());
            }
        }

        [HttpPost("TravelRouteUpdate")]
        public IActionResult TravelRouteUpdate(Route route)
        {
            try
            {
                bool result = _travelRouteService.UpdateTravelRoute(route);
                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }
        [HttpDelete("DeleteTravelRoute")]
        public IActionResult DeleteTravelRoute(int routeId)
        {
            try
            {
                bool result = _travelRouteService.DeleteTravelRoute(routeId);
                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }
    }
}
