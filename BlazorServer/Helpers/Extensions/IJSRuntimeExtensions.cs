namespace BlazorServer.Helpers.Extensions
{
    using Microsoft.JSInterop;
    using System.Threading.Tasks;
    public static class IJSRuntimeExtensions
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime js, string message) => await js.InvokeVoidAsync("ShowToastr", "success", message);
        public static async ValueTask ToastrError(this IJSRuntime js, string message) => await js.InvokeVoidAsync("ShowToastr", "error", message);
    }
}
