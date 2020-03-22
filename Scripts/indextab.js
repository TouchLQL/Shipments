(function ($) {
    $.menutab = {
        closeTab: function () {
            var closeTabId = $(this).parents('a').attr('aria-controls');
            if ($(this).parents('a').parents('li').hasClass('active')) {
                var activeId;
                if ($(this).parents('a').parents('li').next('li').size()) {
                    activeId = $(this).parents('a').parents('li').next('li:eq(0)').children('a').attr('aria-controls');
                    $('#tablist a[href="#' + activeId + '"]').tab('show');
                    $(this).parents('a').parents('li').remove();
                    $('#tabcontent .tab-pane').each(function () {
                        if ($(this).attr('id') == closeTabId) {
                            $(this).remove();
                            return false;
                        }
                    });
                }
                if ($(this).parents('a').parents('li').prev('li').size()) {
                    activeId = $(this).parents('a').parents('li').prev('li:last').children('a').attr('aria-controls');
                    $('#tablist a[href="#' + activeId + '"]').tab('show');
                    $(this).parents('a').parents('li').remove();
                    $('#tabcontent .tab-pane').each(function () {
                        if ($(this).attr('id') == closeTabId) {
                            $(this).remove();
                            return false;
                        }
                    });
                }
            } else {
                $(this).parents('a').parents('li').remove();
                $('#tabcontent .tab-pane').each(function () {
                    if ($(this).attr('id') == closeTabId) {
                        $(this).remove();
                        return false;
                    }
                });
            }
        },
        refresh: function () {
            var iframe = $(this).attr('data-iframeid');
            $('#iframe' + iframe).attr('src', $('#iframe' + iframe).attr('src'));
        },
        addTab: function (el) {
            var flag = true;
            var dataId = $(el).attr('data-code');
            var dataUrl = $(el).attr('data-url');
            var menuName = $(el).attr('title');
            var enName = "menu-" + $(el).attr('data-code');
            if (dataUrl == undefined || $.trim(dataUrl).length == 0) {
                return false;
            }
            $('#tablist li').each(function () {
                if ($(this).children('a').attr('aria-controls') == enName) {
                    //判断当前点击菜单是否为active状态
                    if (!$(this).parents('li').hasClass('active')) {
                        $('#tablist a[href="#' + enName + '"]').tab('show');
                    }
                    flag = false;
                    return false;
                }
            });
            if (flag) {
                var tab = ' <li role="presentation" class="active"><a href="#' + enName + '" aria-controls="' + enName + '" role="tab" data-toggle="tab"><i class="icon-reload page-refresh" aria-hidden="true" data-iframeid=' + dataId + ' title="刷新"></i>&nbsp;&nbsp;&nbsp;' + menuName + '<i class="fa fa-close menu-close" aria-hidden="true" title="关闭菜单"></i></a></li>';
                var tabcontent = '<div id="' + enName + '" role="tabpanel" class="tab-pane active"><iframe class="tab_iframe" id="iframe' + dataId + '" name="iframe' + dataId + '"  width="100%" height="100%" src="' + dataUrl + '?menucode_str=' + $(el).attr('data-code') + '" frameborder="0" data-id="' + dataUrl + '" seamless></iframe></div>';
                $('#tabcontent').find('div.tab-pane.active').removeClass("active");
                $('#tabcontent').append(tabcontent);
                $('#tablist').find('li.active').removeClass("active");
                $('#tablist').append(tab);
                //$('#tablist a[href="#' + enName + '"]').tab('show');  
            }
        },
        init: function () {
            //$('.menuItem').on('click', $.menutab.addTab);
            $('#tablist').on('click', 'li i.menu-close', $.menutab.closeTab);
            $('#tablist').on('click', 'li i.page-refresh', $.menutab.refresh);
            //$('.menu-close').on('click', $.menutab.closeTab);
            //$('.menuTabs').on('click', '.menuTab i', $.menutab.closeTab);
            //$('.tabCloseCurrent').on('click', function () {
            //    $('.page-tabs-content').find('.active i').trigger("click");
            //});
        }
    };
    $(function () {
        $.menutab.init();
    });
})(jQuery);