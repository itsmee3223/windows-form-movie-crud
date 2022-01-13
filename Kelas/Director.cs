using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCRUD.Kelas
{
    public class Director
    {
        public Director(string dirId, string dirName, string dirGender, string movId)
        {
            DirId = dirId;
            DirName = dirName;
            DirGender = dirGender;
            MovId = movId;
        }

        public string DirId { get; set; }
        public string DirName { get; set; }
        public string DirGender { get; set; }
        public string MovId { get; set; }
    }
}
