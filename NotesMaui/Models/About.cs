using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesMaui.Models
{
    class About
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://learn.microsoft.com/en-us/dotnet/maui/tutorials/notes-app/?view=net-maui-7.0&tutorial-step=2";
        public string Message => "Это приложение оч крутое";
    }
}
