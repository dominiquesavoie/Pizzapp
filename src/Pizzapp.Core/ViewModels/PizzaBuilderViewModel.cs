using System;
using Cirrious.MvvmCross.ViewModels;

namespace Pizzapp.Core
{
    public class PizzaBuilderViewModel: MvxViewModel
    {
        public PizzaBuilderViewModel ()
        {
            Cheese = "No";    
        }

        public static string[] Crusts = new[] {
            "Pan Pizza", "Hand Tossed Pizza", "Thin 'N Crispy", "Original Stuffed Crust", "Skinny Slice Pizza",
        };

        public static string[] Sizes = new[] {
            "Small", "Medium", "Large", "Extra-Large",
        };

        public static string[] Recipes = new [] {
            "Philly Steak", "Hawaiian", "Meat Lover's", "Chicken Supreme", "Veggie", "Peperonni", "Smoked Meat"
        };

        public IMvxViewModel CreateCrustPickerViewModel()
        {
            return new PickerViewModel (Crusts, selectedValue =>  Crust = selectedValue);
        }

        public IMvxViewModel CreateSizePickerViewModel()
        {
            return new PickerViewModel (Sizes, selectedValue =>  Size = selectedValue);
        }

        public IMvxViewModel CreateRecipePickerViewModel()
        {
            return new PickerViewModel (Recipes, selectedValue =>  Recipe = selectedValue);
        }

        private string _crust;
        public string Crust
        {
            get { return _crust; }
            set
            {
                _crust = value;
                RaisePropertyChanged ();
            }
        }

        private string _recipe;
        public string Recipe
        {
            get { return _recipe; }
            set
            {
                _recipe = value;
                RaisePropertyChanged ();
            }
        }

        private string _size;
        public string Size
        {
            get { return _size; }
            set
            {
                _size = value;
                RaisePropertyChanged ();
            }
        }

        private string _cheese;
        public string Cheese
        {
            get { return _cheese; }
            set
            {
                _cheese = value;
                RaisePropertyChanged ();
            }
        }

        public IMvxCommand NavigateToMap
        {
            get
            {
                return new MvxCommand (() => {
                    ShowViewModel<HomeViewModel>();
                });
            }
        }
    }
}

