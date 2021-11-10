using System;

namespace MentalStates.Extensions
{
    // is mutable struct a good idea here? SharpDX does this as well and a class seems weird.
    public struct Colour : IEquatable<Colour>, IFormattable
    {
        public float Red, Green, Blue, Alpha;

        public static readonly Colour   Black = new Colour(0.0f, 0.0f, 0.0f, 1.0f),
                                        White = new Colour(255.0f, 255.0f, 255.0f, 1.0f),
                                        GreenYellow = new Colour(171.0f, 255.0f, 46.0f),
                                        Crimson = new Colour(219.0f, 20.0f, 60.0f),
                                        Gold = new Colour(255.0f, 217.0f, 0.0f);


        // params or split into multiple constructors?
        public Colour(params float[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            if (values.Length is not (1 or 3 or 4))
            {
                throw new ArgumentOutOfRangeException("values", "Colour takes 1, 3 or 4 input values (grey, RGB, or RGBA).");
            }

            switch (values.Length)
            {
                case 1:
                    Red = values[0];
                    Green = values[0];
                    Blue = values[0];
                    Alpha = 1.0f;
                    break;
                case 3:
                    Red = values[0];
                    Green = values[1];
                    Blue = values[2];
                    Alpha = 1.0f;
                    break;
                case 4:
                    Red = values[0];
                    Green = values[1];
                    Blue = values[2];
                    Alpha = values[3];
                    break;
                default:
                    Red = 0.0f;
                    Green = 0.0f;
                    Blue = 0.0f;
                    Alpha = 1.0f;
                    break;
            }
        }

        public bool Equals(Colour other)
        {
            return Red == other.Red && Green == other.Green && Blue == other.Blue && Alpha == other.Alpha;
        }

        // should return round numbers.
        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }
}