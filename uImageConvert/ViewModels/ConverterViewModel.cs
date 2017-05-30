using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace uImageConvert.ViewModels
{
    public class ConverterViewModel : BindableBase
    {
        private ObservableCollection<string> mFileList;
        public ObservableCollection<string> FileList
        {
            get { return mFileList; }
            set { SetProperty(ref mFileList, value); }
        }
        public ConverterViewModel()
        {
            FileList = new ObservableCollection<string>();
        }
        private DelegateCommand addFileCommand;
private DelegateCommand clearFileCommand;
        public DelegateCommand AddFileCommand =>
            addFileCommand ?? (addFileCommand = new DelegateCommand(AddFile, () => true));


        public DelegateCommand ClearFileCommand =>
            clearFileCommand ?? (clearFileCommand = new DelegateCommand(()=> FileList.Clear(), () => true));

        private void AddFile()
        {
            var a = new Microsoft.Win32.OpenFileDialog()
            {
                Multiselect = true,
                Title = "Add File"
            };
            if (a.ShowDialog()== true)
            {
                FileList.AddRange(a.FileNames);
            }
              
        }
    }
}
