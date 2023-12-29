using BusinessLayer.Abstract;
using Dingo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISocialMediaService socialMediaService;
        private readonly IContactInfoService contactInfoService;
        public FooterViewComponent(ISocialMediaService socialMediaService, IContactInfoService contactInfoService)
        {
            this.socialMediaService = socialMediaService;
            this.contactInfoService = contactInfoService;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterVM footer = new FooterVM
            {
                SocialMedias = await socialMediaService.GetActiveCachingSocialMedias(),
                ContactInfo= await contactInfoService.GetContactInfoAsync()
            };
            return View(footer);
        }
    }
}
