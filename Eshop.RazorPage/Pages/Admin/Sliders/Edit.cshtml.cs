﻿using Common.Application.Validation.CustomValidation.IFormFile;
using Eshop.RazorPage.Infrastructure.RazorUtils;
using Eshop.RazorPage.Models.Sliders;
using Eshop.RazorPage.Services.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.RateLimiting;

namespace Eshop.RazorPage.Pages.Admin.Sliders
{
    [BindProperties]
    public class EditModel : BaseRazorPage
    {
        private readonly ISliderService _sliderService;

        public EditModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "لینک")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [DataType(DataType.Url)]
        public string Link { get; set; }
        [Display(Name = "عکس اسلایدر")]
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        public IFormFile? ImageFile { get; set; }
        public string ImageName { get; set; }

        public async Task<IActionResult> OnGet(long id)
        {
            var slider = await _sliderService.GetSliderById(id);
            if(slider == null)
            {
                RedirectToPage("Index");
            }
            Title = slider.Title;
            Link = slider.Link;
            ImageName = slider.ImageName;

            return Page();
        }

        public async Task<IActionResult> OnPost(long id)
        {
            var result = await _sliderService.EditSlider(new EditSliderCommand()
            {
                Id = id,
                Title = Title,
                ImageFile = ImageFile,
                Link = Link
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
    }
}
