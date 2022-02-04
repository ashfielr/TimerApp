using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TimerApp.ViewModels
{
    internal class MainPageViewModel : BaseViewModel
    {
        public int TimerSec { get; set; }
        public int TimerMins { get; set; }
        public int TimerHrs { get; set; }

        public int Sec { get; set; }
        public int Mins { get; set; }
        public int Hrs { get; set; }

        public MainPageViewModel()
        {

        }

        public ICommand SetTimerCommand { get; set; }
        public ICommand ClearTimerCommand { get; set; }
        public ICommand StartTimerCommand { get; set; }
        public ICommand StopTimerCommand { get; set; }

    }
}
