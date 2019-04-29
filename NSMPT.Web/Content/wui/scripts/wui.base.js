function vm(n) {
    var t = this;
    return t.eid = "",
        t.onBindBefore = null,
        t = $.extend({},
            t, n),
        t.data = ko.observableArray([]),
        t.data.subscribe(function (n) {
            if (t.onBindBefore != null) t.onBindBefore(n)
        }),
        t.data(n.data),
        t.eid == "" ? ko.applyBindings(t) : ko.applyBindings(t, document.getElementById(t.eid)),
        t.unbind = function () {
            var n = document.getElementById(t.eid);
            ko.cleanNode(n)
        },
        t
}
var wui = wui || {},
    template;
wui.ajaxDefaultOptions = {
    error: {
        text: "请求服务器失败，请重试！"
    },
    error_401: {
        text: "您未登录或会话已过期，请重新登录！",
        callback: function (n) {
            alert(n)
        }
    },
    error_403: {
        text: "您暂无权限操作此功能，请联系管理员！",
        callback: function (n) {
            alert(n)
        }
    }
};
$(function () {
    jQuery.post = function (n, t, i, r) {
        return jQuery.aopAjax(n, t, i, r, "POST")
    };
    jQuery.get = function (n, t, i, r) {
        return jQuery.aopAjax(n, t, i, r, "GET")
    };
    jQuery.aopAjax = function (n, t, i, r, u) {
        wui.wait.loading();
        var f = wui.ajaxDefaultOptions,
            e = {
                url: n,
                data: t,
                type: u || "POST",
                dataType: r || "json",
                complete: function () {
                    wui.wait.loaded()
                },
                success: function (n) {
                    if (!n.Success) switch (n.StatusCode) {
                        case 401:
                            f.error_401.callback(f.error_401.text);
                            return;
                        case 403:
                            f.error_401.callback(f.error_403.text);
                            return
                    }
                    i(n)
                },
                error: function (n, t, r) {
                    var u = {
                        StatusCode: 0,
                        Success: !1,
                        Message: f.error.text + r,
                        Content: null
                    };
                    i(u)
                }
            };
        return jQuery.ajax(e)
    }
});
$(function () {
    function n(n) {
        var t = this;
        t.settings = {
            title: "系统提示",
            message: "",
            width: 400,
            height: 200,
            icoClass: null,
            callback: null
        };
        t.settings = $.extend(t.settings, n);
        t.show = function () {
            var n = t.createHtml(t.settings);
            $(n.wrap).modal()
        };
        t.createHtml = function (n) {
            var i = template.get("wui.alert.html"),
                t = $(i);
            return $(".modal-dialog", t).css({
                width: n.width
            }),
                $(".modal-title span", t).text(n.title),
                $(".modal-title i", t).addClass(n.icoClass),
                $(".modal-body p", t).html(n.message),
                $("body").append(t),
                {
                    wrap: t
                }
        }
    }
    wui.alert = function (t) {
        var i = new n(t);
        i.show()
    }
});
wui = wui || {};
wui.bindModel = function (n, t) {
    var i = new Vue({
        el: n,
        data: t
    })
};
$.fn.json = function () {
    var n = {},
        t = this.serializeArray();
    return $.each(t,
        function () {
            n[this.name] ? (n[this.name].push || (n[this.name] = [n[this.name]]), n[this.name].push(this.value || "")) : n[this.name] = this.value || ""
        }),
        n
};
wui = wui || {};
wui.wait = {};
wui.wait.loading = function (n) {
    var t = $('<div class="loading alert alert-success" role="alert"><strong><i class="fa fa-refresh fa-spin fa-fw" style=""><\/i>正在加载<\/strong><span class="loading-text">请耐心等待，系统正在为您处理请求！<\/span><\/div>'),
        r,
        i;
    switch (n) {
        case "full":
            t.addClass("loading-full");
            break;
        default:
        case "":
            r = $("body").width() / 2 - 200;
            t.addClass("loading-center");
            t.css({
                left: r
            })
    }
    $("body").prepend(t);
    i = function (n) {
        $(".loading-text", t).html(n)
    };
    setTimeout(function () {
        t.fadeIn(function () {
            setTimeout(function () {
                i("服务器正在拼命加载");
                setTimeout(function () {
                    t.addClass("alert-warning");
                    i("您的网速有点慢哦");
                    setTimeout(function () {
                        t.addClass("alert-danger");
                        i("您的网速太慢了，请确保您的网络是否正常！");
                        setTimeout(function () {
                            i("正在拼命加载中...")
                        },
                            3e3)
                    },
                        6e3)
                },
                    4e3)
            },
                500)
        })
    },
        1e3)
};
wui.wait.loaded = function () {
    $(".loading").remove()
};
template = {};
template.path = "/Resources/scripts/wui/template/";
template.getBasePath = function () {
    for (var i = "wui.base.js",
        r = document.scripts,
        t, n = 0; n < r.length; n++) if (t = r[n].src, t.indexOf(i) > -1) return template.path = t.replace(i, "template/"),
            !0;
    return !1
};
template.get = function (n) {
    var t = template.path + n;
    return template.getTemplate(t)
};
template.getTemplate = function (n) {
    var t = "";
    return $.ajax({
        url: n,
        async: !1,
        success: function (n) {
            t = n
        }
    }),
        t
};
template.getBasePath();
$.fn.success = function (n) {
    var i = {
        text: n,
        eleClass: "text-success",
        icoClass: "glyphicon glyphicon-ok-sign"
    },
        t = $.extend(i, t);
    $(this).tip(t)
};
$.fn.info = function (n) {
    var i = {
        text: n,
        eleClass: "text-info",
        icoClass: "glyphicon glyphicon-list-alt"
    },
        t = $.extend(i, t);
    $(this).tip(t)
};
$.fn.warning = function (n) {
    var i = {
        text: n,
        eleClass: "text-warning",
        icoClass: "glyphicon glyphicon-info-sign"
    },
        t = $.extend(i, t);
    $(this).tip(t)
};
$.fn.error = function (n) {
    var i = {
        text: n,
        eleClass: "text-danger",
        icoClass: "glyphicon glyphicon-remove-sign"
    },
        t = $.extend(i, t);
    $(this).tip(t)
};
$.fn.tip = function (n) {
    var i, t;
    n = $.extend({
        text: "提示消息",
        eleClass: "text-success",
        icoClass: "glyphicon glyphicon-ok-sign"
    },
        n);
    i = $("<i>").addClass(n.icoClass);
    t = $("<span>").addClass(n.eleClass);
    t.append(i);
    t.append(n.text);
    $(this).text("").append(t)
};
wui.waitDefaultOptions = {
    text: "正在提交"
},
    function (n) {
        "use strict";
        n.wait = function (t, i) {
            if (!(this instanceof n.wait)) return new n.wait(t, i);
            var r = this;
            return r.el = n(t),
                r.el.data("wait", r),
                r.init = function () {
                    r.options = n.extend({},
                        wui.waitDefaultOptions, i);
                    r.options.originalText = r.el.html();
                    r.disabled()
                },
                r.disabled = function () {
                    var n = '<i class="fa fa-refresh fa-spin fa-fw"><\/i>' + r.options.text;
                    r.el.html(n);
                    r.el.attr("disabled", "disabled")
                },
                r.enable = function () {
                    r.el.html(r.options.originalText);
                    r.el.removeAttr("disabled")
                },
                r.callMethod = function (t, i) {
                    switch (t) {
                        case "option":
                            r.options = n.extend({},
                                r.options, i);
                            break;
                        case "enable":
                        case "e":
                            r.enable();
                            break;
                        case "disabled":
                        case "d":
                            r.disabled();
                            break;
                        default:
                            throw new Error('[wait] method "' + t + '" does not exist');
                    }
                    return r.el
                },
                r.init(),
                r.el
        };
        n.fn.wait = function () {
            var r = this,
                t = Array.prototype.slice.call(arguments),
                u,
                i;
            if (t[0] == "is:d") return u = n(r).attr("disabled"),
                u == "disabled";
            if (typeof t[0] == "string") {
                if (i = n(r).data("wait"), i) return i.callMethod(t[0], t[1]);
                throw new Error("[wait] the element is not instantiated");
            } else return new n.wait(this, t[0])
        }
    }(jQuery)