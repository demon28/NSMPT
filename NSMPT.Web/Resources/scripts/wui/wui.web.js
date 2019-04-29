var flyout, wui, win; (function (n) {
    "use strict";
    //n.combobox = function (t, i) {
    //    if (!(this instanceof n.combobox)) return new n.combobox(t, i);
    //    var r = this;
    //    return r.el = n(t),
    //        r.comboboxId = Math.floor(Math.random() * 1e3) + "",
    //        r.tagName = r.el.get(0).tagName,
    //        r.mvvm,
    //        r.combobox = null,
    //        r.selectData = null,
    //        r.el.data("combobox", r),
    //        r.init = function (t) {
    //            var f, i, u;
    //            n.combobox.defaultOptions.name = r.el.attr("name") + "Combobox";
    //            f = parseInt(r.el.css("width"));
    //            n.combobox.defaultOptions.width = f < 150 ? "150px" : r.el.css("width");
    //            switch (r.tagName) {
    //                case "SELECT":
    //                    i = [];
    //                    n("option", r.el).each(function () {
    //                        var t = {
    //                            value: n(this).val(),
    //                            name: n(this).text()
    //                        };
    //                        i.push(t)
    //                    });
    //                    n.combobox.defaultOptions.value = r.el.val();
    //                    i.length > 0 && (n.combobox.defaultOptions.data = i)
    //            }
    //            r.options = n.extend({},
    //                n.combobox.defaultOptions, t);
    //            r.render();
    //            u = r.getDefault();
    //            u && r.setDefault(u)
    //        },
    //        r.render = function () {
    //            r.renderHtml();
    //            r.bindEvents()
    //        },
    //        r.renderHtml = function () {
    //            var f = template.get("wui.combobox-2.0.html"),
    //                t = n(f).attr("id", r.comboboxId),
    //                e = n(".combobox-input", t).attr({
    //                    name: r.options.name,
    //                    placeholder: r.el.attr("placeholder")
    //                }),
    //                i = n(".combobox-arrow", t),
    //                u;
    //            n("i", i).addClass(r.options.arrowDownIco);
    //            u = n(".combobox-body", t);
    //            r.setBaseValue("");
    //            r.el.parent().append(t);
    //            u.css({
    //                "max-height": r.options.height,
    //                width: r.options.width
    //            });
    //            i.css("left", parseInt(r.options.width) - 40);
    //            e.css("width", r.options.width);
    //            r.options.search ? n(".search").show() : n(".search").hide();
    //            r.el.hide();
    //            r.combobox = t;
    //            r.bindData(r.options.data)
    //        },
    //        r.bindData = function (n) {
    //            for (var t, i = 0; i < n.length; i++) t = n[i],
    //                t.select || (t.select = 0),
    //                t.icoClass || (t.icoClass = ""),
    //                t.checkedObservable = ko.observable(t.select);
    //            r.mvvm != null && r.mvvm.unbind();
    //            r.mvvm = new vm({
    //                eid: r.comboboxId,
    //                data: n,
    //                valueField: r.options.valueField,
    //                textField: r.options.textField,
    //                click: r.select
    //            })
    //        },
    //        r.bindEvents = function () {
    //            n(".combobox-input,.combobox-arrow", r.combobox).click(function () {
    //                if (!n(".combobox-input", r.combobox).prop("disabled")) {
    //                    var t = n(".combobox-body", r.combobox);
    //                    t.is(":hidden") ? r.slideDown() : r.slideUp()
    //                }
    //            });
    //            n(".combobox-input", r.combobox).keydown(function (n) {
    //                if (n.keyCode != 8) return !1;
    //                r.unselect()
    //            });
    //            n(".combobox-body > a", r.combobox).click(function () {
    //                var t = n(this),
    //                    i = t.data("combobox-item");
    //                return r.select(i),
    //                    !1
    //            });
    //            n(document).click(function () {
    //                r.slideUp()
    //            });
    //            r.combobox.click(function (n) {
    //                n.stopPropagation()
    //            })
    //        },
    //        r.getDefault = function () {
    //            var n = r.options.value,
    //                t, i;
    //            if (!n) for (t = 0; t < r.options.data.length; t++) if (i = r.options.data[t], i.select && i.select == 1) return i[r.options.valueField];
    //            return !n && r.options.data.length > 0 && r.options.required && (n = r.options.data[0][r.options.valueField]),
    //                n
    //        },
    //        r.setDefault = function (n) {
    //            for (var u = r.options.data,
    //                i, t = 0; t < u.length; t++) i = u[t],
    //                    i[r.options.valueField] == n && (r.selectData = i);
    //            r.select(r.selectData)
    //        },
    //        r.slideDown = function () {
    //            n(".combobox-arrow>i", r.combobox).removeClass(r.options.arrowDownIco).addClass(r.options.arrowUpIco);
    //            n(".combobox-body", r.combobox).slideDown(100)
    //        },
    //        r.slideUp = function () {
    //            n(".combobox-arrow>i", r.combobox).removeClass(r.options.arrowUpIco).addClass(r.options.arrowDownIco);
    //            n(".combobox-body", r.combobox).slideUp(100)
    //        },
    //        r.select = function (t) {
    //            var u, i, f, e;
    //            if (t.enable == undefined || t.enable) {
    //                if (r.options.maxCheckedCount + 1 > 1) for (u = 0; u < r.options.data.length; u++)(i = r.options.data[u], !i != t) && (i.select = 0, i.checkedObservable(i.select));
    //                if (t.select = 1, t.checkedObservable(t.select), r.selectData = t, f = t[r.options.textField], e = t[r.options.valueField], n("#" + r.comboboxId + " .combobox-input").val(f), r.setBaseValue(e), r.options.onSelect) r.options.onSelect(t);
    //                r.slideUp()
    //            }
    //        },
    //        r.setBaseValue = function (n) {
    //            switch (r.el.get(0).tagName) {
    //                case "INPUT":
    //                case "SELECT":
    //                    r.el.val(n)
    //            }
    //        },
    //        r.unselect = function () {
    //            n(".combobox-input", r.combobox).val("");
    //            r.setBaseValue("");
    //            r.selectData = null;
    //            r.options.onUnselect && r.options.onUnselect()
    //        },
    //        r.disabled = function () {
    //            n(".combobox-input", r.combobox).attr("disabled", "disabled")
    //        },
    //        r.enable = function () {
    //            n(".combobox-input", r.combobox).removeAttr("disabled")
    //        },
    //        r.callMethod = function (t, i) {
    //            switch (t) {
    //                case "option":
    //                    r.options = n.extend({},
    //                        r.options, i);
    //                    r.combobox.remove();
    //                    r.init(r.options);
    //                    break;
    //                case "setValue":
    //                    r.setDefault(i);
    //                    break;
    //                case "getValue":
    //                    return r.selectData;
    //                case "unselect":
    //                    r.unselect();
    //                    break;
    //                case "disabled":
    //                    r.disabled();
    //                    break;
    //                case "enable":
    //                    r.enable();
    //                    break;
    //                default:
    //                    throw new Error('[combobox] method "' + t + '" does not exist');
    //            }
    //            return r.el
    //        },
    //        r.init(i),
    //        r.el
    //};
    //n.combobox.defaultOptions = {
    //    valueField: "value",
    //    textField: "name",
    //    data: [{
    //        name: "暂无可选项",
    //        value: "",
    //        enable: !1
    //    }],
    //    name: "",
    //    height: 400,
    //    width: 0,
    //    value: "",
    //    required: !1,
    //    search: !1,
    //    maxCheckedCount: 1,
    //    arrowDownIco: "glyphicon glyphicon-menu-down",
    //    arrowUpIco: "glyphicon glyphicon-menu-up",
    //    onSelect: null,
    //    onUnselect: null
    //};
    //n.fn.combobox = function () {
    //    var i = this,
    //        r = Array.prototype.slice.call(arguments),
    //        u,
    //        t;
    //    if (typeof r[0] == "string") {
    //        if (t = n(i).data("combobox"), t) return t.callMethod(r[0], r[1]);
    //        throw new Error("$(" + i.selector + ").combobox() 控件未实例化，无法直接调用其函数");
    //    } else for (u = 0; u < i.length; u++) {
    //        if (t = n(i.eq(u)).data("combobox"), t) {
    //            t.callMethod("option", r[0]);
    //            continue
    //        }
    //        new n.combobox(i[u], r[0])
    //    }
    //}
})(jQuery);
//$(function () {
  //  $("input[data-type='wui-combobox'],select").each(function (i) {
 //       var data = {},
  //          options = $(this).attr("data-options");
    //    options && (options = eval("(" + options + ")"), data = options);
   //     $(this).removeAttr("data-type");
   //     $(this).combobox(data)
  //  })
