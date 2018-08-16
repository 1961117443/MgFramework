/*
==================================================================
程序：框架基础函数包
创建：键盘男
说明：通用方法。
最近更新：16:46 2015-06-10
==================================================================
*/
var com = {};

//弹框提示messager
com.show = function (msg) {
    if (parent == window) {
        $.messager.show({ title: '提示', msg: msg, showType: 'show' });
    } else {
        parent.$.messager.show({ title: '提示', msg: msg, showType: 'show' });
    }
}

//提示messager-页面中间显示
com.showcenter = function (title, msg) {
    if (parent == window) {
        $.messager.show({
            title: title,
            msg: msg,
            showType: 'show',
            style: {
                right: '',
                top: document.body.scrollTop + document.documentElement.scrollTop,
                bottom: ''
            }
        });
    } else {
        parent.$.messager.show({
            title: title,
            msg: msg,
            showType: 'show',
            style: {
                right: '',
                top: document.body.scrollTop + document.documentElement.scrollTop,
                bottom: ''
            }
        });
    }
}

//警告alert
com.alert = function (msg) {
    var htmlHS = '<span style="font-size:15px;color:red;font-weight:bold">' + msg + '</span>';
    if (parent == window) {
        $.messager.alert('警告', htmlHS, 'warning');
    } else {
        parent.$.messager.alert('警告', htmlHS, 'warning');
    }
}

com.msg = function (data, callback) {
    if (data) {
        if (data.s) {
            com.message('s', data.emsg, callback);
        }
        else {
            com.message('e', data.emsg, callback);
        }
    } else {
        com.message('e', "未知错误");
    }

}

//弹messagee
com.message = function (type, message, callback) {
    var html_success = '<span style="font-size:13px;color:green;font-weight:bold"> ' + message + '</span>';
    var html_alert = '<span style="font-size:13px;color:red;font-weight:bold">' + message + '</span>';
    var html_confirm = '<span style="font-size:13px;color:#E2392D;font-weight:bold">' + message + '</span>';
    switch (type) {
        case "s":
        case "success":
            if (parent == window) {
                $.messager.show({
                    title: '成功提示', msg: html_success,
                    timeout: 1000, showType: 'slide', style: {
                        right: '',
                        top: document.body.scrollTop + document.documentElement.scrollTop,
                        bottom: ''
                    }
                });
            }
            else {
                parent.$('#notity').jnotifyAddMessage({ text: message, permanent: false });
            }
            break;
        case "error":
        case "e":
            if (parent == window) {
                //$.messager.show({ title: '错误', msg: html_success });
                $.messager.alert('错误提示', html_alert, 'warning');
                console.info(html_alert);
            }
            else {
                parent.$('#notity').jnotifyAddMessage({ text: message, permanent: false, type: 'error' });
            }
            break;
        case "warning":
        case "w":
            if (parent == window) {
                $.messager.alert('警告', html_alert, 'warning');
            }
            else {
                parent.$('#notity').jnotifyAddMessage({ text: message, permanent: false, type: 'warning' });
            }
            break;
        case "information":
        case "i":
        case "info":
            if (parent == window) {
                $.messager.show({ title: '消息', msg: message });
            }
            else {
                parent.$.messager.show({ title: '消息', msg: message });
            }
            break;
        case "confirm":
        case "c":
            if (parent == window) {
                return $.messager.confirm('确认', html_confirm, callback);
            }
            else {
                return parent.$.messager.confirm('确认', html_confirm, callback);
            }
    }

    if (callback) callback();
    return null;
};

