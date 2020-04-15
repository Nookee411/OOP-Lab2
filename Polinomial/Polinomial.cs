using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinomial
{
    class Polinomial
    {
        //Fields
        private List<double> coef= new List<double>(); //coefficients at x^index
        public int Degree => this.coef.Count - 1; 
        //Constructor
        public Polinomial()
        {
            this.coef.Add(0);
        }
        public Polinomial(double[] coef)
        {
           for(int i=0;i<coef.Length;i++)
                this.coef.Add(coef[i]);
        }
        public Polinomial(int degree)
        {
            this.coef = Enumerable.Repeat(0.0,degree).ToList();
        }

        //Methods
        public double Value(int agrument)
        {
            double res = 0D;
            for(int i=0;i<coef.Count;i++)
                res += coef[i] * Math.Pow(agrument, i);
            return res;
        }
        //Override
        public override string ToString()
        {
            string res = "";
            for(int i= coef.Count-1; i>=0;i--)
            {
                //if(coef[i]!=0)
                    res += ((coef[i] >= 0) ? " +" : " ") + coef[i].ToString() + "x^" + i.ToString();
            }
            return res;
        }

        public override bool Equals(Object obj)
        {
            Polinomial temp = (Polinomial)obj;
            bool res= true;
            if (this.Degree != temp.Degree)
                res = false;
            else
            {
                for (int i = 0; i < this.Degree + 1; i++)
                    if (this[i] != temp.Degree)
                        res = false;
            }
            return res;
        }

        public override int GetHashCode()
        {
            int sum=0;
            foreach (int ele in this.coef)
                sum += ele;
            return sum;
        }

        //Index override
        public double    this[int index]
        {
            get
            {
                if (index < 0 || index >= coef.Count)
                    throw new IndexOutOfRangeException();
                return this.coef[index];
            }
            set
            {
                if (index < 0 || index >= coef.Count)
                    throw new IndexOutOfRangeException();
                this.coef[index] = value;
            }
        }
        //Operators
      
        public static  Polinomial operator +(Polinomial Fpol, Polinomial Spol)
        {
            Polinomial result = new Polinomial();
            if (Fpol.Degree > Spol.Degree)
            {
                result.coef = Spol.coef.Concat(Enumerable.Repeat(0.0, Fpol.Degree - Spol.Degree).ToList()).ToList();
                result.coef = Fpol.coef.Zip(result.coef, (x, y) => x + y).ToList();
            }
            else
            {
                result.coef = Fpol.coef.Concat(Enumerable.Repeat(0.0, Spol.Degree - Fpol.Degree).ToList()).ToList();
                result.coef = Spol.coef.Zip(result.coef, (x, y) => x + y).ToList();
            }
            return result;
        }

        public static Polinomial operator -(Polinomial Fpol, Polinomial Spol)
        {
            Polinomial result = new Polinomial();
            if (Fpol.Degree > Spol.Degree)
            {
                result.coef = Spol.coef.Concat(Enumerable.Repeat(0.0, Fpol.Degree - Spol.Degree).ToList()).ToList();
                result.coef = Fpol.coef.Zip(result.coef, (x, y) => x - y).ToList();
            }
            else
            {
                result.coef = Fpol.coef.Concat(Enumerable.Repeat(0.0, Spol.Degree - Fpol.Degree).ToList()).ToList();
                result.coef = Spol.coef.Zip(result.coef, (x, y) => y - x).ToList();
            }
            return result;
        }

        public static Polinomial operator *(Polinomial fpol,Polinomial spol)
        {
            Polinomial res = new Polinomial(fpol.Degree + spol.Degree+1);
            for(int k1 = 0;k1<=fpol.Degree;k1++)
            {
                for(int k2 = 0;k2<=spol.Degree;k2++)
                {
                    res.coef[k1 + k2] += fpol.coef[k1] * spol.coef[k2]; 
                }
            }
            return res;
        }

        public static bool operator ==(Polinomial fpol,Polinomial spol)
        {
            if (fpol.Degree != spol.Degree)
                return false;
            for(int i=0;i<fpol.Degree+1;i++)
                if (fpol[i] != spol[i])
                    return false;
            return true;
        }
        public static bool operator !=(Polinomial fpol, Polinomial spol)
        {
            bool isequal = true;
            for (int i = 0; i < Math.Min(fpol.Degree,spol.Degree) + 1; i++)
                if (fpol[i] != spol[i])
                     isequal = false;
            return !isequal;
        }



    }
}
