namespace Script.Comparaison.Editor
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(CompatibilityDatabase))]

    public class CompatibilityDatabaseEditor : Editor
    {
       public override void OnInspectorGUI()
        {
            CompatibilityDatabase db = (CompatibilityDatabase)target;

            if (GUILayout.Button("Generate Entries"))
            {
                db.GenerateEntries();
            }

            GUILayout.Space(10);

            foreach (var person in db.people)
            {
                EditorGUILayout.LabelField(person, EditorStyles.boldLabel);

                // Plantes
                GUILayout.Label("Plante:");
                DrawCategory(db, person, Category.Plante, db.planteCount);

                // Blessures internes
                GUILayout.Label("Blessures internes:");
                DrawCategory(db, person, Category.BlessureInt, db.blessureInterneCount);

                // Blessures externes
                GUILayout.Label("Blessures externes:");
                DrawCategory(db, person, Category.BlessureExt, db.blessureExterneCount);

                // Gazette
                GUILayout.Label("Gazette:");
                DrawCategory(db, person, Category.Gazette, db.gazetteCount);

                GUILayout.Space(15);
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(db);
            }
        }

        private void DrawCategory(CompatibilityDatabase db, string person, Category category, int count)
        {
            EditorGUILayout.BeginHorizontal();

            for (int i = 1; i <= count; i++)
            {
                var entry = db.entries.Find(e => e.person == person && e.category == category && e.infoNumber == i);
                if (entry == null) continue; // au cas où GenerateEntries n'a pas été lancé

                EditorGUILayout.BeginVertical();

                EditorGUILayout.LabelField(i.ToString(), GUILayout.Width(20));

                EditorGUILayout.BeginHorizontal();

                if (GUILayout.Toggle(entry.compatibility == Compatibility.Compatible, "OK", "Button"))
                    entry.compatibility = Compatibility.Compatible;
                if (GUILayout.Toggle(entry.compatibility == Compatibility.PartiallyCompatible, "MEH", "Button"))
                    entry.compatibility = Compatibility.PartiallyCompatible;
                if (GUILayout.Toggle(entry.compatibility == Compatibility.Incompatible, "NO", "Button"))
                    entry.compatibility = Compatibility.Incompatible;

                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.EndHorizontal();
        }

    } 
}