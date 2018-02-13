using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventories.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Inventories.Data.Models.Api;
using Microsoft.EntityFrameworkCore;
using Inventories.Infrastructure.Interfaces;

namespace Inventories.Controllers
{
    [Route("")]
    public class ValuesController : Controller
    {
        private readonly IApiConfiguration _errorsConfiguration;
        private readonly IUnitOfWork _unitOfWork;

        public ValuesController(IApiConfiguration errorsConfiguration, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _errorsConfiguration = errorsConfiguration;
        }
    
        [HttpPost("inventories")]
        public async Task<IActionResult> Inventories([FromBody]List<Inventory> inventories)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    foreach (var item in inventories)
                    {
                        var cinema = await _unitOfWork
                            .CinemaRepository.GetAll()
                            .FirstOrDefaultAsync(x => x.VistaId == item.CinemaVistaId);

                        if(cinema is null)
                        {
                            var error = Api.Errors.Errors.Get(
                                "sync_inventories",
                                "CinemaNotFound",
                                _errorsConfiguration.ApplicationName,
                                _errorsConfiguration.Version, null);
                            return Content(error.HttpStatusCode.ToString(), error.Response.ToString());
                        }

                        var consessionCinema = await _unitOfWork
                            .ConsessionCinemaRepository
                            .GetAll().Include(x => x.Cinema)
                            .Include(x => x.Status)
                            .FirstOrDefaultAsync(x => x.CinemaId == cinema.Id && x.Hopk == item.Hopk);

                        if (consessionCinema is null)
                        {
                            var error = Api.Errors.Errors.Get(
                                "sync_inventories",
                                "HopkNotFound",
                                _errorsConfiguration.ApplicationName,
                                _errorsConfiguration.Version, null);
                            return Content(error.HttpStatusCode.ToString(), error.Response.ToString());
                        }

                        var status = await _unitOfWork
                            .StatusRepository.GetAll()
                            .FirstOrDefaultAsync(x => x.Code == (item.IsAvailable ? "Active" : "Inactive"));

                        consessionCinema.Stock = item.StokQuantity;
                        consessionCinema.Status = status;

                        var t = await _unitOfWork
                            .ConsessionCinemaRepository
                            .UpdateAsync(consessionCinema, consessionCinema.Id);
                    }

                    var errors = _errorsConfiguration;
                    return Ok();
                }
                else
                {
                    var error = Api.Errors.Errors.Get(
                        "sync_inventories",
                        "InvalidModel",
                        _errorsConfiguration.ApplicationName,
                        _errorsConfiguration.Version, null);
                    return Content(error.HttpStatusCode.ToString(), error.Response.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        [HttpPost("prices")]
        public async Task<IActionResult> Prices([FromBody]List<Price> Prices)
        {
            try
            {
                foreach (var item in Prices)
                {
                    var cinema = await _unitOfWork
                        .CinemaRepository.GetAll()
                        .FirstOrDefaultAsync(x => x.VistaId == item.CinemaVistaId);

                    if (cinema is null)
                    {
                        var error = Api.Errors.Errors.Get(
                            "sync_inventories",
                            "CinemaNotFound",
                            _errorsConfiguration.ApplicationName,
                            _errorsConfiguration.Version, null);
                        return Content(error.HttpStatusCode.ToString(), error.Response.ToString());
                    }

                    var consessionCinema = await _unitOfWork
                        .ConsessionCinemaRepository
                        .GetAll().Include(x => x.Cinema)
                        .Include(x => x.Status)
                        .FirstOrDefaultAsync(x => x.CinemaId == cinema.Id && x.Hopk == item.Hopk);

                    if (consessionCinema is null)
                    {
                        var error = Api.Errors.Errors.Get(
                            "sync_inventories",
                            "HopkNotFound",
                            _errorsConfiguration.ApplicationName,
                            _errorsConfiguration.Version, null);
                        return Content(error.HttpStatusCode.ToString(), error.Response.ToString());
                    }

                    var promotionPrice = await _unitOfWork
                        .PromotionPriceRepostory.GetAll()
                        .FirstOrDefaultAsync(x => x.ConsesionCinemaId == consessionCinema.Id);
                    if(promotionPrice is null)
                    {
                        await _unitOfWork.PromotionPriceRepostory
                                         .AddAsync(new Data.EntityFramework.Models.PromotionPrice
                                         {
                                             ConsesionCinemaId = consessionCinema.Id,
                                             StartDate = DateTime.Now,
                                             EndDate = DateTime.Now,
                                             Price = item.PromotionalPrice
                                         });

                    }
                    else
                    {
                        promotionPrice.Price = item.PromotionalPrice;

                        var updatedprice = await _unitOfWork
                            .PromotionPriceRepostory
                            .UpdateAsync(promotionPrice, promotionPrice.Id);
                    }

                    consessionCinema.Price = item.NormalPrice; 

                    var t = await _unitOfWork
                        .ConsessionCinemaRepository
                        .UpdateAsync(consessionCinema, consessionCinema.Id);
                }

                var errors = _errorsConfiguration;
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        //[HttpPost("consessions")]
        //public async Task<OkResult> Consessions([FromBody]List<Concession> Consessions)
        //{
        //    try
        //    {
        //        foreach (var item in Consessions)
        //        {
        //            var cinema = await _unitOfWork
        //                .CinemaRepository.GetAll()
        //                .FirstOrDefaultAsync(x => x.VistaId == item.CinemaVistaId);
        //            var consessionCinema = await _unitOfWork
        //                .ConsessionCinemaRepository
        //                .GetAll().Include(x => x.Cinema)
        //                .Include(x => x.Status)
        //                .FirstOrDefaultAsync(x => x.CinemaId == cinema.Id && x.Hopk == item.Hopk);
        //            var promotionPrice = await _unitOfWork
        //                .PromotionPriceRepostory.GetAll()
        //                .FirstOrDefaultAsync(x => x.ConsesionCinemaId == consessionCinema.Id);
        //            if (promotionPrice is null)
        //            {
        //                await _unitOfWork.PromotionPriceRepostory
        //                                 .AddAsync(new Data.EntityFramework.Models.PromotionPrice
        //                                 {
        //                                     ConsesionCinemaId = consessionCinema.Id,
        //                                     StartDate = DateTime.Now,
        //                                     EndDate = DateTime.Now,
        //                                     Price = item.PromotionalPrice
        //                                 });

        //            }
        //            else
        //            {
        //                promotionPrice.Price = item.PromotionalPrice;

        //                var updatedprice = await _unitOfWork
        //                    .PromotionPriceRepostory
        //                    .UpdateAsync(promotionPrice, promotionPrice.Id);
        //            }

        //            consessionCinema.Price = item.NormalPrice;

        //            var t = await _unitOfWork
        //                .ConsessionCinemaRepository
        //                .UpdateAsync(consessionCinema, consessionCinema.Id);


        //        }

        //        var errors = _errorsConfiguration;
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }

        //}
    }
}
