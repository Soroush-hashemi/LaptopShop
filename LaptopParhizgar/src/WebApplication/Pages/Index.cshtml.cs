using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Categories;
using PresentationFacade.MainPage;
using PresentationFacade.MainPage.DTOs;
using PresentationFacade.Products.Serivce;
using PresentationFacade.SliderPosters;
using PresentationFacade.Sliders;
using Query.Categories.DTOs;
using Query.Products.DTOs;
using Query.SliderPosters.DTO;
using Query.Sliders.DTO;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMainPageService _mainPageService;
        private readonly ICategoryFacade _categoryFacade;
        private readonly ISlidersPostersFacade _slidersPostersFacade;
        private readonly ISliderFacade _sliderFacade;
        private readonly IProductSerivce _productSerivce;

        public IndexModel(IMainPageService mainPageService, ICategoryFacade categoryFacade, ISlidersPostersFacade slidersPostersFacade
            , ISliderFacade sliderFacade, IProductSerivce productSerivce)
        {
            _mainPageService = mainPageService;
            _categoryFacade = categoryFacade;
            _sliderFacade = sliderFacade;
            _slidersPostersFacade = slidersPostersFacade;
            _productSerivce = productSerivce;
        }

        public MainPageDto MainPageData { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<ProductDto> LastProduct { get; set; }
        public List<ProductDto> Popularproduct { get; set; }
        public List<SliderDto> Sliders { get; set; }
        public List<SliderPostersDto> SliderPosters { get; set; }

        public async void OnGet()
        {
            MainPageData = _mainPageService.GetData();
            Categories = await _categoryFacade.GetList();
            LastProduct = _productSerivce.GetLastesProduct();
            Popularproduct = _productSerivce.GetPopularProduct();
            Sliders = await _sliderFacade.GetList();
            SliderPosters = await _slidersPostersFacade.GetList();
        }

        public IActionResult OnGetLatestProducts()
        {
            var filterDto = _productSerivce.GetProductByFilter(new ProductFilterParams()
            {
                PageId = 1,
                Take = 10
            });
            return RedirectToPage(filterDto.Product);
        }

        public IActionResult OnGetPopularProduct()
        {
            return RedirectToPage(_productSerivce.GetPopularProduct());
        }
    }
}
