using UnityEditor;
using UnityEngine;
using Script.Comparaison;

namespace Script.Comparaison.Editor
{
    [CustomEditor(typeof(CompatibilityDatabase))]
    public class CompatibilityDatabaseEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            CompatibilityDatabase db = (CompatibilityDatabase)target;

            if (GUILayout.Button("Generate Entries"))
            {
                db.GenerateEntries();
            }

            GUILayout.Space(10);

            if (db.entries == null || db.entries.Count == 0)
            {
                EditorGUILayout.HelpBox("Aucune entrée. Clique sur Generate Entries.", MessageType.Warning);
            }
            else
            {
                EditorGUILayout.HelpBox($"Entries: {db.entries.Count}", MessageType.Info);
            }

            GUILayout.Space(10);

            foreach (var person in db.people)
            {
                if (string.IsNullOrEmpty(person))
                    continue;

                EditorGUILayout.LabelField(person, EditorStyles.boldLabel);

                DrawTable(db, person);

                GUILayout.Space(15);
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(db);
            }
        }

        private void DrawTable(CompatibilityDatabase db, string person)
        {
            EditorGUILayout.BeginVertical("box");

            DrawCategoryRow(db, person, Category.Plante, db.planteCount, "Plantes");
            DrawCategoryRow(db, person, Category.BlessureInt, db.blessureInterneCount, "Blessures int.");
            DrawCategoryRow(db, person, Category.BlessureExt, db.blessureExterneCount, "Blessures ext.");
            DrawCategoryRow(db, person, Category.Gazette, db.gazetteCount, "Gazette");

            EditorGUILayout.EndVertical();
        }

        private void DrawCategoryRow(CompatibilityDatabase db, string person, Category category, int count, string label)
        {
            EditorGUILayout.LabelField(label, EditorStyles.miniBoldLabel);
            EditorGUILayout.BeginHorizontal();

            for (int i = 1; i <= count; i++)
            {
                var entry = db.entries.Find(e =>
                    e.person == person &&
                    e.category == category &&
                    e.infoNumber == i);

                if (entry == null)
                {
                    DrawMissingCell();
                    continue;
                }

                DrawToggleCell(entry);
            }

            EditorGUILayout.EndHorizontal();
        }

        private void DrawToggleCell(CompatibilityEntry entry)
        {
            EditorGUILayout.BeginVertical("box", GUILayout.Width(45));

            EditorGUILayout.LabelField(entry.infoNumber.ToString(), GUILayout.Width(20));

            entry.compatibility = GUILayout.Toggle(entry.compatibility == Compatibility.Compatible, "OK", "Button")
                ? Compatibility.Compatible
                : entry.compatibility;

            entry.compatibility = GUILayout.Toggle(entry.compatibility == Compatibility.Incompatible, "NO", "Button")
                ? Compatibility.Incompatible
                : entry.compatibility;

            EditorGUILayout.EndVertical();
        }

        private void DrawMissingCell()
        {
            EditorGUILayout.BeginVertical("box", GUILayout.Width(45));
            EditorGUILayout.LabelField("?", GUILayout.Width(20));
            EditorGUILayout.EndVertical();
        }
    }
}