using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wm.util
{
    public enum ErrorCodes : sbyte
    {
        None = 0,

        InvalidObject = 1,
        ObjectTaken = 2,

        NullArgument = 3,
        InvalidArgumentLength = 4,
        ArgumentHasSpaces = 5,
        ArgumentHasNoNumbers = 6,
        ArgumentHasNumbers = 7,
        ArgumentHasLetters = 8,
        ArgumentHasSymbols = 9,

        EmailHasNoAtSign = 10,
        EmailHasNoDomain = 11
    }
}
