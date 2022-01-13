using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCRUD.Kelas
{
    public class Actor
    {
        public string ActId { get; set; }
        public string ActName { get; set; }
        public string ActGender { get; set; }
        public string MovId { get; set; }

        public Actor(string actId, string actName, string actGender, string movId)
        {
            ActId = actId;
            ActName = actName;
            ActGender = actGender;
            MovId = movId;
        }
    }


}
