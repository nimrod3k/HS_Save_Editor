using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_Save_Editor
{

    internal class Collectibles
    {
        static Dictionary<string, CollectName> _allCollectibles = new Dictionary<string, CollectName>();
        static string _flagFile;
        Dictionary<string, bool> _collected = new Dictionary<string, bool>();
        List<string> _uncollected = new List<string>();
        public Dictionary<CollectName, bool> filters = new Dictionary<CollectName, bool>();
        public int mapFilter = 0; // 0 means all
        public bool otherFilter = true;
        public bool keyItemsFilter = true;
        public static void Initialize(string filename = @"flags.txt")
        {
            _flagFile = filename;
            List<string> collectibles = File.ReadAllLines(filename).ToList<string>();
            foreach (var collectible in collectibles)
            {
                string[] collect_split = collectible.Split(':');
                string address = collect_split[0];
                CollectName name = CollectName.unknown;
                if (collect_split.Length > 1)
                {
                    name = (CollectName)Enum.Parse(typeof(CollectName), collect_split[1]);
                }
                _allCollectibles.Add(address, name);
            }
        }

        private static void saveCollectibles()
        {
            List<string> updateList = new List<string>();
            foreach (var key in _allCollectibles.Keys)
            {
                updateList.Add(string.Format("{0}:{1}", key, _allCollectibles[key].ToString()));
            }
            File.WriteAllLines(_flagFile, updateList);
        }

        internal static CollectName getCollectibleType(string key)
        {
            if (_allCollectibles.ContainsKey(key))
                return _allCollectibles[key];
            else
                return CollectName.unknown;
        }

        internal static void setCollectibleType(string key, CollectName type)
        {
            _allCollectibles[key] = type;
            saveCollectibles();
        }

        public Collectibles()
        {
            filters.Add(CollectName.unknown, true);
            filters.Add(CollectName.heart, true);
            filters.Add(CollectName.gdoor, true);
            filters.Add(CollectName.sdoor, true);
            filters.Add(CollectName.gkey, true);
            filters.Add(CollectName.skey, true);
            filters.Add(CollectName.pstone, true);
            filters.Add(CollectName.sword, true);
            filters.Add(CollectName.gem, true);
            filters.Add(CollectName.treasure, true);
            filters.Add(CollectName.pcoin, true);
        }

        public void addDoneCollectibles(Dictionary<string, bool> dones)
        {
            _collected = dones.ToDictionary(entry => entry.Key, entry => entry.Value);
            List<string> updateValues = _collected.Keys.Where(x => !_allCollectibles.ContainsKey(x)).ToList();
            
            foreach (var item in updateValues)
            {
                _allCollectibles.Add(item,CollectName.unknown);
            }
            _uncollected = _allCollectibles.Keys.Where(x => !_collected.ContainsKey(x)).ToList();
            if (updateValues.Count > 0)
            {
                saveCollectibles();
            }
        }

        private bool isInSet(string key)
        {
            int map = Convert.ToInt32(key.Split('.')[0]);
            if (mapFilter != 0 && map != mapFilter)
                return false;
            if (keyItemsFilter && _allCollectibles[key] >= CollectName.keyitem && _allCollectibles[key] < CollectName.keyitem_end)
                return true;
            else if (otherFilter && _allCollectibles[key] >= CollectName.other && _allCollectibles[key] < CollectName.other_end)
                return true;
            else if (filters.ContainsKey(_allCollectibles[key]) && filters[_allCollectibles[key]])
                return true;
            return false;
        }

        public List<string> getCollected()
        {
            List<string> collected = new List<string>();
            foreach (var key in _collected.Keys)
            {
                if (isInSet(key))
                {
                    string[] key_parts = key.Split('.');
                    string item = "Unknown";
                    if (_allCollectibles.ContainsKey(key))
                    {
                        item = _allCollectibles[key].ToString();
                    }
                    string line = string.Format
                        (
                        "({0})'{1}': {2}",
                        (Maps)Convert.ToInt64(key_parts[0]),
                        key,
                        item
                        );
                    collected.Add(line);
                }
            }
            return collected;
        }
        public List<string> getUncollected()
        {
            List<string> uncollected = new List<string>();
            foreach (var key in _uncollected)
            {
                if (isInSet(key))
                {
                    string[] key_parts = key.Split('.');
                    string item = "Unknown";
                    if (_allCollectibles.ContainsKey(key))
                    {
                        item = _allCollectibles[key].ToString();
                    }
                    string line = string.Format
                        (
                        "({0})'{1}': {2}",
                        (Maps)Convert.ToInt64(key_parts[0]),
                        key,
                        item
                        );
                    uncollected.Add(line);
                }
            }
            return uncollected;
        }

        internal void uncollect(string item)
        {
            string[] splitstring = item.Split('\'');
            _collected.Remove(splitstring[1]);
            _uncollected.Add(splitstring[1]);
        }

        internal void collect(string item)
        {
            string[] splitstring = item.Split('\'');
            _collected.Add(splitstring[1],true);
            _uncollected.Remove(splitstring[1]);
        }
        internal Dictionary<string, bool> getCollectedForSave()
        {
            throw new NotImplementedException();
        }

    }

    public enum CollectName
    {
        unknown,
        heart,
        gdoor,
        sdoor,
        gkey,
        skey,
        pstone,
        sword,
        gem,
        treasure,
        pcoin,
        other,
        tealkey,
        purplekey,
        tealdoor,
        purpledoor,
        other_end,
        keyitem,
        bluekey,
        redkey,
        greenkey,
        bluedoor,
        reddoor,
        greendoor,
        smugglers_eye,
        skeleton_key,
        hammer,
        wind_ring,
        lava_charm,
        compass,
        boots,
        BoBS,
        red_boots,
        blue_sword,
        blue_shield,
        red_sword,
        red_shield,
        green_sword,
        green_shield,
        keyitem_end
    }
}
