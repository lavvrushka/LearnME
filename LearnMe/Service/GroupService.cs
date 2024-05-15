using LearnMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Data;

namespace LearnMe.Service
{
    public class GroupsService
    {
        private readonly GroupRepository _groupRepository;

        public GroupsService(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        private static List<Group> groups = new()

    {
        //new()
        //{
        //    Name = "Math",
        //    //HeroImage = "mercury.png",
        //    Description = "Mercury is the first of the four terrestrial planets. This means it is a planet made mostly of rock. The planets closest to the Sun—Venus, Earth, and Mars—are the other three.",
        //    AccentColorStart = Color.FromArgb("#353535"),
        //    AccentColorEnd = Color.FromArgb("#8d9098"),
        //    Images = new()
        //    //{
        //    //    "https://cdn.theatlantic.com/thumbor/D15rQggf6357X1-u6VpTD2N1yQE=/0x27:1041x613/976x549/media/img/mt/2017/04/MercuryImage/original.jpg",
        //    //    "https://solarsystem.nasa.gov/system/feature_items/images/73_carousel_mercury_2.jpg",
        //    //    "https://solarsystem.nasa.gov/system/feature_items/images/75_mercury_carousel_1.jpg"
        //    //}
        //},
        //new()
        //{
        //    Name = "Dutch",
        //    //HeroImage = "venus.png",
        //    Description = "Of all the planets, Venus is the one most similar to Earth. In fact, Venus is often called Earth's “sister” planet. As similar as it is in some ways, however, it is also very different in others.",
        //    AccentColorStart = Color.FromArgb("#a6393b"),
        //    AccentColorEnd = Color.FromArgb("#d17f21"),

        //},
        //new()
        //{
        //    Name = "English",
        //    //HeroImage = "earth.png",
        //    Description = "The Earth is the only planet known where life exists. Almost 1.5 million species of animals and plants have been discovered so far, and many more have yet to be found. While other planets may have small amounts of ice or steam, the Earth is 2/3 water. Earth has perfect conditions for a breathable atmosphere.",
        //    AccentColorStart = Color.FromArgb("#0e3d68"),
        //    AccentColorEnd = Color.FromArgb("#2e97c7"),


        //},
        //new()
        //{
        //    Name = "Interview C#",
        //    //HeroImage = "mars.png",
        //    Description = "No planet has sparked the imaginations of humans as much as Mars. It may be the reddish color of Mars, or the fact that it can often be easily seen in the night sky, that has caused people to wonder about this close neighbor of ours. Tales of “Martians” invading Earth have been around for well over fifty years. But is it likely that any kind of life really does exist on Mars?",
        //    AccentColorStart = Color.FromArgb("#a23036"),
        //    AccentColorEnd = Color.FromArgb("#eb3333"),


        //},
        //new()
        //{
        //    Name = "Interview C++",
        //    //HeroImage = "jupiter.png",
        //    Description = "The planet Jupiter is the first of the gas giant planets. Made mostly of gas, they include Jupiter, Saturn, Uranus, and Neptune.\n\nJupiter is first among the planets in terms of size and mass. Its diameter is 11 times bigger than Earth, and its mass is 2.5 times greater than all the other planets combined. The “Great Red Spot” on Jupiter is actually a raging storm.",
        //    AccentColorStart = Color.FromArgb("#9d4a40"),
        //    AccentColorEnd = Color.FromArgb("#cd8026"),

        //},
        //new()
        //{
        //    Name = "Interview full-stack",
        //    //HeroImage = "saturn.png",
        //    Description = "Most people know about the rings around Saturn, because they are the brightest and most colorful. These rings are made mainly out of ice particles orbiting the planet. While the rings themselves seem big, the particles are very small, usually no more than 10 feet (3 meters) wide.",
        //    AccentColorStart = Color.FromArgb("#996237"),
        //    AccentColorEnd = Color.FromArgb("#c6502f"),

        //},
        //new()
        //{
        //    Name = "Driving test",
        //    //HeroImage = "uranus.png",
        //    Description = "Uranus is the first planet so far away from the Earth that it can only be seen with the use of a telescope. When it was first discovered in 1781, scientists didn't know what they had found. As astronomers studied the object more closely, they discovered that it had a circular orbit around the Sun. They had found the seventh planet.",
        //    AccentColorStart = Color.FromArgb("#9d4a40"),
        //    AccentColorEnd = Color.FromArgb("#996237"),

        //},
        //new()
        //{
        //    Name = "Сomputer science exam",
        //    //HeroImage = "neptune.png",
        //    Description = "Imagine being so good at math that you could figure out the location of a planet you had never even seen! That is what John C. Adams did in 1843 when he discovered Neptune.",
        //    AccentColorStart = Color.FromArgb("#0c293d"),
        //    AccentColorEnd = Color.FromArgb("#26abe0"),

        //}
    };

        public List<Group> GetDbGroups()
            => _groupRepository.GetAllGroups();

        public Group GetGroup(string groupName)
            => groups.Where(_group => _group.Name == groupName).FirstOrDefault();

        public List<Group> GetCreatedGroups()
        {
            return _groupRepository.GetCreatedGroups().ToList();
        }

        public int AddGroup(Group group)
        {
            return _groupRepository.AddGroup(group);
        }

        public void RemoveGroup(Group group) {
          _groupRepository.DelGroup(group);
        }
    }
}
