using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodTruck.Service
{
    public interface IMasterDetailPage
    {
       Task pushAsync(Page page);

    }
}
