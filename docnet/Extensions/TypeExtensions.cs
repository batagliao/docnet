using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using docnet.Models;

namespace docnet.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns category of type: Class, Enumeration, Delegate, Strucuture and Interface
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TypeCategoryEnum GetCategory(this Type type)
        {
            if (type.IsSubclassOf(typeof(MulticastDelegate)))
                return TypeCategoryEnum.Delegate;
            if (type.IsClass)
                return TypeCategoryEnum.Class;
            if (type.IsEnum)
                return TypeCategoryEnum.Enumeration;
            if (type.IsInterface)
                return TypeCategoryEnum.Interface;
            if (type.IsValueType && !type.IsEnum)
                return TypeCategoryEnum.Strucutre;

            return TypeCategoryEnum.Class;
        }

        //public static string GetModifierText(this TypeInfo type)
        //{
        //    //type.IsClass

        //    if(type.IsAbstract)
        //        if(type.IsEnum)
        //            if(type.IsGenericType)
        //                if(type.IsInterface)
        //                    if(type.IsNotPublic) //private
        //                        if(type.IsPublic) //public
        //                            if(type.IsSealed)
        //                                if(type.IsVisible) //if false > internal
        //}
    }
}
