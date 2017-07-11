import { Component, Inject } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { Title } from '../../models/Title';

import 'rxjs/add/observable/of';
import 'rxjs/add/operator/filter';


@Component({
    selector: 'titleList',
    templateUrl: 'title.component.html',
    styleUrls: []
})
export class TitleListComponent {
    public titleList: Title[];

    constructor(http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        http.get(originUrl + '/api/Titles/').subscribe(result => {
            this.titleList = result.json() as Title[];
        });
    }
}
