﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    abstract class SizedShape : Shape
    {
        public uint Size { get; }

        public SizedShape(int x, int y, uint size, ConsoleColor color = ConsoleColor.White) : base(x, y, color)
        {
            Size = size;
        }
    }
}