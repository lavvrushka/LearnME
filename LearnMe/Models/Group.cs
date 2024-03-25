using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Card> Cards { get; set; }

        public int UserId { get; set; }
        public bool IsBased { get; set; }
        public User User { get; set; }

        public Color AccentColorStart { get; set; }
        public Color AccentColorEnd { get; set; }
        public List<string> Images { get; set; }
        public string HeroImage { get; set; }


        // Background
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
