var logc = (function(){
	var hostname = window.location.hostname.toLowerCase();
	if (hostname == 'localhost' || hostname == 'cnm'){
		return function(data){
			if (window.console && console.log){ console.log(data); }
			return data;
		}
	}
	else {
		return function(data){ return data; }
	}
})();

(function($) {
	$.fn.log = function(){
		return logc($(this));
	}
})(jQuery);

