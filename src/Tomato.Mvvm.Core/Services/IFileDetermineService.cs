using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Mvvm.Services
{
    public interface IFileDetermineService
    {
        string Filter { get; set; }
        bool ValidateNames { get; set; }
        string FileName { get; set; }
        Task<bool> DetermineFile();
    }
}
