window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "BlazorServer");
    }
    if (type === "error") {
        toastr.error(message, "BlazorServer Error");
    }
};