using Mirage.Generators.BaseClasses;
using Mirage.Interfaces;

namespace Mirage.Generators.ContactInfo
{
    /// <summary>
    /// TimeZone generator attribute
    /// </summary>
    /// <seealso cref="StringGeneratorBase"/>
    public sealed class TimeZoneAttribute : StringGeneratorBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TimeZoneAttribute()
            : base("", "")
        {
        }

        /// <summary>
        /// The TimeZone list
        /// </summary>
        private static readonly string[] TimeZoneList = {"Pacific/Midway",
      "Pacific/Pago_Pago",
      "Pacific/Honolulu",
      "America/Juneau",
      "America/Los_Angeles",
      "America/Tijuana",
      "America/Denver",
      "America/Phoenix",
      "America/Chihuahua",
      "America/Mazatlan",
      "America/Chicago",
      "America/Regina",
      "America/Mexico_City",
      "America/Mexico_City",
      "America/Monterrey",
      "America/Guatemala",
      "America/New_York",
      "America/Indiana/Indianapolis",
      "America/Bogota",
      "America/Lima",
      "America/Lima",
      "America/Halifax",
      "America/Caracas",
      "America/La_Paz",
      "America/Santiago",
      "America/St_Johns",
      "America/Sao_Paulo",
      "America/Argentina/Buenos_Aires",
      "America/Guyana",
      "America/Godthab",
      "Atlantic/South_Georgia",
      "Atlantic/Azores",
      "Atlantic/Cape_Verde",
      "Europe/Dublin",
      "Europe/London",
      "Europe/Lisbon",
      "Europe/London",
      "Africa/Casablanca",
      "Africa/Monrovia",
      "Etc/UTC",
      "Europe/Belgrade",
      "Europe/Bratislava",
      "Europe/Budapest",
      "Europe/Ljubljana",
      "Europe/Prague",
      "Europe/Sarajevo",
      "Europe/Skopje",
      "Europe/Warsaw",
      "Europe/Zagreb",
      "Europe/Brussels",
      "Europe/Copenhagen",
      "Europe/Madrid",
      "Europe/Paris",
      "Europe/Amsterdam",
      "Europe/Berlin",
      "Europe/Berlin",
      "Europe/Rome",
      "Europe/Stockholm",
      "Europe/Vienna",
      "Africa/Algiers",
      "Europe/Bucharest",
      "Africa/Cairo",
      "Europe/Helsinki",
      "Europe/Kiev",
      "Europe/Riga",
      "Europe/Sofia",
      "Europe/Tallinn",
      "Europe/Vilnius",
      "Europe/Athens",
      "Europe/Istanbul",
      "Europe/Minsk",
      "Asia/Jerusalem",
      "Africa/Harare",
      "Africa/Johannesburg",
      "Europe/Moscow",
      "Europe/Moscow",
      "Europe/Moscow",
      "Asia/Kuwait",
      "Asia/Riyadh",
      "Africa/Nairobi",
      "Asia/Baghdad",
      "Asia/Tehran",
      "Asia/Muscat",
      "Asia/Muscat",
      "Asia/Baku",
      "Asia/Tbilisi",
      "Asia/Yerevan",
      "Asia/Kabul",
      "Asia/Yekaterinburg",
      "Asia/Karachi",
      "Asia/Karachi",
      "Asia/Tashkent",
      "Asia/Kolkata",
      "Asia/Kolkata",
      "Asia/Kolkata",
      "Asia/Kolkata",
      "Asia/Kathmandu",
      "Asia/Dhaka",
      "Asia/Dhaka",
      "Asia/Colombo",
      "Asia/Almaty",
      "Asia/Novosibirsk",
      "Asia/Rangoon",
      "Asia/Bangkok",
      "Asia/Bangkok",
      "Asia/Jakarta",
      "Asia/Krasnoyarsk",
      "Asia/Shanghai",
      "Asia/Chongqing",
      "Asia/Hong_Kong",
      "Asia/Urumqi",
      "Asia/Kuala_Lumpur",
      "Asia/Singapore",
      "Asia/Taipei",
      "Australia/Perth",
      "Asia/Irkutsk",
      "Asia/Ulaanbaatar",
      "Asia/Seoul",
      "Asia/Tokyo",
      "Asia/Tokyo",
      "Asia/Tokyo",
      "Asia/Yakutsk",
      "Australia/Darwin",
      "Australia/Adelaide",
      "Australia/Melbourne",
      "Australia/Melbourne",
      "Australia/Sydney",
      "Australia/Brisbane",
      "Australia/Hobart",
      "Asia/Vladivostok",
      "Pacific/Guam",
      "Pacific/Port_Moresby",
      "Asia/Magadan",
      "Asia/Magadan",
      "Pacific/Noumea",
      "Pacific/Fiji",
      "Asia/Kamchatka",
      "Pacific/Majuro",
      "Pacific/Auckland",
      "Pacific/Auckland",
      "Pacific/Tongatapu",
      "Pacific/Fakaofo",
      "Pacific/Apia" };

        /// <summary>
        /// Gets a value indicating whether this <see cref="IGenerator"/> is a default one.
        /// </summary>
        /// <value><c>true</c> if default; otherwise, <c>false</c>.</value>
        public override bool Default => false;

        /// <summary>
        /// Generates a random value of the specified type
        /// </summary>
        /// <param name="rand">Random number generator that it can use</param>
        /// <returns>A randomly generated object of the specified type</returns>
        public override string Next(Random rand)
        {
            return rand.Next(TimeZoneList);
        }
    }
}