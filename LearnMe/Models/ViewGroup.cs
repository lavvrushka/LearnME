using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LearnMe.Models
{
    public class ViewGroup
    {

        public ViewGroup(Group group)
        {
            Id = group.Id;  
            Name = group.Name;  
            Description = group.Description;
            UserId = group.UserId;
            AccentColorEnd = Color.FromArgb(group.AccentColorEndString);
            AccentColorStart = Color.FromArgb(group.AccentColorStartString);
        }
        public int Id { get; set; }

        public string Name { get; set; }

   
        public string Description { get; set; }

        public int UserId { get; set; }

  
        public Color AccentColorStart
        {
            get;
            set;
        }

        public Color AccentColorEnd
        {
            get;
            set;
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
                    new Point(0.0, 0.0),
                    new Point(1.0, 1.0));

                return bgBrush;
            }
        }
    }
}
