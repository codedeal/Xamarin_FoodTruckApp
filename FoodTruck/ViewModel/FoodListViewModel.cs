using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using FoodTruck.Model;
using FoodTruck.Service;
using FoodTruck.View;
using Xamarin.Forms;

namespace FoodTruck.ViewModel
{
    public class FoodListViewModel : BaseViewModel
    {
        private  ObservableCollection<Food> _foodList;

        public ObservableCollection<Food> FoodList
        {
            get { return _foodList; }
            set
            {
               // _foodList = value;
                SetValue(ref _foodList, value);
            }
        }
        private ObservableCollection<Food> _selectdFood;
        public ObservableCollection<Food> SelectedFood
        {
            get { return _selectdFood; }
            set
            {
                _selectdFood = value;
            }
        }
        private Dictionary<Food, Int32> _cartdictionary;
        public Dictionary<Food, Int32> Cartdictionary
        {
            get{
                return _cartdictionary;
            }
            set{
                _cartdictionary = value;
            }
        }
        public ICommand AddFoodCommand { get;  set; }
        public ICommand RewindCommand { get; private set; }
        public ICommand CartCommnad { get;  set; }
        public MasterDetailPageOperations operations;
        private IPageService pageService;
        public  FoodListViewModel()
        {
            //  GetContactsAsync();
            FoodList = GetContactsAsync();
            SelectedFood = new ObservableCollection<Food>();
            Cartdictionary = new Dictionary<Food, int>();
            AddFoodCommand = new Command<Food>(AddFood);
            RewindCommand = new Command<Food>(RewindData);
            CartCommnad = new Command(SelectedFoodItems);
            operations = new MasterDetailPageOperations();
            pageService = new PageService();
        }

        public void SelectedFoodItems()
        {
            if (Cartdictionary == null||Cartdictionary.Count==0)
            {
                Debug.Write("List is empty mate");
                pageService.DisplayAlert("Empty Cart", "Please search some products", "OK", "Cancel");
                return;
            }
            //foreach( var item in SelectedFood)
            //{
            //    Debug.WriteLine(item.Name);
            //}
           Debug.Write(Cartdictionary);
            //   pageService.pushMaster(new CartPage(SelectedFood));
          //  operations.pushMaster(new CartPage(Cartdictionary));
        }

        public void AddFoodToList()
        {
          
        }
       
        public void RewindData(Food obj)
        {
            Debug.Write(obj);
        }


        private void AddFood(Food food)
        {
            Debug.Write(food);
            if(Cartdictionary==null)
            {
                Cartdictionary.Add(food, 1);
                return;

            }
            if(Cartdictionary.ContainsKey(food))
            {
                Cartdictionary[food] = Cartdictionary[food] + 1;
                return;
            }
            else
            {
                Cartdictionary.Add(food, 1);
            }
           // SelectedFood.Add(food);
            
        }


        public ObservableCollection<Food> GetContactsAsync()
        {

        var  foods  = new ObservableCollection<Food>
             {

                  new Food{Id=1,Name="Choclate Cake",Category="Burger",Image="http://lorempixel.com/200/100/food/10/",Description="Spice of Choclate"},
                  new Food{Id=1,Name="Tofu Salad",Category="Juice",Image="http://lorempixel.com/200/100/food/2/",Description="Tofu with a Twist"},
                 new Food{Id=1,Name="Green Omelete",Category="Fruits",Image="http://lorempixel.com/200/100/food/3/",Description="Healthy Duck Egg with Wheat Bread"},
                 new Food{Id=1,Name="Organic Salad",Category="Juice",Image="http://lorempixel.com/200/100/food/4/",Description="From Fresh Farm"},
                 new Food{Id=1,Name="Fruit Salad",Category="Beverages",Image="http://lorempixel.com/200/100/food/5/",Description="Good as New"},
                new Food{Id=1,Name="Sushi",Category="Chicken Wing",Image="http://lorempixel.com/200/100/food/6/",Description="Ting Wih Sushi"}
             };
             return foods;
             

          
        }
    }
}
