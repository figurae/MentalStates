using System;
using System.Linq;

namespace MentalStates.Extensions
{
    public static class Mathematics
    {
        public static float Lerp(this float a, float b, float t)
        {
            t = Math.Clamp(t, 0.0f, 1.0f);
            return a * (1 - t) + b * t;
        }

        public static Colour Lerp(this Colour a, Colour b, float t)
        {
            float   red = Lerp(a.Red, b.Red, t),
                    green = Lerp(a.Green, b.Green, t),
                    blue = Lerp(a.Blue, b.Blue, t),
                    alpha = Lerp(a.Alpha, b.Alpha, t);

            return new Colour(red, green, blue, alpha);
        }

        public static Colour Lerp(this Colour a, float t, params Colour[] colours)
        {
            Colour[] allColours = new Colour[colours.Length + 1];
            allColours[0] = a;
            colours.CopyTo(allColours, 1);

            float range = 1/(float)(colours.Length);

            for (int i = 1; i <= allColours.Length; i++)
            {
                if (t <= i * range)
                {
                    return Lerp(allColours[i - 1], allColours[i], t.Map((i - 1) * range, i * range, 0.0f, 1.0f));
                }
            }

            return Colour.Black;
        }

        public static Colour Clamp(this Colour colour, Colour min, Colour max)
        {
            float   red = Math.Clamp(colour.Red, min.Red, max.Red),
                    green = Math.Clamp(colour.Green, min.Green, max.Green),
                    blue = Math.Clamp(colour.Blue, min.Blue, max.Blue),
                    alpha = Math.Clamp(colour.Alpha, min.Alpha, max.Alpha);

            return new Colour(red, green, blue, alpha);
        }

        public static float Map(this float value, float fromLow, float fromHigh, float toLow, float toHigh)
        {
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }

        public static float Normalize(this float value, float min, float max)
        {
            return Map(value, min, max, 0.0f, 1.0f);
        }

        public static bool CheckPowerOfTwo(this int n)
        {
            return n != 0 && ((n & (n - 1)) == 0);
        }
    }
}