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
    public class AstroidBelt : SpaceObject
    {
        public AstroidBelt(String name) : base(name) { }
        public override void Draw()
        {
            Console.Write("Astroid Belt : ");
            base.Draw();
        }
    }
    public class Astroid : SpaceObject
    {
        public Astroid(String name) : base(name) { }
        public override void Draw()
        {
            Console.Write("Astroid : ");
            base.Draw();
        }
    }
    public class Comet : SpaceObject
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
