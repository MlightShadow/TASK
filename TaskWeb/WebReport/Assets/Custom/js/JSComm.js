

//AJAX=================================================
function cusAjax(type, url, data, resFunc) {
    $.ajax({
        type: type,
        url: url,
        data: data,
        dataType: 'json',
        success: function (res) {
            resFunc(res)
        }
    });
}

var Postor = {
    Post: function (url, data, resFunc) {
        cusAjax('POST', url, data, resFunc)
    },
    Get: function (url, data, resFunc) {
        cusAjax('GET', url, data, resFunc)
    }
}
//======================================================



































//================================================================================================================
$(function () {
    //选中行变色
    $('table').on('click-row.bs.table', function (e, row, element) {
        $('.success').removeClass('success');//去除之前选中的行的，选中样式
        $(element).addClass('success');//添加当前选中的 success样式用于区别
    });
});

///返回执行成功与失败json的简易方法
function operationAjax_POST(url, data, successFunc) {
    $.ajax({
        type: "post",
        dataType: "json",
        url: url,
        data: data,
        success: function (result) {
            alert(result.msg);
            if (result.res == 1) {
                successFunc();
            }
        }
    });
}

function tradeTypeConvert(typeCode) {
    var str = '';
    switch (typeCode) {
        case 0: str = '入库库存'; break;
        case 2: str = '介绍信'; break;
        case 3: str = '不可撤销'; break;
        case 4: str = '货转'; break;
        default: str = '其他'; break;
    }
    return str
}

function feeTypeConvert(typeCode) {
    var str = '';
    switch (typeCode) {
        case 'jarFee': str = '包罐费用'; break;
        case 'prime': str = '首期费用'; break;
        case 'daily': str = '超期费用'; break;
        case 'carwork': str = '车卸费用'; break;
        case 'jarOverFee': str = '周转超量费'; break;
        default: str = '其他'; break;
    }
    return str
}

function initDropDownList(name, url, propName) {
    getDropDownListData(name, url, propName);
    $("#txt" + name).bind('input propertychange', function () {
        getDropDownListData(name, url, propName);
    })
}

function getDropDownListData(name, url, propName) {
    $.ajax({
        type: "post",
        dataType: "json",
        url: url,
        data: { q: $("#txt" + name).val() },
        success: function (result) {
            //清除所有数据重新加载
            $("#lst" + name).empty();
            var html = '';
            for (var i in result) {
                html += '<li onclick="$(\'#txt' + name + '\').val($(this).text())" style="padding-left: 4px" onmouseover="$(this).css(\'backgroundColor\', \'#dff0d8\')" onmouseout="$(this).css(\'backgroundColor\', \'#FFF\')">' + result[i][propName] + '</li>';
            }
            $("#lst" + name).html(html);
        }
    });
}

