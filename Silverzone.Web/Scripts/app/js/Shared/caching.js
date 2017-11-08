"use strict";
var Rx_1 = require("rxjs/Rx");
function cacheable(o) {
    var replay = new Rx_1.ReplaySubject(1);
    o.subscribe(function (x) { return replay.next(x); }, function (x) { return replay.error(x); }, function () { return replay.complete(); });
    return replay.asObservable();
}
exports.cacheable = cacheable;
// create a unique key for all cache request with observable data
var cacheableCache = {};
function cacheablee(returnObservable, key, customCache) {
    if (!!key && (customCache || cacheableCache)[key]) {
        return (customCache || cacheableCache)[key];
    }
    var replay = new Rx_1.ReplaySubject(1);
    returnObservable.subscribe(function (x) { return replay.next(x); }, function (x) { return replay.error(x); }, function () { return replay.complete(); });
    var observable = replay.asObservable();
    if (!!key) {
        if (!!customCache) {
            customCache[key] = observable;
        }
        else {
            cacheableCache[key] = observable;
        }
    }
    return observable;
}
exports.cacheablee = cacheablee;
function setCacheKey(url, params) {
    return params ? url + "?" + params.toString() : "" + url;
}
exports.setCacheKey = setCacheKey;
//# sourceMappingURL=caching.js.map