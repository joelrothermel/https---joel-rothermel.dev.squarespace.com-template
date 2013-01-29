///<reference path="jquery-1.7.1.js" />

var GeoProvider = function () {

};

GeoProvider.prototype.GetStates = function (options) {
    var configuration = $.extend({
        success: function () { }
    }, options);

    $.ajax({
        type: 'GET',
        url: '/Geo/States',
        success: function(data)
        {
            var jsonParse = $.parseJSON(data);
            
            if (jsonParse != null)
                configuration.success(jsonParse);
            else
                configuration.success(data);
        },
        error: function(data)
        {

        }
    });
};

GeoProvider.prototype.GetCities = function (options) {
    var configuration = $.extend({
        success: function () { },
        stateName: ''
    }, options);

    $.ajax({
        type: 'GET',
        url: '/Geo/Cities/' + configuration.stateName + '?rand=' + Math.random(),
        success: function (data) {
            var jsonParse = $.parseJSON(data);

            if (jsonParse != null)
                configuration.success(jsonParse);
            else
                configuration.success(data);
        },
        error: function (data) {
        }
    });
};