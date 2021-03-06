﻿using InstaSharper.Classes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Il modello di elemento Controllo utente è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234236

namespace WinGoTag.UserControls
{
    public sealed partial class GridItemUC : UserControl, INotifyPropertyChanged
    {
        //public BitmapImage BMI = new BitmapImage();
        public InstaMedia Media
        {
            get
            {
                return (InstaMedia)GetValue(MediaProperty);
            }
            set
            {
                SetValue(MediaProperty, value);
                this.DataContext = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Media"));
            }
        }
        public static readonly DependencyProperty MediaProperty = DependencyProperty.Register(
         "Media",
         typeof(InstaMedia),
         typeof(GridItemUC),
         new PropertyMetadata(null)
        );

        //public BitmapImage BitmapImg
        //{
        //    get { return BMI; }
        //    set { BMI = value; }
        //}


        public event PropertyChangedEventHandler PropertyChanged;
        public GridItemUC()
        {
            this.InitializeComponent();
            this.Image.ImageOpened += Image_ImageOpened;
            this.DataContextChanged += InstaMediaUC_DataContextChanged;
        }

        private void InstaMediaUC_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            try
            {
                if (args.NewValue.GetType() == typeof(InstaMedia))
                {
                    switch (Media.MediaType)
                    {
                        case InstaMediaType.Image:
                            SymbolType.Text = "";
                            //BMI.UriSource = new Uri(Media.Images.FirstOrDefault().URI, UriKind.RelativeOrAbsolute);
                           /* Image.Source = BMI;*/ /*new BitmapImage(new Uri(Media.Images.FirstOrDefault().URI, UriKind.RelativeOrAbsolute));*/
                            break;

                        case InstaMediaType.Carousel:
                            SymbolType.Text = "\ue923";
                            //BMI.UriSource = new Uri(Media.Carousel.FirstOrDefault().Images.FirstOrDefault().URI, UriKind.RelativeOrAbsolute);
                            /*Image.Source = BMI;*/ /*new BitmapImage(new Uri(Media.Carousel.FirstOrDefault().Images.FirstOrDefault().URI, UriKind.RelativeOrAbsolute));*/
                            break;
                         
                        case InstaMediaType.Video:
                            SymbolType.Text = "\ueA0C";
                            //BMI.UriSource = new Uri(Media.Images.FirstOrDefault().URI, UriKind.RelativeOrAbsolute);
                           /* Image.Source = BMI;*/ /*new BitmapImage(new Uri(Media.Images.FirstOrDefault().URI, UriKind.RelativeOrAbsolute));*/
                            break;
                    }
                    //Image.Loaded += Image_Loaded;
                    //BMI.DownloadProgress += BMI_DownloadProgress;
                }
            }
            catch { }
        }


        

        //private void BMI_DownloadProgress(object sender, DownloadProgressEventArgs e)
        //{
        //    RadialProgressBarControl.Value = e.Progress;

        //    //if (e.Progress < 100)
        //    //{
        //    //    RadialProgressBarControl.Visibility = Visibility.Visible;
        //    //}

        //    if (e.Progress is 100)
        //    {
        //        RadialProgressBarControl.Visibility = Visibility.Collapsed;
        //    }
        //}


        private void Image_ImageOpened(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fade = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.2),
                EnableDependentAnimation = true
            };
            Storyboard.SetTarget(fade, (Image)sender);
            Storyboard.SetTargetProperty(fade, "Opacity");
            Storyboard openpane = new Storyboard();
            openpane.Children.Add(fade);
            openpane.Begin();
        }

        //private void Image_Loaded(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        switch (Media.MediaType)
        //        {
        //            case InstaMediaType.Image:

        //                BMI.UriSource = new Uri(Media.Images.FirstOrDefault().URI, UriKind.RelativeOrAbsolute); break;


        //            case InstaMediaType.Carousel:

        //                BMI.UriSource = new Uri(Media.Carousel.FirstOrDefault().Images.FirstOrDefault().URI, UriKind.RelativeOrAbsolute); break;


        //            case InstaMediaType.Video:

        //                BMI.UriSource = new Uri(Media.Images.FirstOrDefault().URI, UriKind.RelativeOrAbsolute); break;
        //        }
        //    }
        //    catch { }
        //}
    }
}
