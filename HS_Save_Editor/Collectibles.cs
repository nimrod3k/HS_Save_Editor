using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_Save_Editor
{
    internal class Collectibles
    {
        static Dictionary<string, CollectName[]> _allCollectibles = new Dictionary<string, CollectName[]>();
        static string _flagFile;
        List<string> _uncollected = new List<string>();
        public Dictionary<CollectName, bool> filters = new Dictionary<CollectName, bool>();
        public int mapFilter = 0; // 0 means all
        public bool otherFilter = true;
        public bool keyItemsFilter = true;
        public static GameMode gameMode = GameMode.NG;


        public static void Initialize(string filename = @"flags.txt")
        {
            try
            {
                _flagFile = filename;
                List<string> collectibles = File.ReadAllLines(filename).ToList<string>();
                foreach (var collectible in collectibles)
                {
                    string[] collect_split = collectible.Split(':');
                    string address = collect_split[0];
                    CollectName[] names = new CollectName[(int)GameMode.size];
                    if (collect_split.Length > 1)
                    {
                        string[] collect_names = collect_split[1].Split('-');
                        if (collect_names.Length == 1)
                        {
                            names[(int)GameMode.NG] = (CollectName)Enum.Parse(typeof(CollectName), collect_names[0]);
                            names[(int)GameMode.NGP] = names[(int)GameMode.NG];
                            names[(int)GameMode.NGPP] = names[(int)GameMode.NG];
                        }
                        else
                        {
                            for (int i = 0; i < collect_names.Length; ++i)
                            {
                                if (string.IsNullOrEmpty(collect_names[i]))
                                {
                                    names[i] = CollectName.DoesNotExist;
                                }
                                else
                                {
                                    names[i] = (CollectName)Enum.Parse(typeof(CollectName),collect_names[i]);
                                }
                            }
                            if (collect_names.Length < names.Length)
                            {
                                for (int i = collect_names.Length; i < names.Length; ++i)
                                {
                                    names[i] = names[collect_names.Length-1];
                                }
                            }
                        }
                        
                    }
                    _allCollectibles.Add(address, names);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Failed to initialize collectibles: \n\n{0}",ex.Message));
            }
        }

        private static void saveCollectibles()
        {
            List<string> updateList = new List<string>();
            foreach (var key in _allCollectibles.Keys)
            {
                string modesText = _allCollectibles[key][0].ToString();
                if (getMap(key) == Maps.THE_UNDERWORLD)
                    modesText = CollectName.DoesNotExist.ToString();
                if (!_allCollectibles[key].All(x => x == CollectName.unknown))
                {
                    for (int i = 1; i < _allCollectibles[key].Length; ++i)
                    {
                        modesText += string.Format("-{0}", _allCollectibles[key][i]);
                    }
                }
                updateList.Add(string.Format("{0}:{1}", key, modesText));
            }
            File.WriteAllLines(_flagFile, updateList);
        }

        internal static CollectName getCollectibleType(string key)
        {
            if (_allCollectibles.ContainsKey(key))
                return getModeCollectible(key);
            else
                return CollectName.unknown;
        }

        internal static void setCollectibleType(string key, CollectName type)
        {
            if (_allCollectibles[key][(int)gameMode] == CollectName.unknown)
            {
                if (gameMode == GameMode.NGP && _allCollectibles[key][(int)GameMode.NGPP] == CollectName.unknown)
                {
                    _allCollectibles[key][(int)GameMode.NGPP] = type;
                }
                if (gameMode == GameMode.NGPP && _allCollectibles[key][(int)GameMode.NGP] == CollectName.unknown)
                {
                    _allCollectibles[key][(int)GameMode.NGP] = type;
                }
            }
            _allCollectibles[key][(int)gameMode] = type;
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

        public void addDoneCollectibles()
        {
            var dones = DataUtils.GetFlags();
            List<string> updateValues = dones.Keys.Where(x => !_allCollectibles.ContainsKey(x)).ToList();
            
            foreach (var item in updateValues)
            {
                CollectName[] collectNames = new CollectName[(int)GameMode.size];
                for (int i = 0; i < collectNames.Length; ++i)
                {
                    collectNames[i] = CollectName.unknown;
                }
                _allCollectibles.Add(item, collectNames);
            }
            _uncollected = _allCollectibles.Keys.Where(x => !dones.ContainsKey(x)).ToList();
            if (updateValues.Count > 0)
            {
                saveCollectibles();
            }
        }

        private static CollectName getModeCollectible(string key)
        {
            CollectName modeItem = CollectName.DoesNotExist;
            if (_allCollectibles.ContainsKey(key))
            {
                modeItem = _allCollectibles[key][(int)gameMode];
            }
            else
            {
                throw new Exception("Key not found. Check for key before calling getModeCollectible.");
            }
            return modeItem;
        }
        
        private static Maps getMap(string key)
        {
            return (Maps)Convert.ToInt32(key.Split('.')[0]);
        }

        private bool isInSet(string key)
        {
            CollectName name = getModeCollectible(key);
            if (name != CollectName.DoesNotExist)
            {
                int map = Convert.ToInt32(key.Split('.')[0]);
                if (mapFilter != 0 && map != mapFilter)
                    return false;
                if (keyItemsFilter && name >= CollectName.keyitem && name <= CollectName.keyitem_end)
                    return true;
                else if (otherFilter && name >= CollectName.other && name <= CollectName.other_end)
                    return true;
                else if (filters.ContainsKey(name) && filters[name])
                    return true;
                return false;
            }
            return false;
        }

        public List<string> getCollected()
        {
            if (!DataUtils.dataIsLoaded)
                return null;
            List<string> collected = new List<string>();
            foreach (var key in DataUtils.GetFlags().Keys)
            {
                if (isInSet(key))
                {
                    string[] key_parts = key.Split('.');
                    string item = "Unknown";
                    if (_allCollectibles.ContainsKey(key))
                    {
                        item = _allCollectibles[key][(int)gameMode].ToString();
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
                        item = _allCollectibles[key][(int)gameMode].ToString();
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
            DataUtils.RemoveFlag(splitstring[1]);
            _uncollected.Add(splitstring[1]);
        }

        internal void collect(string item)
        {
            string[] splitstring = item.Split('\'');
            DataUtils.AddFlag(splitstring[1],true);
            _uncollected.Remove(splitstring[1]);
        }


    }

    enum GameMode
    {
        NG,
        NGP,
        NGPP,
        size
    }

    public enum CollectName
    {
        DoesNotExist,
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
        goldsword,
        shield,
        greengem,
        greengemlock,
        trianglekey,
        trianglelock,
        triangledoor,
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
        spectacles,
        red_boots,
        blue_sword,
        blue_shield,
        blue_heart,
        red_sword,
        red_shield,
        green_sword,
        green_shield,
        save_crystals,
        carrot,
        mirror,
        broom,
        fishingrod,
        fish,
        keyitem_end
    }
}
