using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Solarsystem_and_planets
{
    public class SpaceObject
    {
        public String Name { get; protected set; }
        public float ObjectRadius { get; set; }
        public float RotationalPeriod { get; set; }
        public Color ObjectColor { get; set; }

        public SpaceObject(String name)
        {
            Name = name;
        }
        public virtual void Draw()
        {
            Console.WriteLine($"{Name}: Radius={ObjectRadius}, Rotation={RotationalPeriod}, Color={ObjectColor.Name}");
        }
    }

    public class CelestialBody : SpaceObject
    {
        public float OrbitRadius { get; set; }
        public float OrbitPeriod { get; set; }

        public CelestialBody(string name) : base(name) { }

        public (float x, float y) GetPosition(float time)
        {
            double angle = 2 * Math.PI * (time / OrbitPeriod);
            float x = OrbitRadius * (float)Math.Cos(angle);
            float y = OrbitRadius * (float)Math.Sin(angle);
            return (x, y);
        }
    }
    public class Star : SpaceObject
    {
        public Star(String name) : base(name) { }

        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }
    public class Planet : CelestialBody
    {
        public Planet(String name) : base(name) { }

        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }
    public class Moon : CelestialBody
    {
        public Planet OrbitingPlanet { get; set; }

        public Moon(String name, Planet orbitingPlanet) : base(name) 
        {
            OrbitingPlanet = orbitingPlanet;
        }

        public new (float x, float y) GetPosition(float time)
        {
            var (planetX, planetY) = OrbitingPlanet.GetPosition(time);
            double angle = 2 * Math.PI * (time / OrbitPeriod);
            float moonX = OrbitRadius * (float)Math.Cos(angle);
            float moonY = OrbitRadius * (float)Math.Sin(angle);
            return (planetX + moonX, planetY + moonY);

        }

        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }
    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(String name) : base(name) { }

        public override void Draw()
        {
            Console.Write("Astroid Belt : ");
            base.Draw();
        }
    }
    public class Astroid : CelestialBody
    {
        public Astroid(String name) : base(name) { }

        public override void Draw()
        {
            Console.Write("Astroid : ");
            base.Draw();
        }
    }
    public class Comet : CelestialBody
    {
        public Comet(String name) : base(name) { }

        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }
    public class  DwarfPlanet : Planet
    {
        public DwarfPlanet(String name) : base(name) { }

        public override void Draw()
        {
            Console.Write("Dwarf Planet : ");
            base.Draw();
        }
    }
}
