(function (n, t, i) {
    if (typeof i == "undefined") throw new Error("This application's JavaScript requires jQuery");
    i(function () {
        var n = i("body");
        (new StateToggler).restoreState(n);
        i("#chk-fixed").prop("checked", n.hasClass("layout-fixed"));
        i("#chk-collapsed").prop("checked", n.hasClass("aside-collapsed"));
        i("#chk-collapsed-text").prop("checked", n.hasClass("aside-collapsed-text"));
        i("#chk-boxed").prop("checked", n.hasClass("layout-boxed"));
        i("#chk-float").prop("checked", n.hasClass("aside-float"));
        i("#chk-hover").prop("checked", n.hasClass("aside-hover"));
        i(".offsidebar.hide").removeClass("hide");
        i.ajaxPrefilter(function (n) {
            n.async = !0
        })
    })
})(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        i('[data-toggle="popover"]').popover();
        i('[data-toggle="tooltip"]').tooltip({
            container: "body"
        });
        i(".dropdown input").on("click focus", function (n) {
            n.stopPropagation()
        })
    })
}(window, document, window.jQuery), function (n, t, i) {
    function f(n, t) {
        var u = i("#remove-after-drop");
        n.fullCalendar({
            header: {
                left: "prev,next today",
                center: "title",
                right: "month,agendaWeek,agendaDay"
            },
            buttonIcons: {
                prev: " fa fa-caret-left",
                next: " fa fa-caret-right"
            },
            buttonText: {
                today: "today",
                month: "month",
                week: "week",
                day: "day"
            },
            editable: !0,
            droppable: !0,
            drop: function (t, r) {
                var e = i(this),
					o = e.data("calendarEventObject"),
					f;
                o && (f = i.extend({}, o), f.start = t, f.allDay = r, f.backgroundColor = e.css("background-color"), f.borderColor = e.css("border-color"), n.fullCalendar("renderEvent", f, !0), u.is(":checked") && e.remove())
            },
            eventDragStart: function (n) {
                r = n
            },
            events: t
        })
    }
    function e(n) {
        var f = i(".external-events");
        new u(f.children("div"));
        var t = "#f6504d",
			s = i(".external-event-add-btn"),
			e = i(".external-event-name"),
			o = i(".external-event-color-selector .circle");
        i(".external-events-trash").droppable({
            accept: ".fc-event",
            activeClass: "active",
            hoverClass: "hovered",
            tolerance: "touch",
            drop: function (t, i) {
                if (r) {
                    var u = r.id || r._id;
                    n.fullCalendar("removeEvents", u);
                    i.draggable.remove();
                    r = null
                }
            }
        });
        o.click(function (n) {
            n.preventDefault();
            var r = i(this);
            t = r.css("background-color");
            o.removeClass("selected");
            r.addClass("selected")
        });
        s.click(function (n) {
            var r, o;
            (n.preventDefault(), r = e.val(), i.trim(r) !== "") && (o = i("<div/>").css({
                "background-color": t,
                "border-color": t,
                color: "#fff"
            }).html(r), f.prepend(o), new u(o), e.val(""))
        })
    }
    function o() {
        var r = new Date,
			i = r.getDate(),
			n = r.getMonth(),
			t = r.getFullYear();
        return [{
            title: "All Day Event",
            start: new Date(t, n, 1),
            backgroundColor: "#f56954",
            borderColor: "#f56954"
        }, {
            title: "Long Event",
            start: new Date(t, n, i - 5),
            end: new Date(t, n, i - 2),
            backgroundColor: "#f39c12",
            borderColor: "#f39c12"
        }, {
            title: "Meeting",
            start: new Date(t, n, i, 10, 30),
            allDay: !1,
            backgroundColor: "#0073b7",
            borderColor: "#0073b7"
        }, {
            title: "Lunch",
            start: new Date(t, n, i, 12, 0),
            end: new Date(t, n, i, 14, 0),
            allDay: !1,
            backgroundColor: "#00c0ef",
            borderColor: "#00c0ef"
        }, {
            title: "Birthday Party",
            start: new Date(t, n, i + 1, 19, 0),
            end: new Date(t, n, i + 1, 22, 30),
            allDay: !1,
            backgroundColor: "#00a65a",
            borderColor: "#00a65a"
        }, {
            title: "Open Google",
            start: new Date(t, n, 28),
            end: new Date(t, n, 29),
            url: "//google.com/",
            backgroundColor: "#3c8dbc",
            borderColor: "#3c8dbc"
        }]
    }
    if (i.fn.fullCalendar) {
        i(function () {
            var n = i("#calendar"),
				t = o();
            e(n);
            f(n, t)
        });
        var r = null,
			u = function (n) {
			    n && n.each(function () {
			        var n = i(this),
						t = {
						    title: i.trim(n.text())
						};
			        n.data("calendarEventObject", t);
			        n.draggable({
			            zIndex: 1070,
			            revert: !0,
			            revertDuration: 0
			        })
			    })
			}
    }
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        function e() {
            var t = i(this),
				n = t.data();
            n && (n.triggerInView ? (f.scroll(function () {
                r(t, n)
            }), r(t, n)) : u(t, n))
        }
        function r(n, r) {
            !n.hasClass(t) && i.Utils.isInView(n, {
                topoffset: -20
            }) && u(n, r)
        }
        function u(n, i) {
            n.ClassyLoader(i).addClass(t)
        }
        var f = i(n),
			t = "js-is-in-view";
        i("[data-classyloader]").each(e)
    })
}(window, document, window.jQuery), function (n, t, i) {
    "use strict";
    n(i).on("click", "[data-reset-key]", function (i) {
        i.preventDefault();
        var r = n(this).data("resetKey");
        r ? (n.localStorage.remove(r), t.location.reload()) : n.error("No storage key specified for reset.")
    })
}(jQuery, window, document), function (n) {
    n.APP_COLORS = {
        primary: "#5d9cec",
        success: "#27c24c",
        info: "#23b7e5",
        warning: "#ff902b",
        danger: "#f05050",
        inverse: "#131e26",
        green: "#37bc9b",
        pink: "#f532e5",
        purple: "#7266ba",
        dark: "#3a3f51",
        yellow: "#fad732",
        "gray-darker": "#232735",
        "gray-dark": "#3a3f51",
        gray: "#dde6e9",
        "gray-light": "#e4eaec",
        "gray-lighter": "#edf1f2"
    };
    n.APP_MEDIAQUERY = {
        desktopLG: 1200,
        desktop: 992,
        tablet: 768,
        mobile: 480
    }
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        i(".flatdoc").each(function () {
            Flatdoc.run({
                fetcher: Flatdoc.file("/Content/documentation/readme.md"),
                root: ".flatdoc",
                menu: ".flatdoc-menu",
                title: ".flatdoc-title",
                content: ".flatdoc-content"
            })
        })
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        var r = i("[data-trigger-resize]"),
			u = r.data("triggerResize");
        r.on("click", function () {
            setTimeout(function () {
                var i = t.createEvent("UIEvents");
                i.initUIEvent("resize", !0, !1, n, 0);
                n.dispatchEvent(i)
            }, u || 300)
        })
    })
}(window, document, window.jQuery), function (n, t, i) {
    typeof screenfull != "undefined" && i(function () {
        function f(n) {
            screenfull.isFullscreen ? n.children("em").removeClass("fa-expand").addClass("fa-compress") : n.children("em").removeClass("fa-compress").addClass("fa-expand")
        }
        var e = i(t),
			r = i("[data-toggle-fullscreen]"),
			u = n.navigator.userAgent;
        if ((u.indexOf("MSIE ") > 0 || !!u.match(/Trident.*rv\:11\./)) && r.addClass("hide"), r.is(":visible")) {
            r.on("click", function (n) {
                n.preventDefault();
                screenfull.enabled ? (screenfull.toggle(), f(r)) : console.log("Fullscreen not enabled")
            });
            if (screenfull.raw && screenfull.raw.fullscreenchange) e.on(screenfull.raw.fullscreenchange, function () {
                f(r)
            })
        }
    })
}(window, document, window.jQuery), function (n) {
    "use strict";
    var i = [{
        featureType: "water",
        stylers: [{
            visibility: "on"
        }, {
            color: "#bdd1f9"
        }]
    }, {
        featureType: "all",
        elementType: "labels.text.fill",
        stylers: [{
            color: "#334165"
        }]
    }, {
        featureType: "landscape",
        stylers: [{
            color: "#e9ebf1"
        }]
    }, {
        featureType: "road.highway",
        elementType: "geometry",
        stylers: [{
            color: "#c5c6c6"
        }]
    }, {
        featureType: "road.arterial",
        elementType: "geometry",
        stylers: [{
            color: "#fff"
        }]
    }, {
        featureType: "road.local",
        elementType: "geometry",
        stylers: [{
            color: "#fff"
        }]
    }, {
        featureType: "transit",
        elementType: "geometry",
        stylers: [{
            color: "#d8dbe0"
        }]
    }, {
        featureType: "poi",
        elementType: "geometry",
        stylers: [{
            color: "#cfd5e0"
        }]
    }, {
        featureType: "administrative",
        stylers: [{
            visibility: "on"
        }, {
            lightness: 33
        }]
    }, {
        featureType: "poi.park",
        elementType: "labels",
        stylers: [{
            visibility: "on"
        }, {
            lightness: 20
        }]
    }, {
        featureType: "road",
        stylers: [{
            color: "#d8dbe0",
            lightness: 20
        }]
    }],
		t;
    n.fn.gMap && (t = [], n("[data-gmap]").each(function () {
        var r = n(this),
			u = r.data("address") && r.data("address").split(";"),
			e = r.data("title") && r.data("title").split(";"),
			h = r.data("zoom") || 14,
			c = r.data("maptype") || "ROADMAP",
			o = [],
			f;
        if (u) {
            for (f in u) typeof u[f] == "string" && o.push({
                address: u[f],
                html: e && e[f] || "",
                popup: !0
            });
            var l = {
                controls: {
                    panControl: !0,
                    zoomControl: !0,
                    mapTypeControl: !0,
                    scaleControl: !0,
                    streetViewControl: !0,
                    overviewMapControl: !0
                },
                scrollwheel: !1,
                maptype: c,
                markers: o,
                zoom: h
            },
				a = r.gMap(l),
				s = a.data("gMap.reference");
            t.push(s);
            r.data("styled") !== undefined && s.setOptions({
                styles: i
            })
        }
    }))
}(jQuery, window, document), function (n, t, i) {
    function r(n) {
        var t = "autoloaded-stylesheet",
			r = i("#" + t).attr("id", t + "-old");
        return i("head").append(i("<link/>").attr({
            id: t,
            rel: "stylesheet",
            href: n
        })), r.length && r.remove(), i("#" + t)
    }
    i(function () {
        i("[data-load-css]").on("click", function (n) {
            var u = i(this),
				t, f;
            u.is("a") && n.preventDefault();
            t = u.data("loadCss");
            t ? (f = r(t), f || i.error("Error creating stylesheet link element.")) : i.error("No stylesheet location defined.")
        })
    })
}(window, document, window.jQuery), function (n, t, i) {
    //var u = "en",
	//	f = "/Content/i18n",
	//	e = "site",
	//	r = "jq-appLang";
    //i(function () {
    //    function o(n) {
    //        i("[data-localize]").localize(e, n)
    //    }
    //    function s(n) {
    //        var t = n.parents(".dropdown-menu"),
	//			i;
    //        t.length && (i = t.prev("button, a"), i.text(n.text()))
    //    }
    //    if (i.fn.localize) {
    //        var n = i.localStorage.get(r) || u,
	//			t = {
	//			    language: n,
	//			    pathPrefix: f,
	//			    callback: function (t, u) {
	//			        i.localStorage.set(r, n);
	//			        u(t)
	//			    }
	//			};
    //        o(t);
    //        i("[data-set-lang]").on("click", function () {
    //            n = i(this).data("setLang");
    //            n && (t.language = n, o(t), s(i(this)))
    //        })
    //    }
    //})
}(window, document, window.jQuery), function (n) {
    n.defaultColors = {
        markerColor: "#23b7e5",
        bgColor: "transparent",
        scaleColors: ["#878c9a"],
        regionFill: "#bbbec6"
    };
    n.VectorMap = function (n, t, i) {
        function e(n, t, i, r) {
            n.vectorMap({
                map: t.mapName,
                backgroundColor: t.bgColor,
                zoomMin: 1,
                zoomMax: 8,
                zoomOnScroll: !1,
                regionStyle: {
                    initial: {
                        fill: t.regionFill,
                        "fill-opacity": 1,
                        stroke: "none",
                        "stroke-width": 1.5,
                        "stroke-opacity": 1
                    },
                    hover: {
                        "fill-opacity": .8
                    },
                    selected: {
                        fill: "blue"
                    },
                    selectedHover: {}
                },
                focusOn: {
                    x: .4,
                    y: .6,
                    scale: t.scale
                },
                markerStyle: {
                    initial: {
                        fill: t.markerColor,
                        stroke: t.markerColor
                    }
                },
                onRegionLabelShow: function (n, t, r) {
                    i && i[r] && t.html(t.html() + ": " + i[r] + " visitors")
                },
                markers: r,
                series: {
                    regions: [{
                        values: i,
                        scale: t.scaleColors,
                        normalizeFunction: "polynomial"
                    }]
                }
            })
        }
        if (n && n.length) {
            var r = n.data(),
				u = r.height || "300",
				f = {
				    markerColor: r.markerColor || defaultColors.markerColor,
				    bgColor: r.bgColor || defaultColors.bgColor,
				    scale: r.scale || 1,
				    scaleColors: r.scaleColors || defaultColors.scaleColors,
				    regionFill: r.regionFill || defaultColors.regionFill,
				    mapName: r.mapName || "world_mill_en"
				};
            n.css("height", u);
            e(n, f, t, i)
        }
    }
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        var n = new r,
			e = i("[data-search-open]"),
			u, f;
        e.on("click", function (n) {
            n.stopPropagation()
        }).on("click", n.toggle);
        u = i("[data-search-dismiss]");
        f = '.navbar-form input[type="text"]';
        i(f).on("click", function (n) {
            n.stopPropagation()
        }).on("keyup", function (t) {
            t.keyCode == 27 && n.dismiss()
        });
        i(t).on("click", n.dismiss);
        u.on("click", function (n) {
            n.stopPropagation()
        }).on("click", n.dismiss)
    });
    var r = function () {
        var n = "form.navbar-form";
        return {
            toggle: function () {
                var t = i(n),
                    r;
                t.toggleClass("open");
                r = t.hasClass("open");
                t.find("input")[r ? "focus" : "blur"]()
            },
            dismiss: function () {
                i(n).removeClass("open").find('input[type="text"]').blur()
            }
        }
    }
}(window, document, window.jQuery), function (n, t, i) {
    "use strict";

    function r(t) {
        var i = t.data("message"),
			r = t.data("options");
        i || n.error("Notify: No message specified");
        n.notify(i, r || {})
    }
    var u = "[data-notify]",
		f = n(i);
    n(function () {
        n(u).each(function () {
            var t = n(this),
				i = t.data("onload");
            i !== undefined && setTimeout(function () {
                r(t)
            }, 800);
            t.on("click", function (n) {
                n.preventDefault();
                r(t)
            })
        })
    })
}(jQuery, window, document), function (n) {
    var i = {},
		t = {},
		u = function (t) {
		    return n.type(t) == "string" && (t = {
		        message: t
		    }), arguments[1] && (t = n.extend(t, n.type(arguments[1]) == "string" ? {
		        status: arguments[1]
		    } : arguments[1])), new r(t).show()
		},
		f = function (n, i) {
		    var r;
		    if (n) for (r in t) n === t[r].group && t[r].close(i);
		    else for (r in t) t[r].close(i)
		},
		r = function (u) {
		    var f = this;
		    this.options = n.extend({}, r.defaults, u);
		    this.uuid = "ID" + (new Date).getTime() + "RAND" + Math.ceil(Math.random() * 1e5);
		    this.element = n(['<div class="uk-notify-message alert-dismissable">', '<a class="close">&times;<\/a>', "<div>" + this.options.message + "<\/div>", "<\/div>"].join("")).data("notifyMessage", this);
		    this.options.status && (this.element.addClass("alert alert-" + this.options.status), this.currentstatus = this.options.status);
		    this.group = this.options.group;
		    t[this.uuid] = this;
		    i[this.options.pos] || (i[this.options.pos] = n('<div class="uk-notify uk-notify-' + this.options.pos + '"><\/div>').appendTo("body").on("click", ".uk-notify-message", function () {
		        n(this).data("notifyMessage").close()
		    }))
		};
    return n.extend(r.prototype, {
        uuid: !1,
        element: !1,
        timout: !1,
        currentstatus: "",
        group: !1,
        show: function () {
            var n, t;
            if (!this.element.is(":visible")) return n = this, i[this.options.pos].show().prepend(this.element), t = parseInt(this.element.css("margin-bottom"), 10), this.element.css({
                opacity: 0,
                "margin-top": -1 * this.element.outerHeight(),
                "margin-bottom": 0
            }).animate({
                opacity: 1,
                "margin-top": 0,
                "margin-bottom": t
            }, function () {
                if (n.options.timeout) {
                    var t = function () {
                        n.close()
                    };
                    n.timeout = setTimeout(t, n.options.timeout);
                    n.element.hover(function () {
                        clearTimeout(n.timeout)
                    }, function () {
                        n.timeout = setTimeout(t, n.options.timeout)
                    })
                }
            }), this
        },
        close: function (n) {
            var r = this,
				u = function () {
				    r.element.remove();
				    i[r.options.pos].children().length || i[r.options.pos].hide();
				    delete t[r.uuid]
				};
            this.timeout && clearTimeout(this.timeout);
            n ? u() : this.element.animate({
                opacity: 0,
                "margin-top": -1 * this.element.outerHeight(),
                "margin-bottom": 0
            }, function () {
                u()
            })
        },
        content: function (n) {
            var t = this.element.find(">div");
            return n ? (t.html(n), this) : t.html()
        },
        status: function (n) {
            return n ? (this.element.removeClass("alert alert-" + this.currentstatus).addClass("alert alert-" + n), this.currentstatus = n, this) : this.currentstatus
        }
    }), r.defaults = {
        message: "",
        status: "normal",
        timeout: 5e3,
        group: null,
        pos: "top-center"
    }, n.notify = u, n.notify.message = r, n.notify.closeAll = f, u
}(jQuery, window, document), function (n, t, i) {
    i(function () {
        i("[data-now]").each(function () {
            function t() {
                var t = moment(new Date).format(r);
                n.text(t)
            }
            var n = i(this),
				r = n.data("format");
            t();
            setInterval(t, 1e3)
        })
    })
}(window, document, window.jQuery), function (n, t, i) {
    "use strict";
    var u = "panel.remove",
		r = "panel.removed";
    n(i).on("click", '[data-tool="panel-dismiss"]', function () {
        function e() {
            n.support.animation ? t.animo({
                animation: "bounceOut"
            }, f) : f()
        }
        function f() {
            var i = t.parent();
            n.when(t.trigger(r, [t])).done(function () {
                t.remove();
                i.trigger(r).filter(function () {
                    var t = n(this);
                    return t.is('[class*="col-"]:not(.sortable)') && t.children("*").length === 0
                }).remove()
            })
        }
        var t = n(this).closest(".panel"),
			i = new n.Deferred;
        t.trigger(u, [t, i]);
        i.done(e)
    })
}(jQuery, window, document), function (n, t, i) {
    "use strict";

    function e(n) {
        n.removeClass("fa-plus").addClass("fa-minus")
    }
    function o(n) {
        n.removeClass("fa-minus").addClass("fa-plus")
    }
    function u(t, i) {
        var u = n.localStorage.get(r);
        u || (u = {});
        u[t] = i;
        n.localStorage.set(r, u)
    }
    function s(t) {
        var i = n.localStorage.get(r);
        if (i) return i[t] || !1
    }
    var f = '[data-tool="panel-collapse"]',
		r = "jq-panelState";
    n(f).each(function () {
        var h = n(this),
			f = h.closest(".panel"),
			t = f.find(".panel-wrapper"),
			c = {
			    toggle: !1
			},
			l = h.children("em"),
			i = f.attr("id"),
			r;
        t.length || (t = f.children(".panel-heading").nextAll().wrapAll("<div/>").parent().addClass("panel-wrapper"), c = {});
        t.collapse(c).on("hide.bs.collapse", function () {
            o(l);
            u(i, "hide");
            t.prev(".panel-heading").addClass("panel-heading-collapsed")
        }).on("show.bs.collapse", function () {
            e(l);
            u(i, "show");
            t.prev(".panel-heading").removeClass("panel-heading-collapsed")
        });
        r = s(i);
        r && (setTimeout(function () {
            t.collapse(r)
        }, 0), u(i, r))
    });
    n(i).on("click", f, function () {
        var t = n(this).closest(".panel"),
			i = t.find(".panel-wrapper");
        i.collapse("toggle")
    })
}(jQuery, window, document), function (n, t, i) {
    "use strict";

    function e() {
        this.removeClass(r)
    }
    var u = "panel.refresh",
		r = "whirl",
		f = "standard";
    n(i).on("click", '[data-tool="panel-refresh"]', function () {
        var t = n(this),
			i = t.parents(".panel").eq(0),
			o = t.data("spinner") || f;
        i.addClass(r + " " + o);
        i.removeSpinner = e;
        t.trigger(u, [i])
    })
}(jQuery, window, document), function (n, t, i) {
    "use strict";
    var r = "[data-animate]";
    n(function () {
        var u = n(t).add("body, .wrapper");
        n(r).each(function () {
            function r(t) {
                !t.hasClass("anim-running") && n.Utils.isInView(t, {
                    topoffset: i
                }) && (t.addClass("anim-running"), setTimeout(function () {
                    t.addClass("anim-done").animo({
                        animation: e,
                        duration: .7
                    })
                }, f))
            }
            var t = n(this),
				i = t.data("offset"),
				f = t.data("delay") || 100,
				e = t.data("play") || "bounce";
            typeof i != "undefined" && (r(t), u.scroll(function () {
                r(t)
            }))
        });
        n(i).on("click", r, function () {
            var i = n(this),
				r = i.data("target"),
				u = i.data("play") || "bounce",
				t = n(r);
            t && t.length && t.animo({
                animation: u
            })
        })
    })
}(jQuery, window, document), function (n) {
    "use strict";

    function r() {
        var i = n.localStorage.get(t);
        i || (i = {});
        i[this.id] = n(this).sortable("toArray");
        i && n.localStorage.set(t, i)
    }
    function u() {
        var u = n.localStorage.get(t),
			i, r, f;
        u && (i = this.id, r = u[i], r && (f = n("#" + i), n.each(r, function (t, i) {
            n("#" + i).appendTo(f)
        })))
    }
    if (n.fn.sortable) {
        var i = '[data-toggle="portlet"]',
			t = "jq-portletState";
        n(function () {
            n(i).sortable({
                connectWith: i,
                items: "div.panel",
                handle: ".portlet-handler",
                opacity: .7,
                placeholder: "portlet box-placeholder",
                cancel: ".portlet-cancel",
                forcePlaceholderSize: !0,
                iframeFix: !1,
                tolerance: "pointer",
                helper: "original",
                revert: 200,
                forceHelperSize: !0,
                update: r,
                create: u
            })
        })
    }
}(jQuery, window, document), function (n, t, i) {
    function l() {
        var n = i("<div/>", {
            "class": "dropdown-backdrop"
        });
        n.insertAfter(".aside").on("click mouseenter", function () {
            c()
        })
    }
    function e(n) {
        n.siblings("li").removeClass("open").end().toggleClass("open")
    }
    function a(n) {
        var r, o, h;
        if (c(), r = n.children("ul"), !r.length) return i();
        if (n.hasClass("open")) return e(n), i();
        var s = i(".aside"),
			l = i(".aside-inner"),
			a = parseInt(l.css("padding-top"), 0) + parseInt(s.css("padding-top"), 0),
			t = r.clone().appendTo(s);
        e(n);
        o = n.position().top + a - u.scrollTop();
        h = f.height();
        t.addClass("nav-floating").css({
            position: p() ? "fixed" : "absolute",
            top: o,
            bottom: t.outerHeight(!0) + o > h ? 0 : "auto"
        });
        t.on("mouseleave", function () {
            e(n);
            t.remove()
        });
        return t
    }
    function c() {
        i(".sidebar-subnav.nav-floating").remove();
        i(".dropdown-backdrop").remove();
        i(".sidebar li.open").removeClass("open")
    }
    function v() {
        return s.hasClass("touch")
    }
    function y() {
        return r.hasClass("aside-collapsed") || r.hasClass("aside-collapsed-text")
    }
    function p() {
        return r.hasClass("layout-fixed")
    }
    function o() {
        return r.hasClass("aside-hover")
    }
    var f, s, r, u, h;
    i(function () {
        var t, c, p, e, w;
        f = i(n);
        s = i("html");
        r = i("body");
        u = i(".sidebar");
        h = APP_MEDIAQUERY;
        t = u.find(".collapse");
        t.on("show.bs.collapse", function (n) {
            n.stopPropagation();
            i(this).parents(".collapse").length === 0 && t.filter(".in").collapse("hide")
        });
        c = i(".sidebar .active").parents("li");
        o() || c.addClass("active").children(".collapse").collapse("show");
        u.find("li > a + ul").on("show.bs.collapse", function (n) {
            o() && n.preventDefault()
        });
        p = v() ? "click" : "mouseenter";
        e = i();
        u.on(p, ".nav > li", function () {
            (y() || o()) && (e.trigger("mouseleave"), e = a(i(this)), l())
        });
        if (w = u.data("sidebarAnyclickClose"), typeof w != "undefined") i(".wrapper").on("click.sidebar", function (n) {
            if (r.hasClass("aside-toggled")) {
                var t = i(n.target);
                t.parents(".aside").length || t.is("#user-block-toggle") || t.parent().is("#user-block-toggle") || r.removeClass("aside-toggled")
            }
        })
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        i("[data-skycon]").each(function () {
            var n = i(this),
				t = new Skycons({
				    color: n.data("color") || "white"
				});
            n.html('<canvas width="' + n.data("width") + '" height="' + n.data("height") + '"><\/canvas>');
            t.add(n.children()[0], n.data("skycon"));
            t.play()
        })
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        i("[data-scrollable]").each(function () {
            var n = i(this);
            n.slimScroll({
                height: n.data("height") || 250
            })
        })
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        function t() {
            var r = i(this),
				t = r.data(),
				u = t.values && t.values.split(",");
            t.type = t.type || "bar";
            t.disableHiddenCheck = !0;
            r.sparkline(u, t);
            t.resize && i(n).resize(function () {
                r.sparkline(u, t)
            })
        }
        i("[data-sparkline]").each(t)
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        i("[data-check-all]").on("change", function () {
            var n = i(this),
				t = n.index() + 1,
				r = n.find('input[type="checkbox"]'),
				u = n.parents("table");
            u.find("tbody > tr > td:nth-child(" + t + ') input[type="checkbox"]').prop("checked", r[0].checked)
        })
    })
}(window, document, window.jQuery), function (n, t, i, r) {
    i(function () {
        var t = i("body");
        toggle = new StateToggler;
        i("[data-toggle-state]").on("click", function (u) {
            u.stopPropagation();
            var e = i(this),
				f = e.data("toggleState"),
				s = e.data("target"),
				h = e.attr("data-no-persist") !== r,
				o = s ? i(s) : t;
            f && (o.hasClass(f) ? (o.removeClass(f), h || toggle.removeState(f)) : (o.addClass(f), h || toggle.addState(f)));
            i(n).resize()
        })
    });
    n.StateToggler = function () {
        var n = "jq-toggleState",
			t = {
			    hasWord: function (n, t) {
			        return new RegExp("(^|\\s)" + t + "(\\s|$)").test(n)
			    },
			    addWord: function (n, t) {
			        if (!this.hasWord(n, t)) return n + (n ? " " : "") + t
			    },
			    removeWord: function (n, t) {
			        if (this.hasWord(n, t)) return n.replace(new RegExp("(^|\\s)*" + t + "(\\s|$)*", "g"), "")
			    }
			};
        return {
            addState: function (r) {
                var u = i.localStorage.get(n);
                u = u ? t.addWord(u, r) : r;
                i.localStorage.set(n, u)
            },
            removeState: function (r) {
                var u = i.localStorage.get(n);
                u && (u = t.removeWord(u, r), i.localStorage.set(n, u))
            },
            restoreState: function (t) {
                var r = i.localStorage.get(n);
                r && t.addClass(r)
            }
        }
    }
}(window, document, window.jQuery), function (n, t, i) {
    "use strict";
    var u = n("html"),
		r = n(t);
    n.support.transition = function () {
        var n = function () {
            var r = i.body || i.documentElement,
                n = {
                    WebkitTransition: "webkitTransitionEnd",
                    MozTransition: "transitionend",
                    OTransition: "oTransitionEnd otransitionend",
                    transition: "transitionend"
                };
            for (var t in n) if (r.style[t] !== undefined) return n[t]
        }();
        return n && {
            end: n
        }
    }();
    n.support.animation = function () {
        var n = function () {
            var r = i.body || i.documentElement,
                n = {
                    WebkitAnimation: "webkitAnimationEnd",
                    MozAnimation: "animationend",
                    OAnimation: "oAnimationEnd oanimationend",
                    animation: "animationend"
                };
            for (var t in n) if (r.style[t] !== undefined) return n[t]
        }();
        return n && {
            end: n
        }
    }();
    n.support.requestAnimationFrame = t.requestAnimationFrame || t.webkitRequestAnimationFrame || t.mozRequestAnimationFrame || t.msRequestAnimationFrame || t.oRequestAnimationFrame ||
	function (n) {
	    t.setTimeout(n, 1e3 / 60)
	};
    n.support.touch = "ontouchstart" in t && navigator.userAgent.toLowerCase().match(/mobile|tablet/) || t.DocumentTouch && document instanceof t.DocumentTouch || t.navigator.msPointerEnabled && t.navigator.msMaxTouchPoints > 0 || t.navigator.pointerEnabled && t.navigator.maxTouchPoints > 0 || !1;
    n.support.mutationobserver = t.MutationObserver || t.WebKitMutationObserver || t.MozMutationObserver || null;
    n.Utils = {};
    n.Utils.debounce = function (n, t, i) {
        var r;
        return function () {
            var u = this,
				f = arguments,
				e = function () {
				    r = null;
				    i || n.apply(u, f)
				},
				o = i && !r;
            clearTimeout(r);
            r = setTimeout(e, t);
            o && n.apply(u, f)
        }
    };
    n.Utils.removeCssRules = function (n) {
        var i, r, t, u, e, f, s, h, c, o;
        n && setTimeout(function () {
            try {
                for (o = document.styleSheets, u = 0, s = o.length; u < s; u++) {
                    for (t = o[u], r = [], t.cssRules = t.cssRules, i = e = 0, h = t.cssRules.length; e < h; i = ++e) t.cssRules[i].type === CSSRule.STYLE_RULE && n.test(t.cssRules[i].selectorText) && r.unshift(i);
                    for (f = 0, c = r.length; f < c; f++) t.deleteRule(r[f])
                }
            } catch (l) { }
        }, 0)
    };
    n.Utils.isInView = function (t, i) {
        var u = n(t);
        if (!u.is(":visible")) return !1;
        var f = r.scrollLeft(),
			e = r.scrollTop(),
			o = u.offset(),
			s = o.left,
			h = o.top;
        return i = n.extend({
            topoffset: 0,
            leftoffset: 0
        }, i), h + u.height() >= e && h - i.topoffset <= e + r.height() && s + u.width() >= f && s - i.leftoffset <= f + r.width() ? !0 : !1
    };
    n.Utils.options = function (t) {
        if (n.isPlainObject(t)) return t;
        var i = t ? t.indexOf("{") : -1,
			r = {};
        if (i != -1) try {
            r = new Function("", "var json = " + t.substr(i) + "; return JSON.parse(JSON.stringify(json));")()
        } catch (u) { }
        return r
    };
    n.Utils.events = {};
    n.Utils.events.click = n.support.touch ? "tap" : "click";
    n.langdirection = u.attr("dir") == "rtl" ? "right" : "left";
    n(function () {
        if (n.support.mutationobserver) {
            var t = new n.support.mutationobserver(n.Utils.debounce(function () {
                n(i).trigger("domready")
            }, 300));
            t.observe(document.body, {
                childList: !0,
                subtree: !0
            })
        }
    });
    u.addClass(n.support.touch ? "touch" : "no-touch")
}(jQuery, window, document), function (n, t, i) {
    i(function () {
        if (typeof Chart != "undefined") var n = function () {
            return Math.round(Math.random() * 100)
        },
			i = {
			    labels: ["January", "February", "March", "April", "May", "June", "July"],
			    datasets: [{
			        label: "My First dataset",
			        fillColor: "rgba(114,102,186,0.2)",
			        strokeColor: "rgba(114,102,186,1)",
			        pointColor: "rgba(114,102,186,1)",
			        pointStrokeColor: "#fff",
			        pointHighlightFill: "#fff",
			        pointHighlightStroke: "rgba(114,102,186,1)",
			        data: [n(), n(), n(), n(), n(), n(), n()]
			    }, {
			        label: "My Second dataset",
			        fillColor: "rgba(35,183,229,0.2)",
			        strokeColor: "rgba(35,183,229,1)",
			        pointColor: "rgba(35,183,229,1)",
			        pointStrokeColor: "#fff",
			        pointHighlightFill: "#fff",
			        pointHighlightStroke: "rgba(35,183,229,1)",
			        data: [n(), n(), n(), n(), n(), n(), n()]
			    }]
			},
			r = t.getElementById("chartjs-linechart").getContext("2d"),
			c = new Chart(r).Line(i, {
			    scaleShowGridLines: !0,
			    scaleGridLineColor: "rgba(0,0,0,.05)",
			    scaleGridLineWidth: 1,
			    bezierCurve: !0,
			    bezierCurveTension: .4,
			    pointDot: !0,
			    pointDotRadius: 4,
			    pointDotStrokeWidth: 1,
			    pointHitDetectionRadius: 20,
			    datasetStroke: !0,
			    datasetStrokeWidth: 2,
			    datasetFill: !0,
			    responsive: !0
			}),
			u = {
			    labels: ["January", "February", "March", "April", "May", "June", "July"],
			    datasets: [{
			        fillColor: "#23b7e5",
			        strokeColor: "#23b7e5",
			        highlightFill: "#23b7e5",
			        highlightStroke: "#23b7e5",
			        data: [n(), n(), n(), n(), n(), n(), n()]
			    }, {
			        fillColor: "#5d9cec",
			        strokeColor: "#5d9cec",
			        highlightFill: "#5d9cec",
			        highlightStroke: "#5d9cec",
			        data: [n(), n(), n(), n(), n(), n(), n()]
			    }]
			},
			f = t.getElementById("chartjs-barchart").getContext("2d"),
			l = new Chart(f).Bar(u, {
			    scaleBeginAtZero: !0,
			    scaleShowGridLines: !0,
			    scaleGridLineColor: "rgba(0,0,0,.05)",
			    scaleGridLineWidth: 1,
			    barShowStroke: !0,
			    barStrokeWidth: 2,
			    barValueSpacing: 5,
			    barDatasetSpacing: 1,
			    responsive: !0
			}),
			e = t.getElementById("chartjs-doughnutchart").getContext("2d"),
			a = new Chart(e).Doughnut([{
			    value: 300,
			    color: "#7266ba",
			    highlight: "#7266ba",
			    label: "Purple"
			}, {
			    value: 50,
			    color: "#23b7e5",
			    highlight: "#23b7e5",
			    label: "Info"
			}, {
			    value: 100,
			    color: "#fad732",
			    highlight: "#fad732",
			    label: "Yellow"
			}], {
			    segmentShowStroke: !0,
			    segmentStrokeColor: "#fff",
			    segmentStrokeWidth: 2,
			    percentageInnerCutout: 85,
			    animationSteps: 100,
			    animationEasing: "easeOutBounce",
			    animateRotate: !0,
			    animateScale: !1,
			    responsive: !0
			}),
			o = t.getElementById("chartjs-piechart").getContext("2d"),
			v = new Chart(o).Pie([{
			    value: 300,
			    color: "#7266ba",
			    highlight: "#7266ba",
			    label: "Purple"
			}, {
			    value: 40,
			    color: "#fad732",
			    highlight: "#fad732",
			    label: "Yellow"
			}, {
			    value: 120,
			    color: "#23b7e5",
			    highlight: "#23b7e5",
			    label: "Info"
			}], {
			    segmentShowStroke: !0,
			    segmentStrokeColor: "#fff",
			    segmentStrokeWidth: 2,
			    percentageInnerCutout: 0,
			    animationSteps: 100,
			    animationEasing: "easeOutBounce",
			    animateRotate: !0,
			    animateScale: !1,
			    responsive: !0
			}),
			s = t.getElementById("chartjs-polarchart").getContext("2d"),
			y = new Chart(s).PolarArea([{
			    value: 300,
			    color: "#f532e5",
			    highlight: "#f532e5",
			    label: "Red"
			}, {
			    value: 50,
			    color: "#7266ba",
			    highlight: "#7266ba",
			    label: "Green"
			}, {
			    value: 100,
			    color: "#f532e5",
			    highlight: "#f532e5",
			    label: "Yellow"
			}, {
			    value: 140,
			    color: "#7266ba",
			    highlight: "#7266ba",
			    label: "Grey"
			}, ], {
			    scaleShowLabelBackdrop: !0,
			    scaleBackdropColor: "rgba(255,255,255,0.75)",
			    scaleBeginAtZero: !0,
			    scaleBackdropPaddingY: 1,
			    scaleBackdropPaddingX: 1,
			    scaleShowLine: !0,
			    segmentShowStroke: !0,
			    segmentStrokeColor: "#fff",
			    segmentStrokeWidth: 2,
			    animationSteps: 100,
			    animationEasing: "easeOutBounce",
			    animateRotate: !0,
			    animateScale: !1,
			    responsive: !0
			}),
			h = t.getElementById("chartjs-radarchart").getContext("2d"),
			p = new Chart(h).Radar({
			    labels: ["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"],
			    datasets: [{
			        label: "My First dataset",
			        fillColor: "rgba(114,102,186,0.2)",
			        strokeColor: "rgba(114,102,186,1)",
			        pointColor: "rgba(114,102,186,1)",
			        pointStrokeColor: "#fff",
			        pointHighlightFill: "#fff",
			        pointHighlightStroke: "rgba(114,102,186,1)",
			        data: [65, 59, 90, 81, 56, 55, 40]
			    }, {
			        label: "My Second dataset",
			        fillColor: "rgba(151,187,205,0.2)",
			        strokeColor: "rgba(151,187,205,1)",
			        pointColor: "rgba(151,187,205,1)",
			        pointStrokeColor: "#fff",
			        pointHighlightFill: "#fff",
			        pointHighlightStroke: "rgba(151,187,205,1)",
			        data: [28, 48, 40, 19, 96, 27, 100]
			    }]
			}, {
			    scaleShowLine: !0,
			    angleShowLineOut: !0,
			    scaleShowLabels: !1,
			    scaleBeginAtZero: !0,
			    angleLineColor: "rgba(0,0,0,.1)",
			    angleLineWidth: 1,
			    pointLabelFontFamily: "'Arial'",
			    pointLabelFontStyle: "bold",
			    pointLabelFontSize: 10,
			    pointLabelFontColor: "#565656",
			    pointDot: !0,
			    pointDotRadius: 3,
			    pointDotStrokeWidth: 1,
			    pointHitDetectionRadius: 20,
			    datasetStroke: !0,
			    datasetStrokeWidth: 2,
			    datasetFill: !0,
			    responsive: !0
			})
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        if (typeof Morris != "undefined") {
            var n = [{
                y: "2006",
                a: 100,
                b: 90
            }, {
                y: "2007",
                a: 75,
                b: 65
            }, {
                y: "2008",
                a: 50,
                b: 40
            }, {
                y: "2009",
                a: 75,
                b: 65
            }, {
                y: "2010",
                a: 50,
                b: 40
            }, {
                y: "2011",
                a: 75,
                b: 65
            }, {
                y: "2012",
                a: 100,
                b: 90
            }];
            new Morris.Line({
                element: "morris-line",
                data: n,
                xkey: "y",
                ykeys: ["a", "b"],
                labels: ["Serie A", "Serie B"],
                lineColors: ["#31C0BE", "#7a92a3"],
                resize: !0
            });
            new Morris.Donut({
                element: "morris-donut",
                data: [{
                    label: "Download Sales",
                    value: 12
                }, {
                    label: "In-Store Sales",
                    value: 30
                }, {
                    label: "Mail-Order Sales",
                    value: 20
                }],
                colors: ["#f05050", "#fad732", "#ff902b"],
                resize: !0
            });
            new Morris.Bar({
                element: "morris-bar",
                data: n,
                xkey: "y",
                ykeys: ["a", "b"],
                labels: ["Series A", "Series B"],
                xLabelMargin: 2,
                barColors: ["#23b7e5", "#f05050"],
                resize: !0
            });
            new Morris.Area({
                element: "morris-area",
                data: n,
                xkey: "y",
                ykeys: ["a", "b"],
                labels: ["Serie A", "Serie B"],
                lineColors: ["#7266ba", "#23b7e5"],
                resize: !0
            })
        }
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        var n, r, i, u, f, e, o, s;
        if (typeof Rickshaw != "undefined") {
            for (n = [
				[],
				[],
				[]
            ], r = new Rickshaw.Fixtures.RandomData(150), i = 0; i < 150; i++) r.addData(n);
            u = [{
                color: "#c05020",
                data: n[0],
                name: "New York"
            }, {
                color: "#30c020",
                data: n[1],
                name: "London"
            }, {
                color: "#6060c0",
                data: n[2],
                name: "Tokyo"
            }];
            f = new Rickshaw.Graph({
                element: t.querySelector("#rickshaw1"),
                series: u,
                renderer: "area"
            });
            f.render();
            e = new Rickshaw.Graph({
                element: t.querySelector("#rickshaw2"),
                renderer: "area",
                stroke: !0,
                series: [{
                    data: [{
                        x: 0,
                        y: 40
                    }, {
                        x: 1,
                        y: 49
                    }, {
                        x: 2,
                        y: 38
                    }, {
                        x: 3,
                        y: 30
                    }, {
                        x: 4,
                        y: 32
                    }],
                    color: "#f05050"
                }, {
                    data: [{
                        x: 0,
                        y: 40
                    }, {
                        x: 1,
                        y: 49
                    }, {
                        x: 2,
                        y: 38
                    }, {
                        x: 3,
                        y: 30
                    }, {
                        x: 4,
                        y: 32
                    }],
                    color: "#fad732"
                }]
            });
            e.render();
            o = new Rickshaw.Graph({
                element: t.querySelector("#rickshaw3"),
                renderer: "line",
                series: [{
                    data: [{
                        x: 0,
                        y: 40
                    }, {
                        x: 1,
                        y: 49
                    }, {
                        x: 2,
                        y: 38
                    }, {
                        x: 3,
                        y: 30
                    }, {
                        x: 4,
                        y: 32
                    }],
                    color: "#7266ba"
                }, {
                    data: [{
                        x: 0,
                        y: 20
                    }, {
                        x: 1,
                        y: 24
                    }, {
                        x: 2,
                        y: 19
                    }, {
                        x: 3,
                        y: 15
                    }, {
                        x: 4,
                        y: 16
                    }],
                    color: "#23b7e5"
                }]
            });
            o.render();
            s = new Rickshaw.Graph({
                element: t.querySelector("#rickshaw4"),
                renderer: "bar",
                series: [{
                    data: [{
                        x: 0,
                        y: 40
                    }, {
                        x: 1,
                        y: 49
                    }, {
                        x: 2,
                        y: 38
                    }, {
                        x: 3,
                        y: 30
                    }, {
                        x: 4,
                        y: 32
                    }],
                    color: "#fad732"
                }, {
                    data: [{
                        x: 0,
                        y: 20
                    }, {
                        x: 1,
                        y: 24
                    }, {
                        x: 2,
                        y: 19
                    }, {
                        x: 3,
                        y: 15
                    }, {
                        x: 4,
                        y: 16
                    }],
                    color: "#ff902b"
                }]
            });
            s.render()
        }
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        var f, e, o;
        if (typeof Chartist != "undefined") {
            f = {
                labels: ["W1", "W2", "W3", "W4", "W5", "W6", "W7", "W8", "W9", "W10"],
                series: [
					[1, 2, 4, 8, 6, -2, -1, -4, -6, -2]
                ]
            };
            e = {
                high: 10,
                low: -10,
                height: 280,
                axisX: {
                    labelInterpolationFnc: function (n, t) {
                        return t % 2 == 0 ? n : null
                    }
                }
            };
            new Chartist.Bar("#ct-bar1", f, e);
            new Chartist.Bar("#ct-bar2", {
                labels: ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"],
                series: [
					[5, 4, 3, 7, 5, 10, 3],
					[3, 2, 9, 5, 4, 6, 4]
                ]
            }, {
                seriesBarDistance: 10,
                reverseData: !0,
                horizontalBars: !0,
                height: 280,
                axisY: {
                    offset: 70
                }
            });
            new Chartist.Line("#ct-line1", {
                labels: ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"],
                series: [
					[12, 9, 7, 8, 5],
					[2, 1, 3.5, 7, 3],
					[1, 3, 4, 5, 6]
                ]
            }, {
                fullWidth: !0,
                height: 280,
                chartPadding: {
                    right: 40
                }
            });
            o = new Chartist.Line("#ct-line3", {
                labels: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat"],
                series: [
					[1, 5, 2, 5, 4, 3],
					[2, 3, 4, 8, 1, 2],
					[5, 4, 3, 2, 1, .5]
                ]
            }, {
                low: 0,
                showArea: !0,
                showPoint: !1,
                fullWidth: !0,
                height: 300
            });
            o.on("draw", function (n) {
                (n.type === "line" || n.type === "area") && n.element.animate({
                    d: {
                        begin: 2e3 * n.index,
                        dur: 2e3,
                        from: n.path.clone().scale(1, 0).translate(0, n.chartRect.height()).stringify(),
                        to: n.path.clone().stringify(),
                        easing: Chartist.Svg.Easing.easeOutQuint
                    }
                })
            });
            var u = new Chartist.Line("#ct-line2", {
                labels: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"],
                series: [
					[12, 9, 7, 8, 5, 4, 6, 2, 3, 3, 4, 6],
					[4, 5, 3, 7, 3, 5, 5, 3, 4, 4, 5, 5],
					[5, 3, 4, 5, 6, 3, 3, 4, 5, 6, 3, 4],
					[3, 4, 5, 6, 7, 6, 4, 5, 6, 7, 6, 3]
                ]
            }, {
                low: 0,
                height: 300
            }),
				t = 0,
				i = 80,
				r = 500;
            u.on("created", function () {
                t = 0
            });
            u.on("draw", function (n) {
                if (t++, n.type === "line") n.element.animate({
                    opacity: {
                        begin: t * i + 1e3,
                        dur: r,
                        from: 0,
                        to: 1
                    }
                });
                else if (n.type === "label" && n.axis === "x") n.element.animate({
                    y: {
                        begin: t * i,
                        dur: r,
                        from: n.y + 100,
                        to: n.y,
                        easing: "easeOutQuart"
                    }
                });
                else if (n.type === "label" && n.axis === "y") n.element.animate({
                    x: {
                        begin: t * i,
                        dur: r,
                        from: n.x - 100,
                        to: n.x,
                        easing: "easeOutQuart"
                    }
                });
                else if (n.type === "point") n.element.animate({
                    x1: {
                        begin: t * i,
                        dur: r,
                        from: n.x - 10,
                        to: n.x,
                        easing: "easeOutQuart"
                    },
                    x2: {
                        begin: t * i,
                        dur: r,
                        from: n.x - 10,
                        to: n.x,
                        easing: "easeOutQuart"
                    },
                    opacity: {
                        begin: t * i,
                        dur: r,
                        from: 0,
                        to: 1,
                        easing: "easeOutQuart"
                    }
                });
                else if (n.type === "grid") {
                    var f = {
                        begin: t * i,
                        dur: r,
                        from: n[n.axis.units.pos + "1"] - 30,
                        to: n[n.axis.units.pos + "1"],
                        easing: "easeOutQuart"
                    },
						e = {
						    begin: t * i,
						    dur: r,
						    from: n[n.axis.units.pos + "2"] - 100,
						    to: n[n.axis.units.pos + "2"],
						    easing: "easeOutQuart"
						},
						u = {};
                    u[n.axis.units.pos + "1"] = f;
                    u[n.axis.units.pos + "2"] = e;
                    u.opacity = {
                        begin: t * i,
                        dur: r,
                        from: 0,
                        to: 1,
                        easing: "easeOutQuart"
                    };
                    n.element.animate(u)
                }
            });
            u.on("created", function () {
                n.__exampleAnimateTimeout && (clearTimeout(n.__exampleAnimateTimeout), n.__exampleAnimateTimeout = null);
                n.__exampleAnimateTimeout = setTimeout(u.update.bind(u), 12e3)
            })
        }
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        var n = [],
			t;
        if (i(".tour-step").each(function () {
			var t = i(this).data();
			t.element = "#" + this.id;
			n.push(t)
        }), n.length) {
            t = new Tour({
                backdrop: !0,
                onShown: function () {
                    i(".wrapper > section").css({
                        position: "static"
                    })
                },
                onHide: function () {
                    i(".wrapper > section").css({
                        position: ""
                    })
                },
                steps: n
            });
            t.init();
            i("#start-tour").on("click", function () {
                t.restart()
            })
        }
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        i("#swal-demo1").on("click", function (n) {
            n.preventDefault();
            swal("Here's a message!")
        });
        i("#swal-demo2").on("click", function (n) {
            n.preventDefault();
            swal("Here's a message!", "It's pretty, isn't it?")
        });
        i("#swal-demo3").on("click", function (n) {
            n.preventDefault();
            swal("Good job!", "You clicked the button!", "success")
        });
        i("#swal-demo4").on("click", function (n) {
            n.preventDefault();
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: !0,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: !1
            }, function () {
                swal("Deleted!", "Your imaginary file has been deleted.", "success")
            })
        });
        i("#swal-demo5").on("click", function (n) {
            n.preventDefault();
            swal({
                title: "Are you sure?",
                text: "You will not be able to recover this imaginary file!",
                type: "warning",
                showCancelButton: !0,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                cancelButtonText: "No, cancel plx!",
                closeOnConfirm: !1,
                closeOnCancel: !1
            }, function (n) {
                n ? swal("Deleted!", "Your imaginary file has been deleted.", "success") : swal("Cancelled", "Your imaginary file is safe :)", "error")
            })
        })
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        i.fn.colorpicker && (i(".demo-colorpicker").colorpicker(), i("#demo_selectors").colorpicker({
            colorSelectors: {
                "default": "#777777",
                primary: APP_COLORS.primary,
                success: APP_COLORS.success,
                info: APP_COLORS.info,
                warning: APP_COLORS.warning,
                danger: APP_COLORS.danger
            }
        }))
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        var n, t, r, u;
        i.fn.knob && (n = {
            width: "50%",
            displayInput: !0,
            fgColor: APP_COLORS.info
        }, i("#knob-chart1").knob(n), t = {
            width: "50%",
            displayInput: !0,
            fgColor: APP_COLORS.purple,
            readOnly: !0
        }, i("#knob-chart2").knob(t), r = {
            width: "50%",
            displayInput: !0,
            fgColor: APP_COLORS.info,
            bgColor: APP_COLORS.gray,
            angleOffset: -125,
            angleArc: 250
        }, i("#knob-chart3").knob(r), u = {
            width: "50%",
            displayInput: !0,
            fgColor: APP_COLORS.pink,
            displayPrevious: !0,
            thickness: .1,
            lineCap: "round"
        }, i("#knob-chart4").knob(u))
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        var n, t, r, u;
        i.fn.easyPieChart && (n = {
            animate: {
                duration: 800,
                enabled: !0
            },
            barColor: APP_COLORS.success,
            trackColor: !1,
            scaleColor: !1,
            lineWidth: 10,
            lineCap: "circle"
        }, i("#easypie1").easyPieChart(n), t = {
            animate: {
                duration: 800,
                enabled: !0
            },
            barColor: APP_COLORS.warning,
            trackColor: !1,
            scaleColor: !1,
            lineWidth: 4,
            lineCap: "circle"
        }, i("#easypie2").easyPieChart(t), r = {
            animate: {
                duration: 800,
                enabled: !0
            },
            barColor: APP_COLORS.danger,
            trackColor: !1,
            scaleColor: APP_COLORS.gray,
            lineWidth: 15,
            lineCap: "circle"
        }, i("#easypie3").easyPieChart(r), u = {
            animate: {
                duration: 800,
                enabled: !0
            },
            barColor: APP_COLORS.danger,
            trackColor: APP_COLORS.yellow,
            scaleColor: APP_COLORS["gray-dark"],
            lineWidth: 15,
            lineCap: "circle"
        }, i("#easypie4").easyPieChart(u))
    })
}(window, document, window.jQuery), function (n, t, i) {
    i(function () {
        i.fn.select2 && (i("#select2-1").select2({
            theme: "bootstrap"
        }), i("#select2-2").select2({
            theme: "bootstrap"
        }), i("#select2-3").select2({
            theme: "bootstrap"
        }), i("#select2-4").select2({
            placeholder: "Select a state",
            allowClear: !0,
            theme: "bootstrap"
        }))
    })
}(window, document, window.jQuery)