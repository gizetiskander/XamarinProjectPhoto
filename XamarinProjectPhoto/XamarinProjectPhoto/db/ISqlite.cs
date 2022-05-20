using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinProjectPhoto.db
{
    public interface ISqlite
    {
        string GetDatabasePath(string filename);
    }
}
