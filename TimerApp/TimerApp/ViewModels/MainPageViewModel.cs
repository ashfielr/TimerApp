using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TimerApp.ViewModels
{
    internal class MainPageViewModel : BaseViewModel
    {
        private int _timerhrs;
        private int _timermins;
        private int _timersec;
        private int _hrs;
        private int _mins;
        private int _sec;

        public int TimerHrs
        {
            get => _timerhrs;
            set
            {
                if (_timerhrs != value)
                {
                    _timerhrs = value;
                    OnPropertyChanged(nameof(TimerHrs));
                }
            }
        }

        public int TimerMins
        {
            get => _timermins;
            set
            {
                if (_timermins != value)
                {
                    _timermins = value;
                    OnPropertyChanged(nameof(TimerMins));
                }
            }
        }

        public int TimerSec
        {
            get => _timersec;
            set
            {
                if (_timersec != value)
                {
                    _timersec = value;
                    OnPropertyChanged(nameof(TimerSec));
                }
            }
        }



        public int Hrs
        {
            get => _hrs;
            set
            {
                if(_hrs != value)
                {
                    _hrs = value;
                    OnPropertyChanged(nameof(Hrs));
                }
            }
        }
        public int Mins
        {
            get => _mins;
            set
            {
                if (_mins != value)
                {
                    _mins = value;
                    OnPropertyChanged(nameof(Mins));
                }
            }
        }
        public int Sec
        {
            get => _sec;
            set
            {
                if (_sec != value)
                {
                    _sec = value;
                    OnPropertyChanged(nameof(Sec));
                }
            }
        }


        public MainPageViewModel()
        {
            SetTimerCommand = new Command(SetTimer);
            ClearTimerCommand = new Command(ClearTimer);
        }

        public ICommand SetTimerCommand { get; set; }
        public ICommand ClearTimerCommand { get; set; }
        public ICommand StartTimerCommand { get; set; }
        public ICommand StopTimerCommand { get; set; }

        private void SetTimer()
        {
            TimerHrs = Hrs;
            TimerMins = Mins;
            TimerSec = Sec;
        }

        private void ClearTimer()
        {
            TimerHrs = 0;
            TimerMins = 0;
            TimerSec= 0;
            Hrs = 0;
            Mins = 0;
            Sec = 0;
        }

    }
}
