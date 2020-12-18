using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DBDman.Classes;

namespace DBDman
{
    public partial class InventoryManager : Form
    {
        [DllImport(@"qrypt0r.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern void readData(byte[] jsonBytes, byte[] buffer);

        List<Character> characters = new List<Character>(); //contains translations for character names

        JObject json_obj; //main json
        JArray inventory; //inventory array

        List<Item> cosmetics = new List<Item>(); //contains every cosmetic known to man :D

        List<Inventory> currentInventory = new List<Inventory>(); //stores loaded inventory
        List<Inventory> newInventory = new List<Inventory>(); //where changes are written to

        Random r = new Random(); //for generating random unix stamps

        int unreleasedCount = 0; //tracking unreleased skins

        string inventory_loc = AppDomain.CurrentDomain.BaseDirectory + "inventory.txt"; //path to save inventory to

        private void storeCharacters()
        {
            characters.Add(new Character() { realName = "David", codeName = "Smoke" });
            characters.Add(new Character() { realName = "Tapp", codeName = "Eric" });

            characters.Add(new Character() { realName = "Trapper", codeName = "Chuckles" });
            characters.Add(new Character() { realName = "Wraith", codeName = "Bob" });
            characters.Add(new Character() { realName = "Billy", codeName = "HillBilly" });
            characters.Add(new Character() { realName = "Myers", codeName = "Shape" });
            characters.Add(new Character() { realName = "Hag", codeName = "Witch" });
            characters.Add(new Character() { realName = "Doctor", codeName = "Killer07" });
            characters.Add(new Character() { realName = "Huntress", codeName = "Bear" });
            characters.Add(new Character() { realName = "Leatherface", codeName = "Cannibal" });
            characters.Add(new Character() { realName = "Freddy", codeName = "Nightmare" });
        }

        public InventoryManager()
        {
            storeCharacters();
            WebClient client = new WebClient();
            byte[] buf = new byte[0x2000000];
            byte[] catalog = client.DownloadData("https://cdn.live.dbd.bhvronline.com/gameinfo/catalog.json");
            buf[0] = 0;
            readData(catalog, buf);
            string catalog_data = Encoding.ASCII.GetString(buf);
            catalog_data = catalog_data.TrimEnd('\x00');
            JArray catalog_arr = JArray.Parse(catalog_data);
            foreach (JObject o in catalog_arr.Children<JObject>())
            {
                if ((string)o["categories"][0] == "item"/* && (bool)o["purchasable"] == true*/)
                {
                    Item item = new Item();
                    item.character = (string)o["metaData"]["character"];
                    item.itemId = (string)o["id"];
                    item.startDate = DateTime.ParseExact((string)o["metaData"]["newStartDate"], "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    cosmetics.Add(item);
                }
            }
            InitializeComponent();
        }

        //FUNCTION DECLARATIONS
        private bool isInInventory(string itemToCheck)
        {
            foreach (Inventory item in currentInventory)
            {
                if (item.objectId == itemToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        private string returnCodeName(string name)
        {
            foreach (Character character in characters)
            {
                if (name == character.realName)
                {
                    return character.codeName;
                }
            }
            return name;
        }

        private void loadInventory(string filepath)
        {
            try
            {
                json_obj = JObject.Parse(File.ReadAllText(filepath));
                inventory = (JArray)json_obj["data"]["inventory"];
                currentInventory.Clear();

                foreach (Inventory entry in inventory.ToObject<List<Inventory>>())
                {
                    currentInventory.Add(entry);
                }

                foreach (Control c in panelSurvivorDLC.Controls)
                {
                    if (c is CheckBox)
                    {
                        if (isInInventory(returnCodeName(c.Text)))
                        {
                            ((CheckBox)c).Checked = true;
                            ((CheckBox)c).Enabled = false;
                        }
                    }
                }

                foreach (Control c in panelKillerDLC.Controls)
                {
                    if (c is CheckBox)
                    {
                        if (isInInventory(returnCodeName(c.Text)))
                        {
                            ((CheckBox)c).Checked = true;
                            ((CheckBox)c).Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error loading inventory: {0}", ex), DBDman.MessageBoxTitles[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addToInventory(string itemId, int startDate)
        {
            if (startDate > (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds() && !unreleasedSkinsToolStripMenuItem.Checked)
            {
                return;
            }
            Inventory item = new Inventory();
            item.quantity = 1;
            item.objectId = itemId;
            if (startDate < (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            {
                item.lastUpdateAt = r.Next(startDate, (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            }
            else
            {
                item.lastUpdateAt = r.Next(startDate, startDate + 2592000);
                unreleasedCount++;
            }
            newInventory.Add(item);
        }

        //EVENT DECLARATIONS
        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Control c in ((Button)sender).Parent.Controls)
            {
                if (c is CheckBox && c.Enabled)
                {
                    ((CheckBox)c).Checked = true;
                }
            }
        }

        private void buttonDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (Control c in ((Button)sender).Parent.Controls)
            {
                if (c is CheckBox && c.Enabled)
                {
                    ((CheckBox)c).Checked = false;
                }
            }
        }

        private void unreleasedSkinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!unreleasedSkinsToolStripMenuItem.Checked)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to include unreleased skins?\nThis will only work if the local game data has a reference to the skin", DBDman.MessageBoxTitles[2], MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    unreleasedSkinsToolStripMenuItem.Checked = true;
                }
            }
            else
            {
                unreleasedSkinsToolStripMenuItem.Checked = false;
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                Filter = "Inventory (*.txt)|*.txt"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                loadInventory(ofd.FileName);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(json_obj == null)
            {
                MessageBox.Show("You need to load an inventory first!", DBDman.MessageBoxTitles[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach(Control c in panelSurvivorDLC.Controls)
            {
                if((c is CheckBox) && ((CheckBox)c).Checked)
                {
                    if (!isInInventory(returnCodeName(c.Text)))
                    {
                        addToInventory(returnCodeName(c.Text), (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 2592000); //launch dates aren't listed in the catalog so we'll just generate random ones within the last month
                    }
                }
            }

            foreach (Control c in panelKillerDLC.Controls)
            {
                if ((c is CheckBox) && ((CheckBox)c).Checked)
                {
                    if (!isInInventory(returnCodeName(c.Text)))
                    {
                        addToInventory(returnCodeName(c.Text), (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 2592000);
                    }
                }
            }

            foreach (Control c in panelSurvivorCosmetics.Controls)
            {
                if ((c is CheckBox) && ((CheckBox)c).Checked)
                {
                    foreach (Item cosmetic in cosmetics)
                    {
                        if (returnCodeName(((CheckBox)c).Text) == cosmetic.character && !isInInventory(cosmetic.itemId))
                        {
                            addToInventory(cosmetic.itemId, (int)((DateTimeOffset)cosmetic.startDate).ToUnixTimeSeconds()); //grabbing launch date from catalog
                        }
                    }
                }
            }

            foreach (Control c in panelKillerCosmetics.Controls)
            {
                if ((c is CheckBox) && ((CheckBox)c).Checked)
                {
                    foreach (Item cosmetic in cosmetics)
                    {
                        if (returnCodeName(((CheckBox)c).Text) == cosmetic.character && !isInInventory(cosmetic.itemId))
                        {
                            addToInventory(cosmetic.itemId, (int)((DateTimeOffset)cosmetic.startDate).ToUnixTimeSeconds());
                        }
                    }
                }
            }

            foreach (Inventory item in currentInventory)
            {
                newInventory.Add(item);
            }

            List<Inventory> finalInventory = newInventory.OrderByDescending(o => o.lastUpdateAt).ToList();

            inventory.Clear();
            foreach (Inventory item in finalInventory)
            {
                inventory.Add(JObject.FromObject(item));
            }

            File.WriteAllText(inventory_loc, JsonConvert.SerializeObject(json_obj, Formatting.None));

            if(unreleasedSkinsToolStripMenuItem.Checked)
            {
                MessageBox.Show(string.Format("{0} unreleased skins added", unreleasedCount.ToString()), DBDman.MessageBoxTitles[2], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                unreleasedCount = 0;
            }

            MessageBox.Show(string.Format("Inventory written to {0}", inventory_loc), DBDman.MessageBoxTitles[1], MessageBoxButtons.OK, MessageBoxIcon.Information);
            newInventory.Clear();

            loadInventory(inventory_loc);
        }
    }
}