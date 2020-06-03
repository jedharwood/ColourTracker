using System;

namespace ColourTrackerDTOs
{
    public class ColourModel
    {
        public int Id { get; set; }

        public string ColourName { get; set; }

        public string ColourFamily { get; set; }

        public int ColourFamilyId { get; set; }

        public string BrandName { get; set; }

        public int BrandId { get; set; }

        public string Expiry { get; set; }

        public string SerialNumber { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateDeleted { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