function changeNumToChinese(money) {
    var cnNums = new Array("零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖"); //汉字的数字  
    var cnIntRadice = new Array("", "拾", "佰", "仟"); //基本单位  
    var cnIntUnits = new Array("", "万", "亿", "兆"); //对应整数部分扩展单位  
    //var cnDecUnits = new Array("角", "分", "毫", "厘"); //对应小数部分单位  
    //var cnInteger = "整"; //整数金额时后面跟的字符  
    var cnIntLast = ""; //整型完以后的单位  
    var maxNum = 999999999999999.9999; //最大处理的数字  

    var IntegerNum; //金额整数部分  
    var DecimalNum; //金额小数部分  
    var ChineseStr = ""; //输出的中文金额字符串  
    var parts; //分离金额后用的数组，预定义  
    if (money == "") {
        return "";
    }
    money = parseFloat(money);
    if (money >= maxNum) {
        $.alert('超出最大处理数字');
        return "";
    }
    if (money == 0) {
        //ChineseStr = cnNums[0]+cnIntLast+cnInteger;  
        ChineseStr = cnNums[0] + cnIntLast
        //document.getElementById("show").value=ChineseStr;  
        return ChineseStr;
    }
    money = money.toString(); //转换为字符串  
    if (money.indexOf(".") == -1) {
        IntegerNum = money;
        DecimalNum = '';
    } else {
        parts = money.split(".");
        IntegerNum = parts[0];
        DecimalNum = parts[1].substr(0, 4);
    }
    if (parseInt(IntegerNum, 10) > 0) {//获取整型部分转换  
        zeroCount = 0;
        IntLen = IntegerNum.length;
        for (i = 0; i < IntLen; i++) {
            n = IntegerNum.substr(i, 1);
            p = IntLen - i - 1;
            q = p / 4;
            m = p % 4;
            if (n == "0") {
                zeroCount++;
            } else {
                if (zeroCount > 0) {
                    ChineseStr += cnNums[0];
                }
                zeroCount = 0; //归零  
                ChineseStr += cnNums[parseInt(n)] + cnIntRadice[m];
            }
            if (m == 0 && zeroCount < 4) {
                ChineseStr += cnIntUnits[q];
            }
        }
        ChineseStr += cnIntLast;
        //整型部分处理完毕  
    }
    if (DecimalNum != '') {//小数部分 
        ChineseStr += '点'
        decLen = DecimalNum.length;
        for (i = 0; i < decLen; i++) {
            n = DecimalNum.substr(i, 1);
            if (n != '0') {
                ChineseStr += cnNums[Number(n)];//+ cnDecUnits[i];
            }
        }
    }
    if (ChineseStr == '') {
        //ChineseStr += cnNums[0]+cnIntLast+cnInteger;  
        ChineseStr += cnNums[0] + cnIntLast;
    }/* else if( DecimalNum == '' ){ 
                ChineseStr += cnInteger; 
                ChineseStr += cnInteger; 
            } */
    return ChineseStr;
}

Date.prototype.format = function (format) {
    var date = {
        "M+": this.getMonth() + 1,
        "d+": this.getDate(),
        "h+": this.getHours(),
        "m+": this.getMinutes(),
        "s+": this.getSeconds(),
        "q+": Math.floor((this.getMonth() + 3) / 3),
        "S+": this.getMilliseconds()
    };
    if (/(y+)/i.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + '').substr(4 - RegExp.$1.length));
    }
    for (var k in date) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1
                ? date[k] : ("00" + date[k]).substr(("" + date[k]).length));
        }
    }
    return format;
}

//获取当前时间
function getTodayPlus(add) {
    var today = new Date();
    var todayms = today.getTime() + (add * 24 * 60 * 60 * 1000)
    today.setTime(todayms);
    return today.format('yyyy-MM-dd');
}

function getTodayMinPlus(add) {
    var today = new Date();
    var todayms = today.getTime() + (add * 24 * 60 * 60 * 1000)
    today.setTime(todayms);
    return today.format('yyyy-MM-dd hh:mm');
}

//日期格式化 yyyy
function yearFormatter(time) {
    if (time == null || time == "/Date(-62135596800000)/") {
        return null;
    } else {
        var sj = parseInt(time.replace(/\D/igm, ""));
        var rq = new Date(sj);
        return rq.format('yyyy');
    }
}

//日期格式化 yyyy-mm-dd
function dateFormatter(time) {
    if (time == null || time == "/Date(-62135596800000)/") {
        return null;
    } else {
        var sj = parseInt(time.replace(/\D/igm, ""));
        var rq = new Date(sj);
        return rq.format('yyyy-MM-dd');
    }
}

function timeMinuteFormatter(time) {
    if (time == null || time == "/Date(-62135596800000)/") {
        return null;
    } else {
        var sj = parseInt(time.replace(/\D/igm, ""));
        var rq = new Date(sj);
        return rq.format('yyyy-MM-dd hh:mm');
    }
}

//时间格式化 yyyy-mm-dd hh:mm:ss
function timeFormatter(time) {
    if (time == null || time == "/Date(-62135596800000)/") {
        return null;
    } else {
        var sj = parseInt(time.replace(/\D/igm, ""));
        var rq = new Date(sj);
        return rq.format('yyyy-MM-dd hh:mm:ss');
    }
}

//获取所选行的id数组
function selectIds(tbName) {
    var select = $('#' + tbName).bootstrapTable('getSelections');
    var ids = [];
    for (var i in select) {
        var id = { id: 0 };
        id.id = select[i].id;
        ids.push(id);
    }

    return ids;
}

