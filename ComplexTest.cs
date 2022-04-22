using System;
using System.Globalization;
using ComplexStruct;

namespace ComplexSpace
{
    class ComplexTest
    {
        static void Main(string[] args)
        {
            #region Complex
            Random rnd = new Random();//задаю два произвольных комплексных числа    
            double a1 = rnd.Next(-100, 100);//в промежутке от -100 до 100
            double b1 = rnd.Next(-100, 100);
            double a2 = rnd.Next(-100, 100);
            double b2 = rnd.Next(-100, 100);
            Complex c2 = new Complex(a2, b2);//создаю экземпляры комплексных чисел
            Complex c1 = new Complex(a1, b1);//Imagionary, Real
            #endregion
            #region Поля
            Console.WriteLine("ImaginaryOne");
            Complex c = Complex.ImaginaryOne;//ImaginaryOne
            Console.WriteLine(c.ToString());
            Complex c3 = new Complex(0, 1);
            Console.WriteLine(c.Equals(c3));//проверяю равенство

            Console.WriteLine("One");
            Complex c4 = Complex.One;//One
            Console.WriteLine(c4.ToString());
            Complex c5 = new Complex(1, 0);
            Console.WriteLine(c4.Equals(c5));//проверяю равенство

            Console.WriteLine("Zero");
            Complex c6 = Complex.Zero;//Zero
            Console.WriteLine(c6.ToString());
            Complex c7 = new Complex(0, 0);
            Console.WriteLine(c7.Equals(c6));//проверяю равенство

            Console.WriteLine("NaN");
            Complex c8 = Complex.NaN;//NaN
            Console.WriteLine(c8.ToString());
            Complex c9 = new Complex(double.NaN,double.NaN);
            Console.WriteLine(c9.Equals(c8));//проверяю равенство
            #endregion
            #region Свойства
            Console.WriteLine("Первое комплексное число :" + c1.ToString()+",где "+c1.Real+":действительная часть, а "+c1.Imaginary+":мнимая часть.");
            Console.WriteLine("Второе комплексное число :" + c2.ToString() + ",где " + c2.Real + ":действительная часть, а " + c2.Imaginary + ":мнимая часть.");
            Console.WriteLine("Magnitude первого: |{0}|={1}", c1.ToString(), c1.Magnitude);//Magnitude
            Console.WriteLine("Phase первого: {0}={1}", c1.ToString(), c1.Phase);//Phase
            #endregion
            #region Методы
            double x = 5;
            Console.WriteLine("Abs: |{0}| = {1}", c1, Complex.Abs(c1));//модуль 

            Console.WriteLine("Conjugate: {0}", Complex.Conjugate(c1).ToString());//комплексно-сопряженное

            Console.WriteLine("Cosh: Cosh{0}) = {1}", c1, Complex.Cosh(c1));//гип косинус

            Console.WriteLine("Sinh: Sinh{0}) = {1}", c1, Complex.Sinh(c1));//гип синус

            Console.WriteLine("Divide(complex,complex): {0} / {1} = {2:N2}", c1, c2, Complex.Devide(c1, c2));///деление
            Console.WriteLine("Divide(complex,double): {0} / {1} = {2:N2}", c1, x, Complex.Devide(c1, x));
            Console.WriteLine("Divide(double,complex): {0} / {1} = {2:N2}", x, c2, Complex.Devide(x, c2));

            Console.WriteLine("Equals c1 and x :{0}", c1.Equals(x));//сравнение
            Console.WriteLine("Equals c2 and x :{0}", c2.Equals(x));

            Console.WriteLine("Exp: Exp(Log({0}) = {1}", c1, Complex.Exp(Complex.Log(c1)));//эксопоненета

            Complex c10 = Complex.FromPolarCoordinates(10, 60 * Math.PI / 180);//комплекс из координат
            Console.WriteLine("FromPolarCoordinates: {0}:", c10);
            Console.WriteLine("Magnitude: {0}", Complex.Abs(c10));
            Console.WriteLine("Phase:     {0} radians", c10.Phase);
            Console.WriteLine("Phase      {0} degrees", c10.Phase * 180 / Math.PI);
            Console.WriteLine("Atan(b/a): {0}", Math.Atan(c10.Imaginary / c10.Real));

            Console.WriteLine("Hash Code {0}:  {1}", c1, c1.GetHashCode());//Хеш-код

            Console.WriteLine("Log({0}) = {1}", c2, Complex.Exp(Complex.Log(c2)));//логарифмы
            Console.WriteLine("Log x({0}) = {1}", c2, Complex.Exp(Complex.Log(c2, x)));

            Console.WriteLine("Pow(complex,complex): {0} ^ {1} = {2}", c1, c2, Complex.Pow(c1, c2));//возведение в степень
            Console.WriteLine("Pow(complex,double){0} ^ {1} = {2}", c1, x, Complex.Pow(c1, x));

            Complex r1 = Complex.Reciprocal(c1);//обратное комлексное
            Console.WriteLine("Reciprocal check: {0:N0} x {1:N2} = {2:N2}", c1, r1, c1 * r1);

            Console.WriteLine("Sqrt: {0}^0,5= {1}", c1, Complex.FromPolarCoordinates(Math.Sqrt(c1.Magnitude), c1.Phase / 2));//корень квадратный

            CultureInfo[] cultures = { new CultureInfo("en-US") };

            Console.WriteLine("ToString(): {0}= {1}", c1, c1.ToString());//строковое представление
            Console.WriteLine("ToString(IFormatProvider): {0}= {1}", c1, c1.ToString("F2"));
            Console.WriteLine("ToString(String): {0}= {1}({2})", c1, c1.ToString("en-US"), cultures);

            Console.WriteLine("Проверка Parse");
            Console.WriteLine(Complex.Parse("(123:-456)\n"));//проверка Parse
            Console.WriteLine(Complex.Parse("(-563:74)"));

            Console.WriteLine("Проверка TryParse");
            Console.WriteLine(Complex.TryParse("(123:-456)\n"));//проверка TryParse
            Console.WriteLine(Complex.TryParse("(12g3:-456)"));
            #endregion
            #region Операторы
            Console.WriteLine("Addition(complex,complex): {0} + {1} = {2}", c1, c2, c1 + c2);//сложение
            Console.WriteLine("Addition(double,complex): {0} + {1} = {2}", x, c2, x + c2);
            Console.WriteLine("Addition(complex, double): {0} + {1} = {2}", c1, x, c1 + x);

            Console.WriteLine("Division(complex,complex): {0} / {1} = {2}", c1, c2, c1 / c2);//деление
            Console.WriteLine("Division(double,complex): {0} / {1} = {2}", x, c2, x / c2);
            Console.WriteLine("Division(complex, double): {0} / {1} = {2}", c1, x, c1 / x);

            Console.WriteLine("Equality: {0} == {1} => {2}", c1, c2, c1 == c2);//равенство

            Complex c11 = Math.PI;//неявное преобраование
            Console.WriteLine("Implicit(double to complex):{0,30}-->{1} ", Math.PI, c11);

            Console.WriteLine("Inequality: {0} != {1} => {2}", c1, c2, c1 != c2);//неравенство

            Console.WriteLine("Multiply(complex,complex): {0} * {1} = {2}", c1, c2, c1 * c2);//умножение
            Console.WriteLine("Multiply(complex,double): {0} * {1} = {2}", c1, x, c1 * x);
            Console.WriteLine("Multiply(double,complex): {0} * {1} = {2}", x, c2, x * c2);

            Console.WriteLine("Subtraction(complex,complex): {0} - {1} = {2}", c1, c2, c1 - c2);//вычитание
            Console.WriteLine("Subtraction(double,complex): {0} - {1} = {2}", x, c2, x - c2);
            Console.WriteLine("Subtraction(complex, double): {0} - {1} = {2}", c1, x, c1 - x);
            #endregion
            Console.ReadLine();
        }
    }
}
