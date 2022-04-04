
namespace MarsRoverProblem.Core.Constant.EnumExtensions
{
    public static class EnumExtensions
    {
        /// <summary>To the enum value.</summary>
        /// <typeparam name="T">The enum type to cast to.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T ToEnumValue<T>(this string value) where T : System.Enum
        {
            try
            {
                return (T)System.Enum.Parse(typeof(T), value);
            }
            catch
            {
                return default;
            }
        }
    }
}
