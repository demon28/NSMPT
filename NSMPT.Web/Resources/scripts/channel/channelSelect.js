(function ($) {
    'use strict';

    $.channelSelect = function (el, options) {
        if (!(this instanceof $.channelSelect)) {
            return new $.channelSelect(el, options);
        }

        var self = this;

        self.selected = { ChannelId: "", ChannelName: "" };

        self.$container = $(el);
        self.$container.data('channelSelect', self);

        self.init = function () {
            //参数
            self.options = $.extend({}, $.channelSelect.defaultOptions, options);

            self.render();

            self.bindEvent();
        };

        self.render = function () {
            //判断空间是否为空
            if (self.options.name != null) {
                //修改原来控件的id和name
                var hidden = $("<input>").attr({ id: self.options.name + "_id", name: self.options.name, type: "hidden" });
                $(el.selector).after(hidden);
            }
        };

        self.bindEvent = function () {
            $(el.selector).click(function () {
                self.showWin();
            });
        }

        self.showWin = function () {
            var model = {
                ChannelId: self.options.channelId,
                ChannelType: self.options.channelType
            };
            var url = "";
            switch (self.options.mode) {
                case "tree": {
                    url = "/admin/channel/tree?" + $.param(model);
                    break;
                }
                default: {
                    url = "/admin/channel/select?" + $.param(model);
                    break;
                }

            }
            wui.win.show({
                url: url,
                title: "选择父级栏目",
                width: 1000,
                height: 500,
                icoClass: "glyphicon glyphicon-align-justify",
                callback: function (result) {
                    $("#" + self.options.name + "_id").val(result.ChannelId);
                    $(el.selector).val(result.ChannelName);
                }
            });
        }

        self.callMethod = function (method, options) {
            switch (method) {
                case 'option':
                    self.options = $.extend({}, self.options, options);
                    self.verify();
                    self.render();
                    break;
                case 'selected':
                    return self.selected;
                default:
                    throw new Error('[channelSelect] 没有 "' + method + '" 方法');
            }

            return self.$container;
        };

        self.init();

        return self.$container;
    };

    $.channelSelect.defaultOptions = {
        name: "Channel",
        //展示的模式：select/tree
        mode: "select",
        title: "选择栏目",
        channelType: null,
        channelId: 0,
    };

    $.fn.channelSelect = function () {
        var self = this,
            args = Array.prototype.slice.call(arguments);

        if (typeof args[0] === 'string') {
            var $instance = $(self).data('channelSelect');
            if (!$instance) {
                throw new Error('[channelSelect] 未实例化');
            } else {
                return $instance.callMethod(args[0], args[1]);
            }
        } else {
            return new $.channelSelect(this, args[0]);
        }
    };

})(jQuery);