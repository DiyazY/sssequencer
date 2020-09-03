﻿using System;
using System.Collections.Generic;
using System.Text;

namespace sss_second
{
    public interface IHandler<in TIn, out TOut>
    {
        TOut Handle(TIn input);
    }
}
