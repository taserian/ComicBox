
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'books',
    templateUrl: 'books.component.html',
    styleUrls: [ 'books.component.css' ]
})
export class BooksComponent {
    name: String;

    constructor() {
        this.name = 'Sam';
    }
}
