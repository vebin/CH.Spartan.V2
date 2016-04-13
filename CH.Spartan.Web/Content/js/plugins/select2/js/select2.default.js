//$("#selectCenter").select2Remote({
//    placeholder: '请输入上级专业名称',//这里填写空选项时显示的文字  
//    url: 'url',//远程加载的url  
//    initUrl: 'initurl',//初始化url  
//    valueField: 'id',//value名   在vo中对应id的属性名  
//    textField: 'text'//显示的text  
//})

(function ($) {
    if (!$) {
        return;
    }

    $.fn.select2Remote = function (options) {
        var opts = $.extend({}, $.fn.select2Remote.defaults, options);
        this.select2({
            allowClear: true,
            placeholder: opts.placeholder,
            minimumInputLength: opts.minLength,
            id: function (obj) { return obj[opts.valueField] },
            ajax: {
                url: opts.url,
                dataType: "json",
                quietMillis: opts.delay,
                data: function (term, page) { return { q: term }; },
                results: function (data, page) { return { results: data }; }
            },
            initSelection: function (element, callback) {
                var id = $(element).val();
                if (id !== "") {
                    $.ajax(opts.initUrl, {
                        data: {
                            q: id
                        },
                        dataType: "json"
                    }).done(function (data) { callback(data); });
                }
            },
            formatResult: function (obj) { return obj[opts.textField] },
            formatSelection: function (obj) { return obj[opts.textField] },
            dropdownCssClass: "bigdrop",
            escapeMarkup: function (m) { return m; }
        });
    }
})(jQuery);