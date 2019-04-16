﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Editor
{
    public interface IAsset : IDisposable
    {
        bool Construct(Stream stream);
        void Save(Stream stream);
    }
}
