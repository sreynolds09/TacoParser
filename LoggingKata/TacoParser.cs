using System;
using System.Linq;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        static ILog logger = new TacoLogger();
        
        public static ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            if (string.IsNullOrWhiteSpace(line))
            {
                logger.LogWarning("Input line is null or empty.");
                return null;
            }

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogError("Not enough information to parse.");
                return null;
            }

            // TODO: Grab the latitude from your array at index 0--DONE
            // TODO: Grab the longitude from your array at index 1--DONE
            // You're going to need to parse your string as a `double` which is similar to parsing a string as an `int`
            //TODO: Grab the name from your array at index 2--DONE

            double latitude;
            double longitude;

            if (!double.TryParse(cells[0], out latitude) || !double.TryParse(cells[1], out longitude))
            {
                logger.LogError("Failed to parse latitude or longitude.");
                return null;
            }

            var name = cells[2];


            var point = new Point()
            {
                Latitude = latitude,
                Longitude = longitude
            };

            var tacoBell = new TacoBell()
            {
                Name = name,
                Location = point
            };

            return tacoBell;
            // TODO: Create a TacoBell class that conforms to ITrackable
            

            // TODO: Create an instance of the Point Struct
      
            // TODO: Set the values of the point correctly (Latitude and Longitude) 

            // TODO: Create an instance of the TacoBell class
            // TODO: Set the values of the class correctly (Name and Location)

            // TODO: Then, return the instance of your TacoBell class,since it conforms to ITrackable
        }
    }
}
