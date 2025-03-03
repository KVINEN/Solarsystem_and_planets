using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Solarsystem_and_planets
{
    public class SpaceObject
    {
        public String Name { get; protected set; }
        public SpaceObject(String name)
        {
            Name = name;
        }
        public virtual void Draw()
        {
            Console.WriteLine(Name);
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
    public class Planet : SpaceObject
    {
        public Planet(String name) : base(name) { }
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }
    public class Moon : Planet
    {
        public Moon(String name) : base(name) { }
        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }
}
