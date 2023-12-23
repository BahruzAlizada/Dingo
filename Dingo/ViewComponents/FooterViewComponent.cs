using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Dingo.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISocialMediaService socialMediaService;
        public FooterViewComponent(ISocialMediaService socialMediaService)
        {
            this.socialMediaService = socialMediaService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SocialMedia> socialMedias = await socialMediaService.GetActiveCachingSocialMedias();
            return View(socialMedias);
        }
    }
}
