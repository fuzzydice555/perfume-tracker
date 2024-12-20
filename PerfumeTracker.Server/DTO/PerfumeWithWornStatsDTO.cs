﻿using PerfumeTrackerAPI.Models;

namespace PerfumeTrackerAPI.DTO {
    public class PerfumeWithWornStatsDTO {
        public PerfumeDTO Perfume { get; set; }
        public int WornTimes { get; set; }
        public DateTime? LastWorn {  get; set; }
        public List<TagDTO> Tags { get; set; }
    }
}