//初始化打勾
function checkIconSetTrue(name) {
    $("#" + name).next().children().first().show()
    $("#" + name).next().children().last().hide()
}

//初始化打叉
function checkIconSetFalse(name) {
    $("#" + name).next().children().first().hide()
    $("#" + name).next().children().last().show()
}


//检查是否重复
function CheckExist(type, element, id) {
    var searchString = $(element).val();
    if (searchString != "") {
        $.ajax({
            type: "post",
            dataType: "json",
            url: "/Admin/CommAPI/CheckExist",
            data: { type: type, searchString: searchString, id: id },
            success: function (result) {
                if (result.res == 1) {
                    $(element).next().children().first().show()
                    $(element).next().children().last().hide()
                }
                else if (result.res == -1) {
                    $(element).next().children().first().hide()
                    $(element).next().children().last().show()
                    alert(result.msg);
                    $(element).val("");
                }
            }
        })
    }
}

function RefreshTableForSearch(tableName,
    searchString,
    searchString2,
    searchString3,
    searchString4,
    searchString5,
    searchString6,
    searchString7,
    searchString8,
    searchString9,
    searchString10,
    searchString11,
    searchString12,
    searchString13
) {
    $('#' + tableName).bootstrapTable('refresh', {
        query: {
            searchString: searchString != null ? $('#' + searchString).val().trim() : null,
            searchString2: searchString2 != null ? $('#' + searchString2).val().trim() : null,
            searchString3: searchString3 != null ? $('#' + searchString3).val().trim() : null,
            searchString4: searchString4 != null ? $('#' + searchString4).val().trim() : null,
            searchString5: searchString5 != null ? $('#' + searchString5).val().trim() : null,
            searchString6: searchString6 != null ? $('#' + searchString6).val().trim() : null,
            searchString7: searchString7 != null ? $('#' + searchString7).val().trim() : null,
            searchString8: searchString8 != null ? $('#' + searchString8).val().trim() : null,
            searchString9: searchString9 != null ? $('#' + searchString9).val().trim() : null,
            searchString10: searchString10 != null ? $('#' + searchString10).val().trim() : null,
            searchString11: searchString11 != null ? $('#' + searchString11).val().trim() : null,
            searchString12: searchString12 != null ? $('#' + searchString12).val().trim() : null,
            searchString13: searchString13 != null ? $('#' + searchString13).val().trim() : null
        },
        silent: true
    });
}

function tableSearchParam(params,
    searchString,
    searchString2,
    searchString3,
    searchString4,
    searchString5,
    searchString6,
    searchString7,
    searchString8,
    searchString9,
    searchString10,
    searchString11,
    searchString12,
    searchString13
) {
    params.searchString = searchString != null ? $('#' + searchString).val().trim() : null;
    params.searchString2 = searchString2 != null ? $('#' + searchString2).val().trim() : null;
    params.searchString3 = searchString3 != null ? $('#' + searchString3).val().trim() : null;
    params.searchString4 = searchString4 != null ? $('#' + searchString4).val().trim() : null;
    params.searchString5 = searchString5 != null ? $('#' + searchString5).val().trim() : null;
    params.searchString6 = searchString6 != null ? $('#' + searchString6).val().trim() : null;
    params.searchString7 = searchString7 != null ? $('#' + searchString7).val().trim() : null;
    params.searchString8 = searchString8 != null ? $('#' + searchString8).val().trim() : null;
    params.searchString9 = searchString9 != null ? $('#' + searchString9).val().trim() : null;
    params.searchString10 = searchString10 != null ? $('#' + searchString10).val().trim() : null;
    params.searchString11 = searchString11 != null ? $('#' + searchString11).val().trim() : null;
    params.searchString12 = searchString12 != null ? $('#' + searchString12).val().trim() : null;
    params.searchString13 = searchString13 != null ? $('#' + searchString13).val().trim() : null;
    return params;
}

function searchRefresh(tableName) {
    $('#' + tableName).bootstrapTable('refresh', {
        silent: true
    });
}

