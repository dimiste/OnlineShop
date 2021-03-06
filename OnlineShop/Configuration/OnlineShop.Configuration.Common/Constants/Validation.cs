﻿namespace OnlineShop.Configuration.Common.Constants
{
    public static class Validation
    {
        public static class Regexs
        {
            public const string EnBgNumSpaceMinus = @"^[a-zA-Zа-яА-Я0-9\-\s]+$";
            public const string EnBgNumSpace = @"^[a-zA-Zа-яА-Я0-9\s]+$";
            public const string EnBgNumSpaceMinusPlusMore = @"^[a-zA-Zа-яА-Я0-9\-\s\+\!\?]+$";
            public const string EnBgNumSpaceQuotesMinusPlusMore = @"^[a-zA-Zа-яА-Я0-9\-\s\+\!\?""\']+$";
        }

        public static class CategoryValidations
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 30;
        }

        public static class ProductValidations
        {
            public const int ProductIdMinLenght = 2;
            public const int ProductIdMaxLenght = 50;
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 50;
        }

        public static class PhotoItemValidations
        {
            public const int SmallSizeUrlMaxLenght = 200;
            public const int FullSizeUrlMaxLenght = 200;
        }
    }
}
