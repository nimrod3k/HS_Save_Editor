using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HS_Tools;

namespace Door_Locator
{
    internal static class Utils
    {
        public static Dictionary<Maps, string> hintDict = new Dictionary<Maps, string>()
        {
            { Maps.DUST_SHELF, "A "},
            { Maps.THRONE_ROOM,"Throne Room" },
            { Maps.THRONE_ROOM_Q,"Throne Room" },
            { Maps.CASTLE_RUINS,"Castle Ruins" },
            { Maps.NORTH_MUNDEMAN,"inside a cave of lava" },
            { Maps.SOUTH_MUNDEMAN,"inside a cave water" },
            { Maps.VERDANT_COAST,"in a land of cherry blossoms" },
            { Maps.OTHERWORLD,"Otherworld" },
            { Maps.CASTLE_GROUNDS,"on the Castle Grounds" },
            { Maps.SANCTUARY,"Sanctuary" },
            { Maps.THE_TUNNELS,"inside a dark tunnel" },
            { Maps.GLITCH,"Glitch" },
            { Maps.LUDDERSHORE,"Luddershore" },
            { Maps.THE_TUNDRA,"somewhere on a vast tundra" },
            { Maps.FROZEN_SHORE,"someplace cold" },
            { Maps.HALLOW_GROUND, "somewhat haunted" },
            { Maps.SOUTHERN_SWAMP,"inside a swamp" },
            { Maps.DRAGONS_LAIR,"hanging with a smurf dragon" },
            { Maps.CORRUPTED_CASTLE,"Corrupted Castle" },
            { Maps.CASTLE_MONILLUD,"waiting for you in the castle" },
            { Maps.THRONE_ROOM_A, "Throne Room" },
            { Maps.THE_UNDERWORLD,"in the basement of the world" },
            { Maps.OTHERWORLD_p,"Otherworld" },
            { Maps.MOLTEN_CAVERN,"lava hot (actually I think it's called magma)" },
            { Maps.THE_DUNGEONS,"chillin' with Frank" },
            { Maps.ITEM_SHOP,"wants to go shopping" },
            { Maps.CONVERGENCE,"Convergence" },
            { Maps.TRIAL_OF_REALITY,"Trial of Reality" },
            { Maps.THE_FALLEN_WORLD,"Fallen World" },
            { Maps.THE_ROAD_TO_HELL,"Road to Hell" },
            { Maps.HAUNTED_MANSE,"somewhat haunted" },
            { Maps.THE_MOONWELL,"Moonwell" },
            { Maps.SMUGGLERS_ROAD,"Smuggler's Road" },
            { Maps.SMUGGLERS_RUIN,"Smuggler's Road"}
        };


    }
}
