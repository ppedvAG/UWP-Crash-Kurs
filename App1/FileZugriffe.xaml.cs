using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace App1
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class FileZugriffe : Page
    {
        public FileZugriffe()
        {
            this.InitializeComponent();
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            //var folder = KnownFolders.PicturesLibrary;

            var folder = ApplicationData.Current.LocalFolder;
            var f = await folder.CreateFileAsync("aracom.txt", CreationCollisionOption.OpenIfExists);
            await FileIO.AppendTextAsync(f, Text1.Text + ";" + DateTime.Now.ToString() + Environment.NewLine);
        }

        private async void Button_Click2Async(object sender, RoutedEventArgs e)
        {
            var f = await StorageFile.GetFileFromApplicationUriAsync(new Uri(this.BaseUri, "Assets/schwein.jpg"));
            var fs = await f.OpenAsync(FileAccessMode.Read);
            var bmp = new BitmapImage();
            bmp.SetSource(fs);
            img1.Source = bmp;
        }

        private async void Button3_ClickAsync(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            var result = await picker.PickSingleFileAsync();
            if (result != null)
            {
                var tn = await result.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.PicturesView,
                     200,
                     Windows.Storage.FileProperties.ThumbnailOptions.UseCurrentScale);
                var bmp = new BitmapImage();
                bmp.SetSource(tn);
                img1.Source = bmp;
            }

        }
    }
}
