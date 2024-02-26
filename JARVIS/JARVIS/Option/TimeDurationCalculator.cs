namespace JARVIS.Option
{
    public class TimeDurationCalculator : IOptionResolver
    {
        public string Key => "tdur";

        public string Name => "Time Durations";

        public string ShortDescription => "Calculate time duration";

        public double Version => throw new NotImplementedException();

        public async Task Resolve(List<string>? pParams = null)
        {
            try
            {
                string startTime = string.Empty;
                string finishTime = string.Empty;

                if (pParams?.Any() == true && pParams.Count() == 6)
                {
                    startTime = $"{pParams[2]} {pParams[3]}";

                    finishTime = $"{pParams[4]} {pParams[5]}";
                }

                if (string.IsNullOrWhiteSpace(startTime))
                {
                    Console.Write("Start (yyyy-MM-DD HH:mm:ss.m):".PadLeft(24, ' '));

                    startTime = (Console.ReadLine() ?? string.Empty);

                    if (string.IsNullOrWhiteSpace(startTime.Trim()))
                    {
                        Console.WriteLine("Invalid start time");
                        return;
                    }
                }

                if (string.IsNullOrWhiteSpace(finishTime))
                {
                    Console.Write("Finish (yyyy-MM-DD HH:mm:ss.m):".PadLeft(24, ' '));

                    finishTime = (Console.ReadLine() ?? string.Empty);

                    if (string.IsNullOrWhiteSpace(finishTime.Trim()))
                    {
                        Console.WriteLine("Invalid finish time");
                        return;
                    }
                }

                DateTime dtStartTime = DateTime.Parse(startTime);
                DateTime dtFinishTime = DateTime.Parse(finishTime);

                // Calculate duration
                TimeSpan duration = dtFinishTime - dtStartTime;

                // Display the duration
                Console.WriteLine("Time Duration: {0} days, {1} hours, {2} minutes, {3} seconds, {4} microseconds",
                    duration.Days, duration.Hours, duration.Minutes, duration.Seconds, duration.Milliseconds * 1000);

                // Alternatively, if you want to display the total duration in seconds
                Console.WriteLine("Total Days: {0} seconds", duration.TotalDays.ToString("00.00"));
                Console.WriteLine("Total Hours: {0} seconds", duration.TotalHours.ToString("00.00"));
                Console.WriteLine("Total Minutes: {0} seconds", duration.TotalMinutes.ToString("00.00"));
                Console.WriteLine("Total Seconds: {0} seconds", duration.TotalSeconds.ToString("00.00"));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
