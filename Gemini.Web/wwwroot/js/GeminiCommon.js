/*
GeminiCommon 使用说明：

开启加载遮罩层
var i = GeminiCommon.loading();

关闭加载遮罩层
GeminiCommon.loadComplete(i);

回车键触发登录事件
GeminiCommon.enterEvent($,$("[lay-submit]"));

获取localhost:61275/Menu/MenuList?searchVal=123中searchVal的值，结果是123
var searchVal = GeminiCommon.getQueryString("searchVal");
'laydate', 'laypage', 'layer', 'table', 'carousel', 'upload', 'element'

获取当月第一天
GeminiCommon.getFirstDay();如2018-05-01

获取当前日期
GeminiCommon.getNowDate();

获取当前时间
GeminiCommon.getNowDateTime();如2018-08-31 14:30:31

//获取特定时间
GeminiCommon.getDateTime(myDate);如2018-09-03 16:25:32；myDate是一个js的时间对象

//显示或者隐按钮
GeminiCommon.setBtnShowOrHide();

导出
GeminiCommon.export('/ServiceLog/ExportMessage/', { message: escape(message), fileType: fileType });//escape编码,不然会报潜在危险的 Request.Form 值错误，后台Server.UrlDecode解码

*/

/*common操作js文件*/
layui.use(['form', 'laydate'], function () {
    $ = layui.jquery;//jquery操作。必须要先声明$ = layui.jquery才可以跟之前jquery写法完全一样

    $(document).ajaxError(function (event, xhr, settings, infoError) {//全局事件提示错误
        var errorText = xhr.statusText;
        if (xhr.status == "404") {
            errorText = "请求的地址不存在";
        }
        else if (xhr.status == "408") {
            errorText = "客户端请求超时";
        }
        else if (xhr.status == "500") {
            errorText = "服务器错误";
        }

        layer.msg('对' + settings.url + "的访问出现错误,【状态码】" + xhr.status + "【错误信息】" + errorText + "");
    });

    $(".layui-input").attr("autocomplete", "off");
    $('.layui-input').bind('keypress', function (event) {
        if (event.keyCode == "13") {
            event.preventDefault ? event.preventDefault() : event.returnValue = false;
        }
    });

    layui.laydate.set({
        theme: 'molv'
    });
});

var GeminiCommon = {

    /*
    功能：开启加载遮罩层
    */
    loading: function (obj) {
        if (obj)
            layer = obj;
        var i = layer.msg('数据请求中...', { icon: 16, shade: [0.6, '#1e1e1e'], scrollbar: false, time: false });
        return i;
    },

    /*
    功能：关闭加载遮罩层
    参数：i，编号
    */
    loadComplete: function (i) {
        layer.close(i);
    },

    /*
    功能：回车事件
    参数：$:jquery操作符; obj，要执行模拟点击的jquery对象
    */
    enterEvent: function ($, obj) {
        //回车键触发登录事件
        $(document).keyup(function (event) {
            if (event.keyCode == 13) {
                obj.click();
            }
        });
    },

    /*
    功能：获取url参数值
    参数：name参数名
    */
    getQueryString: function (name) {
        var original = location.hash || location.search;
        var paramterurl = original.substr(original.indexOf("?") + 1)
        if (paramterurl != undefined && paramterurl != "") {
            var paraindex = paramterurl.indexOf(name);
            if (paraindex != -1) {
                var surplusUrl = paramterurl.substr(paraindex + name.length + 1);
                var endIndex = surplusUrl.indexOf("&");
                if (endIndex != -1) {
                    return surplusUrl.substr(0, endIndex);
                } else {
                    return surplusUrl;
                }
            }

        }
        return null;
    },

    //当前月份第一天
    getFirstDay: function () {
        var myDate = new Date();
        var year = myDate.getFullYear();
        var month = myDate.getMonth() + 1;
        if (month < 10)
            month = "0" + month.toString();

        return year + "-" + month + "-" + "01";
    },

    //当前日期
    getNowDate: function () {
        var myDate = new Date();
        var year = myDate.getFullYear();
        var month = myDate.getMonth() + 1;
        if (month < 10)
            month = "0" + month.toString();
        var day = myDate.getDate();
        if (day < 10)
            day = "0" + day.toString();
        return year + "-" + month + "-" + day;
    },

    //当前时间
    getNowDateTime: function () {
        var myDate = new Date();
        var year = myDate.getFullYear();
        var month = myDate.getMonth() + 1;
        if (month < 10)
            month = "0" + month.toString();
        var day = myDate.getDate();
        if (day < 10)
            day = "0" + day.toString();
        var hour = myDate.getHours();
        if (hour < 10)
            hour = "0" + hour.toString();
        var minute = myDate.getMinutes();
        if (minute < 10)
            minute = "0" + minute.toString();
        var second = myDate.getSeconds();
        if (second < 10)
            second = "0" + second.toString();
        return year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second;
    },

    //获取特定时间
    getDateTime: function (myDate) {
        if (!myDate) {
            return "";
        }
        var year = myDate.getFullYear();
        var month = myDate.getMonth() + 1;
        if (month < 10)
            month = "0" + month.toString();
        var day = myDate.getDate();
        if (day < 10)
            day = "0" + day.toString();
        var hour = myDate.getHours();
        if (hour < 10)
            hour = "0" + hour.toString();
        var minute = myDate.getMinutes();
        if (minute < 10)
            minute = "0" + minute.toString();
        var second = myDate.getSeconds();
        if (second < 10)
            second = "0" + second.toString();
        return year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second;
    },

    //显示或者隐按钮
    setBtnShowOrHide: function ($) {
        if (window.frameElement && window.frameElement.id.indexOf("layui-layer-iframe") >= 0) {
            $(".layui-form-item:last").hide();
        }
        else {
            $(".layui-form-item:last").show();
        }
    },

    //模拟表单提交（可直接导出对应文件）
    export: function (url, datas) {
        var form = $("<form method='post'></form>");//定义一个form表单
        form.attr("action", url);
        $("body").append(form);
        for (var key in datas) {
            var hidden = $("<input type='hidden' />");
            hidden.attr("name", key);
            hidden.attr("value", datas[key]);
            form.append(hidden);
        }
        form.submit();//表单提交
        form.remove();//用完删掉
    }

}