//显示模态dialog-顶层模态。
com.dialog = function (opts, onBeforeOpen, onSave) {
    var query = parent.$;
    var win = query('<div></div>').appendTo('body').html(opts.html);
    var btntext = '保存';
    if (opts.btntext) btntext = opts.btntext;
    opts = query.extend({
        title: 'My Dialog', cache: false, modal: true, html: '', url: '',
        buttons: [{
            text: '&nbsp;&nbsp;&nbsp;&nbsp;<b>' + btntext + '<b>&nbsp;&nbsp;&nbsp;&nbsp;', handler: function () {
                if (onSave instanceof Function) {
                    onSave(win); //win.dialog('destroy');
                }
            }
        }],
        onBeforeOpen: function () {
            if (onBeforeOpen instanceof Function) {
                onBeforeOpen(win);
            }
        },
        onClose: function () {
            query(this).dialog('destroy');
        }
    }, opts);

    win.dialog(opts);
    query.parser.parse(win);
    return win;
}

//初始化模态dialog--iframe内模态。
com.initdialog = function (target, title, callback) {
    var d = target.dialog({
        title: title, top: 10, cache: false, modal: true, inline: true,
        buttons: [{
            text: '保存', iconCls: 'icon-save', handler: function () {
                if (callback instanceof Function) {
                    callback();
                }
            }
        }]
    }).dialog('close');
}

//局部遮罩。
com.mask = function (locale, show) {
    var zindex = 1;
    if (show == true) {
        locale.addClass("mask-container");
        //var mask = $("<div style='background-color:#000 '><div style='position:absolute;background-color:yellow;color:blue;height: 22px; width: 100px;margin: 0 auto ;top:10px; left:10px;border-radius:5px;z-index:0'><img src='../style/images/ajax-loader.gif' />正在加载...</div></div>").addClass("datagrid-mask").css({ display: "block", "z-index": +zindex }).appendTo(locale);
        var mask = $("<div style='background-color:#ccc '></div>").addClass("datagrid-mask").css({ display: "block", "z-index": +zindex }).appendTo(locale);
    } else {
        locale.removeClass("mask-container");
        locale.children("div.datagrid-mask-msg,div.datagrid-mask").remove();
    }
}

//ajax请求 成功后返回IResult对象
com.ajax = function (options) {
    options = $.extend({
        showLoading: false//新加属性，是否显示loading效果
    }, options);

    var ajaxDefaults = {
        type: 'POST',////数据的提交方式：get和post
        dataType: 'json',////服务器返回数据的类型，例如xml,String,Json等
        //contentType: 'application/json',
        error: function (e) {
            var msg = e.responseText + '|' + e.statusText;
            //console.info(e);
            //  alert('ajax出现错误：' + msg);
        },
        success: function (data) {  
            data = eval(data);
            if (data) { 
                if (data.ResultMsg) { 
                    layer.msg(data.ResultMsg, {
                        time: 600,  
                    });
                } 
                if (data.ResultUrl) {
                    window.location.href = data.ResultUrl;
                }
            } 
            if (options.callback) {
                options.callback(data);
            }
        }
    };

    if (options.showLoading) {
        ajaxDefaults.beforeSend = $.showLoading;
        ajaxDefaults.complete = $.hideLoading;
    }

    $.ajax($.extend(ajaxDefaults, options));
};


/*关于页面html公共格式化方式*/
com.html_formatter = {
    get_color_html: function (text, color) {
        return '<span style="font-weight:bold; color:' + color + ';">' + text + '</span>';
    },
    yesno: function (value, row, index) {
        var text = value == 1 ? '是' : '否';
        var color = value == 1 ? 'green' : 'red';
        var result = com.html_formatter.get_color_html(text, color);
        return result;
    },
    datetime: function (v, r, i) {
        return utils.formatDate(v);
    }
};

/*公共设置*/
com.settings = {
    timestamp: function () {
        var d = new Date();
        var result = d.getYear() + '' + d.getMonth() + '' + d.getDay() + '' + d.getMinutes() + '' + d.getSeconds() + '' + d.getMilliseconds();
        return result;
    },
    ajax_timestamp: function () {
        return '?timestamp=' + this.timestamp();
    }
};

