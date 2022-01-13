using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCRUD.Kelas
{
    public class Studio
    {
        public Studio(string studioName, string studioId)
        {
            StudioId = studioId;
            StudioName = studioName;
        }

        public string StudioId { get; set; }
        public string StudioName { get; set; }
    }
}
