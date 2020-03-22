(function (n) {
    "use strict";
    var t = 0,
		i = function (t, i) {
		    this.options = i;
		    this.$elementFilestyle = [];
		    this.$element = n(t)
		},
		r;
    i.prototype = {
        clear: function () {
            this.$element.val("");
            this.$elementFilestyle.find(":text").val("");
            this.$elementFilestyle.find(".badge").remove()
        },
        destroy: function () {
            this.$element.removeAttr("style").removeData("filestyle");
            this.$elementFilestyle.remove()
        },
        disabled: function (n) {
            if (n === !0) this.options.disabled || (this.$element.attr("disabled", "true"), this.$elementFilestyle.find("label").attr("disabled", "true"), this.options.disabled = !0);
            else if (n === !1) this.options.disabled && (this.$element.removeAttr("disabled"), this.$elementFilestyle.find("label").removeAttr("disabled"), this.options.disabled = !1);
            else return this.options.disabled
        },
        buttonBefore: function (n) {
            if (n === !0) this.options.buttonBefore || (this.options.buttonBefore = !0, this.options.input && (this.$elementFilestyle.remove(), this.constructor(), this.pushNameFiles()));
            else if (n === !1) this.options.buttonBefore && (this.options.buttonBefore = !1, this.options.input && (this.$elementFilestyle.remove(), this.constructor(), this.pushNameFiles()));
            else return this.options.buttonBefore
        },
        icon: function (n) {
            if (n === !0) this.options.icon || (this.options.icon = !0, this.$elementFilestyle.find("label").prepend(this.htmlIcon()));
            else if (n === !1) this.options.icon && (this.options.icon = !1, this.$elementFilestyle.find(".icon-span-filestyle").remove());
            else return this.options.icon
        },
        input: function (n) {
            if (n === !0) this.options.input || (this.options.input = !0, this.options.buttonBefore ? this.$elementFilestyle.append(this.htmlInput()) : this.$elementFilestyle.prepend(this.htmlInput()), this.$elementFilestyle.find(".badge").remove(), this.pushNameFiles(), this.$elementFilestyle.find(".group-span-filestyle").addClass("input-group-btn"));
            else if (n === !1) {
                if (this.options.input) {
                    this.options.input = !1;
                    this.$elementFilestyle.find(":text").remove();
                    var t = this.pushNameFiles();
                    t.length > 0 && this.options.badge && this.$elementFilestyle.find("label").append(' <span class="badge">' + t.length + "<\/span>");
                    this.$elementFilestyle.find(".group-span-filestyle").removeClass("input-group-btn")
                }
            } else return this.options.input
        },
        size: function (n) {
            if (n !== undefined) {
                var t = this.$elementFilestyle.find("label"),
					i = this.$elementFilestyle.find("input");
                t.removeClass("btn-lg btn-sm");
                i.removeClass("input-lg input-sm");
                n != "nr" && (t.addClass("btn-" + n), i.addClass("input-" + n))
            } else return this.options.size
        },
        placeholder: function (n) {
            if (n !== undefined) this.options.placeholder = n, this.$elementFilestyle.find("input").attr("placeholder", n);
            else return this.options.placeholder
        },
        buttonText: function (n) {
            if (n !== undefined) this.options.buttonText = n, this.$elementFilestyle.find("label .buttonText").html(this.options.buttonText);
            else return this.options.buttonText
        },
        buttonName: function (n) {
            if (n !== undefined) this.options.buttonName = n, this.$elementFilestyle.find("label").attr({
                "class": "btn " + this.options.buttonName
            });
            else return this.options.buttonName
        },
        iconName: function (n) {
            if (n !== undefined) this.$elementFilestyle.find(".icon-span-filestyle").attr({
                "class": "icon-span-filestyle " + this.options.iconName
            });
            else return this.options.iconName
        },
        htmlIcon: function () {
            return this.options.icon ? '<span class="icon-span-filestyle ' + this.options.iconName + '"><\/span> ' : ""
        },
        htmlInput: function () {
            return this.options.input ? '<input type="text" class="form-control ' + (this.options.size == "nr" ? "" : "input-" + this.options.size) + '" placeholder="' + this.options.placeholder + '" disabled> ' : ""
        },
        pushNameFiles: function () {
            var i = "",
				n = [],
				t;
            for (this.$element[0].files === undefined ? n[0] = {
                name: this.$element[0] && this.$element[0].value
            } : n = this.$element[0].files, t = 0; t < n.length; t++) i += n[t].name.split("\\").pop() + ", ";
            return i !== "" ? this.$elementFilestyle.find(":text").val(i.replace(/\, $/g, "")) : this.$elementFilestyle.find(":text").val(""), n
        },
        constructor: function () {
            var i = this,
				f = "",
				r = i.$element.attr("id"),
				u = "";
            r !== "" && r || (r = "filestyle-" + t, i.$element.attr({
                id: r
            }), t++);
            u = '<span class="group-span-filestyle ' + (i.options.input ? "input-group-btn" : "") + '"><label for="' + r + '" class="btn ' + i.options.buttonName + " " + (i.options.size == "nr" ? "" : "btn-" + i.options.size) + '" ' + (i.options.disabled ? 'disabled="true"' : "") + ">" + i.htmlIcon() + '<span class="buttonText">' + i.options.buttonText + "<\/span><\/label><\/span>";
            f = i.options.buttonBefore ? u + i.htmlInput() : i.htmlInput() + u;
            i.$elementFilestyle = n('<div class="bootstrap-filestyle input-group">' + f + "<\/div>");
            i.$elementFilestyle.find(".group-span-filestyle").attr("tabindex", "0").keypress(function (n) {
                if (n.keyCode === 13 || n.charCode === 32) return i.$elementFilestyle.find("label").click(), !1
            });
            i.$element.css({
                position: "absolute",
                clip: "rect(0px 0px 0px 0px)"
            }).attr("tabindex", "-1").after(i.$elementFilestyle);
            i.options.disabled && i.$element.attr("disabled", "true");
            i.$element.change(function () {
                var n = i.pushNameFiles();
                i.options.input == !1 && i.options.badge ? i.$elementFilestyle.find(".badge").length == 0 ? i.$elementFilestyle.find("label").append(' <span class="badge">' + n.length + "<\/span>") : n.length == 0 ? i.$elementFilestyle.find(".badge").remove() : i.$elementFilestyle.find(".badge").html(n.length) : i.$elementFilestyle.find(".badge").remove()
            });
            window.navigator.userAgent.search(/firefox/i) > -1 && i.$elementFilestyle.find("label").click(function () {
                return i.$element.click(), !1
            })
        }
    };
    r = n.fn.filestyle;
    n.fn.filestyle = function (t, r) {
        var u = "",
			f = this.each(function () {
			    if (n(this).attr("type") === "file") {
			        var e = n(this),
						f = e.data("filestyle"),
						o = n.extend({}, n.fn.filestyle.defaults, t, typeof t == "object" && t);
			        f || (e.data("filestyle", f = new i(this, o)), f.constructor());
			        typeof t == "string" && (u = f[t](r))
			    }
			});
        return typeof u !== undefined ? u : f
    };
    n.fn.filestyle.defaults = {
        buttonText: "Choose file",
        iconName: "glyphicon glyphicon-folder-open",
        buttonName: "btn-default",
        size: "nr",
        input: !0,
        badge: !0,
        icon: !0,
        buttonBefore: !1,
        disabled: !1,
        placeholder: ""
    };
    n.fn.filestyle.noConflict = function () {
        return n.fn.filestyle = r, this
    };
    n(function () {
        n(".filestyle").each(function () {
            var t = n(this),
				i = {
				    input: t.attr("data-input") === "false" ? !1 : !0,
				    icon: t.attr("data-icon") === "false" ? !1 : !0,
				    buttonBefore: t.attr("data-buttonBefore") === "true" ? !0 : !1,
				    disabled: t.attr("data-disabled") === "true" ? !0 : !1,
				    size: t.attr("data-size"),
				    buttonText: t.attr("data-buttonText"),
				    buttonName: t.attr("data-buttonName"),
				    iconName: t.attr("data-iconName"),
				    badge: t.attr("data-badge") === "false" ? !1 : !0,
				    placeholder: t.attr("data-placeholder")
				};
            t.filestyle(i)
        })
    })
})(window.jQuery)