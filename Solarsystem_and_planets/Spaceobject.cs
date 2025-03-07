﻿using System;
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
            Console.WriteLine(Name + " " + ObjectRadius + " " + RotationalPeriod + " " + ObjectColor);
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
        public float OrbitRadius { get; set; }
        public float OrbitPeriod { get; set; }

        public override void Draw()
        {
            Console.Write("Planet: " + OrbitPeriod + " " + OrbitRadius + " ");
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
        public float OrbitRadius { get; set; }
        public float OrbitPeriod { get; set; }

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
