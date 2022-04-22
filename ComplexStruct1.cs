using System;
using System.Globalization;

namespace ComplexStruct
{
    public struct Complex : IFormattable, IEquatable<Complex>
    {
        #region Complex
        public double Real
        { private set; get; }
        public double Imaginary
        { private set; get; }
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        #endregion
        #region Fields
        public static readonly Complex ImaginaryOne = new Complex(0, 1);
        public static readonly Complex One = new Complex(1, 0);
        public static readonly Complex Zero = new Complex(0, 0);
        public static readonly Complex NaN = new Complex(double.NaN, double.NaN);
        #endregion
        #region Operators
        public static Complex operator +(Complex c1, Complex c2) => new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        public static Complex operator -(Complex c1, Complex c2) => new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        public static Complex operator -(Complex c) => new Complex(-c.Real, -c.Imaginary);
        public static Complex operator *(Complex c1, Complex c2) => new Complex(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary, c1.Real * c2.Imaginary + c2.Real * c1.Imaginary);
        public static Complex operator *(Complex C, double d) => new Complex(C.Real * d, C.Imaginary * d);
        public static Complex operator *(double d, Complex C) => new Complex(C.Real * d, C.Imaginary * d);
        public static Complex operator /(Complex c1, Complex c2) => new Complex(Conjugate(c1 * c2).Real / c2.Magnitude / c2.Magnitude, Conjugate(c1 * c2).Imaginary / c2.Magnitude / c2.Magnitude);
        public static bool operator ==(Complex c1, Complex c2)
        {
            if (c1.Real == c2.Real && c1.Imaginary == c2.Imaginary)
            { return true; }
            else return false;
        }
        public static bool operator !=(Complex c1, Complex c2)
        {
            if (c1.Real != c2.Real || c1.Imaginary != c2.Imaginary)
            { return true; }
            else return false;

        }
        public static implicit operator Complex(double d) => new Complex(d, 0);
        #endregion
        #region Properities 
        public double Magnitude => Math.Sqrt(Real * Real + Imaginary * Imaginary);
        public double Phase => Math.Acos(Real / Magnitude);
        #endregion
        #region Methods
        public static Complex Cos(Complex c) => new Complex(Math.Cos(c.Real) * Math.Cosh(c.Imaginary), -(Math.Sin(c.Real) * Math.Sinh(c.Imaginary)));
        public static Complex FromPolarCoordinates(double magnitude, double phase) => new Complex(magnitude * Math.Cos(phase), magnitude * Math.Sin(phase));
        public static Complex Cosh(Complex c) => new Complex(Math.Cosh(c.Real) * Math.Cos(c.Imaginary), Math.Sinh(c.Real) * Math.Sin(c.Imaginary));
        public static Complex Sin(Complex c) => new Complex(Math.Sin(c.Real) * Math.Cosh(c.Imaginary), Math.Cos(c.Real) * Math.Sinh(c.Imaginary));
        public static Complex Sinh(Complex c) => new Complex(Math.Sinh(c.Real) * Math.Cos(c.Imaginary), Math.Cosh(c.Real) * Math.Sin(c.Imaginary));
        public static Complex Tan(Complex c) => Sin(c) / Cos(c);
        public static Complex Tanh(Complex c) => Sinh(c) / Cosh(c);
        public static double Abs(Complex c) => c.Magnitude;
        public static Complex Conjugate(Complex c) => new Complex(c.Real, -c.Imaginary);
        public static Complex Exp(Complex c) => Math.Exp(c.Real) * new Complex(Math.Cos(c.Imaginary), Math.Sin(c.Imaginary));
        public static Complex Reciprocal(Complex c) => One / c;
        public static Complex Devide(Complex c1, Complex c2) => new Complex((c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / (c2.Magnitude * c2.Magnitude), (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / (c2.Magnitude * c2.Magnitude));
        public static Complex Pow(Complex c, double d) => new Complex(Math.Cos(d * c.Phase) * Math.Pow(c.Magnitude, d), Math.Sin(d * c.Phase) * Math.Pow(c.Magnitude, d));
        public static Complex Log(Complex c) => new Complex(Math.Log(c.Magnitude), c.Phase * Math.Log(Math.E));
        public static Complex Log(Complex c, double d) => new Complex(Math.Log(c.Magnitude) / Math.Log(d), c.Phase * Math.Log(Math.E) / Math.Log(d));
        public static Complex Pow(Complex c1, Complex c2) => Complex.Exp(c2 * Complex.Log(c1));
        #endregion
        #region Realization of interfaces
        public string ToString(string format = null, IFormatProvider formatprovider = null)
        {
            return ("("+Real.ToString(format,formatprovider)+":"+Imaginary.ToString(format,formatprovider)+")");
        }
        public bool Equals(Complex other)
        {
            return Equals((object)other);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
        #region Parse
        public static Complex Parse(string k)
        {
            double re = Double.Parse(k.Substring(k.IndexOf("(") + 1, k.IndexOf(":") - k.IndexOf("(") - 1));
            double im = Double.Parse(k.Substring(k.IndexOf(":") + 1, k.IndexOf(")") - k.IndexOf(":") - 1));
            return new Complex(re, im);
        }
        #endregion
        #region TryParse
        public static bool TryParse(string m)
        {
            if (m.Contains("(") == true && m.Contains(")") == true && m.Contains(":") == true && m.IndexOf(")") > m.IndexOf(":") && m.IndexOf(":") > m.IndexOf("("))
            {
                bool re1 = Double.TryParse((m.Substring(m.IndexOf("(") + 1, m.IndexOf(":") - m.IndexOf("(") - 1)), out double n1);
                bool im1 = Double.TryParse((m.Substring(m.IndexOf(":") + 1, m.IndexOf(")") - m.IndexOf(":") - 1)), out double n2);
                if (re1 == true && im1 == true)
                {
                    Complex c = new Complex(n1, n2);
                    Console.WriteLine(c);
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        #endregion
    }
}
