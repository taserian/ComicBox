import { Component, Inject } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { Title } from '../../models/Title';
import { TitleService } from '../../services/title.service';

@Component({
    selector: 'titleList',
    templateUrl: './title.component.html',
    styleUrls: [ './title.component.css' ]
})
export class TitleListComponent {
    titleList: Title[];
    selectedTitle: Title;

    constructor(private dbService: TitleService) {
    }

    ngOnInit() {
        this.getTitles();
    }

    getTitles() {
        this.dbService.getTitles()
            .subscribe((data: Title[]) => this.titleList = data);
    }

    select(title?: Title) {
        this.selectedTitle = title || new Title();
    }
}
