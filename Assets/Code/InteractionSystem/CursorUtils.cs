using UnityEngine;

public static class CursorUtils
{
    public static void SetCursor(Texture2D texture, CursorMode mode = CursorMode.Auto)
    {
        if (texture == null)
        {
            Cursor.SetCursor(null, Vector2.zero, mode);
            return;
        }

        Vector2 hotspot = new Vector2(texture.width / 2f, texture.height / 2f);
        Cursor.SetCursor(texture, hotspot, mode);
    }
}
