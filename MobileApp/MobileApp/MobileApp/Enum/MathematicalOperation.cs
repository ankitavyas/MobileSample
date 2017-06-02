using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileApp.Enum
{
    public enum MathematicalOperation
    {
        [Description(@" ")]
        None,
        [Description(@" + ")]
        Addition,
        [Description(@" - ")]
        Subtraction,
        [Description(@" X ")]
        Multiplication,
        [Description(@" ÷ ")]
        Division
    }
}
