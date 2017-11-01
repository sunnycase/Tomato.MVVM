using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ookii.Dialogs.Wpf;

namespace Tomato.Mvvm.Services
{
    [Export(typeof(ISaveFileService)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class SaveFileService : ISaveFileService
    {
        private readonly VistaSaveFileDialog _saveFileDialog;
        public string FileName
        {
            get { return _saveFileDialog.FileName; }
            set { _saveFileDialog.FileName = value; }
        }

        public string Filter
        {
            get { return _saveFileDialog.Filter; }
            set { _saveFileDialog.Filter = value; }
        }

        public bool ValidateNames
        {
            get { return _saveFileDialog.ValidateNames; }
            set { _saveFileDialog.ValidateNames = value; }
        }

        public SaveFileService()
        {
            _saveFileDialog = new VistaSaveFileDialog();
        }

        public Task<bool> DetermineFile()
        {
            return Task.FromResult(_saveFileDialog.ShowDialog() ?? false);
        }
    }
}
