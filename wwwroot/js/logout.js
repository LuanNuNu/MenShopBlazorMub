

window.onBeforeUnloadLogout = () => {
    window.addEventListener("beforeunload", function (e) {
        // Gọi phương thức C# không đồng bộ mà không cần await
        if (window.dotNetLogoutRef) {
            window.dotNetLogoutRef.invokeMethod("LogoutFromJS");
        }
    });
};
