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
        public SpaceObject Orbiting { get; set; }
        private float currentAngle = 0;

        public CelestialBody(string name) : base(name) { }

        public (float x, float y) GetPosition(float time)
        {
            currentAngle += (float)(2 * Math.PI * time / OrbitPeriod);
            float x = OrbitRadius * (float)Math.Cos(currentAngle);
            float y = OrbitRadius * (float)Math.Sin(currentAngle);
            return (x, y);
        }
    }
    public class Star : SpaceObject
    {
        public Star(String name) : base(name) 
        {
            ObjectColor = Color.Yellow;
            ObjectRadius = 696340F;
        }

        public (float x, float y) GetPosition()
        {
            return (0, 0);
        }

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
        public Moon(String name) : base(name) {}
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
