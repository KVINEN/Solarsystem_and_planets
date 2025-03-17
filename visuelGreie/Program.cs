using Solarsystem_and_planets;

namespace visuelGreie
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var sun = new Star("Sun");
            var mercury = new Planet("Mercury") { OrbitRadius = 57910000F, OrbitPeriod = 87.97F, ObjectRadius = 2440F, RotationalPeriod = 59F, ObjectColor = Color.Gray };
            var venus = new Planet("Venus") { OrbitRadius = 108200000F, OrbitPeriod = 224.7F, ObjectRadius = 6052F, RotationalPeriod = 243F, ObjectColor = Color.Orange };
            var earth = new Planet("Earth") { OrbitRadius = 149600000F, OrbitPeriod = 365.25F, ObjectRadius = 6371F, RotationalPeriod = 1F, ObjectColor = Color.Blue };
            var mars = new Planet("Mars") { OrbitRadius = 227900000F, OrbitPeriod = 687F, ObjectRadius = 3390F, RotationalPeriod = 1.03F, ObjectColor = Color.Red };
            var jupiter = new Planet("Jupiter") { OrbitRadius = 778500000F, OrbitPeriod = 4331F, ObjectRadius = 69911F, RotationalPeriod = 0.41F, ObjectColor = Color.Orange };
            var saturn = new Planet("Saturn") { OrbitRadius = 1433000000F, OrbitPeriod = 10747F, ObjectRadius = 58232F, RotationalPeriod = 0.45F, ObjectColor = Color.Yellow };
            var uranus = new Planet("Uranus") { OrbitRadius = 2871000000F, OrbitPeriod = 30589F, ObjectRadius = 25362F, RotationalPeriod = 0.72F, ObjectColor = Color.Cyan };
            var neptune = new Planet("Neptune") { OrbitRadius = 4495000000F, OrbitPeriod = 59800F, ObjectRadius = 24622F, RotationalPeriod = 0.67F, ObjectColor = Color.Blue };
            Application.Run(new Form1(new List<SpaceObject>
            {
                sun,
                mercury,
                venus,
                earth,
                new Moon("The Moon") { Orbiting=earth, OrbitRadius=384400F, OrbitPeriod=27.3F, ObjectRadius=1737F, RotationalPeriod=27.3F, ObjectColor=Color.White },
                mars,
                new AsteroidBelt("Asteroid Belt"),
                new DwarfPlanet("Ceres") { OrbitRadius=414000000F, OrbitPeriod=1680F, ObjectRadius=473F, RotationalPeriod=9F, ObjectColor=Color.Brown },
                jupiter,
                new Moon("Ganymede") { Orbiting=jupiter, OrbitRadius=1070400F, OrbitPeriod=7.15F, ObjectRadius=2634F, RotationalPeriod=7.15F, ObjectColor=Color.Gray },
                new Moon("Callisto") { Orbiting=jupiter, OrbitRadius=1882700F, OrbitPeriod=16.69F, ObjectRadius=2410F, RotationalPeriod=16.69F, ObjectColor=Color.Gray },
                saturn,
                new Moon("Titan") { Orbiting=saturn, OrbitRadius=1221870F, OrbitPeriod=15.95F, ObjectRadius=2575F, RotationalPeriod=15.95F, ObjectColor=Color.Orange },
                uranus,
                neptune,
                new DwarfPlanet("Pluto") { OrbitRadius=5906000000F, OrbitPeriod=90560F, ObjectRadius=1188F, RotationalPeriod=6.39F, ObjectColor=Color.Gray },
                new Comet("Halley") { OrbitRadius=2600000000F, OrbitPeriod=27540F, ObjectRadius=11F, RotationalPeriod=2.2F, ObjectColor=Color.White }
            }));
        }
    }
}