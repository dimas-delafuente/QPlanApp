using System;

using QPlanApp.Models;

namespace QPlanApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Restaurant Restaurant { get; set; }
        public ItemDetailViewModel(Restaurant restaurant = null)
        {
            Title = restaurant?.Name;
            Restaurant = restaurant;
        }
    }
}
