if (!Cnm){ var Cnm = {}; }

Cnm.Bootstrap = (function(){
	var Registry = {};

	return {
		Add: function(Key, Fn){
			if (typeof Fn !== 'function'){
				logc(Key + ' function is invalid.');
				return;
			}
			Registry[Key] = Fn;
		},
		Init: function(){
			for (var Key in Registry){
				Registry[Key]();
			}
		},
		Log: function(){
			logc(Registry);
		}
	};
})();
