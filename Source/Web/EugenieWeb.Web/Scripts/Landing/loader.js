!function(n){"use strict";function e(n){return new RegExp("(^|\\s+)"+n+"(\\s+|$)")}function t(n,e){var t=i(n,e)?o:s;t(n,e)}var i,s,o;"classList"in document.documentElement?(i=function(n,e){return n.classList.contains(e)},s=function(n,e){n.classList.add(e)},o=function(n,e){n.classList.remove(e)}):(i=function(n,t){return e(t).test(n.className)},s=function(n,e){i(n,e)||(n.className=n.className+" "+e)},o=function(n,t){n.className=n.className.replace(e(t)," ")});var a={hasClass:i,addClass:s,removeClass:o,toggleClass:t,has:i,add:s,remove:o,toggle:t};"function"==typeof define&&define.amd?define(a):n.classie=a}(window),function(n){"use strict";function e(n){this.el=n,this.el.style.strokeDasharray=this.el.style.strokeDashoffset=this.el.getTotalLength()}e.prototype._draw=function(n){this.el.style.strokeDashoffset=this.el.getTotalLength()*(1-n)},e.prototype.setProgress=function(n,e){this._draw(n),e&&"function"==typeof e&&setTimeout(e,200)},e.prototype.setProgressFn=function(n){"function"==typeof n&&n(this)},n.PathLoader=e}(window),function(){function n(){var n=function(){i.animations&&this.removeEventListener(c,n),e()};window.addEventListener("scroll",t),classie.add(s,"loading"),i.animations?s.addEventListener(c,n):n()}function e(){var n=function(n){var e=0,a=setInterval(function(){if(e=Math.min(e+.1*Math.random(),1),n.setProgress(e),1===e){classie.remove(s,"loading"),classie.add(s,"loaded"),clearInterval(a);var r=function(n){if(i.animations){if(n.target!==o)return;this.removeEventListener(c,r)}classie.add(document.body,"layout-switch"),window.removeEventListener("scroll",t)};i.animations?o.addEventListener(c,r):r()}},80)};a.setProgressFn(n)}function t(){window.scrollTo(0,0)}var i={animations:Modernizr.cssanimations},s=document.getElementById("ip-container"),o=s.querySelector("header.ip-header"),a=new PathLoader(document.getElementById("ip-loader-circle")),r={WebkitAnimation:"webkitAnimationEnd",OAnimation:"oAnimationEnd",msAnimation:"MSAnimationEnd",animation:"animationend"},c=r[Modernizr.prefixed("animation")];n()}();