//});
flyout = {
    show: function (n) {
        var i = {
            id: Math.floor(Math.random() * 999 + 1),
            title: "未命名",
            subtitle: "",
            url: "about:blank",
            width: "50%",
            height: 400,
            icoClass: null,
            closable: !0,
            callback: null
        },
            t;
        i = $.extend(i, n);
        t = flyout.createHtml(i);
        $.data(t.iframe[0], "randomId", i.id);
        $.data(t.iframe[0], "callback", i.callback);
        t.fade.click(function () {
            i.id = t.iframe[0].id;
            flyout.close(i)
        });
        t.fade.show();
        $("body").addClass("fade-body");
        t.body.show().animate({
            width: i.width
        },
            function () {
                t.iframe.attr("src", i.url);
                setTimeout(function () {
                    $("span", t.load).html("服务器正在拼命加载");
                    setTimeout(function () {
                        $("span", t.load).html("您的网速有点慢哦");
                        setTimeout(function () {
                            $("span", t.load).html("您的网速太慢了，请确保您的网络是否正常！");
                            setTimeout(function () {
                                $("span", t.load).html("正在拼命加载中...")
                            },
                                3e3)
                        },
                            6e3)
                    },
                        4e3)
                },
                    2e3);
                t.iframe.load(function () {
                    t.load.hide();
                    t.load.remove()
                })
            })
    },
    createHtml: function (n) {
        var r = template.get("wui.flyout.iframe.html"),
            t = $(r),
            i = $(".flyout-body", t),
            o = $(".flyout-content", t),
            u = $(".iframe-load", t),
            f = $("iframe", t).attr({
                id: n.id
            }).css({
                height: $(window).height() - 120
            }),
            e = $(".fade-background", t);
        return $(".page-header>h3>i", i).addClass(n.icoClass),
            $(".page-header>h3>span", i).html(n.title),
            $(".page-header>h3>small", i).html(n.subtitle),
            $("body").append(t),
            {
                body: i,
                load: u,
                iframe: f,
                fade: e
            }
    },
    close: function (n) {
        var t = {
            id: "0"
        };
        t = $.extend(t, n);
        var r = $("#" + t.id),
            e = $.data(r[0], "randomId"),
            i = r.parents(".flyout"),
            f = $(".flyout-body", i),
            u = $(".fade-background", i);
        $("body").removeClass("fade-body");
        f.animate({
            width: "0"
        },
            function () {
                u.hide();
                u.remove();
                i.remove()
            })
    },
    callback: function (n) {
        var t = {
            id: "0",
            result: null
        },
            r,
            i;
        t = $.extend(t, n);
        r = $("#" + t.id);
        i = $.data(r[0], "callback");
        i && i(t.result)
    }
},
    function (n) {
        "use strict";
        n.flyout = function (t, i) {
            if (!(this instanceof n.flyout)) return new n.flyout(t, i);
            var r = this;
            return r.$container = n(t),
                r.$container.data("flyout", r),
                r.init = function () {
                    r.options = n.extend({},
                        n.flyout.defaultOptions, i);
                    r.render();
                    r.show()
                },
                r.render = function () {
                    r.renderHtml();
                    r.bindEvents()
                },
                r.renderHtml = function () {
                    var t = n('<div class="fade-background"><\/div>');
                    n("body").append(t);
                    r.$container.addClass("flyout-body")
                },
                r.callMethod = function (t, i) {
                    switch (t) {
                        case "option":
                            r.options = n.extend({},
                                r.options, i);
                            r.verify();
                            r.render();
                            break;
                        default:
                            throw new Error('[flyout] method "' + t + '" does not exist');
                    }
                    return r.$container
                },
                r.bindEvents = function () {
                    n(".fade-background").click(function () {
                        r.close()
                    })
                },
                r.show = function () {
                    n(".fade-background").show();
                    n("body").addClass("fade-body");
                    r.$container.show().animate({
                        width: r.options.width
                    })
                },
                r.close = function () {
                    n("body").removeClass("fade-body");
                    var t = r.$container,
                        i = n(".fade-background");
                    t.animate({
                        width: "0"
                    },
                        function () {
                            i.hide();
                            i.remove();
                            t.hide()
                        })
                },
                r.init(),
                r.$container
        };
        n.flyout.defaultOptions = {
            width: "50%"
        };
        n.fn.flyout = function () {
            var r = this,
                t = Array.prototype.slice.call(arguments),
                i;
            if (typeof t[0] == "string") {
                if (i = n(r).data("flyout"), i) return i.callMethod(t[0], t[1]);
                throw new Error("[flyout] the element is not instantiated");
            } else return new n.flyout(this, t[0])
        }
    }(jQuery);
