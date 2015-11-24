
using System;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Pizzapp.Core;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Pizzapp
{
    [MvxFromStoryboard("PizzaBuilderView")]
    public partial class PizzaBuilderView : MvxTableViewController<PizzaBuilderViewModel>
    {
        public PizzaBuilderView (IntPtr handle) : base (handle)
        {
        }

        public override void DidReceiveMemoryWarning ()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning ();
            
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            
            var set = this.CreateBindingSet<PizzaBuilderView, PizzaBuilderViewModel> ();

            set.Bind (lblCrust).To (vm => vm.Crust);
            set.Bind (lblSize).To (vm => vm.Size);
            set.Bind (lblRecipe).To (vm => vm.Recipe);
            set.Bind (lblCheese).To (vm => vm.Cheese);

            set.Apply ();
        }

        [Action ("UnwindToPizzaBuilderView:")]
        public void UnwindToPizzaBuilderView(UIStoryboardSegue segue)
        {
            Console.WriteLine("UnwindToPizzaBuilderView");
        }

        public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
        {
            var picker = (PickerView)segue.DestinationViewController.ChildViewControllers[0];
            switch (segue.Identifier)
            {
            case "CrustPickerSegue":
                picker.DataContext = ViewModel.CreateCrustPickerViewModel ();
                break;
            case "SizePickerSegue":
                picker.DataContext = ViewModel.CreateSizePickerViewModel ();
                break;
            case "RecipePickerSegue":
                picker.DataContext = ViewModel.CreateRecipePickerViewModel ();
                break;
            default:
                break;
            }
           
        }

        public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.CellAt(indexPath);
            if (cell == cellCheese)
            {
                if (cell.Accessory == UITableViewCellAccessory.Checkmark)
                {
                    cell.Accessory = UITableViewCellAccessory.None;
                    ViewModel.Cheese = "No";
                }
                else
                {
                    cell.Accessory = UITableViewCellAccessory.Checkmark;
                    ViewModel.Cheese = "Yes";
                }
            }
        }

        partial void btnOk_Activated (UIBarButtonItem sender)
        {
            ViewModel.NavigateToMap.Execute();
        }
    }
}

