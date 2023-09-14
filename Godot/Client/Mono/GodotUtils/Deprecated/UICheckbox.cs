﻿namespace GodotUtils.Deprecated;

using Godot;
using System;

public partial class UICheckbox : UIElement
{
    public Action<bool> ValueChanged { get; set; }

    CheckboxOptions options;

    public UICheckbox(CheckboxOptions options) : base(options)
    {
        this.options = options;
    }

    public override void CreateUI(HBoxContainer hbox)
    {
        var checkbox = options.CheckBox;

        checkbox.Toggled += value => ValueChanged?.Invoke(value);

        hbox.AddChild(checkbox);
    }
}

public class CheckboxOptions : ElementOptions
{
    public CheckBox CheckBox { get; set; } = new CheckBox();
}
