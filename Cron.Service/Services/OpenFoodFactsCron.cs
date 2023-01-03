
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Quartz;
using Repository.models;
using Repository.services;

namespace Cron.Service.services
{
    public class OpenFoodFactsCron : IJob
    {
        private readonly ILogger<OpenFoodFactsCron> _logger;
        private readonly ProductsCollection _productsRepository;
        private ChromeDriver _chromeDriver = new();
        public OpenFoodFactsCron(ILogger<OpenFoodFactsCron> logger, ProductsCollection productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try {
                _logger.LogInformation("Scrapping products starting..");

                _chromeDriver.Navigate().GoToUrl("https://world.openfoodfacts.org/");

                var elements = _chromeDriver.FindElements(By.ClassName("list_product_a")).ToList();

                if(elements != null)
                {
                    elements = elements.Take(100).ToList();

                    var urls = elements.Select(u => u.GetAttribute("href")).ToList();

                    if (urls.Count >= 100)
                    {
                        var count = urls.Count - 100;
                        urls.RemoveRange(100, count);
                    }

                    foreach (var url in urls)
                    {
                        try
                        {
                            var product = new Product();

                            _chromeDriver.Navigate().GoToUrl(url);

                            product.Url = _chromeDriver.Url;
                            if (Exists(By.Id("barcode")))
                            {
                                product.Code = long.Parse(_chromeDriver.FindElement(By.Id("barcode")).Text);
                                product.ImageUrl = $"https://static.openfoodfacts.org/images/products/{FormatBarCode(product.Code.ToString())}";
                            }
                            if (Exists(By.Id("field_quantity_value")))
                            {
                                product.Quantity = _chromeDriver.FindElement(By.Id("field_quantity_value")).Text;
                            }
                            if (Exists(By.Id("field_packaging_value")))
                            {
                                product.Packaging = _chromeDriver.FindElement(By.Id("field_packaging_value")).Text;
                            }
                            if (Exists(By.Id("barcode_paragraph")))
                            {
                                var barCode = _chromeDriver.FindElement(By.Id("barcode_paragraph")).Text;
                                product.BarCode = barCode.Remove(0, barCode.IndexOf(" ")).Trim();
                            }
                            if (Exists(By.Id("field_generic_name_value")))
                            {
                                product.ProductName = _chromeDriver.FindElement(By.Id("field_generic_name_value")).Text;
                            }
                            if (Exists(By.Id("field_categories_value")))
                            {
                                product.Categories = _chromeDriver.FindElement(By.Id("field_categories_value")).Text;
                            }
                            if (Exists(By.Id("field_brands_value")))
                            {
                                product.Brands = _chromeDriver.FindElement(By.Id("field_brands_value")).Text;
                            }

                            var productExists = await _productsRepository.ProductExists(product.BarCode);

                            if (productExists)
                            {
                                await _productsRepository.UpdateProductAsync(product);
                            }
                            else
                            {
                                await _productsRepository.AddProductAsync(product);
                            }
                        }
                        catch (Exception e)
                        {
                            _logger.LogError("Scrapping products error. Product Url: " + url, e);
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                _logger.LogError("Scrapping products error.", e);
            }
        }

        private string FormatBarCode(string value)
        {
            var endLenght = value.Remove(0, 9);
            return $"{value.Substring(0, 3)}/{value.Substring(3, 3)}/{value.Substring(6, 3)}/{value.Substring(9, endLenght.Length)}";
        }
        private bool Exists(By by)
        {
            try
            {
                _chromeDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
