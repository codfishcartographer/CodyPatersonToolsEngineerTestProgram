namespace CodyPatersonToolsEngineerTestProgram
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Nodes;

    public partial class Form1 : Form
    {
        OpenFileDialog jsonFileDialogue;


        //Used to store information about each troop
        public class Troop 
        {
            public string? name;
            public string? type = "ground";
            public int damage = 0;
            public int health = 0;
            public string? target = "ground";
            public List<Troop>? derivedTroops;
        }

        //Stores the list of troops themselves
        List<Troop> troops;

        public Form1()
        {
            InitializeComponent();

            jsonFileDialogue = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json"
            };

            //Various initializing, and hiding various UI elements that aren't needed from the start

            troops = new();

            HideDerivedTroopInfo();

            saveButton.Hide();
            saveBinButton.Hide();
            addTroopButton.Hide();
            delTroopButton.Hide();
            addDTroopButton.Hide();
            delDTroopButton.Hide();
            ResetShownValues();
        }

        #region Load/Save Buttons

        /*========================================================
         * Load / Save Buttons
         * =======================================================
         */

        private void loadButton_Click(object sender, EventArgs e)
        {
            if(jsonFileDialogue.ShowDialog() == DialogResult.OK) //Verify that a JSON file has been loaded correctly
            {
                StreamReader streamReader = new(jsonFileDialogue.FileName);

                //read the JSON string from the file and store it into a JsonNode
                string jsonString = streamReader.ReadToEnd();

                //failsafe in case an invalid json is loaded
                try
                {
                    JsonNode.Parse(jsonString);
                }
                catch
                {
                    return;
                }

                JsonNode root = JsonNode.Parse(jsonString)!;
                streamReader.Close();

                if (root["troops"] == null) //failsafe in case an improperly-formatted JSON is loaded
                    return;

                //Get the "troops" array from the JSON, then add each one to the "troops" array that the tool modifies
                JsonArray jsonTroops = root["troops"]!.AsArray();
                foreach (JsonNode? jsonTroop in jsonTroops)
                {
                    //initialize a troop using stats from the json
                    Troop troop = new()
                    {
                        name = jsonTroop!["name"]!.ToString(),
                        type = jsonTroop!["type"]!.ToString(),
                        damage = jsonTroop!["damage"]!.GetValue<int>(),
                        health = jsonTroop!["health"]!.GetValue<int>(),
                        target = jsonTroop!["target"]!.ToString(),
                        derivedTroops = new List<Troop>()
                    };

                    //if there's any derived troops in the json, add them to the "derivedTroops" array for the troop we're creating
                    JsonArray derivedTroops = jsonTroop["derivedTroops"]?.AsArray()!;
                    if (derivedTroops != null)
                    {
                        foreach (JsonNode? derivedTroop in derivedTroops)
                        {
                            Troop dTroop = new();
                            dTroop.name = derivedTroop!["name"]!.ToString();
                            dTroop.type = derivedTroop!["type"]?.ToString();

                            if (derivedTroop!["damage"] != null)
                                dTroop.damage = derivedTroop!["damage"]!.GetValue<int>();
                            if (derivedTroop!["health"] != null)
                                dTroop.health = derivedTroop!["health"]!.GetValue<int>();

                            dTroop.target = derivedTroop!["target"]?.ToString();

                            dTroop.type ??= troop.type;
                            dTroop.damage = dTroop.damage == 0 ? troop.damage : dTroop.damage;
                            dTroop.health = dTroop.health == 0 ? troop.health : dTroop.health;
                            dTroop.target ??= troop.target;

                            troop.derivedTroops?.Add(dTroop);
                        }
                    }

                    troops.Add(troop);
                }

                //populate the list of troops
                foreach (Troop troop in troops)
                {
                    troopListBox.Items.Add(troop.name);
                }

                //un-hide various buttons that are now needed
                addTroopButton.Show();
                delTroopButton.Show();
                saveButton.Show();
                saveBinButton.Show();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new();

            saveFileDialog1.Filter = "JSON file (*.json)|*.json";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    //Initialize a jsonWriter to write to the selected JSON file
                    JsonWriterOptions writerOptions = new() { Indented = true, };
                    Utf8JsonWriter writer = new Utf8JsonWriter(myStream, writerOptions);

                    writer.WriteStartObject();

                    //write a "troops" array, and set all of its values based on the tool's "troops" array
                    writer.WriteStartArray("troops");
                    foreach (Troop troop in troops)
                    {
                        writer.WriteStartObject();

                        writer.WriteString("name", troop.name);
                        writer.WriteString("type", troop.type);
                        writer.WriteNumber("damage", troop.damage);
                        writer.WriteNumber("health", troop.health);
                        writer.WriteString("target", troop.target);

                        //do the same with derived troops, but skip any stats that match the parent
                        writer.WriteStartArray("derivedTroops");
                        foreach (Troop dTroop in troop.derivedTroops)
                        {
                            writer.WriteStartObject();
                            writer.WriteString("name", dTroop.name);
                            if (dTroop.type != troop.type)
                                writer.WriteString("type", dTroop.type);
                            if (dTroop.damage != troop.damage && dTroop.damage != 0) //an extra check here to ensure a unit doesn't have 0 dmg or health
                                writer.WriteNumber("damage", dTroop.damage);
                            if (dTroop.health != troop.health && dTroop.health != 0)
                                writer.WriteNumber("health", dTroop.health);
                            if (dTroop.target != troop.target)
                                writer.WriteString("target", dTroop.target);
                            writer.WriteEndObject();
                        }
                        writer.WriteEndArray();

                        writer.WriteEndObject();
                    }
                    writer.WriteEndArray();

                    writer.WriteEndObject();
                    writer.Flush();

                    myStream.Close();
                }
            }
        }

        #endregion

        #region Troop Selection

        /*========================================================
         * Code for selecting different troops / derived troops
         * =======================================================
         */

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (troopListBox.SelectedIndex < 0)
                return;

            //grab the currently-selected troop, then update all of the text boxes based on the troop's stats
            Troop troop = troops[troopListBox.SelectedIndex];

            nameBox.Text = troop.name;

            switch (troop.type)
            {
                case "ground":
                    typeGround.Checked = true;
                    typeAir.Checked = false;
                    break;
                case "air":
                    typeGround.Checked = false;
                    typeAir.Checked = true;
                    break;
            }

            dmgBox.Text = troop.damage.ToString();
            healthBox.Text = troop.health.ToString();

            switch (troop.target)
            {
                case "ground":
                    targetGround.Checked = true;
                    targetAir.Checked = false;
                    break;
                case "air":
                    targetGround.Checked = false;
                    targetAir.Checked = true;
                    break;
                case "all":
                    targetGround.Checked = true;
                    targetAir.Checked = true;
                    break;
            }

            derivedTroopListBox.Items.Clear();

            if (troop.derivedTroops?.Count > 0)
            {
                foreach (Troop dTroop in troop.derivedTroops)
                {
                    derivedTroopListBox.Items.Add(dTroop.name);
                }

                delDTroopButton.Show();
            }
            else
            {
                HideDerivedTroopInfo();
                delDTroopButton.Hide();
            }

            addDTroopButton.Show();
        }

        private void derivedTroopListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Troop parent = CurrentTroop();

            if (derivedTroopListBox.SelectedIndex < 0)
                return;

            ShowDerivedTroopInfo();

            //grab the currently-selected troop, then update all of the text boxes based on the troop's stats
            Troop troop = parent.derivedTroops[derivedTroopListBox.SelectedIndex];

            dNameBox.Text = troop.name;


            //we need to check if any stats match the parent - if so, we leave them blank
            if (troop.type == parent.type)
            {
                dTypeGround.Checked = false;
                dTypeAir.Checked = false;
            }
            else
            {
                switch (troop.type)
                {
                    case "ground":
                        dTypeGround.Checked = true;
                        dTypeAir.Checked = false;
                        break;
                    case "air":
                        dTypeGround.Checked = false;
                        dTypeAir.Checked = true;
                        break;
                }
            }

            //We do an additional check on dmg and health to see if they're equal to 0 - if so, instead appear blank and automatically match the parent when the JSON is saved
            if (troop.damage == parent.damage || troop.damage == 0)
                dDmgBox.Text = "";
            else
                dDmgBox.Text = troop.damage.ToString();

            if (troop.health == parent.health || troop.health == 0)
                dHealthBox.Text = "";
            else
                dHealthBox.Text = troop.health.ToString();

            if (troop.target == parent.target)
            {
                dTargetGround.Checked = false;
                dTargetAir.Checked = false;
            }
            else
            {
                switch (troop.type)
                {
                    case "ground":
                        dTargetGround.Checked = true;
                        dTargetAir.Checked = false;
                        break;
                    case "air":
                        dTargetGround.Checked = false;
                        dTargetAir.Checked = true;
                        break;
                    case "all":
                        dTargetGround.Checked = true;
                        dTargetAir.Checked = true;
                        break;
                }
            }
        }

        #endregion

        #region Troop Stat Fields

        /*========================================================
         * Troop Stat Fields
         * =======================================================
         */


        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            if (troopListBox.SelectedIndex < 0)
                return;

            CurrentTroop().name = nameBox.Text;
            troopListBox.Items[troopListBox.SelectedIndex] = nameBox.Text; //update the troop's name in the list view as the Name field is altered
        }

        private void typeGround_CheckedChanged(object sender, EventArgs e)
        {
            CheckType();

            //force a checkmark if the user tries to uncheck both boxes, as a unit always needs at least one type
            if (CurrentTroop()?.type == "none")
            {
                typeGround.Checked = true;
                CheckType();
            }
        }

        private void typeAir_CheckedChanged(object sender, EventArgs e)
        {
            CheckType();

            //force a checkmark if the user tries to uncheck both boxes, as a unit always needs at least one type
            if (CurrentTroop()?.type == "none")
            {
                typeAir.Checked = true;
                CheckType();
            }
        }

        private void dmgBox_TextChanged(object sender, EventArgs e)
        {
            if (CurrentTroop() == null)
                return;

            //If the user attempts to enter a non-number into the box, delete it
            if (System.Text.RegularExpressions.Regex.IsMatch(dmgBox.Text, "[^0-9]"))
            {
                dmgBox.Text = dmgBox.Text.Remove(dmgBox.Text.Length - 1);
            }

            CurrentTroop().damage = Int32.Parse(dmgBox.Text);
        }

        private void healthBox_TextChanged(object sender, EventArgs e)
        {
            if (CurrentTroop() == null)
                return;

            //If the user attempts to enter a non-number into the box, delete it
            if (System.Text.RegularExpressions.Regex.IsMatch(healthBox.Text, "[^0-9]"))
            {
                healthBox.Text = healthBox.Text.Remove(healthBox.Text.Length - 1);
            }

            CurrentTroop().health = Int32.Parse(healthBox.Text);
        }

        private void targetGround_CheckedChanged(object sender, EventArgs e)
        {
            CheckTarget();

            //force a checkmark if the user tries to uncheck both boxes, as a unit always needs at least one target
            if (CurrentTroop()?.target == "none")
            {
                targetGround.Checked = true;
                CheckTarget();
            }
        }

        private void targetAir_CheckedChanged(object sender, EventArgs e)
        {
            CheckTarget();

            //force a checkmark if the user tries to uncheck both boxes, as a unit always needs at least one target
            if (CurrentTroop()?.target == "none")
            {
                targetAir.Checked = true;
                CheckTarget();
            }
        }

        #endregion


        #region Derived Troop StatFields
        /*========================================================
        * Derived Troop Stat Fields
        * =======================================================
        */

        private void dNameBox_TextChanged(object sender, EventArgs e)
        {
            if (derivedTroopListBox.SelectedIndex < 0)
                return;

            CurrentDerivedTroop().name = dNameBox.Text;
            derivedTroopListBox.Items[derivedTroopListBox.SelectedIndex] = dNameBox.Text; //update the troop's name in the list view as the Name field is altered
        }

        private void dTypeGround_CheckedChanged(object sender, EventArgs e)
        {
            CheckDerivedType();

            //we don't force a checkmark for derived troops, as leaving them blank will copy the troop's parent
        }

        private void dTypeAir_CheckedChanged(object sender, EventArgs e)
        {
            CheckDerivedType();

            //we don't force a checkmark for derived troops, as leaving them blank will copy the troop's parent
        }

        private void dDmgBox_TextChanged(object sender, EventArgs e)
        {
            if (CurrentDerivedTroop() == null)
                return;

            if (System.Text.RegularExpressions.Regex.IsMatch(dDmgBox.Text, "[^0-9]"))
            {
                dDmgBox.Text = dDmgBox.Text.Remove(dDmgBox.Text.Length - 1);
            }

            //if the text box is blank, set to 0 dmg - this will be changed to the parent's dmg when the JSON is saved
            if (dDmgBox.Text != "")
            {
                CurrentDerivedTroop().damage = Int32.Parse(dDmgBox.Text);
            }
            else
            {
                CurrentDerivedTroop().damage = 0;
            }
        }

        private void dHealthBox_TextChanged(object sender, EventArgs e)
        {
            if (CurrentDerivedTroop() == null)
                return;

            if (System.Text.RegularExpressions.Regex.IsMatch(dHealthBox.Text, "[^0-9]"))
            {
                dHealthBox.Text = dHealthBox.Text.Remove(dHealthBox.Text.Length - 1);
            }

            //if the text box is blank, set to 0 - this will be changed to the parent's health when the JSON is saved
            if (dHealthBox.Text != "")
            {
                CurrentDerivedTroop().health = Int32.Parse(dHealthBox.Text);
            }
            else
            {
                CurrentDerivedTroop().health = 0;
            }
        }

        private void dTargetGround_CheckedChanged(object sender, EventArgs e)
        {
            CheckDerivedTarget();

            //we don't force a checkmark for derived troops, as leaving them blank will copy the troop's parent
        }

        private void dTargetAir_CheckedChanged(object sender, EventArgs e)
        {
            CheckDerivedTarget();

            //we don't force a checkmark for derived troops, as leaving them blank will copy the troop's parent
        }
        #endregion


        #region Add/Remove Troop buttons

        /*========================================================
         * Buttons for adding and removing Troops / Derived Troops
         * =======================================================
         */

        private void addTroopButton_Click(object sender, EventArgs e)
        {
            Troop troop = new();

            troop.name = "New Troop";

            troops.Add(troop);
            troop.derivedTroops = new();

            troopListBox.Items.Add(troop.name);
        }

        private void delTroopButton_Click(object sender, EventArgs e)
        {
            if (troopListBox.SelectedIndex < 0)
                return;

            int i = troopListBox.SelectedIndex;

            troops?.RemoveAt(i);

            troopListBox.Items.RemoveAt(i);

            HideDerivedTroopInfo();
            addDTroopButton.Hide();
            delDTroopButton?.Hide();
            ResetShownValues();
        }

        private void addDTroopButton_Click(object sender, EventArgs e)
        {
            //initialize a new troop copying the parent's stats, and also enable the button to delete derived troops

            delDTroopButton.Show();

            Troop troop = new()
            {
                name = $"New {CurrentTroop().name}",
                type = CurrentTroop().type,
                damage = CurrentTroop().damage,
                health = CurrentTroop().health,
                target = CurrentTroop().target,
            };

            CurrentTroop().derivedTroops?.Add(troop);

            derivedTroopListBox.Items.Add(troop.name);
        }

        private void delDTroopButton_Click(object sender, EventArgs e)
        {
            if (derivedTroopListBox.SelectedIndex < 0)
                return;

            int i = derivedTroopListBox.SelectedIndex;
            
            derivedTroopListBox.Items.RemoveAt(i);

            CurrentTroop().derivedTroops?.RemoveAt(i);
            HideDerivedTroopInfo();
        }

        #endregion

        #region Utility Functions

        /*========================================================
         * Utility Functions
         * =======================================================
         */

        void ResetShownValues()
        {
            //blank out all the various fields

            nameBox.Text = "";
            typeGround.Checked = false;
            typeAir.Checked = false;   
            dmgBox.Text = "";
            healthBox.Text = "";
            targetGround.Checked = false;
            targetAir.Checked = false;
        }

        private void HideDerivedTroopInfo()
        {
            dTroopGroupBox.Hide();
        }

        private void ShowDerivedTroopInfo()
        {
            dTroopGroupBox.Show();
        }

        Troop? CurrentTroop()
        {
            if (troopListBox.SelectedIndex < 0)
                return null;

            //return the troop that is currently selected in the list
            return troops[troopListBox.SelectedIndex];
        }

        Troop? CurrentDerivedTroop()
        {
            if (derivedTroopListBox.SelectedIndex < 0)
                return null;

            //return the derived troop that is currently selected in the list
            return CurrentTroop()?.derivedTroops[derivedTroopListBox.SelectedIndex];
        }

        void CheckType()
        {
            if (CurrentTroop() == null)
                return;

            //set the troop's type based on which boxes are checked, if any

            if (typeGround.Checked && typeAir.Checked)
                CurrentTroop().type = "all";
            else if (typeGround.Checked)
                CurrentTroop().type = "ground";
            else if (typeAir.Checked)
                CurrentTroop().type = "air";
            else
                CurrentTroop().type = "none";
        }

        void CheckTarget()
        {
            if (CurrentTroop() == null)
                return;

            //set the troop's target based on which boxes are checked, if any

            if (targetGround.Checked && targetAir.Checked)
                CurrentTroop().target = "all";
            else if (targetGround.Checked)
                CurrentTroop().target = "ground";
            else if (targetAir.Checked)
                CurrentTroop().target = "air";
            else
                CurrentTroop().target = "none";
        }

        void CheckDerivedType()
        {
            if (CurrentDerivedTroop() == null)
                return;

            //set the derived troop's type based on which boxes are checked - if none, instead copy parent

            if (dTypeGround.Checked && dTypeAir.Checked)
                CurrentDerivedTroop().type = "all";
            else if (dTypeGround.Checked)
                CurrentDerivedTroop().type = "ground";
            else if (dTypeAir.Checked)
                CurrentDerivedTroop().type = "air";
            else
                CurrentDerivedTroop().type = CurrentTroop().type;
        }

        void CheckDerivedTarget()
        {
            if (CurrentDerivedTroop() == null)
                return;

            //set the derived troop's target based on which boxes are checked - if none, instead copy parent

            if (dTargetGround.Checked && dTargetAir.Checked)
                CurrentDerivedTroop().target = "all";
            else if (dTargetGround.Checked)
                CurrentDerivedTroop().target = "ground";
            else if (dTargetAir.Checked)
                CurrentDerivedTroop().target = "air";
            else
                CurrentDerivedTroop().target = CurrentTroop().target;
        }
        #endregion

        private void saveBinButton_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new();

            saveFileDialog1.Filter = "Data file (*.dat)|*.dat";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    BinaryWriter writer = new BinaryWriter(myStream);

                    //file header "TROP" - for some reason it keeps adding in an extra 04 byte at 0x0000 when i try to just enter in "TROP" so we're doing this the hard way
                    writer.BaseStream.Position = 0x0000;
                    writer.Write(Encoding.UTF8.GetBytes("TROP"));

                    //ver no - only 01 is in use
                    writer.BaseStream.Position = 0x0004;
                    writer.Write(Encoding.UTF8.GetBytes("01"));

                    //Generate a list of all troops + derived troops
                    List<Troop> allTroops = new();
                    foreach (Troop troop in troops)
                    {
                        allTroops.Add(troop);

                        foreach (Troop derivedTroop in troop.derivedTroops)
                            allTroops.Add(derivedTroop);
                    }

                    //number of troops + derived troops
                    writer.BaseStream.Position = 0x0006;
                    writer.Write(allTroops.Count);

                    //Jump to the proper memory address, then begin going through each troop and writing their info
                    writer.BaseStream.Position = 0x000A;

                    foreach (Troop troop in allTroops)
                    {
                        short len = (short)troop.name.Length;
                        writer.Write(len);
                        writer.Write(Encoding.UTF8.GetBytes(troop.name));
                        writer.Write((short)troop.damage);
                        writer.Write(troop.health);

                        //manually set the bits depending on the type + target
                        byte typeTargetVal = 0b_00000000;

                        switch (troop.type)
                        {
                            case "ground":
                                typeTargetVal ^= 0b_00000001;
                                break;
                            case "air":
                                typeTargetVal ^= 0b_00000010;
                                break;
                            case "all":
                                typeTargetVal ^= 0b_00000001;
                                typeTargetVal ^= 0b_00000010;
                                break;
                        }

                        switch (troop.target)
                        {
                            case "ground":
                                typeTargetVal ^= 0b_00000100;
                                break;
                            case "air":
                                typeTargetVal ^= 0b_00001000;
                                break;
                            case "all":
                                typeTargetVal ^= 0b_00000100;
                                typeTargetVal ^= 0b_00001000;
                                break;
                        }

                        writer.Write(typeTargetVal);
                    }

                    writer.BaseStream.Flush();
                    myStream.Close();
                }
            }
        }
    }
}