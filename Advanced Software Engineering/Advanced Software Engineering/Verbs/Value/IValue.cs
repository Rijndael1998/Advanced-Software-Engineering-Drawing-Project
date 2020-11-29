using System.Drawing;

namespace Advanced_Software_Engineering.Verbs.Value {

    public interface IValue {

        string GetDescription();

        int ToInt();

        double ToDouble();

        bool ToBool();

        Color ToColor();

        string GetOriginalType();

        bool isInitialised();

        IValue Clone();
    }
}