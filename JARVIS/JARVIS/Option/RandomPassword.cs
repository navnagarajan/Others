namespace JARVIS.Option
{
    public class RandomPassword : IOptionResolver
    {
        private static readonly Random random = new();
        private const string chars = "@#$%*AaBbCcDdEeFfGgHhIjJiKkLlMmNnOoPpQqRrSsTtUuVvWwXzYyZz0123456789";

        public string Key => "rnd-psw";
        public string Name => "Random Password";
        public string ShortDescription => "Generate random password";
        public double Version => 1.0;


        public async Task Resolve()
        {
            Console.WriteLine("Enter length for Random Password (default is 8):");
            
            string? lengthInStr = Console.ReadLine();
            _ = int.TryParse(lengthInStr, out int length);
            if (length < 1)
            {
                length = 8;
            }

            Console.WriteLine(Generate(length));
        }
        public static string Generate(int length = 8)
        {
            return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
