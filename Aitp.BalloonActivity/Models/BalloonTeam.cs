using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aitp.BalloonActivity.Models
{
    public class BalloonTeam
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int BalloonCount { get; set; }

    }
}
