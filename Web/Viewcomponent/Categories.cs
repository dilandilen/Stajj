using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

public class Categories : ViewComponent
{
    private readonly ICategoryService _categoryService;
    public Categories(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IViewComponentResult Invoke()
    {
        return View(_categoryService.GetAllCategoryWithProduct().Data);
    }
}