/*初始化页面权限按钮*/
com.initbuttons = function (target, listbuttons) {
    //alert($(target).html());
    $(target).html('');
    var htmlButtons = '';
    if (km.model.buttons.length > 0) {
        for (var i = 0; i < listbuttons.length; i++) {
            htmlButtons += '<a id="toolbar_' + listbuttons[i].ButtonCode + '" href="javascript:void(0)" class="easyui-linkbutton" data-options="plain:true,iconCls:\'' + listbuttons[i].IconClass + '\' "  title="' + listbuttons[i].ButtonName + '" onclick="km.toolbar.' + listbuttons[i].JsEvent + ';">' + listbuttons[i].ButtonName + '</a>';
        }
        $(target).append(htmlButtons);
        $(target).find(".easyui-linkbutton").linkbutton();
    }
    //else {
    //    //alert($(target).parent()[0].id); 
    //    $(target).parent().height(0);
    //    $(target).remove();
    //}
}
/*
**把一个div以easyui对话框的形式显示出来
*/
com.dialog1 = function (options, onSuccessed) {
    var def =
        {
            modal: true,
            closed: false,
            onClose: function () {
                $(this).dialog('destroy');
            },
            buttons: [{
                iconCls: 'icon-ok',
                text: '确定',
                handler: function () {
                    if (onSuccessed) {
                        onSuccessed();
                        w.dialog('close');
                    }
                    //w.dialog('close');
                }
            }, {
                iconCls: 'icon-cancel',
                text: '返回',
                handler: function () {
                    //p.window('close');
                    w.dialog('close');
                }
            }]
        };
    var opts = $.extend(def, options);
    var w = $('<div/>').dialog(opts)
    return w;// $('<div/>').dialog(opts);
};

//没用
com.ShowChooseBox = function (e) {
    var key = $(e.data.target)[0].id;
    var form = $(e.data.target)[0].form;

    var opt = $(e.data.target).textbox('options');
    //console.info($(e.data.target));
    var p = opt.icons[0].param;
    p.title = "选择" + opt.label;
    // console.info(p);
    if (p == undefined) {
        return;
    }
    if (key == undefined) {
        return;
    }

    var dia = com.dialog1(
        {
            title: p.title,
            width: 680,
            height: 520,
            closed: false,
            cache: false,
            modal: true,
            href: p.url,
        }, function () {
            var row = dia.find("#masterGrid").datagrid('getSelected');
            if (row == undefined) {
                layer.msg('请选择一条记录！'); return;
            }
            if (row) {
                if (p.ok) {
                    p.ok(row);
                }
            }
        });
};

com.ShowChooseDialog = function (options, callback,fname) {
    var opts = {
        type: 2,
        title: '选择',//传入
        id: 'dialog',
        btn: ['确认', '返回'],
        area: ['800px', '600px'],
        content: '/BaseData/Customer/Test', //传入
        success: function (layero, index) {
            //layer.msg('success', { time: 5000, icon: 6 });
        },
        yes: function (index, layero) {
            var win = window["layui-layer-iframe" + index];
            if (win) {
                if (fname == undefined) {
                    fname = "getData";
                } 
                var data = win[fname] ? win[fname].call(this) : [];
                if (callback) {
                    callback(data);
                }
            }
            layer.close(index);
        },
        btn2: function (index, layero) {
            console.log(layero);
            //layer.msg('btn2|' + index + '|' + layero, { time: 5000, icon: 6 });
        },
        cancel: function () {
            // layer.msg('捕获就是从页面已经存在的元素上，包裹layer的结构', { time: 5000, icon: 6 });
        }
    }; 
    layer.open($.extend(opts, options))
};

com.ShowDialogBox = function (params) {
    var opts =
        {
            type: 2,
            resize: false,
            area: ['98%', '98%'], 
            content: '请设置ur链接',// '/Order/Online/EditItem?id=' + params.Id
            success: function (layero) {
                layer.setTop(layero);
            },
        };
    opts = $.extend(opts, params);
   return layer.open(opts); 
};
































