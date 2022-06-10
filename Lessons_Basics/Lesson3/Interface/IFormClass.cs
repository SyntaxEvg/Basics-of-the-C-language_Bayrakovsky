using Seminar;

namespace Lessons_Basics.Lesson3.Interface
{
    public interface IFormClass
    {
        int Denominator { get; }
        int Numerator { get; }
        int Remainder { get; }

        FormClass Additions(FormClass frac1, FormClass frac2);
        FormClass Division(FormClass frac1, FormClass frac2);
        FormClass Multiplication(FormClass frac1, FormClass frac2);
        int Nod(int x, int y);
        string Simple();
        FormClass Subtraction(FormClass frac1, FormClass frac2);
        string ToString();
    }
}