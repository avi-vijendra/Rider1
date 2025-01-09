using villa.valla1.Models.DTOs;

namespace villa.valla1.Data;

public static class VillaStore
{
    public static List<VillaDTO> vilalList = new List<VillaDTO>
    {
        
            new VillaDTO { Id = 1, Name = "BeachVilla" },
            new VillaDTO { Id = 2, Name = "PoolVilla" },
        };
}