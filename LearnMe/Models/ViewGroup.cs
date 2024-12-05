using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Drawing; // Assuming you meant System.Drawing for Color
using System.Runtime.CompilerServices;
using LearnMe.Models;
using Microsoft.Maui.Graphics; // Use this for Colors in MAUI

namespace LearnMe.Models
{
    public class ViewGroup : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _description;
        private int _userId;
        private int _eventId;
    
        private Microsoft.Maui.Graphics.Color _accentColorStart;
        private Microsoft.Maui.Graphics.Color _accentColorEnd;

        public ViewGroup(Group group)
        {
            Id = group.Id;
            Name = group.Name;
            Description = group.Description;
            UserId = group.UserId;
            AccentColorEnd = Microsoft.Maui.Graphics.Color.FromArgb(group.AccentColorEndString);
            AccentColorStart = Microsoft.Maui.Graphics.Color.FromArgb(group.AccentColorStartString);
        }


     
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public int UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        public int EventId
        {
            get => _eventId;
            set => SetProperty(ref _eventId, value);
        }

        public bool IsChecked { get; set; }

        public Microsoft.Maui.Graphics.Color AccentColorStart
        {
            get => _accentColorStart;
            set => SetProperty(ref _accentColorStart, value);
        }

        public Microsoft.Maui.Graphics.Color AccentColorEnd
        {
            get => _accentColorEnd;
            set => SetProperty(ref _accentColorEnd, value);
        }


        public Brush Background
        {
            get
            {
                var gradientStops = new GradientStopCollection();
                gradientStops.Add(new GradientStop(AccentColorStart, 0.0f));
                gradientStops.Add(new GradientStop(AccentColorEnd, 1.0f));

                var bgBrush = new LinearGradientBrush(
                    gradientStops,
                    new Microsoft.Maui.Graphics.Point(0.0, 0.0),
                    new Microsoft.Maui.Graphics.Point(1.0, 1.0));

                return bgBrush;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
