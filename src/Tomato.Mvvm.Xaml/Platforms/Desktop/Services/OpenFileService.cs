using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ookii.Dialogs.Wpf;

namespace Tomato.Mvvm.Services
{
    [Export(typeof(IOpenFileService)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class OpenFileService : IOpenFileService
    {
        private readonly VistaOpenFileDialog _openFileDialog;
        public string FileName
        {
            get { return _openFileDialog.FileName; }
            set { _openFileDialog.FileName = value; }
        }

        public string Filter
        {
            get { return _openFileDialog.Filter; }
            set { _openFileDialog.Filter = value; }
        }

        public bool ValidateNames
        {
            get { return _openFileDialog.ValidateNames; }
            set { _openFileDialog.ValidateNames = value; }
        }

        public bool IsMultiSelect
        {
            get { return _openFileDialog.Multiselect; }
            set { _openFileDialog.Multiselect = value; }
        }

        public string[] FileNames
        {
            get { return _openFileDialog.FileNames; }
        }

        public OpenFileService()
        {
            _openFileDialog = new VistaOpenFileDialog();
        }

        public Task<bool> DetermineFile()
        {
            return
#if NET40
                TaskEx
#else
                Task
#endif
                .FromResult(_openFileDialog.ShowDialog() ?? false);
        }
    }
}
