﻿var $z = $.noConflict(); //将$2设置为1.4版本的jq
console.log("js内:" + $z.fn.jquery);
//全局变量
var table, myGrid;
//此处只能用 当前页面定义的$z，而不能用html页面定义的$q.不知道为啥
$z(document).ready(function () {
    //console.log("ready:" + $z.fn.jquery);
    GetMenuButtonList("btnOp");
    //#region datatable初始化及值绑定
    $.extend($.fn.dataTable.defaults, {
        dom: 'rt<"#dt-bottom.row"<"col-xs-2"l><"col-xs-7"p><"col-xs-3"i>>'
    });
    var scrollY = document.body.clientHeight - 56 - 53 - 38 - 32 - 13 - 4;
    //适应窗口大小变化
    $(window).resize(function () {
        var newScrollY = document.body.clientHeight - 56 - 53 - 38 - 32 - 13 - 4;
        $('.dataTables_scrollBody').css('height', newScrollY);
    });
    myGrid = {
        id: 'dt_log',
        isenable: false,//是否需要禁用启用按钮
        scrollY: scrollY,
        scrollX: true,
        paging: true,
        hasIndex: true,
        multiSelect: false,
        processing: true,
        serverSide: true,
        columns: [
            //{ data: null, title: "序号", bSortable: true },
            { data: "number", title: "订单号", bSortable: true },
            { data: "customer_name", title: "商家名字" },
            { data: "customer_address", title: "商家地址" },
            { data: "customer_tel", title: "商家电话" },
            { data: "customer_person", title: "联系人" },
            { data: "create_time", title: "创建时间", bSortable: true },
            { data: "delivery_time", title: "发货时间", bSortable: true },
            { data: "mark", title: "备注" }
        ],
        columnDefs: [{
            render: function (data, type, row) {
                if (data.length > 25)
                    return data.substring(0, 25) + "...";
                else
                    return data;
            },
            targets: [5]
        }],
        order: [[5, 'desc']],
        data: {},
        ajax: function (data, callback, settings) {
            //封装请求参数
            var reUrl = '/Order/GetAllOrder';
            var order = data.columns[data.order[0].column].data + " " + data.order[0].dir;
            var pagesize = data.length;
            var pageno = (data.start / data.length) + 1;
            //查询条件
            var s_customerId = $('#s_customerId').val();
            var datest = $('#date_st').val();
            var dateed = $('#date_ed').val();
            var searchData = { pagesize: pagesize, pageno: pageno, order: order, customerId: s_customerId, datest: datest, dateed: dateed };
            //ajax请求数据
            $.ajax({
                type: "GET",
                url: reUrl,
                cache: false,//禁用缓存
                data: searchData,//传入组装的参数
                dataType: "json",
                //headers: param,//请求头参数
                success: function (result, status, xhr) {
                    //封装返回数据
                    var returnData = {};
                    returnData.draw = data.draw; //这里直接自行返回了draw计数器,应该由后台返回
                    returnData.recordsTotal = result.TotalCount;
                    total_curr = result.TotalCurr;
                    returnData.recordsFiltered = result.TotalCount; //后台不实现过滤功能，每次查询均视作全部结果
                    returnData.data = result.Entity; //返回的数据列表
                    //调用DataTables提供的callback方法，代表数据已封装完成并传回DataTables进行渲染
                    //此时的数据需确保正确无误，异常判断应在执行此回调前自行处理完毕
                    callback(returnData);//将你的返回的data转为datatables能识别的数据格式作为参数返回ajax的callback回调中。
                }
            });
        }
    }

    //$('#dt_log').on('dblclick', 'tr', function () {
    //    var r_obj = $(this);
    //    r_obj.addClass('selected');
    //    var row_val = $('#dt_log').DataTable().row(r_obj).data();
    //    $('#c_title').text("ViewLog");
    //    $('#content').html(row_val.logcontent);
    //    $('#logManageModal').modal('show');
    //});

    table = DataBind(myGrid);
    //#endregion

    //console.log("timepicker" + $.fn.jquery);
    //console.log("timepickerq" + $q.fn.jquery);
    //console.log("timepickerz" + $z.fn.jquery);
    //日期框初始化 $q
    //此处只能html页面定义的$q和$,而该js头部定义的$z,会报$z.datetimepicker不是函数，不知道为啥
    $q('#date_st,#date_ed,#date_delivery,#date_delivery_value').datetimepicker({
        format: 'YYYY-MM-DD'
    });

    //查询
    $('#btnInquire').click(function () {
        loadTableData();
    });
   // console.log("ready2:" + $z.fn.jquery);
});

