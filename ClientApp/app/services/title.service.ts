import { Injectable, Inject } from '@angular/core';
import { Title } from '../models/Title';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/Observable/of';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { BASE_URL } from '../app.module.client';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class TitleService {
    private base_url: String;

    constructor(private http: Http, @Inject('ORIGIN_URL') origin_url: string) {
        this.base_url = origin_url;
    }

    getTitles(): Observable<Title[]> {
        console.log("URL: " + this.base_url);
        var tList = this.http.get(this.base_url + '/api/Titles/')
            .map(resp => resp.json())
            .catch(this.handleError);
        return tList;
    }

    getTitleSingle(titleId: number): Observable<Title> {
        var title = this.http.get(this.base_url + '/api/Titles/' + titleId.toString)
            .map(resp => resp.json())
            .catch(this.handleError);
        return title;
    }

    saveTitle(title: Title) {
        if (!title.titleId) {
            this.postTitle(title);
        } else {
            this.putTitle(title.titleId, title);
        }
    }

    postTitle(title) {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(title);
        return this.http.post(this.base_url + '/api/Titles/', body, options).map((res: Response) => res.json());
    }

    putTitle(id, title) {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(title);
        return this.http.put(this.base_url + '/api/Titles/' + id, body, options).map((res: Response) => res.json());
    }

    handleError(error: any) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
