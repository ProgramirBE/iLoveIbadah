using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbadahLover.Application.DTOs.Enums
{
    public enum WarningType
    {
        HaramFullName,
        HaramProfilePictureType
    }

    public static class WarningTypeExtensions // I wanted warningtype + description for each warning, this is what gemini + github copilot suggested
    {
        private static readonly Dictionary<WarningType, string> WarningDescritions = new()
        {
            { WarningType.HaramFullName, "FullName is non-sharia-compliant so non-compliant with terms of service policy." },
            { WarningType.HaramProfilePictureType, "ProfilePictureType is non-sharia-compliant so non-compliant with terms of service policy." }
        };

        public static string GetDescription(this WarningType warningType)
        {
            return WarningDescritions[warningType];
        }
    }
}
