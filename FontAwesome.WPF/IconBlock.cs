using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FontAwesome.WPF {
    public class IconBlock : TextBlock {

        public static readonly FontFamily Font = new FontFamily(new Uri("pack://application:,,,/FontAwesome.WPF;component/"), "./#FontAwesome");



        public IconChar Icon {
            get { return (IconChar)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(IconChar), typeof(IconBlock), new PropertyMetadata(IconChar.None, OnIconPropertyChanged));

        private static void OnIconPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            d.SetValue(TextBlock.TextProperty, char.ConvertFromUtf32((int)e.NewValue));
        }

        public IconBlock() {
            
            var descriptor = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(IconBlock));
            descriptor.AddValueChanged(this, OnTextValueChanged);
            

            this.FontFamily = Font;
            this.TextAlignment = System.Windows.TextAlignment.Center;
        }

        private void OnTextValueChanged(object sender, EventArgs e) {

            var str = this.Text;
            if (str.Length == 1 && Enum.IsDefined(typeof(IconChar), char.ConvertToUtf32(str, 0))) {
                return;
            }
            else {
                throw new FormatException();
            }

        }
    }
}
