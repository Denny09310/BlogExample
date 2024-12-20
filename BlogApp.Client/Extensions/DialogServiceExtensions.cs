using Microsoft.AspNetCore.Components;
using Radzen.Blazor;

namespace Radzen;

internal static class DialogServiceExtensions
{
    private static readonly RenderFragment _loading = builder =>
    {
        builder.OpenComponent<RadzenStack>(0);
        builder.AddAttribute(1, "Orientation", Orientation.Vertical);
        builder.AddAttribute(2, "AlignItems", AlignItems.Center);
        builder.AddAttribute(3, "JustifyContent", JustifyContent.Center);
        builder.AddAttribute(4, "ChildContent", (RenderFragment)(childBuilder =>
        {
            childBuilder.OpenComponent<RadzenProgressBarCircular>(5);
            childBuilder.AddAttribute(6, "Mode", ProgressBarMode.Indeterminate);
            childBuilder.AddAttribute(7, "Size", ProgressBarCircularSize.Large);
            childBuilder.AddAttribute(8, "ShowValue", false);
            childBuilder.CloseComponent();

            childBuilder.OpenComponent<RadzenText>(9);
            childBuilder.AddAttribute(10, "Text", "Loading...");
            childBuilder.CloseComponent();
        }));
        builder.CloseComponent();
    };

    private static readonly DialogOptions _options = new()
    {
        ShowTitle = false,
        Style = "min-height:auto;min-width:auto;width:auto",
        CloseDialogOnEsc = false
    };

    internal static void ShowLoading(this DialogService service)
    {
        service.Open("", ds => _loading, _options);
    }
}