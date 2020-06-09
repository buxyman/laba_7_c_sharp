using System;
using System.Collections.Generic;
using System.Text;

namespace laba7
{
    class RationalFraction : IComparable, IEquatable<RationalFraction>
    {
        private readonly int _numerator;
        private readonly int _denominator;
        public RationalFraction(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }
        public RationalFraction(string num)
        {
            char[] numer = new char[24];
            char[] denom = new char[24];
            int i = 0;
            for (int j = 0; i < num.Length; i++, j++)
            {
                if (num[i] == '/' || num[i] == ':')
                {
                    numer[j] = '\0';
                    i++;
                    break;
                }
                numer[j] = num[i];
            }
            for (int j = 0; i < num.Length; i++, j++)
            {
                denom[j] = num[i];
            }
            string str1 = new string(numer);
            string str2 = new string(denom);
            _numerator = Convert.ToInt32(str1);
            _denominator = Convert.ToInt32(str2);
            if (_denominator == 0) throw new Exception("Неверное значение");
        }

        public static RationalFraction operator +(RationalFraction a, RationalFraction b)
        {
            RationalFraction res;
            res = new RationalFraction(a._numerator * b._denominator + b._numerator * a._denominator, a._denominator * b._denominator);
            return res;
        }

        public static RationalFraction operator -(RationalFraction a, RationalFraction b)
        {
            RationalFraction res;
            res = new RationalFraction(a._numerator * b._denominator - b._numerator * a._denominator, a._denominator * b._denominator);
            return res;
        }

        public static RationalFraction operator *(RationalFraction a, RationalFraction b)
        {
            RationalFraction res;
            res = new RationalFraction(a._numerator * b._numerator, a._denominator * b._denominator);
            return res;
        }

        public static RationalFraction operator /(RationalFraction a, RationalFraction b)
        {
            RationalFraction res;
            res = new RationalFraction(a._numerator * b._denominator, a._denominator * b._numerator);
            return res;
        }

        public static bool operator <(RationalFraction a, RationalFraction b)
        {
            return (a.CompareTo(b) == -1) ? true : false;
        }

        public static bool operator >(RationalFraction a, RationalFraction b)
        {
            return (a.CompareTo(b) == 1) ? true : false;
        }

        public static bool operator >=(RationalFraction a, RationalFraction b)
        {
            return (a.CompareTo(b) == -1) ? false : true;
        }
        
        public static bool operator <=(RationalFraction a, RationalFraction b)
        {
            return (a.CompareTo(b) == 1) ? false : true;
        }

        public static bool operator ==(RationalFraction a, RationalFraction b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(RationalFraction a, RationalFraction b)
        {
            return !a.Equals(b);
        }

        public int CompareTo(object o)
        {
            if (o is RationalFraction num)
            {
                if (_numerator * num._denominator < num._numerator * _denominator)
                    return -1;
                if (_numerator * num._denominator > num._numerator * _denominator)
                    return 1;
                return 0;
            }
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public bool Equals(RationalFraction a)
        {
            if (a is null)
                return false;
            return _numerator * a._denominator == a._numerator * _denominator;
        }

        public override bool Equals(Object obj)
        {
            return (obj is RationalFraction num)?Equals(num):false;
        }

        public static implicit operator double(RationalFraction a)
        {
            return (double)a._numerator / a._denominator;
        }

        public static implicit operator float(RationalFraction a)
        {
            return (float)a._numerator / a._denominator;
        }

        public static implicit operator int(RationalFraction a)
        {
            return a._numerator / a._denominator;
        }

        public static implicit operator string(RationalFraction a) 
        {
            return a.ToString();
        }

        public static explicit operator RationalFraction(string a)
        {
            return new RationalFraction(a);
        }

        public override string ToString()
        {
            return ($"{_numerator}/{_denominator}");
        }
    }
}
