using System;

namespace ColourTrackerDTOs
{
    public class ColourModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string Expiry { get; set; }

        public string SerialNumber { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateDeleted { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
