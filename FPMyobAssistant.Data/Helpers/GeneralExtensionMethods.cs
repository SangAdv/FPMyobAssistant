using System;

namespace FPMyobAssistant
{
    public static class GeneralExtensionMethods
    {
        public static float Round(this float number, int decimalPlaces, MidpointRounding roundingMethod = MidpointRounding.ToEven)
        {
            return (float)Math.Round(number, decimalPlaces, roundingMethod);
        }
    }
}