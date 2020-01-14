﻿using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class CustomGUILayout
{
    private CustomGUILayout()
    {
    }

    public CustomGUILayout(GUISkin skin)
    {
        Skin = skin;
    }

    private GUISkin Skin { get; }

    private bool IsToggled { get; set; }

    public enum CustomSyles
    {
        ButtonDisabled,
        ButtonEnabled
    }

    // TODO: Uniq identifier
    public bool Button(string text)
    {
        // TODO: Rect
        var @return = GUILayout.Button(text,
            !IsToggled
                ? Skin.customStyles[(int)CustomSyles.ButtonDisabled]
                : Skin.customStyles[(int)CustomSyles.ButtonEnabled]);

        Event e = Event.current;

        if (e.type == EventType.Used)
            IsToggled = @return;

        Debug.Log($"{IsToggled} | {@return} | {e.type}");

        return @return;
    }
}