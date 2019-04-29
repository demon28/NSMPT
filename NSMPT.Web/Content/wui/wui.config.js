wui.ajaxDefaultOptions = {
    error: {
        text: "请求服务器失败，请重试！",
    },
    error_401: {
        text: "您未登录或会话已过期，请重新登录！",
        callback: function (message) {
            alert(message);
        }
    },
    error_403: {
        text: "您暂无权限操作此功能，请联系管理员！",
        callback: function (message) {
            alert(message);
        }
    }
};
