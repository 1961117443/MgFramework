
var obj = {
    ip: '0.0.0.0',
    city: '未获取到城市',
    usercode: '',
    pwd: ''
}
$(function () { 
    var returnCitySN = undefined;
    if (returnCitySN) {
        obj.ip = returnCitySN["cip"];
        obj.city = returnCitySN["cname"] + '[' + returnCitySN["cid"] + ']';
    } 
    init();
})

var layinit =function () {
    layui.use('form', function () {
        var form = layui.form;

        //提交
        form.on('submit(LAY-user-login-submit)', function (obj) {
             //console.log(obj.field);

            com.ajax({
                url: '/Account/Login',
                data: JSON.stringify(obj.field),
                showLoading: false,
                callback: function (result) {
                    if (result.s) {
                        //com.message('s', result.emsg);
                        // $(".login_msg").html('<span style="color:green; font-weight:bold"><img src="/Content/images/ajax-loader.gif" />登录成功，正在跳转...</span>');
                        window.location.href = '/';
                    } else {
                        layer.msg(result.emsg);
                    }
                }
            }) 
        }); 
        //开发阶段账号密码就默认好了
        form.val('loginForm', { username: 'admin', password:'admin'});
    }); 
}

var init = function () {

    layinit(); 

    //$("#span_ip").text(obj.city + '[' + obj.ip + ']');
    if (top != window) top.window.location = window.location;
    $("#LAY-user-login-username").bind('keydown', function (e) {
        if (e.keyCode == 13) {	// when press ENTER key, accept the inputed value.
            e.preventDefault();
            $("#LAY-user-login-password").focus();
        }
    });
    $("#LAY-user-login-password").bind('keydown', function (e) {
        if (e.keyCode == 13) {	// when press ENTER key, accept the inputed value.
            e.preventDefault(); 
          //  doLogin();
        }
    });

    //$("#UserCode").focus(); $("#UserCode").select();
    //com.message('s', obj.city);
};

var initlocation = function () {
    var stateObject = {};
    var title = "";
    var newUrl = "/login.do";// "/login/hello-来自" + obj.city + "的朋友!";
    if (window.history.pushState) {
        window.history.pushState(stateObject, title, newUrl);
    }
}
