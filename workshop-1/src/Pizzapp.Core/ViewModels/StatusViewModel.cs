using System;
using Cirrious.MvvmCross.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace Pizzapp.Core
{
    public class StatusViewModel: MvxViewModel
    {
        private IProgress<double> _progress;
        private PizzaDeliveryViewModel _parent;

        public StatusViewModel (PizzaDeliveryViewModel parent)
        {
            _parent = parent;
            _progress = new Progress<double> (d => {
                Progress = d;
                RaisePropertyChanged("Progress");
            });    
        }

        public double Progress
        {
            get;
            private set;
        }

        public async void StartProgress()
        {
            for (int i = 0; i <= 10; i++)
            {
                _progress.Report (i / 10d);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            _parent.InitialStep ();
        }


    }
        
}

