﻿window.matchMedia || (window.matchMedia = function () { "use strict"; var t = window.styleMedia || window.media; if (!t) { var n = document.createElement("style"), i = document.getElementsByTagName("script")[0], r = null; n.type = "text/css"; n.id = "matchmediajs-test"; i.parentNode.insertBefore(n, i); r = "getComputedStyle" in window && window.getComputedStyle(n, null) || n.currentStyle; t = { matchMedium: function (t) { var i = "@media " + t + "{ #matchmediajs-test { width: 1px; } }"; return n.styleSheet ? n.styleSheet.cssText = i : n.textContent = i, r.width === "1px" } } } return function (n) { return { matches: t.matchMedium(n || "all"), media: n || "all" } } }())