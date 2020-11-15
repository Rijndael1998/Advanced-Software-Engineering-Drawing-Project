using System;
using System.Drawing;

namespace Advanced_Software_Engineering.Verbs {

    internal interface IValue {

        string GetDescription();

        int ToInt();

        double ToDouble();

        bool ToBool();

        Color ToColor();

        Type GetOriginalType();
    }
}