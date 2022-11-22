using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for AcercaDe.xaml
    /// </summary>
    public partial class AcercaDe : Window
    {
        bool isDragging;
        DispatcherTimer timer;

        public AcercaDe()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Tick se dispara cada segundo.
            timer.Tick += new EventHandler(timer_Tick);

            isDragging = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!isDragging) // Si NO hay operación de arrastre en el sliderTimeLine, su posición se actualiza cada segundo.
            {
                SliderTimeLine.Value = meVideo.Position.TotalSeconds;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         meVideo.LoadedBehavior = MediaState.Manual;
            meVideo.UnloadedBehavior = MediaState.Close;
            var CurrentDirectory = Directory.GetCurrentDirectory();
        

            meVideo.Source = new Uri(CurrentDirectory + "\\Audio\\videoreb.mp4");
        }

        private void btnReproducir_Click(object sender, RoutedEventArgs e)
        {
            meVideo.Play();
        }

        private void btnPausa_Click(object sender, RoutedEventArgs e)
        {
            meVideo.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            meVideo.Stop();
        }

        private void btnAD_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }

        private void SliderTimeLine_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            isDragging = false;
            meVideo.Position = TimeSpan.FromSeconds(SliderTimeLine.Value);
        }

        private void SliderTimeLine_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            isDragging = true;
        }

        private void SliderTimeLine_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            meVideo.Position = TimeSpan.FromSeconds(SliderTimeLine.Value);
        }

        private void meVideo_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (meVideo.NaturalDuration.HasTimeSpan)
            {
                TimeSpan ts = meVideo.NaturalDuration.TimeSpan;
                SliderTimeLine.Maximum = ts.TotalSeconds;
                SliderTimeLine.SmallChange = 1;
            }

            timer.Start();
        }

        private void meVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            SliderTimeLine.Value = 0;
        }


    }
}
