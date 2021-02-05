using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NMSTools.Framework.Base
{
    public abstract class TkMetaBase
    {
        public abstract void Load(Stream inputStream);
    }
}
