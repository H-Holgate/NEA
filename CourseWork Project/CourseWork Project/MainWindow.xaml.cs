//Harrison Holgate Course Work Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace CourseWork_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point MousePos;
        Graph.GraphingGrid grid;
        Graph.Graph graph;

        public MainWindow()
        {
            InitializeComponent();

            ToolbarButtonSetUp();

            //Set the grid to a new instance of the DrawingGrid class.
            //Pass Canvas, XStart, YStart, XEnd, YEnd values to the object.
            grid = new Graph.GraphingGrid(testBox);



          
  

            //Paint the grid using the values from the object.
            grid.PaintGrid();                    
        }

        //Get images for tool bar buttons.
        private void ToolbarButtonSetUp()
        {
            //grabButton Setup.
            //7SetButtonImage(grabButton, System.AppDomain.CurrentDomain.BaseDirectory + "\\Icons\\Shrek.png");

            //zoomInButton Setup.
            SetButtonImage(zoomInButton, System.AppDomain.CurrentDomain.BaseDirectory + "\\Icons\\zoom-in.png");

            //zoomOutButton Setup.
            SetButtonImage(zoomOutButton, System.AppDomain.CurrentDomain.BaseDirectory + "\\Icons\\zoom-out.png");
        }

        private void SetButtonImage(ToggleButton button,string imagePath)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(imagePath));

            StackPanel stackPnl = new StackPanel();
            stackPnl.Orientation = Orientation.Horizontal;
            stackPnl.Margin = new Thickness(0);
            stackPnl.Children.Add(img);

            button.Content = stackPnl;
        }

        private void testBox_MouseMove(object sender, MouseEventArgs e)
        {
            //Sets cursor image depending on the selected tool.
            SetCursor(e);
            //If the LMB is pressed, enable dragging.
            if ( e.LeftButton == MouseButtonState.Pressed && grabButton.IsChecked == true)
            {
                //Get change in y and x from the previous mouse position.
                decimal deltaY = (int)e.GetPosition(testBox).Y - (int)MousePos.Y;
                decimal deltaX = (int)e.GetPosition(testBox).X - (int)MousePos.X;

                //Set new MousePosition.
                MousePos = e.GetPosition(testBox);

                //Update the XStart, YStart, XEnd and YEnd values to reflect the mouse translation.
                grid.XStart += -((deltaX) * grid.IncrementX / grid.XInterval);
                grid.XEnd += -((deltaX) * grid.IncrementX / grid.XInterval);
                grid.YStart += ((deltaY) * grid.IncrementY / grid.YInterval);
                grid.YEnd += ((deltaY) * grid.IncrementY / grid.YInterval);

                //Redraw the objects on the canvas.
                grid.PaintGrid();
            }
        }

        private void SetCursor(MouseEventArgs e)
        {
            if(grabButton.IsChecked == true && e.LeftButton == MouseButtonState.Pressed)
            {
                this.Cursor = new Cursor(System.AppDomain.CurrentDomain.BaseDirectory + "\\Cursors\\grabbing.cur");
            }
            else if (grabButton.IsChecked == true)
            {
                this.Cursor = new Cursor(System.AppDomain.CurrentDomain.BaseDirectory + "\\Cursors\\grab.cur");
            }
            else if(zoomInButton.IsChecked == true)
            {
                this.Cursor = new Cursor(System.AppDomain.CurrentDomain.BaseDirectory + "\\Cursors\\zoom_in.cur");
            }
            else if (zoomOutButton.IsChecked == true)
            {
                this.Cursor = new Cursor(System.AppDomain.CurrentDomain.BaseDirectory + "\\Cursors\\zoom_out.cur");
            }
            else
            {
                this.Cursor = Cursors.Arrow;
            }
            
        }

        private void testBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetCursor(e);


            //Zoom in condition.
            if (e.LeftButton == MouseButtonState.Pressed && zoomInButton.IsChecked == true)
            {
                MousePos = e.GetPosition(testBox);



                decimal xOffset = (decimal)testBox.Width / 2 - (decimal)MousePos.X;
                decimal yOffSet = (decimal)testBox.Height / 2 - ((decimal)MousePos.Y);

                grid.ZoomValue++;
                zoomLbl.Content = "Zoom: x " + Math.Pow((double)2, (double)grid.ZoomValue).ToString("0.########");

                grid.IncrementX *= 0.5m;
                grid.IncrementY *= 0.5m;


                grid.XStart -= xOffset * grid.IncrementX / grid.XInterval;
                grid.XEnd -= xOffset * grid.IncrementX / grid.XInterval;
                grid.YStart += yOffSet * grid.IncrementY / grid.YInterval;
                grid.YEnd += yOffSet * grid.IncrementY / grid.YInterval;


                grid.XStart += grid.XRange / 4;
                grid.XEnd -= grid.XRange / 4;
                grid.YStart += grid.YRange / 4;
                grid.YEnd -= grid.YRange / 4;

                grid.PaintGrid();

            }
            else
            {
                //Zoom out condition.
                if (e.LeftButton == MouseButtonState.Pressed && zoomOutButton.IsChecked == true)
                {
                    

                    decimal xOffset = (decimal)testBox.Width / 2 - (decimal)MousePos.X;
                    decimal yOffSet = (decimal)testBox.Height / 2 - ((decimal)MousePos.Y);


                    grid.ZoomValue--;
                    Math.Pow((double)2, (double)grid.ZoomValue);
                    zoomLbl.Content = "Zoom: x " + Math.Pow((double)2, (double)grid.ZoomValue).ToString("0.########");

                    grid.IncrementX *= 2;
                    grid.IncrementY *= 2;

                    grid.XStart -= xOffset * grid.IncrementX / grid.XInterval;
                    grid.XEnd -= xOffset * grid.IncrementX / grid.XInterval;
                    grid.YStart += yOffSet * grid.IncrementY / grid.YInterval;
                    grid.YEnd += yOffSet * grid.IncrementY / grid.YInterval;


                    grid.XStart -= grid.XRange / 2;
                    grid.XEnd += grid.XRange / 2;
                    grid.YStart -= grid.YRange / 2;
                    grid.YEnd += grid.YRange / 2;


                    

                    grid.PaintGrid();

                }
            }
        }

        private void testBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SetCursor(e);
        }

        private void testBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MousePos = e.GetPosition(testBox);
        }

        private void testBox_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        #region ToggleButton Click Methods
        private void zoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            if(zoomInButton.IsChecked == true || grabButton.IsChecked == true)
            {
                zoomInButton.IsChecked = false;
                grabButton.IsChecked = false;
            }
        }

        private void zoomInButton_Click(object sender, RoutedEventArgs e)
        {
            if (zoomOutButton.IsChecked == true || grabButton.IsChecked == true)
            {
                zoomOutButton.IsChecked = false;
                grabButton.IsChecked = false;
            }

        }

        private void grabButton_Click(object sender, RoutedEventArgs e)
        {
            if (zoomOutButton.IsChecked == true || zoomInButton.IsChecked == true)
            {
                zoomOutButton.IsChecked = false;
                zoomInButton.IsChecked = false;
            }
        }
        #endregion

        
    }
}
