using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
namespace uImageConvert.ViewModels
{
    public class ConverterViewModel : BindableBase
    {
        private string imageFormat;
        public string Format
        {
            get { return imageFormat.ToString(); }
            set { SetProperty(ref imageFormat, value); }
        }
        private ObservableCollection<string> mFileList;
        public ObservableCollection<string> FileList
        {
            get { return mFileList; }
            set { SetProperty(ref mFileList, value); }
        }
        private string dirPath;
        public string OutputPath
        {
            get { return dirPath; }
            set { SetProperty(ref dirPath, value); }
        }
        public ConverterViewModel()
        {
            FileList = new ObservableCollection<string>();
        }
        private DelegateCommand addFileCommand;
        private DelegateCommand clearFileCommand;
        private DelegateCommand startConvertCommand;

        public DelegateCommand AddFileCommand =>
            addFileCommand ?? (addFileCommand = new DelegateCommand(AddFile, () => true));
        public DelegateCommand StartConvertCommand =>
            startConvertCommand ?? (startConvertCommand = new DelegateCommand(StartConvert, () => true));
        public DelegateCommand ClearFileCommand =>
            clearFileCommand ?? (clearFileCommand = new DelegateCommand(() => FileList.Clear(), () => true));

        
        private void StartConvert()
        {
            var a = Task.Run(StartConverts);
        }
        public async Task StartConverts()
        {
            foreach (var item in FileList)
            {
                // Load the image.
                Image image1 = Image.FromFile(item);
                var newpath = System.IO.Path.Combine(OutputPath, System.IO.Path.ChangeExtension(System.IO.Path.GetFileName(item), Format.ToLower()));
                // Save the image in JPEG format.
                var formats = GetFormat();
                image1.Save(newpath, formats);
                 
            } 
        }

        private ImageFormat GetFormat()
        {
            switch (Format)
            {
                case "Bmp":
                    return ImageFormat.Bmp;
                case "Emf":
                    return ImageFormat.Emf;
                case "Wmf":
                    return ImageFormat.Wmf;
                case "Gif":
                    return ImageFormat.Gif;
                case "Jpeg":
                    return ImageFormat.Jpeg;
                case "Png":
                    return ImageFormat.Png;
                case "Tiff":
                    return ImageFormat.Tiff;
                case "Exif":
                    return ImageFormat.Exif;
                case "Icon":
                    return ImageFormat.Icon;
                default:
                    return ImageFormat.MemoryBmp;

            }
        }

        private void AddFile()
        {
            var a = new Microsoft.Win32.OpenFileDialog()
            {
                Multiselect = true,
                Title = "Add File"
            };
            if (a.ShowDialog() == true)
            {
                FileList.AddRange(a.FileNames);
            }

        }

    }
}
