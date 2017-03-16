using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Multimedia_Lab6
{

    public partial class AnimatedMessage : Window
    {
        private readonly DoubleAnimation _tAnimation;
        private readonly ColorAnimation _cAnimation;
        private readonly DoubleAnimation _sAnimation;
        private readonly DoubleAnimation _rAnimation;


        public AnimatedMessage(DoubleAnimation _transparencyAnimation, ColorAnimation _colorAnimation,
            DoubleAnimation _sizeAnimation, DoubleAnimation _rotateAnimation)
        {
            _tAnimation = _transparencyAnimation;
            _cAnimation = _colorAnimation;
            _sAnimation = _sizeAnimation;
            _rAnimation = _rotateAnimation;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string text = "";

            if (_rAnimation != null)
            {
                text += "Rotation \n";
                var rt = new RotateTransform();
                TextBoxReview.RenderTransform = rt;
                rt.BeginAnimation(RotateTransform.AngleProperty, _rAnimation);
            }

            if (_cAnimation != null)
            {
                text += "Color \n";
                var scb = new SolidColorBrush();
                TextBoxReview.Foreground = scb;
                scb.BeginAnimation(SolidColorBrush.ColorProperty, _cAnimation);
            }

            if (_tAnimation != null)
            {
                text += "Opacity \n";
                TextBoxReview.BeginAnimation(OpacityProperty, _tAnimation);
            }

            if (_sAnimation != null)
            {
                text += "Size \n";
                TextBoxReview.BeginAnimation(FontSizeProperty, _sAnimation);
            }

            if (text == "")
                text = "Над текстом не застосовано жодного ефекту";
            TextBoxReview.Text = text;
        }
    }
}