wui = wui || {};
wui.getFlyout = function () {
    return window.top.flyout
};
wui.getWin = function () {
    return window.top.win
};
wui.flyout = {
    show: function (n) {
        var t = wui.getFlyout();
        t.show(n)
    },
    close: function () {
        if (window.frameElement) {
            var n = $(window.frameElement).attr("id"),
                t = wui.getFlyout();
            t.close({
                id: n
            })
        }
    },
    callback: function (n) {
        if (window.frameElement) {
            var t = $(window.frameElement).attr("id"),
                i = wui.getFlyout();
            i.callback({
                id: t,
                result: n
            })
        }
    }
};
wui.win = {
    show: function (n) {
        var t = wui.getWin();
        t.show(n)
    },
    close: function () {
        if (window.frameElement) {
            var n = $(window.frameElement).attr("id"),
                t = wui.getWin();
            t.close({
                id: n
            })
        }
    },
    callback: function (n) {
        if (window.frameElement) {
            var t = $(window.frameElement).attr("id"),
                i = wui.getWin();
            i.callback({
                id: t,
                result: n
            })
        }
    },
    submit: function (n) {
        if (window.frameElement) {
            var t = $(window.frameElement).attr("id"),
                i = wui.getWin();
            i.submit({
                id: t,
                fn: n
            })
        }
    }
},
    function (n) {
        "use strict";
        n.paging = function (t, i) {
            if (!(this instanceof n.paging)) return new n.paging(t, i);
            var r = this;
            return r.viewModel,
                r.el = n(t),
                r.el.data("paging", r),
                r.init = function () {
                (i.first || i.prev || i.next || i.last || i.page) && (i = n.extend({},
                    {
                        first: "",
                        prev: "",
                        next: "",
                        last: "",
                        page: ""
                    },
                    i));
                    r.options = n.extend({},
                        n.paging.defaultOptions, i);
                    r.viewModel == null && (r.viewModel = new Vue({
                        el: r.options.el,
                        data: {
                            items: []
                        },
                        methods: r.options.methods
                    }));
                    r.verify();
                    r.extendJquery();
                    r.render();
                    r.fireEvent(this.options.currentPage, "init")
                },
                r.verify = function () {
                    var n = r.options;
                    if (!r.isNumber(n.totalPages)) throw new Error("[paging] type error: totalPages");
                    if (!r.isNumber(n.totalCounts)) throw new Error("[paging] type error: totalCounts");
                    if (!r.isNumber(n.pageSize)) throw new Error("[paging] type error: pageSize");
                    if (!r.isNumber(n.currentPage)) throw new Error("[paging] type error: currentPage");
                    if (!r.isNumber(n.visiblePages)) throw new Error("[paging] type error: visiblePages");
                    if (!n.totalPages && !n.totalCounts) throw new Error("[paging] totalCounts or totalPages is required");
                    if (!n.totalPages && !n.totalCounts) throw new Error("[paging] totalCounts or totalPages is required");
                    if (!n.totalPages && n.totalCounts && !n.pageSize) throw new Error("[paging] pageSize is required");
                    if (n.totalCounts && n.pageSize && (n.totalPages = Math.ceil(n.totalCounts / n.pageSize)), n.currentPage < 1 || n.currentPage > n.totalPages) throw new Error("[paging] currentPage is incorrect");
                    if (n.totalPages < 1) throw new Error("[paging] totalPages cannot be less currentPage");
                },
                r.extendJquery = function () {
                    n.fn.jqPaginatorHTML = function (t) {
                        return t ? this.before(t).remove() : n("<p>").append(this.eq(0).clone()).html()
                    }
                },
                r.render = function () {
                    r.renderHtml();
                    r.setStatus();
                    r.bindEvents()
                },
                r.renderHtml = function () {
                    for (var t = [], u = r.getPages(), i = 0, f = u.length; i < f; i++) t.push(r.buildItem("page", u[i]));
                    r.isEnable("prev") && t.unshift(r.buildItem("prev", r.options.currentPage - 1));
                    r.isEnable("first") && t.unshift(r.buildItem("first", 1));
                    r.isEnable("pageSizeText") && t.unshift(r.buildItem("pageSizeText", r.options.pageSize));
                    r.isEnable("statistics") && t.unshift(r.buildItem("statistics"));
                    r.isEnable("next") && t.push(r.buildItem("next", r.options.currentPage + 1));
                    r.isEnable("last") && t.push(r.buildItem("last", r.options.totalPages));
                    r.isEnable("totalPagesText") && t.push(r.buildItem("totalPagesText", r.options.totalPages));
                    r.isEnable("totalCountsText") && t.push(r.buildItem("totalCountsText", r.options.totalCounts));
                    r.isEnable("loadingText") && t.push(r.buildItem("loadingText", r.options.currentPage + 1));
                    r.options.wrapper ? r.el.html(n(r.options.wrapper).html(t.join("")).jqPaginatorHTML()) : r.el.html(t.join(""))
                },
                r.buildItem = function (t, i) {
                    var u = r.options[t].replace(/{{page}}/g, i).replace(/{{pageSize}}/g, r.options.pageSize).replace(/{{totalPages}}/g, r.options.totalPages).replace(/{{totalCounts}}/g, r.options.totalCounts);
                    return n(u).attr({
                        "jp-role": t,
                        "jp-data": i
                    }).jqPaginatorHTML()
                },
                r.setStatus = function () {
                    var t = r.options;
                    r.isEnable("first") && t.currentPage !== 1 || n("[jp-role=first]", r.el).addClass(t.disableClass);
                    r.isEnable("prev") && t.currentPage !== 1 || n("[jp-role=prev]", r.el).addClass(t.disableClass); (!r.isEnable("next") || t.currentPage >= t.totalPages) && n("[jp-role=next]", r.el).addClass(t.disableClass); (!r.isEnable("last") || t.currentPage >= t.totalPages) && n("[jp-role=last]", r.el).addClass(t.disableClass);
                    n("[jp-role=page]", r.el).removeClass(t.activeClass);
                    n("[jp-role=page][jp-data=" + t.currentPage + "]", r.el).addClass(t.activeClass)
                },
                r.getPages = function () {
                    var e = [],
                        n = r.options.visiblePages,
                        o = r.options.currentPage,
                        t = r.options.totalPages,
                        f;
                    n > t && (n = t);
                    var s = Math.floor(n / 2),
                        i = o - s + 1 - n % 2,
                        u = o + s;
                    for (i < 1 && (i = 1, u = n), u > t && (u = t, i = 1 + t - n), f = i; f <= u;) e.push(f),
                        f++;
                    return e
                },
                r.getPageSize = function () {
                    var i = n("#page-size", r.el).val(),
                        t;
                    try {
                        return (t = parseInt(i), isNaN(t) || t <= 0) ? r.options.pageSize : t
                    } catch (u) {
                        return r.options.pageSize
                    }
                    return r.options.pageSize
                },
                r.isNumber = function (n) {
                    var t = typeof n;
                    return t === "number" || t === "undefined"
                },
                r.isEnable = function (n) {
                    return r.options[n] && typeof r.options[n] == "string"
                },
                r.switchPage = function (n) {
                    r.options.currentPage = n;
                    r.render()
                },
                r.fireEvent = function (n) {
                    return r.ajax(n),
                        !0
                },
                r.callMethod = function (t, i) {
                    switch (t) {
                        case "option":
                            r.options = n.extend({},
                                r.options, i);
                            r.verify();
                            r.render();
                            break;
                        case "destroy":
                            r.el.empty();
                            r.el.removeData("paging");
                            break;
                        case "refresh":
                            r.fireEvent(r.options.currentPage, "init");
                            break;
                        case "reload":
                            r.options.currentPage = 1;
                            r.options.totalPages = 1;
                            r.fireEvent(r.options.currentPage, "init");
                            break;
                        default:
                            throw new Error('[paging] method "' + t + '" does not exist');
                    }
                    return r.el
                },
                r.bindEvents = function () {
                    var t = r.options;
                    r.el.off();
                    r.el.on("click", "[jp-role]",
                        function () {
                            var i = n(this),
                                u;
                            i.hasClass(t.disableClass) || i.hasClass(t.activeClass) || i.hasClass("pagesize") || (u = +i.attr("jp-data"), r.fireEvent(u, "change") && r.switchPage(u))
                        });
                    n("#page-size", r.el).keyup(function () {
                        var i = n(this).val(),
                            t;
                        try {
                            if (!i || i.length <= 0) return;
                            if (t = parseInt(i), isNaN(t) || t <= 0) {
                                n("#page-size", r.el).val(r.options.pageSize);
                                return
                            }
                            n("#page-size", r.el).val(t);
                            r.options.pageSize = t
                        } catch (u) {
                            n("#page-size", r.el).val(r.options.pageSize)
                        }
                    })
                },
                r.beginLoading = function () {
                    n(".loading", r.el).show()
                },
                r.endLoading = function () {
                    n(".loading", r.el).hide()
                },
                r.ajax = function (t) {
                    var i = {
                        pageSize: r.getPageSize(),
                        pageIndex: t
                    },
                        u;
                    r.options.getData != undefined && (u = r.options.getData(), i = n.extend(i, u));
                    r.beginLoading();
                    n.post(r.options.url, i,
                        function (t) {
                            if (r.endLoading(), !t.Success) return r.showTip(!0, t.Message),
                                !1;
                            r.viewModel.items = t.Content.Data;
                            t.Content.Data.length <= 0 ? n(r.options.tip).show() : n(r.options.tip).hide();
                            r.showTip(t.Content.Data.length <= 0, "没有找到相关数据，请检查是否条件输入有误！");
                            r.el.paging("option", {
                                currentPage: t.Content.PageIndex,
                                totalCounts: t.Content.Count
                            });
                            r.options.onComplete != undefined && r.options.onComplete()
                        })
                },
                r.showTip = function (t, i) {
                    t ? n(r.options.tip).html("<strong>系统提示!<\/strong>" + i + "").show() : n(r.options.tip).hide()
                },
                r.init(),
                r.el
        };
        n.paging.defaultOptions = {
            url: "",
            ajaxType: "POST",
            wrapper: "",
            pageSizeText: '<li class="pagesize"><span>每页<\/span><input type="text" id="page-size" value="{{pageSize}}" /><span>条<\/span><\/li>',
            first: '<li class="first"><a href="javascript:;">首页<\/a><\/li>',
            prev: '<li class="prev"><a href="javascript:;">上一页<\/a><\/li>',
            next: '<li class="next"><a href="javascript:;">下一页<\/a><\/li>',
            last: '<li class="last"><a href="javascript:;">尾页<\/a><\/li>',
            page: '<li class="page"><a href="javascript:;">{{page}}<\/a><\/li>',
            totalPagesText: '<li class="disabled"><a href="javascript:;">共{{totalPages}}页<\/a><\/li>',
            totalCountsText: '<li class="disabled"><a href="javascript:;">共{{totalCounts}}条<\/a><\/li>',
            loadingText: '<li class="loading disabled" style="display:none;"><a style="border-width:0px 0px 0px 1px" class="text-primary" href="javascript:;"><i class="fa fa-refresh fa-spin fa-fw"><\/i>加载中...<\/a><\/li>',
            tip: "view-tip",
            totalPages: 1,
            totalCounts: 1,
            pageSize: 10,
            currentPage: 1,
            visiblePages: 7,
            disableClass: "disabled",
            activeClass: "active",
            el: "",
            onPageChange: null,
            onComplete: null,
            getData: null,
            methods: {}
        };
        n.fn.paging = function () {
            var r = this,
                t = Array.prototype.slice.call(arguments),
                i;
            if (typeof t[0] == "string") {
                if (i = n(r).data("paging"), i) return i.callMethod(t[0], t[1]);
                throw new Error("[paging] the element is not instantiated");
            } else return new n.paging(this, t[0])
        }
    }(jQuery);
