﻿using System.Collections.Generic;

public class LanguageController
{
    public static List<LocalizedText> localizedTexts = new List<LocalizedText>();
    public static bool[] noLineBreak = { false, true };
    private static int _language;
    public static int LanguageCount => noLineBreak.Length;
    public delegate void LanguageChangeCall();
    public static event LanguageChangeCall Call;
    public static void Refresh() => Language = _language;
    public static int Language
    {
        get { return _language; }
        set
        {
            _language = value;
            for (int i = 0; i < localizedTexts.Count; i++) localizedTexts[i].SetLanguage(value);
            Call?.Invoke();
        }
    }
}