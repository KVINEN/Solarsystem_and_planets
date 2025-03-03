// See https://aka.ms/new-console-template for more information
using Solarsystem_and_planets;
using System.Drawing;

class Astronomy
{
    public static void Main()
    {
        List<SpaceObject> solarSystem = new List<SpaceObject>
        {
            new Star("Sun"),
            new Planet("Mercury"){ OrbitRadius=57910F, OrbitPeriod=87.97F, ObjectRadius=2440F , RotationalPeriod=59F , ObjectColor= Color.FromName("Blue") },
            new Planet("Venus"),
            new Planet("Terra"),
            new Moon("The Moon"),
            new AstroidBelt("Asteroid Belt"),
            new Astroid("Ceres"),
            new DwarfPlanet("Pluto"),
            new Comet("Halley")
        };
        foreach (SpaceObject obj in solarSystem)
        {
            obj.Draw();
        }
        Console.ReadLine();
    }
}