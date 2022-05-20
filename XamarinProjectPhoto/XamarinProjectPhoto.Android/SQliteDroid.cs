using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using XamarinProjectPhoto.db;

namespace XamarinProjectPhoto.Droid
{
    class SQliteDroid : ISqlite
    {
        public SQliteDroid() { }
        public string GetDatabasePath(string filename)
        {
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, filename);
            return path;
        }
    }
}