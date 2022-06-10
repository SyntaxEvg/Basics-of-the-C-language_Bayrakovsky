using Lessons_Basics.Lesson3.Interface;
using System;

namespace Seminar
{
    public class FormClass : IFormClass
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
        public int Remainder { get; private set; }


        public FormClass()
        {

        }

        public override string ToString()
        {
            if (Numerator > Denominator)
            {
                return Simple();
            }
            else
            {
                int nod = this.Nod(Numerator, Denominator);
                if (nod > 1)
                {
                    return $"{Numerator}/{Denominator} -> {Numerator / nod}/{Denominator / nod}";

                }
                else
                {
                    return $"{Numerator}/{Denominator}";
                }
            }
        }


        public FormClass(ref int num, ref int den)
        {
            Numerator = num;
            Denominator = den;
            Remainder = 0;
        }
        public int Nod(int x, int y)
        {
            if (x == y)
            {
                return x;
            }
            else
            {
                if (x > y)
                {
                    return Nod(x - y, y);
                }
                else
                {
                    return Nod(x, y - x);
                }
            }
        }

        public string Simple()
        {
            int quotient = Math.DivRem(Numerator, Denominator, out var rem);
            Remainder = rem;
            int nod = Nod(Remainder, Denominator);
            if (nod > 1)
            {
                return $"{Numerator}\t{Denominator}\t{quotient} {Remainder}/{Denominator}\t{quotient} {Remainder / nod}/{Denominator / nod}";
            }
            else
            {
                return $"{Numerator}/{Denominator}\t{quotient} {Remainder}/{Denominator}";
            }
        }

        public FormClass Additions(FormClass frac1, FormClass frac2)
        {
            FormClass dr = new FormClass();

            if (frac1.Denominator != frac2.Denominator)
            {
                dr.Numerator = frac1.Numerator * frac2.Denominator + frac2.Numerator * frac1.Denominator;
                dr.Denominator = frac1.Denominator * frac2.Denominator;
            }
            else
            {
                dr.Numerator = frac1.Numerator + frac2.Numerator;
                dr.Denominator = frac1.Denominator;
            }
            return dr;
        }
        public FormClass Subtraction(FormClass frac1, FormClass frac2)
        {
            FormClass Subt = new FormClass();

            if (frac1.Denominator != frac2.Denominator)
            {
                Subt.Numerator = frac1.Numerator * frac2.Denominator - frac2.Numerator * frac1.Denominator;
                Subt.Denominator = frac1.Denominator * frac2.Denominator;
            }
            else
            {
                Subt.Numerator = frac1.Numerator - frac2.Numerator;
                Subt.Denominator = frac1.Denominator;
            }
            return Subt;
        }
        public FormClass Multiplication(FormClass frac1, FormClass frac2)
        {
            FormClass Multip = new FormClass();

            if (frac1.Denominator != frac2.Denominator)
            {
                Multip.Numerator = frac1.Numerator * frac2.Numerator;
                Multip.Denominator = frac1.Denominator * frac2.Denominator;
            }
            else
            {
                Multip.Numerator = frac1.Numerator * frac2.Numerator;
                Multip.Denominator = frac1.Denominator;
            }

            return Multip;
        }

        public FormClass Division(FormClass frac1, FormClass frac2)
        {
            FormClass dr = new FormClass();

            if (frac1.Denominator != frac2.Denominator)
            {
                dr.Numerator = frac1.Numerator * frac2.Denominator;
                dr.Denominator = frac1.Denominator * frac2.Numerator;
            }
            else
            {
                dr.Numerator = frac1.Numerator / frac2.Numerator;
                dr.Denominator = frac1.Denominator;
            }
            return dr;
        }
    }


}
