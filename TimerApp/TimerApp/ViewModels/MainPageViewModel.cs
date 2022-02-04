using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        private bool _timerOn = false;

        public int TimerHrs
        {
            get => _timerhrs;
            set
            {
                if (_timerhrs != value)
                {
                    _timerhrs = value;
                    OnPropertyChanged(nameof(TimerHrs));
                    StartTimerCommand.ChangeCanExecute();
                    StopTimerCommand.ChangeCanExecute();
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
                    StartTimerCommand.ChangeCanExecute();
                    StopTimerCommand.ChangeCanExecute();
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
                    StartTimerCommand.ChangeCanExecute();
                    StopTimerCommand.ChangeCanExecute();
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

            StartTimerCommand = new Command(StartTimerAsync, () =>
            {
                return (TimerHrs>0 || TimerMins>0 || TimerSec>0) && !_timerOn;
            });
            StopTimerCommand = new Command(StopTimer, () =>
            {
                return (TimerHrs > 0 || TimerMins > 0 || TimerSec > 0) && _timerOn;
            });
        }

        public ICommand SetTimerCommand { get; set; }
        public ICommand ClearTimerCommand { get; set; }
        public Command StartTimerCommand { get; set; }
        public Command StopTimerCommand { get; set; }

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

        private async void StartTimerAsync()
        {
            _timerOn = true;
            StartTimerCommand.ChangeCanExecute();
            StopTimerCommand.ChangeCanExecute();
            while(_timerOn && (TimerHrs > 0 || TimerMins>0 || TimerSec > 0))
            {
                await Task.Delay(1000);
                TimerSec -= 1;
                if (TimerSec == 0 && TimerMins > 0)
                {
                    TimerMins -= 1;
                    TimerSec = 60;
                }

                if (TimerMins == 0 && TimerHrs > 0)
                {
                    TimerHrs -= 1;
                    TimerMins = 60;
                }
            }
            
        }

        private void StopTimer()
        {
            _timerOn = false;
            StartTimerCommand.ChangeCanExecute();
            StopTimerCommand.ChangeCanExecute();
        }

    }
}
