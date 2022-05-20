using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinProjectPhoto.db
{
    interface ISqlite
    {
        string GetDatabasePath(string filename);
    }
}
