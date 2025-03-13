// See https://aka.ms/new-console-template for more information
using Solarsystem_and_planets;
using System;
using System.Collections.Generic;
using System.Drawing;

class Astronomy
{
    static void Main()
    {
        List<SpaceObject> solarSystem = new List<SpaceObject>
        {
            new Star("Sun"),
            new Planet("Mercury") { OrbitRadius=57910000F, OrbitPeriod=87.97F, ObjectRadius=2440F, RotationalPeriod=59F, ObjectColor=Color.Gray },
            new Planet("Venus") { OrbitRadius=108200000F, OrbitPeriod=224.7F, ObjectRadius=6052F, RotationalPeriod=243F, ObjectColor=Color.Orange },
            new Planet("Earth") { OrbitRadius=149600000F, OrbitPeriod=365.25F, ObjectRadius=6371F, RotationalPeriod=1F, ObjectColor=Color.Blue },
            new Moon("The Moon", new Planet("Earth")) { OrbitRadius=384400F, OrbitPeriod=27.3F, ObjectRadius=1737F, RotationalPeriod=27.3F, ObjectColor=Color.White },
            new Planet("Mars") { OrbitRadius=227900000F, OrbitPeriod=687F, ObjectRadius=3390F, RotationalPeriod=1.03F, ObjectColor=Color.Red },
            new AsteroidBelt("Asteroid Belt"),
            new DwarfPlanet("Ceres") { OrbitRadius=414000000F, OrbitPeriod=1680F, ObjectRadius=473F, RotationalPeriod=9F, ObjectColor=Color.Brown },
            new Planet("Jupiter") { OrbitRadius=778500000F, OrbitPeriod=4331F, ObjectRadius=69911F, RotationalPeriod=0.41F, ObjectColor=Color.Orange },
            new Moon("Ganymede", new Planet("Jupiter")) { OrbitRadius=1070400F, OrbitPeriod=7.15F, ObjectRadius=2634F, RotationalPeriod=7.15F, ObjectColor=Color.Gray },
            new Moon("Callisto", new Planet("Jupiter")) { OrbitRadius=1882700F, OrbitPeriod=16.69F, ObjectRadius=2410F, RotationalPeriod=16.69F, ObjectColor=Color.Gray },
            new Planet("Saturn") { OrbitRadius=1433000000F, OrbitPeriod=10747F, ObjectRadius=58232F, RotationalPeriod=0.45F, ObjectColor=Color.Yellow },
            new Moon("Titan", new Planet("Saturn")) { OrbitRadius=1221870F, OrbitPeriod=15.95F, ObjectRadius=2575F, RotationalPeriod=15.95F, ObjectColor=Color.Orange },
            new Planet("Uranus") { OrbitRadius=2871000000F, OrbitPeriod=30589F, ObjectRadius=25362F, RotationalPeriod=0.72F, ObjectColor=Color.Cyan },
            new Planet("Neptune") { OrbitRadius=4495000000F, OrbitPeriod=59800F, ObjectRadius=24622F, RotationalPeriod=0.67F, ObjectColor=Color.Blue },
            new DwarfPlanet("Pluto") { OrbitRadius=5906000000F, OrbitPeriod=90560F, ObjectRadius=1188F, RotationalPeriod=6.39F, ObjectColor=Color.Gray },
            new Comet("Halley") { OrbitRadius=2600000000F, OrbitPeriod=27540F, ObjectRadius=11F, RotationalPeriod=2.2F, ObjectColor=Color.White }
        };

        Console.Write("Enter time (in days): ");
        if (!float.TryParse(Console.ReadLine(), out float time))
        {
            Console.WriteLine("Invalid input. Using time = 0.");
            time = 0;
        }

        Console.Write("Enter a planet name (or press Enter for the Sun): ");
        string inputPlanet = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(inputPlanet))
        {
            Console.WriteLine("\nDisplaying Sun and all planets:\n");
            foreach (var obj in solarSystem)
            {
                if (obj is Star || obj is Planet)
                {
                    obj.Draw();
                    if (obj is CelestialBody body)
                    {
                        var (x, y) = body.GetPosition(time);
                        Console.WriteLine($"Position at {time} days: X = {x}, Y = {y}\n");
                    }
                }
            }
        }
        else
        {
            var planet = solarSystem.Find(obj => obj is Planet && obj.Name.Equals(inputPlanet, StringComparison.OrdinalIgnoreCase)) as Planet;
            if (planet != null)
            {
                planet.Draw();
                var (x, y) = planet.GetPosition(time);
                Console.WriteLine($"Position at {time} days: X = {x}, Y = {y}\n");

                Console.WriteLine($"Moons of {planet.Name}:");
                foreach (var obj in solarSystem)
                {
                    if (obj is Moon moon && ((Moon)obj).OrbitingPlanet.Name == planet.Name)
                    {
                        moon.Draw();
                        var (mx, my) = moon.GetPosition(time);
                        Console.WriteLine($"Position at {time} days: X = {mx}, Y = {my}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Planet not found!");
            }
        }

        Console.ReadLine();
    }
}
