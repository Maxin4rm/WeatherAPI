namespace WeatherApp.Server
{
    public static class CharExtension
    {
        public static bool IsValueSymbol(this char c)
        {
            return (Char.IsLetter(c) || Char.IsDigit(c) || c == '_' || c == '.');
        }
    }
}
