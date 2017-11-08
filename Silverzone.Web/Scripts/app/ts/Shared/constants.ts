
// global service for global varable like rootscope variable & Api urls
export class globalConfig {

    // readonly constant > By default Public > its a kind of TS fx
    static get apiEndPoint(): string { return 'http://localhost:1234/api/'; }

    // constants coz mark as static
    static version = {
        Site: 'Site',
        User: 'User',
        Admin: 'Admin'
    }
}

