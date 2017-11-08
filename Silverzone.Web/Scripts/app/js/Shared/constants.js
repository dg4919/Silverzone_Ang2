"use strict";
// global service for global varable like rootscope variable & Api urls
var globalConfig = (function () {
    function globalConfig() {
    }
    Object.defineProperty(globalConfig, "apiEndPoint", {
        // readonly constant > By default Public > its a kind of TS fx
        get: function () { return 'http://localhost:1234/api/'; },
        enumerable: true,
        configurable: true
    });
    return globalConfig;
}());
// constants coz mark as static
globalConfig.version = {
    Site: 'Site',
    User: 'User',
    Admin: 'Admin'
};
exports.globalConfig = globalConfig;
//# sourceMappingURL=constants.js.map