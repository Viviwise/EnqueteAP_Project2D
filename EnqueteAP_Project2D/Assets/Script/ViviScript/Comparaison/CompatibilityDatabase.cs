using System.Collections.Generic;
using UnityEngine;

namespace Script.Comparaison
{
    [System.Serializable]
    public class CompatibilityDatabase : MonoBehaviour
    {
        public string[] people = new string[16];

        public int planteCount = 8;
        public int blessureExterneCount = 9;
        public int blessureInterneCount = 9;
        public int gazetteCount = 5;

        [HideInInspector]
        public List<CompatibilityEntry> entries = new List<CompatibilityEntry>();
        
        public void GenerateEntries()
        {
            entries.Clear();

            foreach (var person in people)
            {
                if (string.IsNullOrEmpty(person))
                    continue;

                // Plantes
                for (int i = 1; i <= planteCount; i++)
                {
                    entries.Add(new CompatibilityEntry
                    {
                        person = person,
                        category = Category.Plante,
                        infoNumber = i,
                        compatibility = Compatibility.Incompatible // NO par défaut
                    });
                }

                // Blessures internes
                for (int i = 1; i <= blessureInterneCount; i++)
                {
                    entries.Add(new CompatibilityEntry
                    {
                        person = person,
                        category = Category.BlessureInt,
                        infoNumber = i,
                        compatibility = Compatibility.Incompatible
                    });
                }

                // Blessures externes
                for (int i = 1; i <= blessureExterneCount; i++)
                {
                    entries.Add(new CompatibilityEntry
                    {
                        person = person,
                        category = Category.BlessureExt,
                        infoNumber = i,
                        compatibility = Compatibility.Incompatible
                    });
                }

                // Gazette
                for (int i = 1; i <= gazetteCount; i++)
                {
                    entries.Add(new CompatibilityEntry
                    {
                        person = person,
                        category = Category.Gazette,
                        infoNumber = i,
                        compatibility = Compatibility.Incompatible
                    });
                }
            }

            Debug.Log("Entries generated: " + entries.Count);
        }

        public Compatibility GetCompatibility(string person, Category category, int infoNumber)
        {
            foreach (var entry in entries)
            {
                if (entry.person == person &&
                    entry.category == category &&
                    entry.infoNumber == infoNumber)
                {
                    return entry.compatibility;
                }
            }

            return Compatibility.Incompatible;
        }
    }
}