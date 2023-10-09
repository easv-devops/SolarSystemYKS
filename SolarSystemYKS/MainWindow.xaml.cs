using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SolarSystemApp
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private double[] planetAngles = new double[8];

        public MainWindow()
        {
            InitializeComponent();
            InitializeAnimation();
        }

        private void InitializeAnimation()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50); // Opdater hver 50 millisekunder
            timer.Tick += UpdateSolarSystem;
            timer.Start();
        }

        private void UpdateSolarSystem(object sender, EventArgs e)
        {
            for (int i = 0; i < planetAngles.Length; i++)
            {
                double orbitRadius = (i + 1) * 80; // Øg skalaen for at forbedre synligheden
                double orbitCenterX = SolarSystemCanvas.ActualWidth / 2;
                double orbitCenterY = SolarSystemCanvas.ActualHeight / 2;
                planetAngles[i] += 0.005 * (i + 1); // Juster rotationshastighed baseret på planetens indeks

                double planetX = orbitCenterX + orbitRadius * Math.Cos(planetAngles[i]);
                double planetY = orbitCenterY + orbitRadius * Math.Sin(planetAngles[i]);

                SetPlanetPosition(GetPlanetEllipse(i), planetX, planetY);
                SetPlanetPosition(GetPlanetNameTextBlock(i), planetX, planetY + 25);
            }
        }

        private Ellipse GetPlanetEllipse(int index)
        {
            switch (index)
            {
                case 0: return Merkur;
                case 1: return Venus;
                case 2: return Jorden;
                case 3: return Mars;
                case 4: return Jupiter;
                case 5: return Saturn;
                case 6: return Uranus;
                case 7: return Neptun;
                default: return null;
            }
        }

        private TextBlock GetPlanetNameTextBlock(int index)
        {
            switch (index)
            {
                case 0: return MerkurName;
                case 1: return VenusName;
                case 2: return JordenName;
                case 3: return MarsName;
                case 4: return JupiterName;
                case 5: return SaturnName;
                case 6: return UranusName;
                case 7: return NeptunName;
                default: return null;
            }
        }

        private void SetPlanetPosition(UIElement element, double x, double y)
        {
            if (element != null)
            {
                Canvas.SetLeft(element, x - element.RenderSize.Width / 2);
                Canvas.SetTop(element, y - element.RenderSize.Height / 2);
            }
        }
    }
}
