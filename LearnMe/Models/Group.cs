using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMe.Models
{
    [Table("Group")]
    public class Group
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Column("Name"), NotNull, Unique]
        public string Name { get; set; }

        [Column("Description"), NotNull]
        public string Description { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }


        
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
