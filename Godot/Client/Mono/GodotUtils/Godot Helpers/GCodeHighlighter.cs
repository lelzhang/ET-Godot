﻿namespace GodotUtils;

using Godot;

public partial class GCodeHighlighter : CodeHighlighter
{
    public GCodeHighlighter()
    {
        NumberColor = new Color("FFB6FF");
        SymbolColor = new Color("a8b1d6");
        FunctionColor = new Color("b988ff");
        MemberVariableColor = new Color("becaf5");
        ColorRegions = new Godot.Collections.Dictionary
        {
            { "//", new Color("434048") }
        };
        KeywordColors = new Godot.Collections.Dictionary();

        // keywords cannot contain any symbols except for "_" so can't include stuff like "'"
        var keywords = new string[]
        {
            "var",
            "true",
            "false",
            "new",
            "private",
            "public",
            "protected",
            "internal",
            "void"
        };

        foreach (string keyword in keywords)
            KeywordColors.Add(keyword, new Color("a59fff"));
    }
}
