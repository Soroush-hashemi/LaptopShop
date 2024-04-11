using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PresentationFacade.Categories;
using PresentationFacade.MainPage;
using PresentationFacade.MainPage.DTOs;
using PresentationFacade.Products;
using PresentationFacade.Products.Serivce;
using PresentationFacade.SliderPosters;
using PresentationFacade.SliderPosters.Service;
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
        private readonly ISliderFacade _sliderFacade;
        private readonly IProductSerivce _productSerivce;
        private readonly ISlidersPostersService _slidersPostersService;

        public IndexModel(IMainPageService mainPageService, ICategoryFacade categoryFacade
            , ISliderFacade sliderFacade, IProductSerivce productSerivce, ISlidersPostersService slidersPostersService)
        {
            _mainPageService = mainPageService;
            _categoryFacade = categoryFacade;
            _sliderFacade = sliderFacade;
            _slidersPostersService = slidersPostersService;
            _productSerivce = productSerivce;
        }

        public MainPageDto MainPageData { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<SliderDto> Sliders { get; set; }
        public SliderPostersDto? BigPoster { get; set; }
        public SliderPostersDto? CenterPoster { get; set; }
        public List<SliderPostersDto?> SmallPoster { get; set; }
        public List<ProductDto> LastProduct { get; set; }
        public List<ProductDto> Popularproduct { get; set; }

        public async Task OnGet()
        {
            MainPageData = _mainPageService.GetData();
            LastProduct = _productSerivce.GetLastesProduct();
            Popularproduct = _productSerivce.GetPopularProduct();

            Sliders = await _sliderFacade.GetList();
            Categories = await _categoryFacade.GetList();

            BigPoster = _slidersPostersService.GetBigPoster();
            CenterPoster = _slidersPostersService.GetCenterPoster();
            SmallPoster = _slidersPostersService.GetSmallPoster();
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
