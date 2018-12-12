using System;
using FoodTruck.iOS.Service;
using FoodTruck.Service;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(ToolbarItemBadgeService))]
namespace FoodTruck.iOS.Service
{
    public class ToolbarItemBadgeService : IToolbarItemBadgeService
    {
        public ToolbarItemBadgeService()
        {
        }
        public void SetBadge(Page page, ToolbarItem item, string value, Color backgroundColor, Color textColor)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var renderer = Platform.GetRenderer(page);
                if (renderer == null)
                {
                    renderer = Platform.CreateRenderer(page);
                    Platform.SetRenderer(page, renderer);
                }
                var vc = renderer.ViewController;

                var rightButtomItems = vc?.ParentViewController?.NavigationItem?.RightBarButtonItems;
                var idx = page.ToolbarItems.IndexOf(item);
                if (rightButtomItems != null && rightButtomItems.Length > idx)
                {
                    var barItem = rightButtomItems[idx];
                    if (barItem != null)
                    {
                        barItem.UpdateBadge(value, backgroundColor.ToUIColor(), textColor.ToUIColor());
                    }
                }

            });
        }
    }
}
