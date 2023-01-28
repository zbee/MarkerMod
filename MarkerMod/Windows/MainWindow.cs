using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using ImGuiScene;

namespace MarkerMod.Windows;

public class MainWindow : Window, IDisposable
{
    private TextureWrap icon;
    private Plugin Plugin;

    public MainWindow(Plugin plugin, TextureWrap icon) : base(
        "My Amazing Window", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        this.SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        this.icon = icon;
        this.Plugin = plugin;
    }

    public void Dispose()
    {
        this.icon.Dispose();
    }

    public override void Draw()
    {
        ImGui.Text($"The random config bool is {this.Plugin.Configuration.SomePropertyToBeSavedAndWithADefault}");

        if (ImGui.Button("Show Settings"))
        {
            this.Plugin.DrawConfigUI();
        }

        ImGui.Spacing();

        ImGui.Text("Have an icon:");
        ImGui.Indent(55);
        ImGui.Image(this.icon.ImGuiHandle, new Vector2(this.icon.Width, this.icon.Height));
        ImGui.Unindent(55);
    }
}
