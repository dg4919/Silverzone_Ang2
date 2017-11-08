import { Observable, ReplaySubject } from 'rxjs/Rx';
import { URLSearchParams } from '@angular/http';

export function cacheable<T>(o: Observable<T>): Observable<T> {
    let replay = new ReplaySubject<T>(1);
    o.subscribe(
        x => replay.next(x),
        x => replay.error(x),
        () => replay.complete()
    );
    return replay.asObservable();
}

// create a unique key for all cache request with observable data
let cacheableCache: { [key: string]: Observable<any> } = {};
export function cacheablee<T>(returnObservable: Observable<T>, key?: string, customCache?: { [key: string]: Observable<T> }): Observable<T> {
    if (!!key && (customCache || cacheableCache)[key]) {
        return (customCache || cacheableCache)[key] as Observable<T>;
    }
    let replay = new ReplaySubject<T>(1);
    returnObservable.subscribe(
        x => replay.next(x),
        x => replay.error(x),
        () => replay.complete()
    );
    let observable = replay.asObservable();
    if (!!key) {
        if (!!customCache) {
            customCache[key] = observable;
        } else {
            cacheableCache[key] = observable;
        }
    }
    return observable;
}

export function setCacheKey(url: string, params: URLSearchParams): string {
    return params ? `${url}?${params.toString()}` : `${url}`;
}
