using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tomato.Mvvm.Services
{
    public interface IOpenFileService : IFileDetermineService
    {
        string[] FileNames { get; }
        bool IsMultiSelect { get; set; }
    }
}
