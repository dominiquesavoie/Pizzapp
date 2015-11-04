
using System;

using Foundation;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Pizzapp.Core;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace Pizzapp
{
    public partial class PickerView : MvxTableViewController
    {
        public PickerView (IntPtr handle) : base (handle)
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


            var source = new MyTableViewSource (TableView);
            TableView.Source = source;

            var set = this.CreateBindingSet<PickerView, PickerViewModel> ();

            set.Bind (source).For (x => x.ItemsSource).To (vm => vm.Values);
            set.Bind (source).For (x => x.SelectionChangedCommand).To (vm => vm.SelectValue);

            set.Apply ();
        }



    }

    public class MyTableViewSource: MvxTableViewSource
    {
        public MyTableViewSource (UITableView tableView)
            :base(tableView)
        {
            
        }

        protected override UITableViewCell GetOrCreateCellFor (UITableView tableView, NSIndexPath indexPath, object item)
        {
            return tableView.DequeueReusableCell("PickerCell", indexPath);
        }
    }
}

