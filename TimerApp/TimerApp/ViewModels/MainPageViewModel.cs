using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimerApp.ViewModels
{
    internal class MainPageViewModel : BaseViewModel
    {
        private List<int> _numberedList = Enumerable.Range(0, 61).ToList();

        public List<int> NumberedList { get => _numberedList; }
        public int SelectedSec { get; set; }
        public int SelectedMins { get; set; }
        public int SelectedHours { get; set; }

    }
}
