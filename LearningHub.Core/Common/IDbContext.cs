﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Common
{
    public interface IDbContext
    {


        DbConnection Connection { get; }


    }
}