//$2 = $.noConflict(); //将$2设置为1.4版本的jq
//console.log("out info3" + $2.fn.jquery);

//var $3 = $.noConflict(); //将$2设置为1.4版本的jq
//console.log("out info2" + $3.fn.jquery);

//刷新datatable
function loadTableData(myGrid) {
    table.ajax.reload();
}

//新增
var Btn_Add = function () {
    console.log("add info:" + $.fn.jquery);
    $('#id').val('-1');
    $('#name').val('');
    $('#date_delivery_value').val('');
    $('#order_mark').val('');
    $('#orderId').val('-1');
    $('#orderNumber').val('-1');
    $('#orderAddModal').modal('show');
}

//编辑
var Btn_Edit = function () {
    if (table.rows('.selected').data().length == 0) {
        $.notify({
            message: '<i class="fa fa-bell-o"></i> Choose one data please！',
            status: "info",
            group: null,
            pos: "bottom-right"
        });
        return;
    }
    var seletedItem = table.rows('.selected').data()[0];
    $('#title').text("编辑订单");
    $('#customerId').val(seletedItem.customer_id);
    $('#date_delivery_value').val(seletedItem.delivery_time);
    $('#orderNumber').val(seletedItem.number);
    $('#orderId').val(seletedItem.id);
    $('#order_mark').val(seletedItem.mark);
    $('#orderAddModal').modal('show');
}

//删除
var Btn_Delete = function () {
    if (table.rows('.selected').data().length == 0) {
        $.notify({
            message: '<i class="fa fa-bell-o"></i>请选择一条数据1！',
            status: "info",
            group: null,
            pos: "bottom-right"
        });
        return;
    }
    bconfirm("确定删除？", btnDelete);
}
//删除方法
function btnDelete() {
    var seletedItem = table.rows('.selected').data()[0];
    $.ajax({
        type: "post",
        contentType: "application/json;utf-8",
        url: "/Order/DeleteOrder?id=" + seletedItem.id + "&t=" + new Date().getTime(),
        data: "",
        success: function (result) {
            result = eval('(' + result + ')');
            $.notify({
                message: '<i class="fa fa-check"></i> ' + result.Message,
                status: result.success ? "success" : 'danger',
                pos: "bottom-right"
            });
            if (result.IsSucceed) {
                loadTableData(myGrid);
            }
            else {
                if (result.Entity != "" && result.Entity != null)
                    window.parent.location.href = result.Entity;
            }
        }
    });
}

