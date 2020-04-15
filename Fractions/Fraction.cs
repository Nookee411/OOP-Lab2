using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{

    class Fraction
    {
        private int numerator;
        private int denominator;

        //Constructor 
        public Fraction(int num, int denum)
        {
            if (denum == 0)
                throw new ArgumentException("Denuminator must be different form zero");
            Fraction.Simplify(ref num, ref denum);
            this.numerator = num;
            this.denominator = denum;
            
            
        }
        //override
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            Fraction a = f1, b = f2;
            Fraction.Simplify(ref a.numerator,ref b.denominator);
            Fraction.Simplify(ref a.denominator, ref b.numerator);
            return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int commonDenum = NOK(f1.denominator, f2.denominator);
            f1.numerator *= commonDenum / f1.denominator;
            f2.numerator *= commonDenum / f2.denominator;
            return new Fraction(f1.numerator + f2.numerator, commonDenum);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int commonDenum = NOK(f1.denominator, f2.denominator);
            f1.numerator *= commonDenum / f1.denominator;
            f2.numerator *= commonDenum / f2.denominator;
            return new Fraction(f1.numerator - f2.numerator, commonDenum);
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            Fraction a = f1, b = f2;
            Fraction.Simplify(ref a.numerator, ref b.numerator);
            Fraction.Simplify(ref a.denominator, ref b.denominator);
            return new Fraction(a.numerator*b.denominator, a.denominator*b.numerator);
        }
        public static Fraction operator -(Fraction f)
        {
            return new Fraction(-f.numerator, f.denominator);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Fraction a,Fraction b)
        {
            return !a.Equals(b);
        }

        public Fraction Pow(int n)
        {
            numerator = (int)Math.Pow(numerator, n);
            denominator = (int)Math.Pow(denominator, n);
            return new Fraction(numerator,denominator);
        }
        public override string ToString()
        {
            return numerator.ToString() + "/" + denominator.ToString();
        }

        public override bool Equals(object obj)
        {
            Fraction a = (Fraction)obj;
            return (a.numerator == this.numerator && a.denominator == this.denominator);
        }

        public override int GetHashCode()
        {
            return numerator + denominator;
        }

        public static explicit operator int(Fraction a)
        {
            return a.numerator / a.denominator;
        }
        public static implicit operator double(Fraction a)
        {
            return (double)a.numerator / a.denominator;
        }

        public static bool operator >(Fraction a,Fraction b)
        {
            return (a > b);
        }
        public static bool operator <(Fraction a,Fraction b)
        {
            return (a < b);
        }
        //Private methods
        private static int NOD(int n1, int n2)
        {
            int div;
            if (n1 == n2) return n1;
            int d = n1 - n2;
            if (d < 0)
            {
                d = -d; div = NOD(n1, d);
            }
            else
                div = NOD(n2, d);
            return div;
        }
        private static int NOK(int n1, int n2)
        {
            return n1 * n2 / NOD(n1, n2);
        }

        private static void Simplify(ref int num,ref int denum)
        {
            int nod = NOD(num, denum);
            num /= nod;
            denum /= nod;
        }

        public static void Simplify(ref Fraction a)
        {
            int num = a.numerator;
            int denum = a.denominator;
            int nod = NOD(num, denum);
            num /= nod;
            denum /= nod;
            a = new Fraction(num, denum);
        }

        
    }
}
//implicit explicit

