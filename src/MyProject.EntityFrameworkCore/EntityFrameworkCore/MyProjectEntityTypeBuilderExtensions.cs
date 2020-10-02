using System;
using System.Reflection;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyProject.EntityFrameworkCore
{
    public static class MyProjectEntityTypeBuilderExtensions
    {
        /// <summary>
        /// 配置String类型 默认长度
        /// </summary>
        /// <param name="b"></param>
        /// <param name="len"></param>
        public static void ConfigureStringDefaultLength(this EntityTypeBuilder b, int maxLength = 50)
        {
            Type type = b.Metadata.ClrType;
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in props)
            {
                if (item.PropertyType == typeof(string))
                {
                    b.Property(item.Name).HasMaxLength(maxLength);
                }
            }
        }
    }
}
