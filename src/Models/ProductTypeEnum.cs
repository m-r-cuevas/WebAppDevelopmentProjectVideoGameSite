using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleCafe.WebSite.Models
{
    public enum ProductTypeEnum
    {
        Undefined = 0,
        FPS = 1,
        Racing = 2,
        Sports = 3,
    }

    public static class ProductTypeEnumExtensions
    {
        public static string DisplayName(this ProductTypeEnum data)
        {
            return data switch
            {
                ProductTypeEnum.FPS => "First Person Shooter Game",
                ProductTypeEnum.Racing => "Racing Game",
                ProductTypeEnum.Sports => "Sports Game",

                // Default, Unknown
                _ => "",
            } ;
        }
    }
}