//打印
var Btn_PrintOne = function () {
    if (table.rows('.selected').data().length == 0) {
        $.notify({
            message: '<i class="fa fa-bell-o"></i>请选择要打印的数据！',
            status: "info",
            group: null,
            pos: "bottom-right"
        });
        return;
    }
    var orderTable = document.getElementById("printOrderTable");
    var orderTableTr = orderTable.getElementsByTagName("tr");
    var trCount = orderTableTr.length;
    var childNum = orderTable.childNodes;
    var singlePrice = 0.0;
    //console.log(childNum.rows);
    //alert(orderTable.length);
    //移除之前的信息
    console.log(orderTableTr.length);
    //for (var j = 4; j == 5; j++) {
    //    orderTableTr[j].remove();
    //    console.log("remove times" + j);
    //    console.log(orderTableTr[j]);
    //}
    while (orderTableTr.length > 6) {
        orderTableTr[5].remove();
    }
    $("#printCustomerName").text("购货单位:" + table.rows('.selected').data()[0].customer_name);
    $("#printTime").text("日期:" + table.rows('.selected').data()[0].delivery_time);
    var totalAccount = 0.0;
    $.ajax({
        type: "get",
        contentType: "application/json;utf-8",
        async: false,
        url: "/Order/GetOrderDetailByWhere?t=" + new Date().getTime() + "&where= is_del=0 and order_number='" + table.rows('.selected').data()[0].number + "'",
        success: function (result) {
            result = eval('(' + result + ')');
            result = eval(result);
            var trRow;

            for (var i = 0; i < 15; i++) {
                if (i < result.ds.length) {
                    singlePrice = (result.ds[i].commodity_price * result.ds[i].commodity_count).toFixed(2);
                    totalAccount = Number(totalAccount) + Number(singlePrice);
                    trRow = "<tr><th style='text-align:center;'>" + result.ds[i].commodity_name + "</th><th style='text-align:center;'>" + result.ds[i].commodity_count + "</th><th style='text-align:center;'>" + result.ds[i].commodity_unit + "</th><th style='text-align:center;'>" + result.ds[i].commodity_price + "</th><th style='text-align:center;'>" + singlePrice + "</th>" + "<th style='text-align:center;'>" + result.ds[i].mark + "</th></tr>";

                }
                else {
                    trRow = "<tr><th style='height:24px;'></th><th></th><th></th><th></th><th></th><th></th></tr>";
                }
                $("#printOrderTable tr:eq(" + (4 + i) + ")").after(trRow);
            }
            $("#totalAcount").text("¥：" + totalAccount);
            $z("#printOrder").jqprint();
        }
    });
}

