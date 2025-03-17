using Solarsystem_and_planets;

namespace visuelGreie
{
    public partial class Form1 : Form
    {
        private List<SpaceObject> solarSystem;
        private System.Windows.Forms.Timer simulationTimer;
        private float timeStep = 0.1f;
        private bool showOrbits = true;
        private bool showLabels = true;
        private CelestialBody selectedPlanet = null;
        private float scale = 1e-5f;

        public Form1(List<SpaceObject> planetaryData)
        {
            this.Text = "Solar System simulation";
            this.Width = 1000;
            this.Height = 800;
            this.DoubleBuffered = true;
            this.solarSystem = planetaryData;
            this.BackColor = Color.Black;

            MenuStrip menu = new MenuStrip();
            ToolStripMenuItem viewMenu = new ToolStripMenuItem("View");
            ToolStripMenuItem toggleOrbits = new ToolStripMenuItem("Show orbit", null, (s, e) => { showOrbits = !showOrbits; Invalidate(); });
            ToolStripMenuItem toggleLabels = new ToolStripMenuItem("Show label", null, (s, e) => { showLabels = !showLabels; Invalidate(); });
            ToolStripMenuItem speedUp = new ToolStripMenuItem("Speed up", null, (s, e) => { timeStep *= 2; });
            ToolStripMenuItem slowDown = new ToolStripMenuItem("Slow down", null, (s, e) => { timeStep /= 2; });
            ToolStripMenuItem zoomIn = new ToolStripMenuItem("Zoom in", null, (s, e) => { scale *= 2; Invalidate(); });
            ToolStripMenuItem zoomOut = new ToolStripMenuItem("Zoom out", null, (s, e) => { scale /= 2; Invalidate(); });


            viewMenu.DropDownItems.Add(toggleOrbits);
            viewMenu.DropDownItems.Add(toggleLabels);
            viewMenu.DropDownItems.Add(speedUp);
            viewMenu.DropDownItems.Add(slowDown);
            viewMenu.DropDownItems.Add(zoomIn);
            viewMenu.DropDownItems.Add(zoomOut);
            menu.Items.Add(viewMenu);
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);

            simulationTimer = new System.Windows.Forms.Timer();
            simulationTimer.Interval = 50;
            simulationTimer.Tick += (s, e) =>
            {
                UpdatePositions();
                Invalidate();
            };
            simulationTimer.Start();

            this.MouseWheel += (s, e) =>
            {
                if (e.Delta > 0)
                {
                    scale *= 1.1f;
                }
                else
                {
                    scale /= 1.1f;
                }
                Invalidate();
            };
        }

        private void UpdatePositions()
        {
            foreach (var obj in solarSystem)
            {
                if (obj is CelestialBody body)
                {
                    body.GetPosition(timeStep);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float centerX = this.Width / 2;
            float centerY = this.Height / 2;

            foreach (var obj in solarSystem)
            {
                if (obj is Star star)
                {
                    Brush brush = new SolidBrush(star.ObjectColor);
                    g.FillEllipse(brush, centerX - 15, centerY - 15, 30, 30);

                    if (showLabels)
                    {
                        g.DrawString(star.Name, DefaultFont, Brushes.White, centerX + 15, centerY);
                    }
                }
                if (obj is CelestialBody body)
                {
                    if (body is Moon)
                        continue;

                    var (x, y) = body.GetPosition(timeStep);
                    float scaledX = centerX + x * scale;
                    float scaledY = centerY + y * scale;

                    Brush brush = new SolidBrush(body.ObjectColor);
                    g.FillEllipse(brush, scaledX - 5, scaledY - 5, Math.Max(body.ObjectRadius * scale * 2, 10), Math.Max(body.ObjectRadius * scale * 2, 10));

                    if (showLabels)
                    {
                        g.DrawString(body.Name, DefaultFont, Brushes.White, scaledX + 10, scaledY);
                    }

                    if (showOrbits)
                    {
                        g.DrawEllipse(Pens.White, centerX - body.OrbitRadius * scale, centerY - body.OrbitRadius * scale, body.OrbitRadius * scale * 2, body.OrbitRadius * scale * 2);
                    }
                }
            }
            foreach (var obj in solarSystem)
            {
                if (obj is Moon moon)
                {
                    float planetX = centerX;
                    float planetY = centerY;

                    if (moon.Orbiting is CelestialBody planetBody)
                    {
                        var (px, py) = planetBody.GetPosition(timeStep);
                        planetX = centerX + px * scale;
                        planetY = centerY + py * scale;
                    }

                    var (mx, my) = moon.GetPosition(timeStep);
                    float scaledX = planetX + mx * scale * 0.05f;
                    float scaledY = planetY + my * scale * 0.05f;

                    Brush brush = new SolidBrush(moon.ObjectColor);
                    g.FillEllipse(brush,
                        scaledX - Math.Max(moon.ObjectRadius * scale * 0.5f, 3),
                        scaledY - Math.Max(moon.ObjectRadius * scale * 0.5f, 3),
                        Math.Max(moon.ObjectRadius * scale, 6),
                        Math.Max(moon.ObjectRadius * scale, 6));

                    if (showLabels)
                    {
                        g.DrawString(moon.Name, DefaultFont, Brushes.White, scaledX + 8, scaledY);
                    }

                    if (showOrbits)
                    {
                        g.DrawEllipse(Pens.Gray, planetX - moon.OrbitRadius * scale * 0.05f, planetY - moon.OrbitRadius * scale * 0.05f, moon.OrbitRadius * scale * 0.1f, moon.OrbitRadius * scale * 0.1f);
                    }
                }
            }
        }

        //Funker ikke å zoome inn 
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selectedPlanet = null;
            }
            else
            {
                foreach (var obj in solarSystem)
                {
                    if (obj is CelestialBody body)
                    {
                        var (x, y) = body.GetPosition(timeStep);
                        float scaledX = this.Width / 2 + x * scale;
                        float scaledY = this.Height / 2 + y * scale;
                        if (Math.Abs(e.X - scaledX) < 10 && Math.Abs(e.Y - scaledY) < 10)
                        {
                            selectedPlanet = body;
                            break;
                        }
                    }
                }
            }
            Invalidate();
        }
    }
}