win = {
    show: function (n) {
        var t = {
            id: Math.floor(Math.random() * 999 + 1),
            title: "系统提示",
            url: "about:blank",
            width: 400,
            height: 200,
            icoClass: null,
            callback: null
        },
            i;
        t = $.extend(t, n);
        i = win.createHtml(t);
        $.data(i.iframe[0], "randomId", t.id);
        $.data(i.iframe[0], "callback", t.callback);
        $(i.wrap).modal(n)
    },
    createHtml: function (n) {
        var u = template.get("wui.win.html"),
            i = $(u),
            t,
            r;
        return $(".modal-dialog", i).css({
            width: n.width
        }),
            $(".modal-title span", i).text(n.title),
            $(".modal-title i", i).addClass(n.icoClass),
            t = $("#load", i),
            r = $("iframe", i).attr({
                id: n.id,
                src: n.url
            }).css({
                height: n.height
            }),
            r.load(function () {
                t.hide();
                t.remove()
            }),
            setTimeout(function () {
                $("span", t).html("服务器正在拼命加载");
                setTimeout(function () {
                    $("span", t).html("您的网速有点慢哦");
                    setTimeout(function () {
                        $("span", t).html("您的网速太慢了，请确保您的网络是否正常！");
                        setTimeout(function () {
                            $("span", t).html("正在拼命加载中...")
                        },
                            3e3)
                    },
                        6e3)
                },
                    4e3)
            },
                2e3),
            $("body").append(i),
            {
                wrap: i,
                load: t,
                iframe: r
            }
    },
    close: function (n) {
        var t = {
            id: "0"
        },
            i,
            r;
        t = $.extend(t, n);
        i = $("#" + t.id);
        r = i.parents(".modal");
        $(r).modal("hide")
    },
    callback: function (n) {
        var t = {
            id: "0",
            result: null
        },
            r,
            i;
        t = $.extend(t, n);
        r = $("#" + t.id);
        i = $.data(r[0], "callback");
        i && i(t.result)
    },
    submit: function (n) {
        var t = {
            iframeId: "0",
            fn: null
        };
        t = $.extend(t, n);
        var i = $("#" + t.id),
            r = i.parents(".modal"),
            u = $("#submit", r).click(function () {
                t.fn()
            })
    }
}