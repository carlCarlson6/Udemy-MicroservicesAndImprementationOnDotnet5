namespace Basket.API.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullEmptyOrWhitespace(this string input) => string.IsNullOrWhiteSpace(input);
    }
}