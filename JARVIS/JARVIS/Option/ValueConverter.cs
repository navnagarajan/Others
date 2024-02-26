namespace JARVIS.Option
{
    public class ValueConverter : IOptionResolver
    {
        public string Key => "vc";

        public string Name => "Value Converter";

        public string ShortDescription => "Convert source string value into other formats";

        public double Version => 1.0;

        private readonly string INVALID_CONVERT_NOTATION = "-";

        public async Task Resolve()
        {
            Console.Write("Enter the Source (comma separated string): ");
            string value = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(value.Trim()))
            {
                return;
            }

            Console.WriteLine("1] Hexdecimal, 2] Decimal, 3] Binary");
            Console.Write("Source Type: ");
            string option = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(option, out int valueInt) != true)
            {
                return;
            }

            switch (valueInt)
            {
                case 1:
                    ConvertFromHex(value);
                    break;
                case 2:
                    ConvertFromDecimal(value);
                    break;
                case 3:
                    ConvertFromBinary(value);
                    break;
                default:
                    break;
            }
        }

        private void ConvertFromHex(string pText)
        {
            var values = pText.Split(",");

            if (values?.Any() != true)
            {
                return;
            }
            string source = string.Empty;
            string asInt = string.Empty;
            string asBinary = string.Empty;

            foreach (var item in values)
            {
                try
                {
                    string data = item?.Trim() ?? string.Empty;
                    source += $"{item}";
                    int intValue = HexToInt(data);
                    asInt += $"{intValue.ToString().PadLeft(2, '0')}";
                    asBinary += $"{IntToBinary(intValue)}";
                }
                catch (Exception)
                {
                    asInt += $"{INVALID_CONVERT_NOTATION}";
                    asBinary += $"{INVALID_CONVERT_NOTATION}";
                }
                finally
                {
                    if (item != values.Last())
                    {
                        source += ",";
                        asInt += ",";
                        asBinary += ",";
                    }
                }
            }

            Console.WriteLine($"{PadColumn("Source")}: {source}");
            Console.WriteLine($"{PadColumn("Decimal")}: {asInt}");
            Console.WriteLine($"{PadColumn("Binary")}: {asBinary}");
        }

        private string PadColumn(string pText)
        {
            return pText.PadLeft(2, ' ');
        }

        private void ConvertFromDecimal(string pText)
        {
            var values = pText.Split(",");

            if (values?.Any() != true)
            {
                return;
            }

            string source = string.Empty;
            string asHex = string.Empty;
            string asBinary = string.Empty;

            foreach (var item in values)
            {
                try
                {
                    string data = item?.Trim() ?? string.Empty;
                    source += $"{item}";

                    if (int.TryParse(data, out var decValue) != true)
                    {

                        asHex += $"{INVALID_CONVERT_NOTATION}";
                        asBinary += $"{INVALID_CONVERT_NOTATION}";
                        continue;
                    }

                    asHex += $"{IntToHex(decValue)}";
                    asBinary += $"{IntToBinary(decValue)}";
                }
                catch (Exception)
                {
                    asHex += $"{INVALID_CONVERT_NOTATION}";
                    asBinary += $"{INVALID_CONVERT_NOTATION}";
                }
                finally
                {
                    if (item != values.Last())
                    {
                        source += ",";
                        asHex += ",";
                        asBinary += ",";
                    }
                }
            }

            Console.WriteLine($"{PadColumn("Source")}: {source}");
            Console.WriteLine($"{PadColumn("Hex")}: {asHex}");
            Console.WriteLine($"{PadColumn("Binary")}: {asBinary}");
        }

        private void ConvertFromBinary(string pText)
        {
            var values = pText.Split(",");

            if (values?.Any() != true)
            {
                return;
            }
            string source = string.Empty;
            string asInt = string.Empty;
            string asHex = string.Empty;

            foreach (var item in values)
            {
                try
                {
                    string data = item?.Trim() ?? string.Empty;
                    source += $"{item}";

                    if (data.Any(A => char.IsLetter(A) == true || (A != '0' && A != '1')))
                    {
                        asInt += $"{INVALID_CONVERT_NOTATION}";
                        asHex += $"{INVALID_CONVERT_NOTATION}";
                        continue;
                    }

                    asInt += $"{BinaryToInt(data)}";
                    asHex += $"{IntToHex(BinaryToInt(data))}";
                }
                catch (Exception)
                {
                    asInt += $"{INVALID_CONVERT_NOTATION}";
                    asHex += $"{INVALID_CONVERT_NOTATION}";
                }
                finally
                {
                    if (item != values.Last())
                    {
                        source += ",";
                        asInt += ",";
                        asHex += ",";
                    }
                }
            }

            Console.WriteLine($"{PadColumn("Source")}: {source}");
            Console.WriteLine($"{PadColumn("Hex")}: {asHex}");
            Console.WriteLine($"{PadColumn("Decimal")}: {asInt}");
        }

        private int HexToInt(string pText) => Convert.ToInt32(pText, 16);
        private string IntToBinary(int pValue) => Convert.ToString(pValue, 2).PadLeft(4, '0');
        private string IntToHex(int pValue) => pValue.ToString("X2");
        private int BinaryToInt(string pValue) => Convert.ToInt32(pValue, 2);
    }
}
