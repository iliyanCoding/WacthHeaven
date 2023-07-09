using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchHeaven.Common
{
    public static class EntityValidationConstants
    {
        public static class Category
        {
            public const int NameMaxLength = 20;
            public const int NameMinLength = 2;
        }

        public static class Condition
        {
            public const int NameMaxLength = 20;
            public const int NameMinLength = 2;
        }

        public static class Watch
        {
            public const int BrandMaxLength = 30;
            public const int BrandMinLength = 3;

            public const int ModelMaxLength = 50;
            public const int ModelMinLength = 3;

            public const int DescriptionMaxLength = 500;
            public const int DescriptionMinLength = 10;

            public const int ImageUrlMaxLength = 2048;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "55000000";

            public const int YearOfManufactureMinValue = 1510;
            public const int YearOfManufactureMaxValue = 2023;

        }
    }
}