//打印报表
var Btn_PrintBaoBiao = function () {
    var s_customerId = $('#s_customerId').val();
    var datest = $('#date_st').val();
    var dateed = $('#date_ed').val();
    var searchData = { customerId: s_customerId, datest: datest, dateed: dateed };
    var newTable;
    $.ajax({
        type: "get",
        contentType: "application/json;utf-8",
        async: false,
        url: "/Order/GetOrderBaoBiaoByWhere?t=" + new Date().getTime(),
        cache: false,//禁用缓存
        data: searchData,//传入组装的参数
        success: function (result) {
            result = eval('(' + result + ')');
            result = eval(result).Entity;
            var listCache = [];
            var resultCopy = result;//用来操作的数据列表
            var customerNameCache;
            var elementBaoBiao = document.getElementById("printBaoBiao"); //获取一个div对象
            var totalAmount = 0;
            var statusJudge = 1;//状态判断变量
            var newTr;
            var tableObjMid;//table中间变量
            var x; //newCell
            for (var i = 0; i <= result.length;) {
                if (i === result.length) {
                    break;
                }
                customerNameCache = result[i].customer_name;
                listCache = [];
                //$("#printCustomerNameBaoBiao").innerHTML += customerNameCache;
                statusJudge = 1;//赋为1；新的一页打印开始 
                newTable = "";//新的一个table置空
                newTable += '<table  border="1" style="width:100%;font-size:20px;font-family:"宋体";">' +
                    '<tbody id="printBaoBiaoBody">' +
                    ' <tr style="border-bottom: none;">' +
                    ' <th colspan="4">' +
                    '   <p style="text-align:center;font-size:24px;font-family:"微软雅黑"">重庆品佳调味</p>' +
                    ' </th>' +
                    ' </tr>' +
                    '  <tr style="height:20px;">' +
                    '    <th colspan="4"></th>' +
                    ' </tr>' +
                    ' <tr>' +
                    '     <th colspan="4" style="text-align:left;">购货单位:' + customerNameCache + '</th>' +
                    ' </tr>'+
                    ' <tr>' +
                    '     <th style="text-align:left;">日期</th>' +
                    '     <th style="text-align:left;">金额</th>' +
                    '     <th style="text-align:left;">日期</th>' +
                    '     <th style="text-align:left;">金额</th>' +
                    ' </tr>';
                for (var j = i; j <= resultCopy.length; j++) {                  
                    //if (j <= resultCopy.length) {

                    //}
                     if (j < resultCopy.length && resultCopy[j].customer_name === customerNameCache) {
                         totalAmount = Number(totalAmount) + Number(resultCopy[j].sumAmount);//计算总金额。
                        //如果为奇数，那么将该条数据放在第一列
                        if (statusJudge % 2 === 1) {
                            newTable += "<tr><td style='width:25%;'>" + resultCopy[j].delivery_time + "</td><td style='width:25%;'>" + resultCopy[j].sumAmount + "</td>";
                        }
                        //如果为偶数，放在第二列
                        else {
                            newTable += "<td style='width:25%;'>" + resultCopy[j].delivery_time + "</td><td style='width:25%;'>" + resultCopy[j].sumAmount + "</td></tr>";
                            //$("#printBaoBiaoTable tr").after(newTr);
                        }
                        statusJudge++;
                        //listCache.push(resultCopy[j]);
                    }
                    else {
                        //如果以奇数列结尾，那么结束时加上一个</tr>
                        if (statusJudge % 2 === 0) {
                            newTable += "<td style='width:25%;'></td><td style='width:25%;'></td></tr>";
                            console.log("结束 new tr:"+newTr);
                            //$("#printBaoBiaoTable tr").after(newTr);
                        }
                        //最后加上一行总金额        
                        newTable +="<tr>"+
                            "<th colspan='2'> <p style='float:left;'>合计金额： </p>" +
                            "<p style = 'margin-left:25px;float:left;'> 万</p>" +
                            "<p style='margin-left: 25px; float: left;'>仟</p> " +
                            "<p style = 'margin-left: 25px; float: left;'> 佰</p> "+
                            "<p style = 'margin-left: 25px; float: left;'> 拾</p>"+
                            "<p style='margin-left: 25px; float: left;'>元</p> " +
                            "<p style='margin-left: 25px; float: left;'> 角</p> "+
                            "<p style = 'margin-left: 25px; float: left;'> 分</p></th> " +
                            "<th colspan='2' id='totalAcount'>¥：" + totalAmount+"元</th>" +
                            "</tr>";
                         newTable += '</tbody></table></div><div style="page-break-after:always;">';
                         tableObjMid = $(newTable).get(0); //对当前table进行加空行填满
                         //console.log(tableObjMid.rows.length);
                         while (tableObjMid.rows.length < 22) {
                             console.log(tableObjMid.rows.length);
                             //$("#printOrderTable tr:eq(" + (4 + i) + ")").after(trRow);
                             x = tableObjMid.insertRow(tableObjMid.rows.length - 1);
                             x.style.cssText = 'height:25px';
                             x.insertCell(0);
                             x.insertCell(1);
                             x.insertCell(2);
                             x.insertCell(3);
                             x.clientHeight
                             console.log("add row");
                             console.log(tableObjMid);
                             console.log(tableObjMid.rows.length);
                         }
                         tableObjMid = $(tableObjMid).html();//dom对象转字符串
                         console.log(tableObjMid);
                         tableObjMid = '<table  border="1" style="width:100%;font-size:20px;font-family:"宋体";">' + tableObjMid+'</tbody></table></div><div style="page-break-after:always;">';
                         console.log("new table");
                         console.log(tableObjMid);
                        //elementBaoBiao.innerHTML += "</div><div style='page-break-after: always;'></div>";
                        i = j;
                        break;
                    }
                }
                elementBaoBiao.innerHTML += tableObjMid;
            }
            console.log("html info");       
            $z("#printBaoBiao").jqprint({
                debug: false,
                importCSS: true,
                printContainer: true,
                operaSupport: false
            });
        }
    });
}