//datatabels 控件默认设置配置
$.extend($.fn.dataTable.defaults, {
    language: {
        url: "../../Content/dataTable/zh_CN.txt"
    },
    sPaginationType: "simple_numbers",//full_numbers
    destroy: true,
    //dom: 'rt<"#dt-bottom.row"<"col-xs-2"l><"col-xs-7"p><"col-xs-3"i>>'
    //dom: 'C<"clear">lfrtip'
    //dom: '<"top">rt<"bottom"ipl><"clear">'//'lrtip',
});

//
// 动态分页
//
$.fn.dataTable.pipeline = function (opts) {
    // Configuration options
    var conf = $.extend({
        pages: 5,     // number of pages to cache
        url: '',      // script url
        data: null,   // function or object with parameters to send to the server
        // matching how `ajax.data` works in DataTables
        method: 'POST' // Ajax HTTP method
    }, opts);

    // Private variables for storing the cache
    var cacheLower = -1;
    var cacheUpper = null;
    var cacheLastRequest = null;
    var cacheLastJson = null;

    return function (request, drawCallback, settings) {
        var ajax = false;
        var requestStart = request.start;
        var drawStart = request.start;
        var requestLength = request.length;
        var requestEnd = requestStart + requestLength;

        if (settings.clearCache) {
            // API requested that the cache be cleared
            ajax = true;
            settings.clearCache = false;
        }
        else if (cacheLower < 0 || requestStart < cacheLower || requestEnd > cacheUpper) {
            // outside cached data - need to make a request
            ajax = true;
        }
        else if (JSON.stringify(request.order) !== JSON.stringify(cacheLastRequest.order) ||
                  JSON.stringify(request.columns) !== JSON.stringify(cacheLastRequest.columns) ||
                  JSON.stringify(request.search) !== JSON.stringify(cacheLastRequest.search)
        ) {
            // properties changed (ordering, columns, searching)
            ajax = true;
        }

        // Store the request for checking next time around
        cacheLastRequest = $.extend(true, {}, request);

        if (ajax) {
            // Need data from the server
            if (requestStart < cacheLower) {
                requestStart = requestStart - (requestLength * (conf.pages - 1));

                if (requestStart < 0) {
                    requestStart = 0;
                }
            }

            cacheLower = requestStart;
            cacheUpper = requestStart + (requestLength * conf.pages);

            request.start = requestStart;
            request.length = requestLength * conf.pages;

            // Provide the same `data` options as DataTables.
            if ($.isFunction(conf.data)) {
                // As a function it is executed with the data object as an arg
                // for manipulation. If an object is returned, it is used as the
                // data object to submit
                var d = conf.data(request);
                if (d) {
                    $.extend(request, d);
                }
            }
            else if ($.isPlainObject(conf.data)) {
                // As an object, the data given extends the default
                $.extend(request, conf.data);
            }

            settings.jqXHR = $.ajax({
                "type": conf.method,
                "url": conf.url,
                "data": request,
                "dataType": "json",
                "cache": false,
                "success": function (json) {
                    var returnData = {};
                    //returnData.draw = json.Draw;
                    returnData.recordsTotal = json.TotalCount;
                    returnData.recordsFiltered = json.TotalCount;
                    returnData.data = json.Entity;

                    cacheLastJson = $.extend(true, {}, returnData);

                    if (cacheLower != drawStart) {
                        returnData.data.splice(0, drawStart - cacheLower);
                    }
                    if (requestLength >= -1) {
                        returnData.data.splice(requestLength, returnData.data.length);
                    }

                    drawCallback(returnData);
                }
            });
        }
        else {
            json = $.extend(true, {}, cacheLastJson);
            json.draw = request.draw; // Update the echo for each response
            json.data.splice(0, requestStart - cacheLower);
            json.data.splice(requestLength, json.data.length);

            drawCallback(json);
        }
    }
};

// Register an API method that will empty the pipelined data, forcing an Ajax
// fetch on the next draw (i.e. `table.clearPipeline().draw()`)
$.fn.dataTable.Api.register('clearPipeline()', function () {
    return this.iterator('table', function (settings) {
        settings.clearCache = true;
    });
});

function DataBind(myGrid) {
    var grid = $('#' + myGrid.id).DataTable({
        ajax: myGrid.ajax,
        data: myGrid.data,//myGrid.hasIndex ? Index(myGrid.data) : myGrid.data,
        scrollY: myGrid.scrollY,
        scrollX: myGrid.scrollX,
        paging: myGrid.paging,
        columns: myGrid.columns,
        columnDefs: myGrid.columnDefs,
        order: myGrid.order,
        destroy: true,
        processing: myGrid.processing,
        serverSide: myGrid.serverSide,
        //bFilter: myGrid.bFilter,
        footerCallback: myGrid.footerCallback,
        createdRow: myGrid.createdRow
    });
    //自定义搜索框
    if (myGrid.search != '') {
        $('#' + myGrid.search).on('keyup', function () {
            $('#' + myGrid.id).DataTable().search(this.value).draw();
        });
    };
    //添加索引列
    if (myGrid.hasIndex) {
        //加一列顺序列
        grid.on('order.dt search.dt', function () {
            grid.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                cell.innerHTML = i + 1;
            });
        }).draw();
    };
    ///选择多行
    if (myGrid.multiSelect) {
        //$('#' + myGrid.id + ' tbody tr').click(function () {
        $('#' + myGrid.id + ' tbody').off('click');
        $('#' + myGrid.id + ' tbody').on('click', 'tr', function () {
            $(this).toggleClass('selected');
        });
    }
    else {
        $('#' + myGrid.id + ' tbody').off('click');
        $('#' + myGrid.id + ' tbody').on('click', 'tr', function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                grid.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }
            if (myGrid.isenable) {
                //启用禁用
                var btn;
                $('#' + myGrid.btnEnableId + '').remove();
                if ($(this).hasClass('selected')) {
                    var seletedItem = grid.rows('.selected').data()[0];
                    if (seletedItem.isenable == 1) {
                        btn = '<button id="' + myGrid.btnEnableId + '" type="button" class="btn btn-green text-left"><i class="fa fa-lock">&nbsp;&nbsp;禁用</i></button>';
                    } else {
                        btn = '<button id="' + myGrid.btnEnableId + '" type="button" class="btn btn-green text-left"><i class="fa fa-unlock-alt">&nbsp;&nbsp;启用</i></button>';
                    }
                    $('#' + myGrid.btnOp + '').append(btn);
                }
            }
        });
    }
    return grid;
}
function Index(data) {
    $.each(data, function (index, item) {
        item.index = '';
    });
    return data;
}