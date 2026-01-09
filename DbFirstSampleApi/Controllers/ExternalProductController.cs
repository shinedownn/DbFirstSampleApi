using DbFirstSampleApi.DataAccess.Abstract;
using DbFirstSampleApi.Entities.Concrete;
using DbFirstSampleApi.Entities.Dtos.ProductDto;
using DbFirstSampleApi.Response;
using DbFirstSampleApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DbFirstSampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalProductController : ControllerBase
    {
        private readonly IExternalProductService _externalProductService;
        private readonly IProductRepository _productRepository;

        public ExternalProductController(IExternalProductService externalProductService, IProductRepository productRepository)
        {
            _externalProductService = externalProductService;
            _productRepository = productRepository;
        }

        /// <summary>
        /// https://fakestoreapi.com/products adresine istek atar
        /// </summary>
        /// <returns>adresteki ürünleri listeler</returns>
        [HttpGet]
        public async Task<ResponseModel<IEnumerable<ExternalProduct>>> Get()
        {
            ResponseModel<IEnumerable<ExternalProduct>> responseModel = new();
            try
            {
                var result = await _externalProductService.GetProducts();
                responseModel.Data = result;
                responseModel.Status = true;
                responseModel.Message = "Success";
            }
            catch (Exception ex)
            {
                responseModel.Data = null;
                responseModel.Status = false;
                responseModel.Message = "Error handled";
                responseModel.Errors.Add(ex.Message);
            }
            return responseModel;
        }
        /// <summary>
        /// Dış kaynaktan çektiği ürün listesini iç kaynaktan çektiği ürünlerle karşılaştırır
        /// </summary>
        /// <returns>Fiyatı artanları ve azalanları ayrı ayrı döndürür</returns>
        [HttpGet("GetDifferentProducts")]
        public async Task<ResponseModel<PriceSyncReport>> GetDifferentProducts()
        {
            var localList = await _productRepository.GetListAsync();
            var externalList = await _externalProductService.GetProducts();
            var report = new PriceSyncReport();
            var externalMapped = externalList
                    .Where(e => !string.IsNullOrWhiteSpace(e.Title))
                    .Select(e => new
                    {
                        CleanName = e.Title.Trim().ToLower(),
                        e.Price
                    });

            var localData = localList
                .Select(p => new { p.Id, p.Name, p.Price });

            var toUpdate = localData.Join(externalMapped,
                    l => l.Name.Trim().ToLower(),
                    e => e.CleanName,
                    (l, e) => new { Local = l, External = e })
                    .Where(x => x.Local.Price != x.External.Price)
                    .Select(x =>
                    {
                        var detail = new PriceChangeDetail(x.Local.Name, x.Local.Price, x.External.Price);

                        if (x.External.Price > x.Local.Price) report.Increased.Add(detail);
                        else report.Decreased.Add(detail);

                        return new ProductEntity
                        {
                            Id = x.Local.Id,
                            Price = x.External.Price
                        };
                    }).ToList();
            return new ResponseModel<PriceSyncReport>
            {
                Status = true,
                Message = $"{report.TotalUpdated} adet fiyatı değişmiş ürün bulundu",
                Data = report
            }; 
        }
    }
    public class PriceSyncReport
    {
        public List<PriceChangeDetail> Increased { get; set; } = new();
        public List<PriceChangeDetail> Decreased { get; set; } = new();
        public int TotalUpdated => Increased.Count + Decreased.Count;
    }

    public record PriceChangeDetail(string Name, decimal LocalPrice, decimal ExternalPrice);

}
