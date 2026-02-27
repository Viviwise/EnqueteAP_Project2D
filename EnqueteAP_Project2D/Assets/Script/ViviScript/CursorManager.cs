using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D hoverCursor;

    private static CursorManager instance;
    private int hoverCount = 0;

    public static CursorManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("CursorManager");
                instance = go.AddComponent<CursorManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    private void Start()
    {
        SetCursor(defaultCursor);
    }

    public void OnHoverEnter()
    {
        hoverCount++;
        SetCursor(hoverCursor);
    }

    public void OnHoverExit()
    {
        hoverCount = Mathf.Max(hoverCount - 1, 0);

        if (hoverCount == 0)
            SetCursor(defaultCursor);
    }

    private void SetCursor(Texture2D cursorTexture)
    {
        if (cursorTexture == null) return;

        Vector2 hotspot = new Vector2(cursorTexture.width / 2f, cursorTexture.height / 5f);
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
    }
}