function subTable(name, id, index, row, $detail, url, columns) {
    var cur_table = $detail.append('<div id = "1"><h3>' + name + '</h3><table id = "' + id + '"></table><hr/></div>').find('#' + id);
    $(cur_table).bootstrapTable({
        url: url,
        method: 'post',
        columns: columns
    });
}

var JSComm = {
    initTable: function (customConfig) {
        var config = {
            striped: true,
            url: !customConfig.url ? null : customConfig.url,//数据源
            dataField: "rows",//服务端返回数据键值 就是说记录放的键值是rows，分页时使用总记录数的键值为total
            //height: !customConfig.height ? $(window).height() - 200 : customConfig.height,//高度调整
            height: "auto",
            pagination: customConfig.pagination == null ? true : customConfig.pagination,//是否分页
            pageSize: 35,//单页记录数
            pageList: [20, 25, 35, 50, 70, 100, 200],//分页步进值
            sidePagination: !customConfig.sidePagination ? "client" : customConfig.sidePagination,//服务端分页
            contentType: "application/x-www-form-urlencoded",//请求数据内容格式 默认是 application/json 自己根据格式自行服务端处理
            dataType: "json",//期待返回数据类型
            method: "post",//请求方式
            //search: !customConfig.search ? true : customConfig.search,//是否搜索
            searchAlign: "left",//查询框对齐方式
            queryParamsType: "limit",//查询参数组织方式
            queryParams: !customConfig.getParams ? function (params) {
                //params obj
                //params.other = "otherInfo";
                return params;
            } : customConfig.getParams,
            searchOnEnterKey: false,//回车搜索
            //showRefresh: true,//刷新按钮
            //showColumns: true,//列选择按钮
            buttonsAlign: "left",//按钮对齐方式
            toolbar: "#toolbar",//指定工具栏
            toolbarAlign: "right",//工具栏对齐方式
            columns: customConfig.columns,//列集合
            data: customConfig.data,//数据集合
            locale: "zh-CN", //中文支持
            buttonsClass: "success",
            iconSize: "xs",
            detailView: !customConfig.detailView ? false : customConfig.detailView, //是否显示详情折叠
            detailFormatter: !customConfig.detailFormatter ? function (index, row, element) {
                var html = '';
                $.each(row, function (key, val) {
                    html += "<p>" + key + ":" + val + "</p>"
                });
                return html;
            } : customConfig.detailFormatter,
            onExpandRow: !customConfig.onExpandRow ? function (index, row, element) {
                var html = '';
                $.each(row, function (key, val) {
                    html += "<p>" + key + ":" + val + "</p>"
                });
                return html;
            } : customConfig.onExpandRow,
            rowStyle: !customConfig.rowStyle ? function (row, index) { return { classes: "" } } : customConfig.rowStyle
        };
        return config;
    },
    initJqTable: function (config) {
        var jqGrid = !config.id ? $("#jqGridList") : $("#" + config.id);
        //jqGrid.closest(".ui-jqgrid-bdiv").css({ 'overflow-x': 'hidden' });
        jqGrid.jqGrid({
            caption: config.title,
            url: config.url,
            mtype: "POST",
            styleUI: 'Bootstrap',
            datatype: "json",
            colNames: config.colNames,
            colModel: config.colModel,
            viewrecords: true,
            multiselect: config.iselect,
            //shrinkToFit: false,
            //autowidth: false,
            //autoScroll: true,
            shrinkToFit: !config.FixedConlumn ? true : false,
            autowidth: !config.FixedConlumn ? true : false,
            height: "100%",
            rowNum: 20,
            rownumbers: true, // show row numbers
            rownumWidth: 35, // the width of the row numbers columns
            pager: !config.pagerId ? "#jqGridPager" : "#" + config.pagerId,
            subGrid: config.subGrid ? true : false,
            subGridRowExpanded: config.subGridRowExpanded ? config.subGridRowExpanded : null
        });
        // Add responsive to jqGrid
        //$(window).bind('resize', function () {
        //    var width = $('.jqGrid_wrapper').width();
        //    jqGrid.setGridWidth(width);
        //});
    }
};

