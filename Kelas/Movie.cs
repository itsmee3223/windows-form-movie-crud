using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCRUD.Kelas
{
    public class Movie
    {
        public Movie(string movId, string movTitle, string movGenre, DateTime movDate)
        {
            MovId = movId;
            MovTitle = movTitle;
            MovGenre = movGenre;
            MovDate = movDate;
        }

        public string MovId { get; set; }
        public string MovTitle { get; set; }
        public string MovGenre { get; set; }
        public DateTime MovDate { get; set; }

    }

    
}
